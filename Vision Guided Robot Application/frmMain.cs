using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MachineTools;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro;
using System.Threading;
using System.Collections;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.CalibFix;
using Vision_Guided_Robot_Application.Properties;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;
using System.Timers;

namespace Vision_Guided_Robot_Application
{

    public partial class frmMain : Form
    {
        #region Properties
        AutoMode Auto;

        #region Robot status
        bool isErrMode = false;
        bool[] previousBitStatus = new bool[11];
        bool[] previousErrorStatus = new bool[21];
        bool[] previousWarningStatus = new bool[10];
        bool isErr;
        bool isPreviousErr;
        bool isRefreshError = false;
        int ErrorCount = 0;
        #endregion

        #region Log in 
        List<List<string>> MultiLan_ConfigList;
        List<string> ConfigList;
        bool isOperator = true;
        public bool isRnD = false;
        int LimitNum;
        #endregion

        #region Set frmMain as active form
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//Set frmMain as active form
        #endregion

        #region Configuration
        public PickPlaceDeltaRobot_Communication RB;
        public Config_Connection Config_Conn;
        public Config_HardWare Config_HW;
        public Config_Operational Config_Op;
        Config_Recipe Config_NowRecipe;
        public List<Config_Prod> list_Config_Prod = new List<Config_Prod>();
        public Barcode Config_Barcode;
        #endregion

        #region Camera & Camera region
        public CogToolBlock tbFifo;
        public class CameraRegion
        {
            public int OriginX;
            public int OriginY;
            public int Width;
            public int Height;
        }
        CameraRegion CR_Full, CR_Left, CR_Right;
        CogRectangle cr_Left, cr_Right;
        double widthScale = 0;
        #endregion

        public Log logOper = new Log(Application.StartupPath + "\\Log\\Operational", "Operational");

        Language language;

        Animation animation;
        #endregion

        #region Main
        public frmMain()
        {
            Label.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            Splasher sp = new Splasher();
            sp.Show("Configuration Loading...");

            LoadAllConfig();

            animation = new Animation(pnConveyor, pbYAxis, pbXAxis, cbLivedRobot, cbLivedObject, cbLivedPrinting);

            List<Label> lbProductionList = new List<Label>() { lbSystemStatusR, lbRecogR, lbFinishedR, lbFailR, lbConveyorSpeedR, lbCTR };
            Auto = new AutoMode(lbProductionList, this, tbFifo, RB, Config_HW, Config_Op, list_Config_Prod, dgvPosInfo, cRD, animation, dgvRecipe);
            Auto.region = regionSeparate;

            sp.Close();
            logOper.ADDLog("Open program");
        }

        #region Load Configuration
        void LoadAllConfig()
        {
            LoadLanguage();
            LoadMes();
            Error.LoadErrMes(Language.LanguageIndex);

            Config_HW = new Config_HardWare();
            LoadHardware();

            Config_Conn = new Config_Connection();
            LoadConnection();

            Config_Barcode = new Barcode(Config_Conn, Config_HW, this, dgvRecipe);
            LoadBarcode();

            LoadCamera();

            Config_Op = new Config_Operational();
            LoadOperational();

            LoadUserList();
            Load_MultiLanConfigList();

            SetRobot();
        }
        private void LoadCamera()
        {
            if (!VisionTool.LoadVPP(Application.StartupPath + @"\Config\Fifo.vpp", out tbFifo)) Error.SetErr(53);
            LoadCameraRegion();
            LoadCameraRegion_LeftRight();
        }
        private void LoadConnection()
        {
            Config_Conn.Load();
        }
        private void LoadHardware()
        {
            Config_HW.Load();
            timerMain.Interval = Config_HW.LivedResolution;
            timerAuto.Interval = Config_HW.LivedResolution;
            timerManual.Interval = Config_HW.LivedResolution;
        }
        private void LoadOperational()
        {
            if(Config_Op.Load()) DisplayRecipes();

            Config_NowRecipe = new Config_Recipe();
            if (Config_NowRecipe.Load(Config_Op.RecipeName, Config_Op.Used, Config_Op.CR))
            {
                logOper.ADDLog("\t" + Config_NowRecipe.RunObj.Count.ToString() + " recipes imported: " + Config_Recipe.recipesList);
                ReadProd_Config();
                SetCameraRegion();
            }
        }
        private void LoadBarcode()
       {
            Config_Barcode.Connect();
       }
        private void LoadLanguage()
        {
            language = new Language();
            Language.LoadLanguageIndex();
            language.LoadLanguageFile(Language.translateMainPath);
            language.ChangeLanguageControl(this, language.controlList);
        }
        private void LoadMes()
        {
            Mes.LoadMes(Language.LanguageIndex);
        }
        private void SetRobot()
        {
            RB = new PickPlaceDeltaRobot_Communication(Config_Conn.RobotIP, Config_HW);
        }
        private void LoadUserList()
        {
            frmUserConfig f = new frmUserConfig();
            cbbUserID.DataSource = f.listUserName;
            f.Dispose();
            GC.Collect();
        }
        private void Load_MultiLanConfigList()
        {
            MultiLan_ConfigList = new List<List<string>>();
            MultiLan_ConfigList.Add(new List<string>() { "Recipes & Products", "Language", "Hardware", "Camera", "Connection", "Robot" });
            MultiLan_ConfigList.Add(new List<string>() { "Công thức và mẫu", "Ngôn ngữ", "Phần cứng", "Máy ảnh", "Kết nối", "Robot" });
            MultiLan_ConfigList.Add(new List<string>() { "配方與產品", "語言", "硬件", "相機", "連接", "機器人" });
        }
        private void LoadConfigList()
        {
            int languageIndex = Language.LanguageIndex >= MultiLan_ConfigList.Count() ? 0 : Language.LanguageIndex;
            if (LimitNum <= 1) ConfigList = MultiLan_ConfigList[languageIndex].GetRange(0, 2);
            else ConfigList = MultiLan_ConfigList[languageIndex];
        }
        #endregion

        #region Camera region loading
        private void LoadCameraRegion()
        {
            try
            {
                CR_Full = new CameraRegion()
                {
                    OriginX = Math.Abs(Convert.ToInt32(tbFifo.Outputs["OriginX"].Value)),
                    OriginY = Math.Abs(Convert.ToInt32(tbFifo.Outputs["OriginX"].Value)),
                    Width = Convert.ToInt32(tbFifo.Outputs["Width"].Value),
                    Height = Convert.ToInt32(tbFifo.Outputs["Height"].Value),
                };
            }
            catch
            {
                Error.SetErr(53);
            }
          
        }
        private void LeftRight_Show()
        {
            double scale = (cRD.Width / (double)cRD.Height) / (CR_Full.Width / (double)CR_Full.Height);
            if (scale > 1) widthScale = cRD.Height / (double)CR_Full.Height;
            else widthScale = cRD.Width / (double)CR_Full.Width;

            if (Math.Abs(Config_HW.CR_Left) > CR_Full.Width / 2 || Math.Abs(Config_HW.CR_Right) > CR_Full.Width / 2)
            {
                Config_HW.CR_Left = -150;
                Config_HW.CR_Right = 150;
            }
            CR_Changed();
        }
        private void LoadCameraRegion_LeftRight()
        {
            try
            {
                CR_Left = new CameraRegion()
                {
                    OriginX = CR_Full.OriginX,
                    OriginY = CR_Full.OriginY,
                    Width = CR_Full.Width / 2 + 1 + Config_HW.CR_Left,
                    Height = CR_Full.Height,
                };
                CR_Right = new CameraRegion()
                {
                    OriginX = CR_Full.Width / 2 + CR_Full.OriginX + 1 + Config_HW.CR_Right,
                    OriginY = CR_Full.OriginY,
                    Width = CR_Full.Width / 2 + 1 - Config_HW.CR_Right,
                    Height = CR_Full.Height,
                };
                cr_Left = new CogRectangle() { X = CR_Left.OriginX, Y = CR_Left.OriginY, Width = CR_Left.Width, Height = CR_Left.Height };
                cr_Right = new CogRectangle() { X = CR_Right.OriginX, Y = CR_Right.OriginY, Width = CR_Right.Width, Height = CR_Right.Height };
            }
            catch
            {
                Error.SetErr(53);
            }
        }
        private List<int> GetCameraRegionList()
        {
            List<int> intList = new List<int>();
            for (int i = 0; i < dgvRecipe.RowCount; i++)
            {
                if(Convert.ToBoolean((dgvRecipe.Rows[i].Cells[0] as DataGridViewCheckBoxCell).Value) == true)
                {
                    for (int j = 0; j < Convert.ToInt32(dgvRecipe.Rows[i].Cells[4].Value); j++)
                    {
                        intList.Add((dgvRecipe.Rows[i].Cells[1] as DataGridViewComboBoxCell).Items.IndexOf(dgvRecipe.Rows[i].Cells[1].Value));
                    }
                }
               
            }
            return intList;
        }
        CogToolBlock RecogTB;
        CogPMAlignTool PMA;
        double regionSeparate;
        private void SetCameraRegion()
        {
            bool hasL = false;
            bool hasR = false;
            bool hasN = false;
            List<int> CRList = GetCameraRegionList();
            for (int i = 0; i < list_Config_Prod.Count(); i++)
            {
                try
                {
                    RecogTB = (CogToolBlock)list_Config_Prod[i].TB.Tools["Recognition"];
                    PMA = (CogPMAlignTool)RecogTB.Tools["CogPMAlignTool1"];
                    switch (CRList[i])
                    {
                        case 0:
                            PMA.SearchRegion = null;
                            hasN = true;
                            break;
                        case 1:
                            PMA.RunParams.SearchRegionMode = CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;
                            PMA.SearchRegion = cr_Left;
                            hasL = true;
                            break;
                        case 2:
                            PMA.RunParams.SearchRegionMode = CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;
                            PMA.SearchRegion = cr_Right;
                            hasR = true;
                            break;
                        default:
                            break;
                    }
                }
                catch { }
            }

            if (hasN || (hasL && hasR))
            {
                regionSeparate = CR_Full.OriginX + CR_Full.Width / 2;
                Config_HW.Trans.MapPoint(regionSeparate, 0, out regionSeparate, out double y);
            }
            else if (hasL)
            {
                regionSeparate = CR_Left.OriginX + CR_Left.Width / 2;
                Config_HW.Trans.MapPoint(regionSeparate, 0, out regionSeparate, out double y);
            }
            else if (hasR)
            {
                regionSeparate = CR_Right.OriginX + CR_Right.Width / 2;
                Config_HW.Trans.MapPoint(regionSeparate, 0, out regionSeparate, out double y);
            }
        }
        public void btSaveCameraRegion_Click(object sender, EventArgs e)
        {
            Splasher sp = new Splasher();
            sp.Show("Recipe changing...");

            Config_Op.Load(dgvRecipe);
            if (Config_NowRecipe.Load(Config_Op.RecipeName, Config_Op.Used, Config_Op.CR))
            {
                logOper.ADDLog("\t" + Config_NowRecipe.RunObj.Count.ToString() + " recipes imported: " + Config_Recipe.recipesList );
                ReadProd_Config();
                SetCameraRegion();
                Auto.region = regionSeparate;
            }

            btSaveCameraRegion.FlatStyle = FlatStyle.Standard;
            btSaveCameraRegion.Enabled = false;

            sp.Close();
        }

        /// <summary>
        /// Adjust position of lbSeparate, pnCRL, pnCRR
        /// </summary>
        private void CR_Changed()
        {
            int leftMove = Convert.ToInt32(Config_HW.CR_Left * widthScale);
            int rightMove = Convert.ToInt32(Config_HW.CR_Right * widthScale);

            lbSeparate_L.Size = new Size() { Height = Convert.ToInt32(CR_Full.Height * widthScale), Width = 2 };
            lbSeparate_L.Location = new Point() { X = cRD.Width / 2 - 2 + leftMove, Y = Convert.ToInt32(Math.Abs(CR_Full.Height * widthScale - cRD.Height) / 2) };

            lbSeparate_R.Size = new Size() { Height = Convert.ToInt32(CR_Full.Height * widthScale), Width = 2 };
            lbSeparate_R.Location = new Point() { X = cRD.Width / 2 + rightMove, Y = Convert.ToInt32(Math.Abs(CR_Full.Height * widthScale - cRD.Height) / 2) };

            pnCRL.Location = new Point() { X = cRD.Width / 4 + (leftMove - pnCRL.Width) / 2, Y = 4 };
            pnCRR.Location = new Point() { X = cRD.Width * 3 / 4 + (rightMove - pnCRR.Width) / 2, Y = 4 };
        }
        #endregion

        #region Main Event
        private void frmMain_Load(object sender, EventArgs e)
        {
            SetForegroundWindow(this.Handle);
            Splasher sp = new Splasher();
            sp.Show("Getting ready...");

            RB.Connect();
            btReset_MouseDown(null, null);
            btReset_MouseUp(null, null);

            CollaspScreen(Collasp.LogOut);

            sp.Close();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult mes = MessageBox.Show(Mes.MesList[3].Text, Mes.MesList[3].Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (mes != DialogResult.OK)
            {
                e.Cancel = true;
                return;
            }
            WaitCameraFisishRunning();
            logOper.ADDLog("Close program");
            tbFifo.Dispose();
        }
        private void dgvRecipe_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            btSaveCameraRegion.FlatStyle = FlatStyle.Popup;
            btSaveCameraRegion.Enabled = true;
        }
        private void bt_Mode_MouseDown(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected())
            {
                MessageBox.Show(Mes.MesList[22].Text,
                   Mes.MesList[22].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Button bt = sender as Button;
            bt.Enabled = false;
            Splasher sp = new Splasher();
            sp.Show("Mode changing...");
            WaitCameraFisishRunning();

            if(RB.PLC1_Command(Convert.ToInt32(bt.Tag), true))
            {
                if (bt == btAutoMode)
                {
                    logOper.ADDLog("\t" + "Open Auto control");
                }
                else if (bt == btManualMode)
                {
                    LoadManual();
                    logOper.ADDLog("\t" + "Open Manual control");
                }
            }
            sp.Close();
            bt.Enabled = true;
        }
        private void bt_Mode_MouseUp(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected()) return;

            Button bt = sender as Button;
            RB.PLC1_Command(Convert.ToInt32(bt.Tag), false);
        }
        private void btErrMode_Click(object sender, EventArgs e)
        {
            if (!RB.isConnected())
            {
                MessageBox.Show(Mes.MesList[22].Text,
                   Mes.MesList[22].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (RB.PLC1_Command(8203, !isErrMode))
            {
                if (isErrMode) logOper.ADDLog("\t" + "Error Mode On");
                else logOper.ADDLog("\t" + "Error Mode Off");
                pbErrMode.Image = isErrMode == false ? Resources.GREENLIGHT : Resources.BLACKLIGHT;
                btErrMode.BackgroundImage = isErrMode == false ? Resources.BtOn : Resources.BtOff;
                isErrMode = !isErrMode;
            }
        }
        private void btReset_MouseDown(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected()) return;

            RB.PLC1_Command(8194, true);

            btReset.BackgroundImage = Resources.BtResetOn;
        }
        private void btReset_MouseUp(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected()) return;
            RB.PLC1_Command(8194, false);
            btnClearErr_Click(null, null);
            btReset.BackgroundImage = Resources.BtResetOff;
        }
        private void btConfig_Click(object sender, EventArgs e)
        {
            Splasher sp = new Splasher();
            sp.Show("Settings Loading...");
            WaitCameraFisishRunning();
            
            fConfig fC = new fConfig(Config_Conn, Config_HW, tbFifo, RB, Config_Op, language, isOperator, ConfigList);

            sp.Close();

            fC.ShowDialog();

            if (fC.DialogResult == DialogResult.OK)
            {
                Splasher sp1 = new Splasher();
                sp1.Show("Save changes...");

                switch (fC.ConfigIndex)
                {
                    case 0:
                        LoadOperational();
                        Auto.quantity = 0;
                        logOper.ADDLog("\t" + "Operational Modified");
                        break;
                    case 1:
                        LoadLanguage();
                        LoadMes();
                        Error.LoadErrMes(Language.LanguageIndex);
                        LoadConfigList();
                        logOper.ADDLog("\t" + "Language Modified");
                        break;
                    case 2:
                        LoadHardware();
                        Barcode.timerBarcode.Interval = Config_HW.BarcodeDetectTime;
                        LoadCameraRegion_LeftRight();
                        LoadOperational();
                        Auto.quantity = 0;
                        Auto.region = regionSeparate;
                        logOper.ADDLog("\t" + "Hardware Modified");
                        break;
                    case 3:
                        LoadCamera();
                        Auto.TbFifo = tbFifo;
                        LoadOperational();
                        Auto.quantity = 0;
                        Auto.region = regionSeparate;
                        logOper.ADDLog("\t" + "Fifo.vpp Modified");
                        break;
                    case 4:
                        LoadConnection();
                        SetRobot();
                        RB.Connect();
                        LoadBarcode();
                        logOper.ADDLog("\t" + "Connection Modified");
                        break;
                    default:
                        break;
                }

                sp1.Close();
            }
        }
        private void btnClearErr_Click(object sender, EventArgs e)
        {
            Error.PreviousErrorList = new List<int>(Error.NowErrorList);
            Error.RstAllErr();

            previousErrorStatus = new bool[21];
            previousWarningStatus = new bool[10];
            isPreviousErr = false;

            logOper.ADDLog("\t" + "Clear Error");

            if(btnClearErr.Visible == true)
            {
                //Reload IP
                if (Error.PreviousErrorList.IndexOf(54) != -1) LoadConnection();

                //Reload barcode serial port
                if (Error.PreviousErrorList.IndexOf(170) != -1) LoadBarcode();

                //Reload HW
                if (Config_HW.Trans == null || Error.PreviousErrorList.IndexOf(55) != -1) LoadHardware();

                //Reload Camera
                if (Error.PreviousErrorList.IndexOf(53) != -1) LoadCamera();

                //Reload Recipe
                if (Error.PreviousErrorList.IndexOf(51) != -1 || Error.PreviousErrorList.IndexOf(50) != -1) LoadOperational();

            }

            if (Error.NowErrorList.Count == 0 /*&& RB.List_RBAlarm.Count == 0 && RB.List_RBWarn.Count == 0*/) isErr = false;
            else isErr = true;

            if (isErr == false) splc_Lived_Error.Panel2Collapsed = true;

        }
        private void btLogIn_Click(object sender, EventArgs e)
        {
            #region Log in Ctrl (as RD)
            if (Control.ModifierKeys == Keys.Control) 
            {
                logOper.ADDLog("Login:" + "PCC-Auto, RD Team");
                LimitNum = 3;

                btManageUser.Visible = true;
                isOperator = false;
                isRnD = true;
                CollaspScreen(Collasp.LogIn);
                return;
            }
            #endregion

            #region  Log Out
            if (LimitNum != 0 && LimitNum != -1)
            {
                DialogResult dr = MessageBox.Show(Mes.MesList[10].Text, Mes.MesList[10].Caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.OK)
                {
                    LimitNum = 0;
                    logOper.ADDLog("LogOut");

                    CollaspScreen(Collasp.LogOut);
                }
                return;
            }
            #endregion

            #region Log in
            isRnD = false;
            LimitNum = frmUserConfig.LoginLev(cbbUserID.Text, tbPassword.Text);
            if (LimitNum == -1)
            {
                MessageBox.Show(Mes.MesList[12].Text, Mes.MesList[12].Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btManageUser.Visible = false;
            logOper.ADDLog("Login:" + cbbUserID.Text + "\t" + LimitNum.ToString());

            if (LimitNum <= 1) isOperator = true;
            else isOperator = false;

            CollaspScreen(Collasp.LogIn);
            #endregion
        }
        private void btManageUser_Click(object sender, EventArgs e)
        {
            logOper.ADDLog("PCC-Auto, RD Team" + "\t" + "Press User_Config button");
            frmUserConfig f = new frmUserConfig();
            f.ShowDialog();
            if(f.DialogResult == DialogResult.OK) LoadUserList();
        }
        #endregion

        #region Methods
        void WaitCameraFisishRunning()
        {
            while (Auto.IsRunningCamera)
            {
                Thread.Sleep(10);
            }
        }
        private void ReadErr()
        {
            if (RB.BitStatus[3] == true)
            {
                btErrMode.Enabled = true;
                if (ArrayCompare(previousErrorStatus, RB.ErrorStatus) == false)
                {
                    isRefreshError = true;
                    for (int i = 0; i < RB.ErrorStatus.Count(); i++)
                    {
                        if (RB.ErrorStatus[i] == true) Error.SetErr(i + 201);
                        else Error.RstErr(i + 201);
                    }
                    previousErrorStatus = RB.ErrorStatus;
                }
            }
            else btErrMode.Enabled = false;
        }
        private void ReadWarning()
        {
            if (RB.BitStatus[9] == true)
            {
                if (ArrayCompare(previousWarningStatus, RB.WarningStatus) == false)
                {
                    isRefreshError = true;
                    for (int i = 0; i < RB.WarningStatus.Count(); i++)
                    {
                        if (RB.WarningStatus[i] == true) Error.SetErr(i + 301);
                        else Error.RstErr(i + 301);
                    }
                    previousWarningStatus = RB.WarningStatus;
                }
            }
        }
        private void Check_Vision_Robot_Status()
        {
            #region Error & Warning
            ReadErr();
            ReadWarning();


            if (RB.BitStatus[6] && RB.isAuto == false) Error.SetErr(150);
            else Error.RstErr(150);
            #endregion

            if (ArrayCompare(previousBitStatus, RB.BitStatus) == false)
            {
                previousBitStatus = RB.BitStatus;
                #region System Status

                if (RB.BitStatus[0] == true)
                {
                    pbSystemOn.Image = Resources.GREENLIGHT;
                }
                else
                {
                    pbSystemOn.Image = Resources.BLACKLIGHT;
                }

                if (RB.BitStatus[1] == true)
                {
                    pbSystemReady.Image = Resources.GREENLIGHT;
                }
                else
                {
                    pbSystemReady.Image = Resources.BLACKLIGHT;
                }

                if (RB.BitStatus[3] == true)
                {
                    pbSystemAlarm.Image = Resources.ALARM;
                    if (RB.isAuto) btRun_Click(null, null);
                }
                else
                {
                    pbSystemAlarm.Image = Resources.BLACKLIGHT;
                }

                #endregion

                #region AutoMode
                if (RB.BitStatus[6] == true) CollaspScreen(Collasp.Auto);
                else
                {
                    if (RB.isAuto == true) btRun_Click(null, null);
                    timerAuto.Enabled = false;
                    pbAutoMode.Image = Resources.BLACKLIGHT;
                    btAutoMode.Enabled = true;
                    btAutoMode.BackgroundImage = Resources.BtOff;
                }
                #endregion

                #region ManualMode
                if (RB.BitStatus[7] == true) CollaspScreen(LimitNum <= 1 ? Collasp.Manual : Collasp.Manual_Calibrate);
                else
                {
                    timerManual.Enabled = false;
                    pbManualMode.Image = Resources.BLACKLIGHT;
                    btManualMode.Enabled = true;
                    btManualMode.BackgroundImage = Resources.BtOff;
                }
                #endregion

                #region ErrorMode & ResetMode
                if (RB.BitStatus[6] == false && RB.BitStatus[7] == false)
                {
                    tcMainScreen.SelectedIndex = 2;
                }
                #endregion
            }


        }
        private bool ArrayCompare(bool[] array1, bool[] array2)
        {
            if (array1 == null || array2 == null) return false;
            if (array1.Count() != array2.Count()) return false;
            for (int i = 0; i < array1.Count(); i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }
        void RefreshNowError()
        {
            dgvError.Rows.Clear();
            dgvError.RowCount = Error.NowErrorList.Count /*+ RB.List_RBWarn.Count + RB.List_RBAlarm.Count*/;
            int ci = 0;
            int UsedRowCount = 0;
            for (int i = 0; i < Error.NowErrorList.Count; i++)
            {
                if (i < Error.NowErrorList.Count)
                {
                    dgvError.Rows[i + UsedRowCount].Cells[0].Value = Error.NowErrorList[i].ToString("0000");

                    ci = Error.ErrMes.Keys.IndexOf(Error.NowErrorList[i]);
                    if (ci != -1) dgvError.Rows[i + UsedRowCount].Cells[1].Value = Error.ErrMes[Error.NowErrorList[i]];
                }
            }

            UsedRowCount = Error.NowErrorList.Count;
        }
        void DisplayRecipes()
        {
            dgvRecipe.Rows.Clear();
            dgvRecipe.Rows.Insert(0, Config_Op.RecipeName.Count());
            for (int i = 0; i < Config_Op.RecipeName.Count(); i++)
            {
                dgvRecipe.Rows[i].Cells[0].Value = Config_Op.Used[i];
                dgvRecipe.Rows[i].Cells[1].Value = (dgvRecipe.Rows[i].Cells[1] as DataGridViewComboBoxCell).Items[Config_Op.CR[i]];
                dgvRecipe.Rows[i].Cells[2].Value = (i + 1).ToString();
                dgvRecipe.Rows[i].Cells[3].Value = Config_Op.RecipeName[i];
                dgvRecipe.Rows[i].Cells[4].Value = Config_Op.fileQty_of_Recipe[i];
            }
            btSaveCameraRegion.FlatStyle = FlatStyle.Standard;
            btSaveCameraRegion.Enabled = false;
        }
        void ReadProd_Config()
        {
            Config_Prod TempP = null;
            list_Config_Prod.Clear();
            GC.Collect();
            for (int i = 0; i< Config_NowRecipe.RunObj.Count();i++)
            {
                TempP = new Config_Prod();
                TempP.Name = Config_NowRecipe.RunObj[i];
                TempP.Load();
                list_Config_Prod.Add(TempP);
                list_Config_Prod[i].intTypeNum = Config_NowRecipe.RunObjIntTypeNum[i];
            }
            GC.Collect();
        }
        #endregion

        #endregion

        #region Auto
        public void btRun_Click(object sender, EventArgs e)
        {
            if (RB.isAuto == false)
            {
                if (btSaveCameraRegion.Enabled == true)
                {
                    MessageBox.Show(Mes.MesList[39].Text, Mes.MesList[39].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (RB.BitStatus[3] == true || RB.BitStatus[0] == false || RB.BitStatus[1] == false || Error.SoftwareError == true)
                {
                    MessageBox.Show(Mes.MesList[21].Text, Mes.MesList[21].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Splasher sp = new Splasher();
                sp.Show("Starting....");
                if(!Barcode.isAutoChangeRecipe) logOper.ADDLog("\t" + "Press Start button");

                RB.isAuto = true;
                sp.Close();

                Barcode.isAutoModeRunning = true;
                CollaspScreen(Collasp.Auto_RunOn);
            }
            else
            {
                if (!Barcode.isAutoChangeRecipe) logOper.ADDLog("\t" + "Press Stop button");
                RB.isAuto = false;
                WaitCameraFisishRunning();
                Barcode.isAutoModeRunning = false;
                CollaspScreen(Collasp.Auto_RunOff);
            }
        }
        private void btClearPosInfo_Click(object sender, EventArgs e)
        {
            dgvPosInfo.Rows.Clear();
            logOper.ADDLog("\t" + "Press Clear Pos Info button");
        }
        private void btTakePicture_Click(object sender, EventArgs e)
        {
            if (Error.NowErrorList.IndexOf(50) != -1 || Error.NowErrorList.IndexOf(51) != -1 || Error.NowErrorList.IndexOf(53) != -1) return;

            if (!RB.isAuto)
            {
                btTakePicture.Enabled = false;

                tbFifo.Run();
                if (tbFifo.RunStatus.Result == CogToolResultConstants.Accept)
                {
                    CogImage24PlanarColor pic = (CogImage24PlanarColor)((CogAcqFifoTool)tbFifo.Tools["CogAcqFifoTool2"]).OutputImage;
                    ICogRecord ir = tbFifo.CreateLastRunRecord().SubRecords["CogAcqFifoTool2.OutputImage"];

                    ArrayList labels = Auto.TrigPic_test(pic, ir, Config_HW.Trans);

                    foreach (CogGraphicLabel label in labels)
                        tbFifo.AddGraphicToRunRecord(label, ir, "CogAcqFifoTool2.OutputImage", "script");

                    Auto.ShowGraphic(ir);
                    GC.Collect();
                }
                else
                {
                    Error.SetErr(1);
                }
                btTakePicture.Enabled = true;
                logOper.ADDLog("\t" + "Press Take Picture button");
            }
        }
        #endregion

        #region Manual
        private void LoadManual()
        {
            int[] JogSpeed = RB.ReadDoubleWordIntData(78, 3);
            tbJogSpeedX.Text = JogSpeed[0].ToString();
            tbJogSpeedY.Text = JogSpeed[1].ToString();
            tbJogSpeedR.Text = JogSpeed[2].ToString();
        }
        private void btn_JogHome_MouseDown(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected())
            {
                MessageBox.Show(Mes.MesList[22].Text,
                   Mes.MesList[22].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Button bt = sender as Button;
            RB.PLC1_Command(Convert.ToInt32(bt.Tag), true);
            logOper.ADDLog("\t" + bt.AccessibleDescription);
            LoadManual();
        }
        private void btn_Jog_MouseUp(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected()) return;
            RB.PLC1_Command(8217, new bool[] { false, false, false, false, false, false });
            logOper.ADDLog("\t" + "Stop Jog");
        }
        private void bt_Home_MouseUp(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected()) return;
            RB.PLC1_Command(8212, new bool[] { false, false, false, false });
            logOper.ADDLog("\t" + "Stop Home");
        }
        private void btTestPrint_MouseUp(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected()) return;
            RB.PLC1_Command(8224, false);
            logOper.ADDLog("\t" + "Stop Test Print");
        }
        private void trackbarJogSpeed_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackbar = sender as TrackBar;
            if (trackbar == trackbarJogSpeedX) tbJogSpeedX.Text = trackbar.Value.ToString();
            else if (trackbar == trackbarJogSpeedY) tbJogSpeedY.Text = trackbar.Value.ToString();
            else if (trackbar == trackbarJogSpeedR) tbJogSpeedR.Text = trackbar.Value.ToString();
        }
        private void tbSpeed_TextChanged(object sender, EventArgs e)
        {
            int value;
            TextBox tb = sender as TextBox;
            try
            {
                if (tb == tbJogSpeedX && int.TryParse(tb.Text, out value))
                {
                    if (value > trackbarJogSpeedX.Maximum) value = trackbarJogSpeedX.Maximum;
                    else if (value < trackbarJogSpeedX.Minimum) value = trackbarJogSpeedX.Minimum;
                    tbJogSpeedX.Text = value.ToString();
                    trackbarJogSpeedX.Value = value;
                }
                if (tb == tbJogSpeedY && int.TryParse(tb.Text, out value))
                {
                    if (value > trackbarJogSpeedY.Maximum) value = trackbarJogSpeedY.Maximum;
                    else if (value < trackbarJogSpeedY.Minimum) value = trackbarJogSpeedY.Minimum;
                    tbJogSpeedY.Text = value.ToString();
                    trackbarJogSpeedY.Value = value;
                }
                if (tb == tbJogSpeedR && int.TryParse(tb.Text, out value))
                {
                    if (value > trackbarJogSpeedR.Maximum) value = trackbarJogSpeedR.Maximum;
                    else if (value < trackbarJogSpeedR.Minimum) value = trackbarJogSpeedR.Minimum;
                    tbJogSpeedR.Text = value.ToString();
                    trackbarJogSpeedR.Value = value;
                }
            }
            catch { }
        }
        private void btSetSpeed_Click(object sender, EventArgs e)
        {
            if (!RB.isConnected())
            {
                MessageBox.Show(Mes.MesList[22].Text,
                    Mes.MesList[22].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (int.TryParse(tbJogSpeedX.Text, out Int32 _JogSpeedX) && int.TryParse(tbJogSpeedY.Text, out Int32 _JogSpeedY) && int.TryParse(tbJogSpeedR.Text, out Int32 _JogSpeedR))
            {
                RB.WriteSingleSignIntergerData(_JogSpeedX, 78);
                RB.WriteSingleSignIntergerData(_JogSpeedY, 80);
                RB.WriteSingleSignIntergerData(_JogSpeedR , 82);
            }
            else
            {
                LoadManual();
            }
        }
        private void btManualMove_MouseDown(object sender, MouseEventArgs e)
        {
            int[] movingPoint = new int[3];
            if (!int.TryParse(tbMoveX.Text, out movingPoint[0])) movingPoint[0] = RB.RB_Pos_Speed[0];
            if (!int.TryParse(tbMoveY.Text, out movingPoint[1])) movingPoint[1] = RB.RB_Pos_Speed[1];
            if (!int.TryParse(tbMoveR.Text, out movingPoint[2])) movingPoint[2] = RB.RB_Pos_Speed[2];

            if (movingPoint[0] >= 880000 || movingPoint[0] <= -10000 ||
                movingPoint[1] >= 380000 || movingPoint[1] <= -10000 ||
                movingPoint[2] >= 320000 || movingPoint[2] <= 10000)
            {
                MessageBox.Show(Mes.MesList[32].Text, Mes.MesList[32].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!RB.isConnected())
            {
                MessageBox.Show(Mes.MesList[22].Text,
                   Mes.MesList[22].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RB.WriteSignIntergerData(movingPoint, 84);
            RB.PLC1_Command(8223, true);
            logOper.ADDLog("\t" + "Move: X " + tbMoveX.Text + "Y " + tbMoveY.Text + "R " + tbMoveR.Text);
            LoadManual();
        }
        private void btManualMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (!RB.isConnected()) return;

            RB.PLC1_Command(8223, false);
            logOper.ADDLog("\t" + "Move successfully");

        }
        #endregion

        #region Timer
        private void timerMain_Tick(object sender, EventArgs e)
        {
            Check_Vision_Robot_Status();
            animation.AdjustLocation(RB.RB_Pos_Speed[0]/1000.0, RB.RB_Pos_Speed[1]/1000.0);

            if ((Error.NowErrorList.Count != ErrorCount) || isRefreshError)
            {
                RefreshNowError();
                isRefreshError = false;
                ErrorCount = Error.NowErrorList.Count;
                if (ErrorCount == 0 /*&& RB.List_RBAlarm.Count == 0 && RB.List_RBWarn.Count == 0*/) isErr = false;
                else isErr = true;
            }

            if (isErr == true && isPreviousErr == false) splc_Lived_Error.Panel2Collapsed = false;
            else if(isErr == false) splc_Lived_Error.Panel2Collapsed = true;

            if(isPreviousErr!=isErr) isPreviousErr = isErr;

        }
        private void timerAuto_Tick(object sender, EventArgs e)
        {
            Auto.UpdateAutoMode();
            animation.ProductMove(RB.RB_ProductionStatus[5], Config_HW.Encoder_X_Ratio, Config_HW.Encoder_Y_Ratio);

            if (!Barcode.spBarcode.IsOpen)Error.SetErr(170);
        }
        bool HomeX, HomeY, HomeR;
        private void timerManual_Tick(object sender, EventArgs e)
        {
            if(RB.isConnected())
            {
                lbPosX.Text = RB.RB_Pos_Speed[0].ToString();
                lbPosY.Text = RB.RB_Pos_Speed[1].ToString();
                lbPosR.Text = RB.RB_Pos_Speed[2].ToString();
                lbEnc.Text = RB.RB_ProductionStatus[5].ToString();

                if (lbPosX.Text == "0")
                {
                    btJogHomeX.BackColor = Color.Green;
                    HomeX = true;
                }
                else
                {
                    btJogHomeX.BackColor = Color.Transparent;
                    HomeX = false;
                }

                if (lbPosY.Text == "0")
                {
                    btJogHomeY.BackColor = Color.Green;
                    HomeY = true;
                }
                else
                {
                    btJogHomeY.BackColor = Color.Transparent;
                    HomeY = false;
                }

                if (lbPosR.Text == "28998")
                {
                    btJogHomeR.BackColor = Color.Green;
                    HomeR = true;
                }
                else
                {
                    btJogHomeR.BackColor = Color.Transparent;
                    HomeR = false;
                }

                if (HomeX && HomeY && HomeR) btJogHome.BackColor = Color.Green;
                else btJogHome.BackColor = Color.Transparent;
            }
        }
        #endregion

        #region Calibrate
        CogToolBlock cogToolBlockCamera, cogToolBlockEnc, cogToolBlockCalib;
        int E0, E1, E2;
        List<double> X1, Y1, X2, Y2;
        double X0, Y0;
        double RotationX, RotationY, ScaleX, ScaleY, RMS, EncX, EncY, CCD_RB_X, CCD_RB_Y;

        private void btCalibInitialize_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbCalibInitialize.Text, out int num) && num >= 1)
            {
                tbCalibInitialize.Enabled = false;
                X1 = new List<double>();
                Y1 = new List<double>();
                X2 = new List<double>();
                Y2 = new List<double>();

                dgvCalibData.Rows.Insert(0, num-1);

                for (int i = 0; i < dgvCalibData.RowCount; i++) dgvCalibData.Rows[i].Cells[0].Value = i + 1;

                dgvCalibResult.Rows.Insert(0, 8);

                dgvCalibResult.Rows[0].Cells[0].Value = "Rotation X";
                dgvCalibResult.Rows[1].Cells[0].Value = "Rotation Y";
                dgvCalibResult.Rows[2].Cells[0].Value = "Scale X";
                dgvCalibResult.Rows[3].Cells[0].Value = "Scale Y";
                dgvCalibResult.Rows[4].Cells[0].Value = "RMS Error";
                dgvCalibResult.Rows[5].Cells[0].Value = "Encoder X";
                dgvCalibResult.Rows[6].Cells[0].Value = "Encoder Y";
                dgvCalibResult.Rows[7].Cells[0].Value = "CCD_RB_X ";
                dgvCalibResult.Rows[8].Cells[0].Value = "CCD_RB_Y";

                for (int i = 0; i < num; i++)
                {
                    X1.Add(0.0);
                    Y1.Add(0.0);
                    X2.Add(0.0);
                    Y2.Add(0.0);
                }
                CollaspScreen(Collasp.Calibrate_Initialize);
                logOper.ADDLog("\t" + "Press Calibrate Initialize button");
            }
            else MessageBox.Show(Mes.MesList[23].Text, Mes.MesList[23].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btCalibReset_Click(object sender, EventArgs e)
        {
            dgvCalibData.Rows.Clear();
            dgvCalibResult.Rows.Clear();

            tbCalibInitialize.Text = null;
            tbCalibInitialize.Enabled = true;

            X1 = null;
            Y1 = null;
            X2 = null;
            Y2 = null;
            try
            {
                cogToolBlockCamera.Dispose();
                cogToolBlockEnc.Dispose();
                cogToolBlockCalib.Dispose();
            }
            catch { }

            GC.Collect();

            CollaspScreen(Collasp.Calibrate_Reset);
            logOper.ADDLog("\t" + "Press Calibrate Reset button");
        }
        private void btCalibEnc_Click(object sender, EventArgs e)
        {
            Splasher sp = new Splasher();
            sp.Show("Calib encoder Initializing...");
            try
            {
                if(!VisionTool.LoadVPP(Application.StartupPath + "\\Config\\tbFindCircle.vpp", out cogToolBlockEnc)) Error.SetErr(120);
                if(!VisionTool.LoadVPP(Application.StartupPath + "\\Config\\Fifo.vpp", out CogToolBlock loadImage)) Error.SetErr(122);
                loadImage.Run();
                cogToolBlockEnc.Inputs["InputImage"].Value = loadImage.Outputs["Image"].Value;

                cogToolBlockEditCalib.Subject = cogToolBlockEnc;
                cogToolBlockEnc.Ran += CogToolBlockEnc_Ran;
                
                loadImage.Dispose();
                GC.Collect();

                cogToolBlockEnc.Run();

                CollaspScreen(Collasp.Calibrate_Encoder);
            }
            catch
            {
            }
            sp.Close();
            logOper.ADDLog("\t" + "Press Calibrate Encoder button");
        }

        private void CogToolBlockEnc_Ran(object sender, EventArgs e)
        {
            E0 = Convert.ToInt32(lbEnc.Text);
            X0 = Convert.ToDouble(cogToolBlockEnc.Outputs["X"].Value.ToString());
            Y0 = Convert.ToDouble(cogToolBlockEnc.Outputs["Y"].Value.ToString());

            dgvCalibData.Rows[0].Cells[1].Value = lbEnc.Text;
            dgvCalibData.Rows[0].Cells[2].Value = X0.ToString("0.00");
            dgvCalibData.Rows[0].Cells[3].Value = Y0.ToString("0.00");

            btCalibCamera.Enabled = true;
        }
        private void btCalibCamera_Click(object sender, EventArgs e)
        {
            Splasher sp = new Splasher();
            sp.Show("Calib camera Initializing...");
            cogToolBlockEnc.Dispose();
            GC.Collect();
            try
            {
                if (!VisionTool.LoadVPP(Application.StartupPath + "\\Config\\tbFindCircle.vpp", out cogToolBlockCamera)) Error.SetErr(120);
                if (!VisionTool.LoadVPP(Application.StartupPath + "\\Config\\Fifo.vpp", out CogToolBlock loadImage)) Error.SetErr(122);
                loadImage.Run();
                cogToolBlockCamera.Inputs["InputImage"].Value = loadImage.Outputs["Image"].Value;

                cogToolBlockEditCalib.Subject = cogToolBlockCamera;
                cogToolBlockCamera.Ran += CogToolBlockCamera_Ran;

                loadImage.Dispose();
                GC.Collect();

                cogToolBlockCamera.Run();
            }
            catch { }
            dgvCalibData.CurrentCell = dgvCalibData.Rows[0].Cells[5];
            dgvCalibData.HorizontalScrollingOffset = 234;
            sp.Close();

            CollaspScreen(Collasp.Calibrate_Camera);
            logOper.ADDLog("\t" + "Press Calibrate Camera button");
            finishedCalibCamera = false;
        }
        private void CogToolBlockCamera_Ran(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lbEnc.Text) <= E0)
            {
                DialogResult dr = MessageBox.Show(Mes.MesList[24].Text, Mes.MesList[24].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvCalibData.Rows[dgvCalibData.CurrentRow.Index].Cells[5].Value == null) 
            {
                dgvCalibData.Rows[0].Cells[5].Value = lbEnc.Text;
                E1 = Convert.ToInt32(lbEnc.Text);
            }
            else if (Convert.ToInt32(lbEnc.Text) != E1)
            {
                DialogResult dr = MessageBox.Show(Mes.MesList[25].Text, Mes.MesList[25].Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes) 
                {
                    btCalibReset_Click(null, null);
                    return;
                }
            }
            X1[dgvCalibData.CurrentRow.Index] = Convert.ToDouble(cogToolBlockCamera.Outputs["X"].Value);
            Y1[dgvCalibData.CurrentRow.Index] = Convert.ToDouble(cogToolBlockCamera.Outputs["Y"].Value);

            dgvCalibData.Rows[dgvCalibData.CurrentRow.Index].Cells[6].Value = X1.ElementAt(dgvCalibData.CurrentRow.Index).ToString("0.00");
            dgvCalibData.Rows[dgvCalibData.CurrentRow.Index].Cells[7].Value = Y1.ElementAt(dgvCalibData.CurrentRow.Index).ToString("0.00");

            if(dgvCalibData.CurrentRow.Index<dgvCalibData.RowCount-1) dgvCalibData.CurrentCell = dgvCalibData.Rows[dgvCalibData.CurrentRow.Index + 1].Cells[5];

        }
        bool finishedCalibCamera = false;
        private void btCalibXYRobot_Click(object sender, EventArgs e)
        {
            if(!finishedCalibCamera)
            {
                Splasher sp = new Splasher();
                sp.Show("Calib XYRobot Initializing...");

                cogToolBlockCamera.Dispose();
                GC.Collect();

                sp.Close();
                dgvCalibData.CurrentCell = dgvCalibData.Rows[0].Cells[9];

                CollaspScreen(Collasp.Calibrate_XYRobot);
                finishedCalibCamera = true;
                dgvCalibData.HorizontalScrollingOffset = 204;
            }
            else
            {
                if (dgvCalibData.Rows[dgvCalibData.CurrentRow.Index].Cells[9].Value == null)
                {
                    dgvCalibData.Rows[0].Cells[9].Value = lbEnc.Text;
                    E2 = Convert.ToInt32(lbEnc.Text);
                }
                else if (Convert.ToInt32(lbEnc.Text) != E2)
                {
                    DialogResult dr = MessageBox.Show(Mes.MesList[25].Text, Mes.MesList[25].Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        btCalibReset_Click(null, null);
                        return;
                    }
                }

                X2[dgvCalibData.CurrentRow.Index] = Convert.ToDouble(lbPosX.Text) / 1000.0;
                Y2[dgvCalibData.CurrentRow.Index] = Convert.ToDouble(lbPosY.Text) / 1000.0;

                dgvCalibData.Rows[dgvCalibData.CurrentRow.Index].Cells[10].Value = X2.ElementAt(dgvCalibData.CurrentRow.Index).ToString("0.00");
                dgvCalibData.Rows[dgvCalibData.CurrentRow.Index].Cells[11].Value = Y2.ElementAt(dgvCalibData.CurrentRow.Index).ToString("0.00");

                if (dgvCalibData.CurrentRow.Index < dgvCalibData.RowCount - 1)  dgvCalibData.CurrentCell = dgvCalibData.Rows[dgvCalibData.CurrentRow.Index + 1].Cells[9];
            }
            logOper.ADDLog("\t" + "Press Calibrate XYRobot button");
        }
        CogCalibNPointToNPointTool cogtool;

        private void btCalib_Click(object sender, EventArgs e)
        {
            Splasher sp = new Splasher();
            sp.Show("Calibration Process Calculating...");

            try
            {
                if (!VisionTool.LoadVPP(Application.StartupPath + "\\Config\\tbCalibrate.vpp", out cogToolBlockCalib)) Error.SetErr(12);

                cogtool = (CogCalibNPointToNPointTool)cogToolBlockCalib.Tools["CogCalibNPointToNPointTool1"];
                cogtool.Calibration.NumPoints = Convert.ToInt32(tbCalibInitialize.Text);
                for (int i = 0; i < Convert.ToInt32(tbCalibInitialize.Text); i++)
                {
                    cogtool.Calibration.SetUncalibratedPoint(i, X1.ElementAt(i), Y1.ElementAt(i));
                    cogtool.Calibration.SetRawCalibratedPoint(i, X2.ElementAt(i), Y2.ElementAt(i));
                }
                cogToolBlockEditCalib.Subject = cogToolBlockCalib;
                cogToolBlockCalib.Ran += CogToolBlockCalib_Ran;
                //cogtool.Run();
                cogtool.Calibration.Calibrate();
                cogToolBlockCalib.Run();
            }
            catch { }
            sp.Close();

            CollaspScreen(Collasp.Calibrate);
            logOper.ADDLog("\t" + "Press Calibrate button");
        }
        private void CogToolBlockCalib_Ran(object sender, EventArgs e)
        {
            RotationX = Convert.ToDouble(cogToolBlockCalib.Outputs["RotationX"].Value);
            RotationY = Convert.ToDouble(cogToolBlockCalib.Outputs["RotationY"].Value);
            ScaleX = Convert.ToDouble(cogToolBlockCalib.Outputs["ScaleX"].Value);
            ScaleY = Convert.ToDouble(cogToolBlockCalib.Outputs["ScaleY"].Value);
            RMS = Convert.ToDouble(cogToolBlockCalib.Outputs["RMS"].Value);
            EncX = Math.Abs((X1.ElementAt(0) - X0) / (E1 - E0) / ScaleX);
            EncY = Math.Abs((Y1.ElementAt(0) - Y0) / (E1 - E0) / ScaleX);
            CCD_RB_X = -(E2 - E1) * EncX;
            CCD_RB_Y = -(E2 - E1) * EncY;

            dgvCalibResult.Rows[0].Cells[1].Value = RotationX.ToString("0.00");
            dgvCalibResult.Rows[1].Cells[1].Value = RotationY.ToString("0.00");
            dgvCalibResult.Rows[2].Cells[1].Value = ScaleX.ToString("0.00");
            dgvCalibResult.Rows[3].Cells[1].Value = ScaleY.ToString("0.00");
            dgvCalibResult.Rows[4].Cells[1].Value = RMS.ToString("0.00");
            dgvCalibResult.Rows[5].Cells[1].Value = EncX.ToString();
            dgvCalibResult.Rows[6].Cells[1].Value = EncY.ToString();
            dgvCalibResult.Rows[7].Cells[1].Value = CCD_RB_X.ToString();
            dgvCalibResult.Rows[8].Cells[1].Value = CCD_RB_Y.ToString();
        }
        private void btCalibSave_Click(object sender, EventArgs e)
        {
            try
            {
                Config_HW.CCD_RB_X = CCD_RB_X;
                Config_HW.CCD_RB_Y = CCD_RB_Y;
                //Config_HW.Encoder_X_Ratio = EncX;
                //Config_HW.Encoder_X_Ratio = EncY;
                Config_HW.OffsetX = 0;
                Config_HW.OffsetY = 0;

                if (!Directory.Exists(Config_HW.BackupPath)) Directory.CreateDirectory(Config_HW.BackupPath);

                int xmlCount = Directory.GetFiles(Config_HW.BackupPath, "*.xml").Count();
                int vppCount = Directory.GetFiles(Config_HW.BackupPath, "*.vpp").Count();
                int calibCount = xmlCount >= vppCount ? xmlCount : vppCount;
                if (calibCount >= 100) calibCount = 0;

                string file1 = Config_HW.BackupPath + "\\Hardware" + calibCount.ToString() + ".xml";
                if (File.Exists(file1)) File.Delete(file1);
                File.Move(Config_HW.FilePath, file1);
                Config_HW.Save();

                string file2 = Config_HW.BackupPath + "calib" + calibCount.ToString() + ".vpp";
                if (File.Exists(file2)) File.Delete(file2);
                File.Move(Config_HW.ConfigPath + "calib2.vpp", file2);
                VisionTool.SaveVpp(Config_HW.ConfigPath + "\\calib2.vpp", cogtool);

                CalibrationInfoSave(calibCount);

                CollaspScreen(Collasp.Calibrate_Save);
                cogToolBlockEditCalib.Subject = null;
                GC.Collect();

                Config_HW.Load();
                MessageBox.Show(Mes.MesList[26].Text, Mes.MesList[26].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                btCalibSave.Enabled = false;
            }
            catch
            {
                MessageBox.Show(Mes.MesList[27].Text, Mes.MesList[27].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            logOper.ADDLog("\t" + "Press Calibrate Save button");
        }
        private void CalibrationInfoSave(int calibCount)
        {
            using (ExcelPackage calibInfo = new ExcelPackage())
            {
                //excel file properties setting
                calibInfo.Workbook.Properties.Author = "MM Automation / FAE team ";
                calibInfo.Workbook.Properties.Company = "Chingluh Group - VH";
                calibInfo.Workbook.Properties.Title = "StackIT Wetrun Analysis";

                //excel file worksheet setting
                calibInfo.Workbook.Worksheets.Add("Info");
                ExcelWorksheet calibWs = calibInfo.Workbook.Worksheets[1];
                calibWs.Cells.Style.Font.Size = 11;
                calibWs.Cells.Style.Font.Name = "Calibri";

                for (int i = 1; i <= 14; i++) calibWs.Column(i).Width = 12;
                calibWs.Column(5).Width = 1;
                calibWs.Column(9).Width = 1;
                //Collumn header
                calibWs.Cells[1, 2].Value = "Encoder";
                calibWs.Cells[2, 2].Value = "E0";
                calibWs.Cells[2, 3].Value = "X0";
                calibWs.Cells[2, 4].Value = "Y0";
                calibWs.Cells[1, 2, 1, 4].Merge = true;

                calibWs.Cells[5, 2].Value = "Camera";
                calibWs.Cells[6, 1].Value = "No.";
                calibWs.Cells[6, 2].Value = "E1";
                calibWs.Cells[6, 3].Value = "X1";
                calibWs.Cells[6, 4].Value = "Y1";
                calibWs.Cells[5, 2, 5, 4].Merge = true;

                calibWs.Cells[5, 6].Value = "Robot";
                calibWs.Cells[6, 6].Value = "E2";
                calibWs.Cells[6, 7].Value = "X2";
                calibWs.Cells[6, 8].Value = "Y2";
                calibWs.Cells[5, 6, 5, 8].Merge = true;

                calibWs.Cells[5, 10].Value = "Result";
                calibWs.Cells[6, 10].Value = "Rotation X";
                calibWs.Cells[7, 10].Value = "Rotation Y";
                calibWs.Cells[8, 10].Value = "Scale X";
                calibWs.Cells[9, 10].Value = "Scale Y";
                calibWs.Cells[10, 10].Value = "RMS";
                calibWs.Cells[11, 10].Value = "Encoder X";
                calibWs.Cells[12, 10].Value = "Encoder Y";
                calibWs.Cells[13, 10].Value = "CCD_RB_X";
                calibWs.Cells[14, 10].Value = "CCD_RB_Y";
                calibWs.Cells[5, 10, 5, 11].Merge = true;

                //Data
                calibWs.Cells[3, 2].Value = E0;
                calibWs.Cells[3, 3].Value = X0;
                calibWs.Cells[3, 4].Value = Y0;

                calibWs.Cells[7, 2].Value = E1;
                calibWs.Cells[7, 6].Value = E2;

                int row = 7;
                for(int i = 0; i<dgvCalibData.RowCount;i++)
                {

                    calibWs.Cells[row + i, 1].Value = i + 1;

                    calibWs.Cells[row + i, 3].Value = X1[i];
                    calibWs.Cells[row + i, 4].Value = Y1[i];

                    calibWs.Cells[row + i, 7].Value = X2[i];
                    calibWs.Cells[row + i, 8].Value = Y2[i];
                }
                EncX = Math.Abs((X1.ElementAt(0) - X0) / (E1 - E0) / ScaleX);
                EncY = Math.Abs((Y1.ElementAt(0) - Y0) / (E1 - E0) / ScaleX);
                CCD_RB_X = -(E2 - E1) * EncX;
                CCD_RB_Y = -(E2 - E1) * EncY;

                //Result
                calibWs.Cells[6, 11].Value = RotationX;
                calibWs.Cells[7, 11].Value = RotationY;
                calibWs.Cells[8, 11].Value = ScaleX;
                calibWs.Cells[9, 11].Value = ScaleY;
                calibWs.Cells[10, 11].Value = RMS;
                calibWs.Cells[11, 11].Formula = "=" + "ABS((" + calibWs.Cells[7, 3] + "-" + calibWs.Cells[3, 3] +")/(" + calibWs.Cells[7, 2] + "-" + calibWs.Cells[3, 2] +")/" + calibWs.Cells[8, 11] + ")";
                calibWs.Cells[12, 11].Formula = "=" + "ABS((" + calibWs.Cells[7, 4] + "-" + calibWs.Cells[3, 4] + ")/(" + calibWs.Cells[7, 2] + "-" + calibWs.Cells[3, 2] + ")/" + calibWs.Cells[8, 11] + ")";
                calibWs.Cells[13, 11].Formula = "=-(" + calibWs.Cells[7, 6] + "-" + calibWs.Cells[7, 2] + ")*" + calibWs.Cells[11, 11];
                calibWs.Cells[14, 11].Formula = "=-(" + calibWs.Cells[7, 6] + "-" + calibWs.Cells[7, 2] + ")*" + calibWs.Cells[12, 11];

                //Save file
                byte[] bin = calibInfo.GetAsByteArray();
                string fileName = Config_HW.BackupPath + "CalibInfo" + calibCount.ToString() + ".xlsx";
                File.WriteAllBytes(fileName, bin);
            }

        }
        #endregion

        #region SplitContainer
        private enum Collasp
        {
            LogOut,
            LogIn,
            Auto,
            Auto_RunOn,
            Auto_RunOff,
            Manual,
            Manual_Calibrate,
            Calibrate_Initialize,
            Calibrate_Reset,
            Calibrate_Encoder,
            Calibrate_Camera,
            Calibrate_XYRobot,
            Calibrate,
            Calibrate_Save,
        }
        private void CollaspScreen(Collasp circumtance)
        {
            switch (circumtance)
            {
                case Collasp.LogOut:
                    splcStatus.Panel2Collapsed = true;
                    tcMainScreen.ItemSize = new Size(0, 1);
                    tcMainScreen.SizeMode = TabSizeMode.Fixed;
                    gbRecipe.Visible = false;
                    cbbUserID.Enabled = true;
                    tbPassword.Enabled = true;
                    btLogIn.BackgroundImage = Resources.Lock;
                    btManageUser.Visible = false;
                    tbPassword.Text = "";
                    break;
                case Collasp.LogIn:
                    btLogIn.BackgroundImage = Resources.Unlock;
                    splcStatus.Panel2Collapsed = false;
                    gbRecipe.Visible = true;
                    cbbUserID.Enabled = false;
                    tbPassword.Enabled = false;
                    LoadConfigList();

                    if (!isRnD) gbPosInfo.Visible = false;
                    else
                    {
                        gbPosInfo.Visible = true;
                        tcMainScreen.ItemSize = new Size(30, 30);
                        tcMainScreen.SizeMode = TabSizeMode.Normal;
                    }
                    break;
                case Collasp.Auto:
                    pbAutoMode.Image = Resources.GREENLIGHT;
                    btAutoMode.Enabled = false;
                    btAutoMode.BackgroundImage = Resources.BtOn;
                    tcMainScreen.SelectedIndex = 0;
                    timerAuto.Enabled = true;
                    splcMainScreen.SplitterDistance = 1000;
                    LeftRight_Show();
                    break;
                case Collasp.Auto_RunOn:
                    btConfig.Enabled = false;
                    btTakePicture.Enabled = false;
                    btReset.Enabled = false;
                    pbCameraRegion.Visible = false;
                    btRun.BackgroundImage = Resources.BtRunOn;

                    btLogIn.Enabled = false;
                    btManageUser.Enabled = false;
                    gbModeSwitch.Visible = false;
                    btnClearErr.Visible = false;
                    btAbout.Enabled = false;
                    break;
                case Collasp.Auto_RunOff:
                    btConfig.Enabled = true;
                    btTakePicture.Enabled = true;
                    btReset.Enabled = true;
                    pbCameraRegion.Visible = true;
                    btRun.BackgroundImage = Resources.BtRunOff;

                    btLogIn.Enabled = true;
                    btManageUser.Enabled = true;
                    gbModeSwitch.Visible = true;
                    btnClearErr.Visible = true;
                    btAbout.Enabled = true;
                    break;
                case Collasp.Manual:
                    pbManualMode.Image = Resources.GREENLIGHT;
                    btManualMode.Enabled = false;
                    btManualMode.BackgroundImage = Resources.BtOn;
                    tcMainScreen.SelectedIndex = 1;
                    timerManual.Enabled = true;

                    splcMainScreen.SplitterDistance = 819;
                    splcManual.Panel2Collapsed = true;
                    break;
                case Collasp.Manual_Calibrate:
                    pbManualMode.Image = Resources.GREENLIGHT;
                    btManualMode.Enabled = false;
                    btManualMode.BackgroundImage = Resources.BtOn;
                    tcMainScreen.SelectedIndex = 1;
                    timerManual.Enabled = true;

                    btCalibInitialize.Enabled = true;

                    splcManual.Panel2Collapsed = false;
                    splcMainScreen.SplitterDistance = 819;
                    break;
                case Collasp.Calibrate_Reset:
                    btCalibInitialize.Enabled = true;
                    btCalibEnc.Enabled = false;
                    btCalibCamera.Enabled = false;
                    btCalibXYRobot.Enabled = false;
                    btCalib.Enabled = false;

                    btCalibEnc.BackColor = Color.Transparent;
                    btCalibCamera.BackColor = Color.Transparent;
                    btCalibXYRobot.BackColor = Color.Transparent;
                    btCalib.BackColor = Color.Transparent;

                    splcManual_Calib.Panel2Collapsed = true;
                    splcMainScreen.SplitterDistance = 819;
                    break;
                case Collasp.Calibrate_Initialize:
                    btCalibEnc.Enabled = true;
                    break;
                case Collasp.Calibrate_Encoder:
                    btCalibInitialize.Enabled = false;
                    btCalibCamera.Enabled = true;
                    splcManual_Calib.Panel2Collapsed = false;
                    splcManual_Calib.SplitterDistance = 802;
                    splcMainScreen.SplitterDistance = 1200;
                    cogToolBlockEditCalib.MinimumSize = new Size(0, 0);
                    cogToolBlockEditCalib.MaximumSize = new Size(0, 0);
                    break;
                case Collasp.Calibrate_Camera:
                    btCalibEnc.Enabled = false;
                    btCalibEnc.BackColor = Color.Green;
                    btCalibXYRobot.Enabled = true;
                    btCalibEnc.BackColor = Color.Green;
                    splcManual_Calib.SplitterDistance = 802;
                    splcMainScreen.SplitterDistance = 1200;
                    cogToolBlockEditCalib.MinimumSize = new Size(0, 0);
                    cogToolBlockEditCalib.MaximumSize = new Size(0, 0);
                    break;
                case Collasp.Calibrate_XYRobot:
                    btCalibCamera.Enabled = false;
                    btCalibCamera.BackColor = Color.Green;
                    btCalib.Enabled = true;
                    splcManual_Calib.Panel2Collapsed = true;
                    splcMainScreen.SplitterDistance = 819;
                    break;
                case Collasp.Calibrate:
                    btCalibXYRobot.Enabled = false;
                    btCalibXYRobot.BackColor = Color.Green;
                    btCalibSave.Enabled = true;
                    splcManual_Calib.Panel2Collapsed = false;
                    splcManual_Calib.SplitterDistance = 802;
                    splcMainScreen.SplitterDistance = 1200;
                    cogToolBlockEditCalib.MinimumSize = new Size(0, 0);
                    cogToolBlockEditCalib.MaximumSize = new Size(0, 0);
                    break;
                case Collasp.Calibrate_Save:
                    btCalib.Enabled = false;
                    btCalib.BackColor = Color.Green;
                    splcManual_Calib.Panel2Collapsed = false;
                    splcManual_Calib.Panel2Collapsed = true;
                    splcManual_Calib.SplitterDistance = 819;
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void btAbout_Click(object sender, EventArgs e)
        {
            About_OAS_Application frmAbout = new About_OAS_Application();
            frmAbout.ShowDialog();
            logOper.ADDLog("\t" + "Press About button");
        }
    }
}
