using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolBlock;
using MachineTools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vision_Guided_Robot_Application.Properties;

namespace Vision_Guided_Robot_Application
{
    public class AutoMode
    {
        #region Properties
        Thread th_CCD, th_Recog;
        DateTime dt_C;
        bool isStartRecog = false;
        public double region;

        List<List<string>> MultiLan_SystemStatus;
        public class DisplayPosition
        {
            public int Index;
            public string X;
            public string Y;
            public string R;
            public string Enc;
        }
        List<DisplayPosition> displayPosition;
        enum enum_Act_Capture_SendPos
        {
            WaitTime,
            ReadEnc_Start,
            Capture_Recog,
            ReadEnc_Send,
            SendData,
        }
        enum_Act_Capture_SendPos Act_Capture_SendPos = enum_Act_Capture_SendPos.WaitTime;

        List<string> DisplayPos = new List<string>();

        int TrigEC;
        int PreRegEC;
        int PostRegEC;

        public DateTime Dt_ReadEncoder = DateTime.Now; // Donald

        DateTime Dt_CT = DateTime.Now;
        DateTime Dt_CV = DateTime.Now;
        DateTime Dt_CV_Old = DateTime.Now;
        DateTime dt_TrigTime = DateTime.Now;

        double processTime;

        delegate void ShowVal();
        Log logCT = new Log(Application.StartupPath + "\\Log\\CT", "CT");
        Log logPos = new Log(Application.StartupPath + "\\Log\\Pos", "Pos");
        Log logSendMes = new Log(Application.StartupPath + "\\Log\\SendMes", "SendMes");
        CogImage24PlanarColor pic;
        ICogRecord ir;

        private CogToolBlock tbFifo;
        private PickPlaceDeltaRobot_Communication rB;
        private Config_HardWare config_HW;
        private Config_Operational config_Op;
        private List<Config_Prod> list_Config_Prod;
        public bool IsRunningCamera;
        private DataGridView dgvPosInfo;
        private CogRecordDisplay cRD;
        private frmMain f;
        private Animation animate;
        private List<Label> lbProductionList;
        private DataGridView dgvRecipe;

        public CogToolBlock TbFifo { get => tbFifo; set => tbFifo = value; }
        public PickPlaceDeltaRobot_Communication RB { get => this.rB; set => this.rB = value; }
        public Config_HardWare Config_HW { get => config_HW; set => config_HW = value; }
        public Config_Operational Config_Op { get => config_Op; set => config_Op = value; }
        public List<Config_Prod> List_Config_Prod { get => list_Config_Prod; set => list_Config_Prod = value; }
        public DataGridView DgvPosInfo { get => dgvPosInfo; set => dgvPosInfo = value; }
        public CogRecordDisplay CRD { get => cRD; set => cRD = value; }
        public frmMain F { get => f; set => f = value; }
        public Animation Animate { get => animate; set => animate = value; }
        public List<Label> LbProductionList { get => lbProductionList; set => lbProductionList = value; }
        public DataGridView DgvRecipe { get => dgvRecipe; set => dgvRecipe = value; }

        #endregion

        #region Initialize
        public AutoMode(List<Label> lbProductionList,  frmMain f, CogToolBlock tbFifo, PickPlaceDeltaRobot_Communication rB, Config_HardWare config_HW, Config_Operational config_Op, List<Config_Prod> list_Config_Prod, DataGridView dgvPosInfo, CogRecordDisplay cRD, Animation animate, DataGridView dgvRecipe)
        {
            this.TbFifo = tbFifo;
            this.RB = rB;
            this.Config_HW = config_HW;
            this.Config_Op = config_Op;
            this.List_Config_Prod = list_Config_Prod;
            this.DgvPosInfo = dgvPosInfo;
            this.CRD = cRD;
            this.F = f;
            this.Animate = animate;
            this.LbProductionList = lbProductionList;
            this.DgvRecipe = dgvRecipe;

            displayPosition = new List<DisplayPosition>();

            MultiLan_SystemStatus = new List<List<string>>
            {
                new List<string>() { "Ready for Auto Mode", "Waiting", "Moving", "Printing"},
                new List<string>() { "Sẵn sàng ở chế độ tự động", "Chờ", "Di chuyển", "In"},
                new List<string>() { "準備自動模式", "等待", "在移動", "在打印"}
            };

            SetAutoThread();
        }
        #endregion

        #region Methods
        public void ClearGraphic()
        {
            CRD.StaticGraphics.Clear();
            CRD.InteractiveGraphics.Clear();
        }
        public void ShowGraphic(ICogRecord i)
        {
            CRD.StaticGraphics.Clear();
            CRD.InteractiveGraphics.Clear();
            CRD.Record = i;
            CRD.Fit();
        }

        /// <summary>
        /// Set & Start 2 Threads for CCD (2s) & Recog (1 machine cycle);
        /// </summary>
        void SetAutoThread()
        {
            th_CCD = new Thread(() =>
            {
                while (true)
                {
                    //RB.ReadSystemStatus();
                    RunCCD();
                    Thread.Sleep(Config_HW.CaptureInterval);
                }
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            th_CCD.Start();

            th_Recog = new Thread(() =>
            {
                while (true)
                {
                    RunRecog();
                    Thread.SpinWait(1);
                }
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            th_Recog.Start();
        }

        void RunCCD()
        {
            if (RB.isAuto && !isStartRecog)
            {
                IsRunningCamera = true;
                logSendMes.ADDLog("Camera run start.");
                TbFifo.Run();
                logSendMes.ADDLog("Camera run finish." + tbFifo.RunStatus.Result.ToString() + "\t " + (DateTime.Now - dt_C).TotalMilliseconds.ToString());
                dt_C = DateTime.Now;
                IsRunningCamera = false;

                if (TbFifo.RunStatus.Result == CogToolResultConstants.Accept)
                {
                    if (!isStartRecog && (DateTime.Now - dt_TrigTime).TotalMilliseconds >= Config_HW.CaptureInterval - 200)
                    {
                        logSendMes.ADDLog("Run recognition." + TbFifo.RunStatus.Result.ToString());
                        dt_TrigTime = Dt_CV = Dt_CT = DateTime.Now;

                        pic = (CogImage24PlanarColor)((CogAcqFifoTool)TbFifo.Tools["CogAcqFifoTool2"]).OutputImage;
                        ir = tbFifo.CreateLastRunRecord().SubRecords["CogAcqFifoTool2.OutputImage"]; //Camera_2.CreateLastRunRecord().SubRecords[0];
                        isStartRecog = true;

                    }
                    else logSendMes.ADDLog("filtered." + TbFifo.RunStatus.Result.ToString());
                }
                else Error.SetErr(1);

            }
            else if ((DateTime.Now - dt_C).TotalMilliseconds > Config_HW.CaptureInterval) IsRunningCamera = false;
        }

        void RunRecog()
        {
            DateTime dt_TrigTime = DateTime.Now;
            DateTime dt3 = DateTime.Now;
            switch (Act_Capture_SendPos)
            {
                case enum_Act_Capture_SendPos.WaitTime:
                    if (isStartRecog)
                    {
                        Act_Capture_SendPos = enum_Act_Capture_SendPos.ReadEnc_Start;

                    }
                    break;
                case enum_Act_Capture_SendPos.ReadEnc_Start:
                    if (RB.ReadNowEnc())
                    {

                        Dt_ReadEncoder = DateTime.Now; // donald
                        if ((DateTime.Now - Dt_CT).TotalMilliseconds > 500) Error.SetErr(101);

                        TrigEC = RB.ConveyorEncoder;
                        PreRegEC = RB.ConveyorEncoder;

                        RB.list_Prods.Clear();
                        Recognition();

                        foreach (Product_Data P in RB.list_Prods)
                        {
                            logPos.ADDLog(P.ObjType.ToString() + ", " + P.X.ToString("0.000") + "," + P.Y.ToString("0.000") + ", " + P.U.ToString("0.000"));
                            DisplayPosition dP = new DisplayPosition() { Index = P.ObjType, X = P.X.ToString("0.000"), Y = P.Y.ToString("0.000"), R = P.U.ToString("0.000"), Enc = P.EC.ToString() };
                            displayPosition.Add(dP);
                        }

                        if (RB.list_Prods.Count == 0)
                        {
                            Act_Capture_SendPos = enum_Act_Capture_SendPos.WaitTime;
                            isStartRecog = false;
                        }
                        else
                        {
                            Act_Capture_SendPos = enum_Act_Capture_SendPos.SendData;
                        }
                        logSendMes.ADDLog("Picture recognition fisish.");
                    }
                    break;
                case enum_Act_Capture_SendPos.SendData:
                    DateTime dt = DateTime.Now;
                    double timeOffset = (dt - Dt_ReadEncoder).TotalMilliseconds;
                    RB.ReadNowEnc();
                    PostRegEC = RB.ConveyorEncoder;
                    if (RB.SendData(timeOffset, Config_HW.Encoder_X_Ratio * (PostRegEC - PreRegEC), Config_HW.Encoder_Y_Ratio * (PostRegEC - PreRegEC), region))
                    {
                        try { DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[5].Value = PostRegEC; } catch { };
                        processTime = (DateTime.Now - Dt_CT).TotalMilliseconds;
                        if (processTime > 1500) Error.SetErr(102);
                        else Error.RstErr(102);

                        logCT.ADDLog(processTime.ToString());

                        ShowVal sh = new ShowVal(() =>
                        {
                            LbProductionList[5].Text = (DateTime.Now - Dt_CT).TotalMilliseconds.ToString();
                        });
                        F.BeginInvoke(sh);
                        RB.list_Prods_AlreadySend.AddRange(RB.list_Prods.ToArray());
                        Act_Capture_SendPos = enum_Act_Capture_SendPos.WaitTime;
                        isStartRecog = false;
                    }
                    break;
            }

        }

        void Recognition()
        {
            ArrayList labels2 = TrigPic(pic, ir, Config_HW.Trans);

            foreach (CogGraphicLabel label2 in labels2)
                TbFifo.AddGraphicToRunRecord(label2, ir, "CogAcqFifoTool2.OutputImage", "script");

            ShowVal sh = new ShowVal(() =>
            {
                ShowGraphic(ir);
                GC.Collect();

            });
            try
            {
                F.BeginInvoke(sh);
            }
            catch { }
        }
        public ArrayList TrigPic(CogImage24PlanarColor pic, ICogRecord ir, ICogTransform2D Trans)
        {
            ArrayList labels = new ArrayList();
            double X, Y, U, RealX, RealY;
            Config_Prod M;
            int Trig_EC = TrigEC;

            for (int i = 0; i < List_Config_Prod.Count; i++)
            {
                try
                {
                    M = List_Config_Prod[i];
                    CogToolBlock tb = M.TB;
                    CogToolBlock Recognition = (CogToolBlock)tb.Tools["Recognition"];
                    CogToolBlock Check = (CogToolBlock)tb.Tools["Check"];
                    Recognition.Inputs["InputImage"].Value = pic;

                    Recognition.Run();
                    CogPMAlignResults Results = (CogPMAlignResults)Recognition.Outputs["Results"].Value;
                    Check.Inputs["InputImage"].Value = Recognition.Outputs["OutputImage"].Value;
                    Check.Inputs["InputImage_Color"].Value = pic;
                    if (Results != null)
                        foreach (CogPMAlignResult Result in Results)
                        {
                            Check.Inputs["PMAResult"].Value = Result.GetPose();
                            Check.Run();
                            if (Check.RunStatus.Result == CogToolResultConstants.Accept)
                            {
                                CogGraphicLabel myLabel = new CogGraphicLabel();
                                CogTransform2DLinear pos = Result.GetPose();
                                X = (double)Check.Outputs["X"].Value;
                                Y = (double)Check.Outputs["Y"].Value;
                                U = (double)Check.Outputs["U"].Value * 180 / Math.PI;


                                Trans.MapPoint(X, Y, out RealX, out RealY);
                                double TempX = 0, TempY = 0;

                                TempX = RealX * (Config_HW.MaxErr / Config_HW.WMA);
                                RealX = RealX + Config_HW.CCD_RB_X + Config_HW.OffsetX + TempX;
                                RealY = RealY + Config_HW.CCD_RB_Y + Config_HW.OffsetY + TempY;

                                Product_Data p = new Product_Data(RealX, RealY, U, List_Config_Prod[i].intTypeNum, Trig_EC);

                                bool isAlreadySend = isProdRepeat(p, ref RB.list_Prods_AlreadySend);
                                if (!isAlreadySend)
                                {
                                    if (RB.list_Prods.Count < 10) //10pcs/recognition (1 time only send maximum 10 pcs to robot
                                    {
                                        try
                                        {
                                            RB.list_Prods.Add(p/*new Product_Data(RealX, RealY, U, List_Config_Prod[i].intTypeNum, Trig_EC)*/);
                                        }
                                        catch { }
                                    }
                                }

                                myLabel.SetXYText(pos.TranslationX, pos.TranslationY, M.intTypeNum.ToString());
                                myLabel.Rotation = pos.Rotation;
                                myLabel.Color = isAlreadySend ? CogColorConstants.Green : CogColorConstants.Red;
                                labels.Add(myLabel);
                            }
                        }
                }
                catch { }
            }
            return labels;
        }

        bool isProdRepeat(Product_Data P, ref List<Product_Data> List_P)
        {
            bool isAlreadySend = false;
            List<int> list_OverRange = new List<int>();
            double DisX, DisY, CpX, CpY, disPP;
            for (int j = 0; j < List_P.Count; j++)
            {
                Product_Data Already_S = List_P[j];

                DisX = (P.EC - Already_S.EC) * Config_HW.Encoder_X_Ratio;
                DisY = (P.EC - Already_S.EC) * Config_HW.Encoder_Y_Ratio;
                CpX = Already_S.X + DisX;
                CpY = Already_S.Y + DisY;
                if (CpX > Config_HW.RBX_Leave_CCD_Max ||
                    CpX < Config_HW.RBX_Leave_CCD_Min ||
                    CpY > Config_HW.RBY_Leave_CCD_Max ||
                    CpY < Config_HW.RBY_Leave_CCD_Min
                    )
                {
                    list_OverRange.Add(j);
                }

                disPP = Math.Pow((P.X - CpX) * (P.X - CpX) + (P.Y - CpY) * (P.Y - CpY), .5);
                double disU = Math.Abs(P.U - Already_S.U);
                if (disPP < Config_HW.RepeatRange && (disU < 10 || (disU > 350 && disU < 370)))
                {
                    isAlreadySend = true;
                    Already_S.X = P.X;
                    Already_S.Y = P.Y;
                    Already_S.EC = P.EC;

                    List_P[j] = Already_S;
                    break;
                }
            }
            for (int i = 0; i < list_OverRange.Count; i++)
            {
                List_P.RemoveAt(list_OverRange[list_OverRange.Count - i - 1]);
            }
            return isAlreadySend;
        }
        public ArrayList TrigPic_test(CogImage24PlanarColor pic, ICogRecord ir, ICogTransform2D Trans)
        {
            ArrayList labels = new ArrayList();
            double X, Y, U, RealX, RealY;
            Config_Prod M;
            int Trig_EC = TrigEC;

            for (int i = 0; i < List_Config_Prod.Count; i++)
            {
                try
                {
                    M = List_Config_Prod[i];
                    CogToolBlock tb = M.TB;
                    CogToolBlock Recognition = (CogToolBlock)tb.Tools["Recognition"];

                    CogToolBlock Check = (CogToolBlock)tb.Tools["Check"];
                    Recognition.Inputs["InputImage"].Value = pic;
                    Recognition.Run();

                    CogPMAlignResults Results = (CogPMAlignResults)Recognition.Outputs["Results"].Value;
                    Check.Inputs["InputImage"].Value = Recognition.Outputs["OutputImage"].Value;
                    Check.Inputs["InputImage_Color"].Value = pic;
                    if (Results != null)
                    {
                        ir.SubRecords.Add(tb.CreateLastRunRecord().SubRecords[1]);

                        foreach (CogPMAlignResult Result in Results)
                        {
                            Check.Inputs["PMAResult"].Value = Result.GetPose();
                            Check.Run();
                            if (Check.RunStatus.Result == CogToolResultConstants.Accept)
                            { 
                                CogGraphicLabel myLabel = new CogGraphicLabel();
                                CogTransform2DLinear pos = Result.GetPose();
                                X = (double)Check.Outputs["X"].Value;
                                Y = (double)Check.Outputs["Y"].Value;
                                U = (double)Check.Outputs["U"].Value * 180 / Math.PI;

                                Trans.MapPoint(X, Y, out RealX, out RealY);

                                RealX = RealX + Config_HW.CCD_RB_X;
                                RealY = RealY + Config_HW.CCD_RB_Y;

                                if (F.isRnD == true)
                                {
                                    DgvPosInfo.Rows.Add();
                                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[0].Value = DgvPosInfo.RowCount == 1 ? DgvPosInfo.RowCount : (Convert.ToInt32(DgvPosInfo.Rows[DgvPosInfo.RowCount - 2].Cells[0].Value) + 1);
                                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[1].Value = i + 1;
                                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[2].Value = RealX.ToString("0.000");
                                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[3].Value = RealY.ToString("0.000");
                                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[4].Value = U.ToString("0.000");
                                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[5].Value = RB.ConveyorEncoder;
                                    DgvPosInfo.FirstDisplayedScrollingRowIndex = DgvPosInfo.RowCount - 1;
                                }

                                myLabel.SetXYText(pos.TranslationX, pos.TranslationY, M.intTypeNum.ToString());

                                myLabel.Rotation = (pos.Rotation);
                                myLabel.Color = CogColorConstants.Black;
                                labels.Add(myLabel);
                            }
                        }
                    }
                }
                catch { }

            }


            return labels;
        }


        object LockObj = new object();
        public int[] PreProductionStatus = new int[6];
        public int quantity = 0;
        bool color = true;
        public void UpdateAutoMode()
        {
            quantity += displayPosition.Count();
            List<DisplayPosition> dpList = new List<DisplayPosition>(displayPosition);
            foreach (DisplayPosition dp in dpList)
            {
                if(F.isRnD)
                {
                    DgvPosInfo.Rows.Add();
                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[0].Value = DgvPosInfo.RowCount == 1 ? DgvPosInfo.RowCount : (Convert.ToInt32(DgvPosInfo.Rows[DgvPosInfo.RowCount - 2].Cells[0].Value) + 1);
                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[1].Value = dp.Index;
                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[2].Value = dp.X;
                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[3].Value = dp.Y;
                    DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[4].Value = dp.R;
                    //DgvPosInfo.Rows[DgvPosInfo.RowCount - 1].Cells[5].Value = dp.Enc;
                    DgvPosInfo.FirstDisplayedScrollingRowIndex = DgvPosInfo.RowCount - 1;
                }
                DgvRecipe.Rows[dp.Index - 1].Cells[5].Value = Convert.ToInt32(DgvRecipe.Rows[dp.Index - 1].Cells[5].Value) + 1;
                Animate.AddProduct(dp.Index.ToString(), Convert.ToDouble(dp.X), Convert.ToDouble(dp.Y), Convert.ToInt32(dp.Enc), color);
            }
            if (displayPosition.Count != 0) color = !color;
            lock (LockObj)
            {
                displayPosition.Clear();
            }
            if (DgvPosInfo.RowCount > 200) DgvPosInfo.Rows.RemoveAt(0);

            LbProductionList[1].Text = quantity.ToString();

            if (ArrayCompare(PreProductionStatus, RB.RB_ProductionStatus) == false)
            {
                int languageIndex = Language.LanguageIndex >= MultiLan_SystemStatus.Count() ? 0 : Language.LanguageIndex;
                switch (RB.RB_ProductionStatus[0])
                {
                    case 100:
                        LbProductionList[0].Text = MultiLan_SystemStatus[languageIndex][0];
                        LbProductionList[0].ForeColor = Color.Green;
                        Animation.IsPrinting.isPrinting = false;
                        break;
                    case 5:
                        LbProductionList[0].Text = MultiLan_SystemStatus[languageIndex][1];
                        LbProductionList[0].ForeColor = Color.Goldenrod;
                        Animation.IsPrinting.isPrinting = false;
                        break;
                    case 15:
                        LbProductionList[0].Text = MultiLan_SystemStatus[languageIndex][2];
                        LbProductionList[0].ForeColor = Color.DeepSkyBlue;
                        Animation.IsPrinting.isPrinting = false;
                        break;
                    case 20:
                        LbProductionList[0].Text = MultiLan_SystemStatus[languageIndex][3];
                        LbProductionList[0].ForeColor = Color.MediumSlateBlue;
                        Animation.IsPrinting.X = RB.RB_Pos_Speed[0] / 1000.0;
                        Animation.IsPrinting.Y = RB.RB_Pos_Speed[1] / 1000.0;
                        Animation.IsPrinting.isPrinting = true;
                        break;
                    default:
                        break;
                }
                LbProductionList[2].Text = RB.RB_ProductionStatus[2].ToString();
                LbProductionList[3].Text = RB.RB_ProductionStatus[3].ToString();
                LbProductionList[4].Text = (RB.RB_ProductionStatus[1]/1000.0).ToString("0.000");
            }
            PreProductionStatus = RB.RB_ProductionStatus;
        }
        private bool ArrayCompare(int[] array1, int[] array2)
        {
            if (array1.Count() != array2.Count()) return false;
            for (int i = 0; i < array1.Count(); i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }

        #endregion

    }

}
