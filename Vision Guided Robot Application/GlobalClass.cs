using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.Linq;
using MachineTools;
using System.Windows.Forms;
using System.IO;
using Cognex.VisionPro.CalibFix;
using System.Drawing;
using OfficeOpenXml;
using System.Diagnostics;

namespace Vision_Guided_Robot_Application
{
    public class Config_Connection
    {
        public string FilePath = Application.StartupPath + "\\Config\\Connection.xml";
        public string ConfigPath = Application.StartupPath + "\\Config\\";

        public string CameraIP;
        public string RobotIP;
        public string BarcodePort;

        /// <summary>
        /// Save Hardware value from variable to Connection.XML file
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                Tools.XMLSave(FilePath,
                    new Tools.Param_Class[] {
                        new Tools.Param_Class ("RobotIP",RobotIP.ToString()),
                        new Tools.Param_Class ("CameraIP",CameraIP.ToString()),
                        new Tools.Param_Class ("BarcodePort",BarcodePort.ToString()),
                        });
                return true;
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// Load value from Connection.XML file to variable; 
        /// Load calib2.vpp for camera, save to IcogTransform2D Trans2
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            try
            {
                SortedList<string, string> Configs = Tools.XMLLoad(FilePath);

                if (Configs.Count() == 0) Error.SetErr(54);
                foreach (KeyValuePair<string, string> kvp in Configs)
                {
                    switch (kvp.Key)
                    {
                        case "RobotIP":
                            RobotIP = kvp.Value;
                            break;
                        case "CameraIP":
                            CameraIP = kvp.Value;
                            break;
                        case "BarcodePort":
                            BarcodePort = kvp.Value;
                            break;
                    }
                }
                if (string.IsNullOrWhiteSpace(RobotIP)) RobotIP = "";
                if (string.IsNullOrWhiteSpace(CameraIP)) CameraIP = "";
                if (string.IsNullOrWhiteSpace(BarcodePort)) BarcodePort = "";
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public class Config_HardWare
    {
        public string FilePath = Application.StartupPath + "\\Config\\Hardware.xml";
        public string ConfigPath = Application.StartupPath + "\\Config\\";
        public string BackupPath = Application.StartupPath + "\\Config\\Calib Back up\\";

        public double Encoder_X_Ratio;
        public double Encoder_Y_Ratio;
        public double CCD_RB_X;
        public double CCD_RB_Y;

        public double RBX_Leave_CCD_Min, RBX_Leave_CCD_Max;
        public double RBY_Leave_CCD_Min, RBY_Leave_CCD_Max;


        public ICogTransform2D Trans;

        public double RepeatRange;
        public double OffsetX, OffsetY;

        public double WMA;
        public double MaxErr;

        public int CaptureInterval;
        public int LivedResolution;
        public int BarcodeDetectTime;

        public int CR_Left;
        public int CR_Right;

        public float Print_Distance_XY_Setting;
        /// <summary>
        /// Save Hardware value from variable to Connection.XML file
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            try
            {
                Tools.XMLSave(FilePath,
                    new Tools.Param_Class[] {
                        new Tools.Param_Class ("Encoder_X",Encoder_X_Ratio.ToString()),
                        new Tools.Param_Class ("Encoder_Y",Encoder_Y_Ratio.ToString()),
                        new Tools.Param_Class ("CCD_RB_X",CCD_RB_X.ToString()),
                        new Tools.Param_Class ("CCD_RB_Y",CCD_RB_Y.ToString()),
                        new Tools.Param_Class ("RBX_Leave_CCD_Min",RBX_Leave_CCD_Min.ToString()),
                        new Tools.Param_Class ("RBX_Leave_CCD_Max",RBX_Leave_CCD_Max.ToString()),
                        new Tools.Param_Class ("RBY_Leave_CCD_Min",RBY_Leave_CCD_Min.ToString()),
                        new Tools.Param_Class ("RBY_Leave_CCD_Max",RBY_Leave_CCD_Max.ToString()),
                        new Tools.Param_Class ("RepeatRange",RepeatRange.ToString()),
                        new Tools.Param_Class ("OffsetX",OffsetX.ToString()),
                        new Tools.Param_Class ("OffsetY",OffsetY.ToString()),
                        new Tools.Param_Class ("WMA",WMA.ToString()),
                        new Tools.Param_Class ("MaxErr",MaxErr.ToString()),
                        new Tools.Param_Class ("CaptureInterval",CaptureInterval.ToString()),
                        new Tools.Param_Class ("LivedResolution",LivedResolution.ToString()),
                        new Tools.Param_Class ("CR_Left",CR_Left.ToString()),
                        new Tools.Param_Class ("CR_Right",CR_Right.ToString()),
                        new Tools.Param_Class ("Print_Distance_XY_Setting",Print_Distance_XY_Setting.ToString()),
                        new Tools.Param_Class ("BarcodeDetectTime",BarcodeDetectTime.ToString()),
                        });

                return true;
            }
            catch
            {
                return false;
            }


        }

        /// <summary>
        /// Load value from Connection.XML file to variable; 
        /// Load calib2.vpp for camera, save to IcogTransform2D Trans2
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            try
            {
                SortedList<string, string> Configs = Tools.XMLLoad(FilePath);

                if (Configs.Count() == 0) Error.SetErr(55);

                foreach (KeyValuePair<string, string> kvp in Configs)
                {
                    switch (kvp.Key)
                    {
                        case "Encoder_X":
                            Encoder_X_Ratio = double.Parse(kvp.Value);
                            break;
                        case "Encoder_Y":
                            Encoder_Y_Ratio = double.Parse(kvp.Value);
                            break;
                        case "CCD_RB_X":
                            CCD_RB_X = double.Parse(kvp.Value);
                            break;
                        case "CCD_RB_Y":
                            CCD_RB_Y = double.Parse(kvp.Value);
                            break;
                        case "RBX_Leave_CCD_Min":
                            RBX_Leave_CCD_Min = double.Parse(kvp.Value);
                            break;
                        case "RBX_Leave_CCD_Max":
                            RBX_Leave_CCD_Max = double.Parse(kvp.Value);
                            break;
                        case "RBY_Leave_CCD_Min":
                            RBY_Leave_CCD_Min = double.Parse(kvp.Value);
                            break;
                        case "RBY_Leave_CCD_Max":
                            RBY_Leave_CCD_Max = double.Parse(kvp.Value);
                            break;
                        case "RepeatRange":
                            RepeatRange = double.Parse(kvp.Value);
                            break;
                        case "OffsetX":
                            OffsetX = double.Parse(kvp.Value);
                            break;
                        case "OffsetY":
                            OffsetY = double.Parse(kvp.Value);
                            break;
                        case "WMA":
                            WMA = double.Parse(kvp.Value);
                            break;
                        case "MaxErr":
                            MaxErr = double.Parse(kvp.Value);
                            break;
                        case "CaptureInterval":
                            CaptureInterval = int.Parse(kvp.Value);
                            break;
                        case "LivedResolution":
                            LivedResolution = int.Parse(kvp.Value);
                            break;
                        case "CR_Left":
                            CR_Left = int.Parse(kvp.Value);
                            break;
                        case "CR_Right":
                            CR_Right = int.Parse(kvp.Value);
                            break;
                        case "Print_Distance_XY_Setting":
                            Print_Distance_XY_Setting = float.Parse(kvp.Value);
                            break;
                        case "BarcodeDetectTime":
                            BarcodeDetectTime = int.Parse(kvp.Value);
                            break;
                    }
                }
                if (CaptureInterval < 300) CaptureInterval = 300;

                if (LivedResolution < 100) LivedResolution = 100;
                else if (LivedResolution > 1000) LivedResolution = 1000;

                if (BarcodeDetectTime < 1000) BarcodeDetectTime = 1000;
                else if (BarcodeDetectTime > 10000) BarcodeDetectTime = 10000;

                if (CR_Left < -795) CR_Left = -800;
                else if (CR_Left > 795) CR_Left = 800;

                if (CR_Right < -795) CR_Right = 800;
                else if (CR_Right > 795) CR_Right = 800;

                Save();
                #region 取得9點校正
                CogCalibNPointToNPointTool c;

                bool isOK = VisionTool.LoadVPP(Application.StartupPath + "\\CONFIG\\" + "calib2.vpp", out c);
                if (!isOK)
                {
                    Error.SetErr(52);
                    Trans = null;
                }
                else
                {
                    try { Trans = VisionTool.GetCoordTrans(c); }
                    catch { Error.SetErr(52); }
                   
                }
                #endregion
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public class Config_Operational
    {
        public string FilePath = Application.StartupPath + "\\Config\\Operational.xml";
        public List<string> RecipeName = new List<string>();
        public List<bool> Used = new List<bool>();
        public List<int> CR = new List<int>();
        public List<int> fileQty_of_Recipe = new List<int>();
        public List<int> Pcs = new List<int>();

        /// <summary>
        /// Save Hardware value from variable to Operational.XML file
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            List<Tools.Param_Class> list_Params = new List<Tools.Param_Class>();

            for (int i = 0; i < RecipeName.Count; i++)
            {
                list_Params.Add(new Tools.Param_Class("RecipeName" + i.ToString(), RecipeName[i]));
                list_Params.Add(new Tools.Param_Class("Used" + i.ToString(), Used[i].ToString()));
                list_Params.Add(new Tools.Param_Class("CR" + i.ToString(), CR[i].ToString()));
                list_Params.Add(new Tools.Param_Class("Qty" + i.ToString(), fileQty_of_Recipe[i].ToString()));
            }

            try
            {
                Tools.XMLSave(FilePath, list_Params.ToArray());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load recipes from Operational.XML file to variable
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            try
            {
                RecipeName.Clear();
                Used.Clear();
                CR.Clear();
                fileQty_of_Recipe.Clear();

                SortedList<string, string> Configs = Tools.XMLLoad(FilePath);

                if (Configs.Count() == 0) Error.SetErr(56);
                foreach (KeyValuePair<string, string> kvp in Configs)
                {
                    if (kvp.Key.Contains("RecipeName")) RecipeName.Add(kvp.Value);
                    else if (kvp.Key.Contains("Used")) Used.Add(bool.Parse(kvp.Value));
                    else if (kvp.Key.Contains("CR")) CR.Add(Int32.Parse(kvp.Value));
                    else if (kvp.Key.Contains("Qty")) fileQty_of_Recipe.Add(Int32.Parse(kvp.Value));

                }
                if (RecipeName.Count == 0 || RecipeName == null)
                {
                    RecipeName.Add("Default");
                    Used.Add(false);
                    CR.Add(0);
                    fileQty_of_Recipe.Add(0);
                }
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load recipes from dgvRecipe
        /// </summary>
        /// <param name="dgvRecipe"></param>
        /// <returns></returns>
        public void Load(DataGridView dgvRecipe)
        {
            RecipeName.Clear();
            Used.Clear();
            CR.Clear();
            fileQty_of_Recipe.Clear();

            for (int i = 0; i < dgvRecipe.RowCount; i++)
            {
                Used.Add(Convert.ToBoolean((dgvRecipe.Rows[i].Cells[0] as DataGridViewCheckBoxCell).Value));
                CR.Add((dgvRecipe.Rows[i].Cells[1] as DataGridViewComboBoxCell).Items.IndexOf(dgvRecipe.Rows[i].Cells[1].Value));
                RecipeName.Add(dgvRecipe.Rows[i].Cells[3].Value.ToString());
                fileQty_of_Recipe.Add(Convert.ToInt32(dgvRecipe.Rows[i].Cells[4].Value));

            }
            
            Save();
        }

    }
    public class Config_Recipe
    {
        public string Name;
        public static string FolderPath = Application.StartupPath + "\\Recipe\\";
        public  List<string> RunObj = new List<string>();
        public List<int> RunObjCR = new List<int>();
        public List<int> RunObjIntTypeNum = new List<int>();
        public static string recipesList;
        private List<string> CRList = new List<string>() { "N", "L", "R" };
        private List<int> CRUsed = new List<int>();
        /// <summary>
        /// Save RunObj into recipe 
        /// </summary>
        /// <returns></returns>
        public bool Save(string Name)
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            string FilePath = FolderPath + Name + ".xml";
            List<Tools.Param_Class> list_Params = new List<Tools.Param_Class>();
            for (int i = 0; i < RunObj.Count; i++)
            {
                list_Params.Add(new Tools.Param_Class("RunObj_" + i.ToString(),
                    RunObj[i]));
            }
            try
            {
                Tools.XMLSave(FilePath, list_Params.ToArray());
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Load recipe into RunObj
        /// </summary>
        /// <returns></returns>
        public bool Load(List<string> Name, List<bool> Used, List<int> CR)
        {
            RunObj.Clear();
            RunObjIntTypeNum.Clear();
            RunObjCR.Clear();
            recipesList = null;
            CRUsed.Clear();
            GC.Collect();

            int recipeCount = 0;

            for (int i = 0;i<Name.Count;i++)
            {
                if(Used[i])
                {
                    CRUsed.Add(CR[i]);

                    recipeCount++;
                    string FilePath = FolderPath + Name[i] + ".xml";
                    recipesList += Name[i] +" - " + CRList[CR[i]] + ", ";
                    try
                    {
                        SortedList<string, string> Configs = Tools.XMLLoad(FilePath);

                        foreach (KeyValuePair<string, string> kvp in Configs)
                        {
                            if (kvp.Key.Contains("RunObj"))
                            {
                                RunObj.Add(kvp.Value);
                                RunObjIntTypeNum.Add(i + 1);
                                RunObjCR.Add(CR[i]);
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
             
            }

            if (RunObj.Count() > 12 || RunObj.Count() <= 0 || recipeCount <= 0 || recipeCount > 2)
            {
                Error.SetErr(50);
                return false;
            }
            if(recipeCount == 2)
            {
                try
                {
                    if (!((CRUsed[0] == 1 && CRUsed[1] == 2) || (CRUsed[0] == 2 && CRUsed[1] == 1))) Error.SetErr(103);
                    else Error.RstErr(103);
                }
                catch { }
            }
            else Error.RstErr(103);

            Error.RstErr(50);
            return true;
        }
        private bool CheckChosenRecipe(List<bool> Used, List<int> CR)
        {
            bool check = false;
            int countUsed = 0;
            List<int> CRUsed = new List<int>();
            for (int i = 0; i < Used.Count(); i++)
            {
                if (Used[i])
                {
                    countUsed++;
                    CRUsed.Add(CR[i]);
                }
            }
            switch (countUsed)
            {
                case 1:
                    check = true;
                    break;
                case 2:
                    try
                    {
                        if ((CRUsed[0] == 1 && CRUsed[1] == 2) || (CRUsed[0] == 2 && CRUsed[1] == 1)) check = true;
                        else check = false;
                    }
                    catch
                    {
                        check = false;
                    }
                    break;
                default:
                    check = false;
                    break;
            }
            return check;
        }
        public bool Load(string Name)
        {
            string FilePath = FolderPath + Name + ".xml";

            try
            {
                SortedList<string, string> Configs = Tools.XMLLoad(FilePath);
                RunObj.Clear();
                GC.Collect();
                foreach (KeyValuePair<string, string> kvp in Configs)
                {
                    if (kvp.Key.Contains("RunObj"))
                    {
                        RunObj.Add(kvp.Value);
                    }
                }
            return true;
            }
            catch
            {
                return false;
            }
            
        }


        /// <summary>
        /// Delete recipe DelName.xml
        /// </summary>
        /// <param name="DelName"></param>
        public static void Del(string DelName)
        {
            string FilePath = FolderPath + DelName + ".xml";
            File.Delete(FilePath);
        }

        /// <summary>
        /// Check if recipe file Name.xml is existed
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool isExist(string Name)
        {
            string FilePath = FolderPath + Name + ".xml";
            return File.Exists(FilePath);
        }


        /// <summary>
        /// Clone recipe Source.xml into Target.xml
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Target"></param>
        public static void CloneConfig(string Source, string Target)
        {
            File.Copy(FolderPath + Source + ".xml", FolderPath + Target + ".xml");
        }

        /// <summary>
        /// Get list of recipe file
        /// </summary>
        /// <returns></returns>
        public static string[] FindAll()
        {
            return Tools.GetFileList_WithoutExtension(FolderPath);
        }
        public static string[] GetFilesDescription(string[] recipeNameList)
        {
            List<string> descriptionList = new List<string>();
            foreach (string recipeName in recipeNameList)
            {
                descriptionList.Add(FileVersionInfo.GetVersionInfo(FolderPath + recipeName + ".xml").FileDescription);
            }
            return descriptionList.ToArray();
        }
    }
    public class Config_Prod
    {
        public class FolderInfo
        {
            public int Level;
            public string Code;
            public string Name;
            public string Color;
            public string Size;
            public string Orientation;
        }
        public CogToolBlock TB;
        public int intTypeNum;
        public string Name;

        public static string SetFolder = Application.StartupPath + "\\Training\\Products\\";
        public Image PreView;

        public FolderInfo ProductInfo;
        /// <summary>
        /// Not see where used
        /// </summary>
        /// <returns></returns>
        public Config_Prod Clone()
        {
            Config_Prod p = new Config_Prod();
            //p.Vision = Vision.Clone();
            if (TB != null)
                p.TB = (CogToolBlock)CogSerializer.DeepCopyObject(TB);

            p.intTypeNum = intTypeNum;
            p.Name = Name;

            return p;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {

            string FileFolder = SetFolder + Name + "\\";
            string FilePath_VPP = FileFolder + "TB.vpp";

            if (!Directory.Exists(FileFolder))
            {
                Directory.CreateDirectory(FileFolder);
            }
            try
            {
                File.Delete(FilePath_VPP);
                CogSerializer.SaveObjectToFile(TB, FilePath_VPP);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Load()
        {
            string FileFolder = SetFolder + Name + "\\";
            string FilePath_VPP = FileFolder + "TB.vpp";
            try
            {
               if(! VisionTool.LoadVPP(FilePath_VPP, out TB)) Error.SetErr(51);

                ProductInfo = LoadProductInfo(Name);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static FolderInfo LoadProductInfo(string path)
        {
            FolderInfo fi = new FolderInfo();
            fi = new FolderInfo();
            string[] s = Path.GetFileName(Directory.GetParent(Directory.GetParent(path).ToString()).ToString()).Split('_');
            fi.Code = s[0];
            fi.Name = s[1];
            fi.Orientation = s[2];
            fi.Color = Path.GetFileName(Directory.GetParent(path).ToString());
            fi.Size = Path.GetFileName(path);

            return fi;
        }
        public static void Del(string DelName)
        {
            string FileFolder = SetFolder + DelName + "\\";
            Directory.Delete(FileFolder, true);
            //Directory.Delete(DelFolderPath, true);
        }
        public static bool isExist(string Name)
        {
            string FileFolder = SetFolder + Name + "\\";
            return Directory.Exists(FileFolder);
        }

        public static void CloneConfig(string Source,string Target)
        {
            CopyAll(new DirectoryInfo(SetFolder + Source), new DirectoryInfo(SetFolder + Target));


        }
        static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
    public class Product
    {
        public double X, Y, R;
        public int ObjType;
        public int EC;

        public Product(double _X, double _Y, double _R, int _En, int _ObjType)
        {
            X = _X;
            Y = _Y;
            R = _R;
            EC = _En;
            ObjType = _ObjType;
        }

        public Product_Data Clone(Product_Data oldData)
        {
            return new Product_Data(oldData.X, oldData.Y, oldData.U, oldData.EC, oldData.ObjType);
        }
    }
    public class VisionTool
    {
        /// <summary>得到CogCalibNPointToNPointTool的ICogTransform2D
        /// 使用ICogTransform2D.MapPoint可以得到轉換後的值
        /// </summary>
        /// <param name="CalibNPP"></param>
        /// <returns></returns>
        public static ICogTransform2D GetCoordTrans(CogCalibNPointToNPointTool CalibNPP)
        {
            ICogTransform2D tran = CalibNPP.Calibration.GetComputedUncalibratedFromCalibratedTransform();

            return tran.InvertBase();
        }

        public static bool LoadVPP(string path, out CogToolBlock tb)
        {
            try
            {
                if (File.Exists(path))
                {
                    try
                    {
                        tb = (CogToolBlock)CogSerializer.LoadObjectFromFile(path);
                        return true;
                    }
                    catch
                    {
                        tb = null;
                        return false;
                    }
                }
                else
                {
                    //MessageBox.Show("Vpp is not exist. Program will create a new Vpp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb = null ;
                    return false;
                }

            }
            catch
            {
                //MessageBox.Show("Can't not load VPP." + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb =null;
                return false;
            }

        }
        public static bool LoadVPP(string path, out CogCalibNPointToNPointTool Calib)
        {
            try
            {
                if (File.Exists(path))
                    Calib = (CogCalibNPointToNPointTool)CogSerializer.LoadObjectFromFile(path);
                else
                {
                    Error.SetErr(52);
                    Calib = null;
                    return false;
                }
                return true;
            }
            catch
            {
                Error.SetErr(52);
                Calib = null;
                return false;
            }

        }
        public static bool SaveVpp(string path, CogToolBlock tb)
        {
            try
            {
                CogSerializer.SaveObjectToFile(tb, path);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mes.MesList[20].Text + Environment.NewLine + ex.Message , Mes.MesList[20].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool SaveVpp(string path, CogCalibNPointToNPointTool tb)
        {
            try
            {
                CogSerializer.SaveObjectToFile(tb, path);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Mes.MesList[20].Text + Environment.NewLine + ex.Message
                    , Mes.MesList[20].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static CogToolBlock Clone(CogToolBlock tb)
        {
            if (tb != null)
                return (CogToolBlock)CogSerializer.DeepCopyObject(tb);
            else
                return null;
        }
    }
    public  class Error
    {
        const int ErrNum= 1000;

        static Log ErrLog=new Log(Application.StartupPath + "\\Log\\ErrorMes", "Error");
        //public const int Err_NoCCD1 = 0;
        //public const int Err_NoCCD2 = 1;
        //public const int Err_LoadProd = 51;
        //public const int Err_NoDongle = 2;
        //public const int Err_LoadCalib = 52;
        //public const int Err_RobotConn = 3;
        //public const int Err_NoProdSel = 50;
        //public const int Err_ReadEncToolong = 101;

        public static bool[] isErr = new bool[ErrNum];
        public static SortedList<int, string> ErrMes = new SortedList<int, string>();
        public static List<int> NowErrorList = new List<int>();
        public static List<int> PreviousErrorList = new List<int>();

        public static bool SoftwareError, SoftwareWarning;
        public static void SetErr(int ErrNum)
        {
            isErr[ErrNum] = true;
            if(NowErrorList.IndexOf (ErrNum) == -1)
            {
                if (ErrNum < 100) SoftwareError = true;
                else if (ErrNum >= 100 && ErrNum < 200) SoftwareWarning = true;
                NowErrorList.Add(ErrNum);

                if (ErrMes.Keys.IndexOf(ErrNum) == -1)
                    ErrLog.ADDLog(ErrNum.ToString("0000"));
                else
                    ErrLog.ADDLog(ErrNum.ToString("0000") + "," + ErrMes[ErrNum]);
            }

            
        }
        public static void RstErr(int ErrNum)
        {
            if(NowErrorList.Count<=0)
            {
                SoftwareError = false;
                SoftwareWarning = false;
            }
            NowErrorList.Remove(ErrNum);
            isErr[ErrNum] = false;
        }
        public static void RstAllErr()
        {
            SoftwareError = false;
            SoftwareWarning = false;

            NowErrorList.Clear();
            for (int i = 0; i < ErrNum; i++)
            {
                isErr[i] = false;
            }
        }

        /// <summary>
        /// Load Error Message in ErrMes.txt
        /// </summary>
        public static void LoadErrMes(int languageIndex)
        {
            ErrMes = new SortedList<int, string>();
            string FP = Application.StartupPath + "\\Config\\ErrMes.txt";

            if (File.Exists(FP))
            {
                IEnumerable<string> ss = File.ReadLines(FP);
                string[] sp;
                try
                {
                    foreach (string s in ss)
                    {
                        sp = s.Split('\t');

                        if (int.TryParse(sp[0], out int idx))
                        {
                            ErrMes.Add(idx, sp[languageIndex + 1]);
                        }
                    }
                }
                catch
                {
                    Error.SetErr(112);
                }

            }
        }
    }

    public class Animation
    {
        #region Properties
        private Panel conveyor;
        private PictureBox pY;
        private PictureBox pX;
        private CheckBox cbLivedRobot;
        private CheckBox cbLivedObject;
        private CheckBox cbLivedPrinting;
        double RealConveyorX = 1400/6.61*8.36;
        double Scale;
        public static class IsPrinting
        {
            public static bool isPrinting;
            public static double X;
            public static double Y;
        }
        Timer timer;
        public Panel Conveyor { get => conveyor; set => conveyor = value; }
        public PictureBox PY { get => pY; set => pY = value; }
        public PictureBox PX { get => pX; set => pX = value; }
        public CheckBox CbLivedRobot { get => cbLivedRobot; set => cbLivedRobot = value; }
        public CheckBox CbLivedObject { get => cbLivedObject; set => cbLivedObject = value; }
        public CheckBox CbLivedPrinting { get => cbLivedPrinting; set => cbLivedPrinting = value; }

        public class Product
        {
            public int Count;
            public string Index;
            public double X;
            public double Y;
            public int Enc;
        }
        #endregion

        #region Initialize
        public static class ConveyorCoE//Hê số width, height của conveyor
        {
            public static double X = 1;
            public static double Y = 11/8.36;
        }
        public static class PYCoE//Hê số width, height của  py
        {
            public static double X = 1;
            public static double Y = 2.73/8.36;
        }
        public static class PXCoE//Hê số width, height của  px
        {
            public static double X = 0.9 / 8.36;
            public static double Y = 2.07 / 8.36;
        }
        public static class FSize// Width, height của picturebox conveyor
        {
            public static double X;
            public static double Y;
        }
        public static class OriginCoE// Hệ số khoảng cách từ gốc tọa độ của robot đến gốc tọa độ của conveyor
        {
            public static double X = 2.06 / 8.36;
            public static double Y = 4.4 / 8.36;
        }
        public static class OriginAdjustCOE
        {
            public static double X = 0.45 / 8.36;
            public static double Y = 0.27 / 8.36;
        }
        public static class PixelConveyor//Widht, height của conveyor
        {
            public static double X;
            public static double Y;
        }
        public static class Distance//Khoảng các từ rìa của conveyor đển rìa của picturebox conveyor
        {
            public static double X;
            public static double Y;
        }
        public  static class Origin//Khoảng cách từ gốc tọa độ của robot đến gốc tọa độ của conveyor
        {
            public static double X;
            public static double Y;
        }
        public static class OriginAdjust
        {
            public static double X;
            public static double Y;
        }
        public static double YMaxCOE = 3.55 / 8.36;
        public static double YMax, YMin;
        double CoE;//Tỉ lê giữa conveyor và picturebox conveyor
        public List<Product> productList;
        public Animation(Panel conveyor, PictureBox pY, PictureBox pX, CheckBox cbLivedRobot, CheckBox cbLivedObject, CheckBox cbLivedPrinting)
        {
            this.Conveyor = conveyor;
            this.PX = pX;
            this.PY = pY;
            this.CbLivedRobot = cbLivedRobot;
            this.CbLivedObject = cbLivedObject;
            this.CbLivedPrinting = cbLivedPrinting;

            Conveyor.SizeChanged += Conveyor_SizeChanged;

            timer = new Timer() { Enabled = true, Interval = 100 };

            Conveyor.Controls.Add(PX);
            Conveyor.Controls.Add(PY);

            Conveyor.Controls.SetChildIndex(PX, 1);
            Conveyor.Controls.SetChildIndex(PY, 3);

            Conveyor_SizeChanged(null, null);

            productList = new List<Product>();
        }
        #endregion

        #region Methods
        private void Conveyor_SizeChanged(object sender, EventArgs e)
        {
            FSize.X = Convert.ToDouble(Conveyor.Size.Width);
            FSize.Y = Convert.ToDouble(Conveyor.Size.Height);

            CoE = FSize.X / FSize.Y / (ConveyorCoE.X / ConveyorCoE.Y);

            if (CoE >= 1)
            {
                PixelConveyor.X = FSize.X / CoE * ConveyorCoE.X;
                PixelConveyor.Y = PixelConveyor.X / ConveyorCoE.X * ConveyorCoE.Y;
            }
            else
            {
                PixelConveyor.X = FSize.X * ConveyorCoE.X;
                PixelConveyor.Y = PixelConveyor.X / ConveyorCoE.X * ConveyorCoE.Y;
            }
            Scale = PixelConveyor.X / RealConveyorX;

            Distance.X = (FSize.X - PixelConveyor.X) / 2.0;
            Distance.Y = (FSize.Y - PixelConveyor.Y) / 2.0;

            Origin.X = Distance.X + PixelConveyor.X * OriginCoE.X;
            Origin.Y = Distance.Y + PixelConveyor.X * OriginCoE.Y;

            OriginAdjust.X = PixelConveyor.X * OriginAdjustCOE.X;
            OriginAdjust.Y = PixelConveyor.X * OriginAdjustCOE.Y;

            YMax = Distance.Y + Origin.Y + PixelConveyor.X * YMaxCOE;
            YMin = Distance.Y + Origin.Y;

            AdjustSize();
            AdjustLocation(0, 0);
            AdjustProductLocation();
        }
        public void AdjustSize()
        {
            PY.Size = new Size()
            {
                Width = Convert.ToInt32(PixelConveyor.X * PYCoE.X),
                Height = Convert.ToInt32(PixelConveyor.X * PYCoE.Y),
            };
            PX.Size = new Size()
            {
                Width = Convert.ToInt32(PixelConveyor.X * PXCoE.X),
                Height = Convert.ToInt32(PixelConveyor.X * PXCoE.Y),
            };
        }
        public void AdjustLocation(double moveX, double moveY)
        {
            if(CbLivedRobot.Checked)
            {
                PY.Location = new Point()
                {
                    X = Convert.ToInt32(Distance.X),
                    Y = Convert.ToInt32(Origin.Y - OriginAdjust.Y + moveY * Scale),
                };
                PX.Location = new Point()
                {
                    X = Convert.ToInt32(Origin.X - OriginAdjust.X + moveX * Scale),
                    Y = Convert.ToInt32(Origin.Y - OriginAdjust.Y + moveY * Scale),
                };
            }
        
        }
        public void AddProduct(string Index, double X, double Y, int Enc, bool color)
        {
            if(CbLivedObject.Checked)
            {
                try
                {
                    productList.Add(new Product() { X = X, Y = Y, Count = productList.Count, Enc = Enc });

                    Label lb = new Label()
                    {
                        Text = Index,
                        Location = new Point() { X = Convert.ToInt32(Origin.X + X * Scale), Y = Convert.ToInt32(Origin.Y + Y * Scale) },
                        Font = new Font("Consolas", 12, FontStyle.Bold),
                        Tag = productList.Count() - 1,
                        BackColor = Color.Transparent,
                        ForeColor = Color.Red,
                        AutoSize = true,
                        BorderStyle = BorderStyle.Fixed3D,
                    };
                    if (color) lb.BackColor = Color.White;
                    else lb.BackColor = Color.Black;

                    lb.LocationChanged += Lb_LocationChanged;
                    Conveyor.Controls.Add(lb);
                    Conveyor.Controls.SetChildIndex(lb, 0);
                }
                catch { }
            }
        }
        private void Lb_LocationChanged(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb.Location.Y > YMax)
            {
                Conveyor.Controls.Remove(lb);
                lb.Dispose();
                GC.Collect();
            }
            if(CbLivedPrinting.Checked)
            {
                if (lb.Location.Y > YMin && lb.Location.Y < YMax && lb.BackColor != Color.DodgerBlue && IsPrinting.isPrinting)
                {
                    if (PrintOnProduct(lb)) lb.ForeColor = Color.DodgerBlue;
                }
            }
        

        }
        private bool PrintOnProduct(Label lb)
        {
            bool printing = false;
            double deltaX = (productList.ElementAt(Convert.ToInt32(lb.Tag)).X  - IsPrinting.X) * Scale;
            double deltaY = (productList.ElementAt(Convert.ToInt32(lb.Tag)).Y  - IsPrinting.Y) * Scale;
            if (Math.Sqrt(deltaX * deltaX + deltaY * deltaY) < (35 * Scale)) printing = true;
            return printing;
        }
        public void AdjustProductLocation()
        {
            try
            {
                if(Conveyor.Controls.Count >3)
                {
                    foreach (Control lb in Conveyor.Controls)
                    {
                        if (lb is Label)
                        {
                            Product p = productList.ElementAt(Convert.ToInt32(lb.Tag));
                            lb.Location = new Point() { X = Convert.ToInt32(Distance.X + PixelConveyor.X * OriginCoE.X + p.X * Scale), Y = Convert.ToInt32(Distance.Y + p.Y * Scale) };
                        }
                    }
                }
            }
            catch { }
        
        }
        public void ProductMove(int Enc, double Enc_X_Ratio, double Enc_Y_Ratio)
        {
            try
            {
                if(CbLivedObject.Checked)
                {
                    foreach (Control lb in Conveyor.Controls)
                    {
                        if (lb is Label)
                        {
                            productList.ElementAt(Convert.ToInt32(lb.Tag)).X += (Enc - productList.ElementAt(Convert.ToInt32(lb.Tag)).Enc) * Enc_X_Ratio;
                            productList.ElementAt(Convert.ToInt32(lb.Tag)).Y += (Enc - productList.ElementAt(Convert.ToInt32(lb.Tag)).Enc) * Enc_Y_Ratio;
                            productList.ElementAt(Convert.ToInt32(lb.Tag)).Enc = Enc;
                            lb.Location = new Point()
                            {
                                X = Convert.ToInt32(Origin.X + productList.ElementAt(Convert.ToInt32(lb.Tag)).X * Scale),
                                Y = Convert.ToInt32(Origin.Y + productList.ElementAt(Convert.ToInt32(lb.Tag)).Y * Scale)
                            };
                        }
                    }
                }
            }
            catch { }
        }
        #endregion

    }

    public class Language
    {
        public class ControlLanguage
        {
            public string ControlName;
            public string Language;
        }
        public List<ControlLanguage> controlList;
        public static string translateMainPath = Application.StartupPath + "\\Config\\LanguageMain.xlsx";
        public static string translateConfigPath = Application.StartupPath + "\\Config\\LanguageConfig.xlsx";
        public static string translateTrainingPath = Application.StartupPath + "\\Config\\LanguageTraining.xlsx";
        public static string translateProductPath = Application.StartupPath + "\\Config\\LanguageProduct.xlsx";
        public static string translateRecipePath = Application.StartupPath + "\\Config\\LanguageRecipe.xlsx";
        public static string translateUserPath = Application.StartupPath + "\\Config\\LanguageUser.xlsx";
        public static string MesPath = Application.StartupPath + "\\Config\\Mes.xlsx";
        public static int LanguageIndex;
        public List<string> languageList;

        public static void LoadLanguageIndex()
        {
            try
            {
                ExcelPackage languageFile = new ExcelPackage(new FileInfo(translateMainPath));
                ExcelWorksheet languageWs = languageFile.Workbook.Worksheets[1];
                LanguageIndex = Convert.ToInt32(languageWs.Cells[1, 1].Value);

                languageFile.Dispose();
                languageWs.Dispose();
                GC.Collect();

            }
            catch { };
        }
        public void LoadLanguageFile(string path)
        {
            controlList = new List<ControlLanguage>();
            try
            {
                ExcelPackage languageFile = new ExcelPackage(new FileInfo(path));
                ExcelWorksheet languageWs = languageFile.Workbook.Worksheets[1];

                languageList = new List<string>();
                for (int k = languageWs.Dimension.Start.Column + 1; k <= languageWs.Dimension.End.Column; k++)
                {
                    string s = languageWs.Cells[2, k].Value.ToString();
                    languageList.Add(s);
                }

                for (int i = languageWs.Dimension.Start.Row + 2; i <= languageWs.Dimension.End.Row; i++)
                {
                    ControlLanguage cL = new ControlLanguage()
                    {
                        ControlName = languageWs.Cells[i, 1].Value.ToString(),
                        Language = languageWs.Cells[i, LanguageIndex + 2].Value.ToString(),
                    };
                    controlList.Add(cL);
                }
                languageFile.Dispose();
                languageWs.Dispose();
                GC.Collect();
            }
            catch
            {
                Error.SetErr(110);
            } 
        }
        public void ChangeLanguageControl(Control f, List<ControlLanguage> controlList)
        {
            try
            {
                for (int i = 0; i < controlList.Count; i++)
                {
                    try
                    {
                        Control c = f.Controls.Find(controlList[i].ControlName, true).FirstOrDefault() as Control;
                        if (c != null) c.Text = controlList[i].Language;
                    }
                    catch { }
                }
            }
            catch { }

        }
        public void SaveLangaugeIndex(int index)
        {
            try
            {
                ExcelPackage languageFile = new ExcelPackage(new FileInfo(translateMainPath));
                ExcelWorksheet languageWs = languageFile.Workbook.Worksheets[1];
                languageWs.Cells[1, 1].Value = index;

                byte[] bin = languageFile.GetAsByteArray();
                File.WriteAllBytes(translateMainPath, bin);

                languageFile.Dispose();
                languageWs.Dispose();
                GC.Collect();
            }
            catch
            {

            }
         

        }
    }
    public class Mes
    {
        public static string MesPath = Application.StartupPath + "\\Config\\Mes.xlsx";
        public class MesBox
        {
            public string Caption;
            public string Text;
        }
        public static List<MesBox> MesList = new List<MesBox>();
        public static void LoadMes(int languageIndex)
        {
            try
            {
                MesList.Clear();

                ExcelPackage MesFile;
                MesFile = new ExcelPackage(new FileInfo(MesPath));
                ExcelWorksheet MesWs = MesFile.Workbook.Worksheets[languageIndex+1];

                for (int i = MesWs.Dimension.Start.Row + 1; i <= MesWs.Dimension.End.Row; i++)
                {
                    MesBox cL = new MesBox()
                    {
                        Caption = MesWs.Cells[i, 2].Value.ToString(),
                        Text = MesWs.Cells[i, 3].Value.ToString(),
                    };
                    MesList.Add(cL);
                }
            }
            catch
            {
                Error.SetErr(16);
                for (int i = 0; i < 30; i++)
                {
                    MesList.Add(new MesBox() { Caption = "", Text = "No message loaded" });
                }
            }
        }
    }

    //public class BarcodeDetect
    //{
    //    public class Info
    //    {
    //        public int RecipeIndex;
    //        public int CR;
    //    }
    //    public List<Info> infoList;
    //    public List<Info> Encode(string code128)
    //    {
    //        List<Info> infoList = new List<Info>();
    //        if (string.IsNullOrWhiteSpace(code128)) return infoList;

    //        code128 = code128.Remove(code128.Length - 1);
    //        String[] recipes = code128.Split('\r');

    //        List<string> recipeList = recipes.ToList();
    //        if (recipeList.Count() > 2) recipeList.RemoveRange(2, recipeList.Count - 2);

    //        for (int i = 0; i < recipeList.Count(); i++)
    //        {
    //            Info info = new Info();
    //            info.CR = Convert.ToInt32(recipeList[i][recipeList[i].Count() - 1].ToString());
    //            info.RecipeIndex = Convert.ToInt32(recipeList[i].Remove(recipeList[i].Count() - 1, 1));
    //            infoList.Add(info);
    //        }
    //        return infoList;
    //    }

    //}
}


