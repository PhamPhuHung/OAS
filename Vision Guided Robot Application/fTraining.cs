using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Windows.Forms;

namespace Vision_Guided_Robot_Application
{
    public partial class fTraining : Form
    {
        Config_Prod this_Prod;
        CogImageConvertTool ImgCnv;
        CogToolBlock RecogTB, CheckTB;
        CogPMAlignTool PMA;
        CogAcqFifoTool Acq;
        private CogToolBlock tbFifo;
        string SavePath;
        public CogToolBlock TbFifo { get => tbFifo; set => tbFifo = value; }

        public fTraining(CogToolBlock tbFifo, string productName, string savePath)
        {
            InitializeComponent();
            this.TbFifo = tbFifo;
            Config_Prod.FolderInfo productInfo = Config_Prod.LoadProductInfo(savePath);
            lbCode.Text = productInfo.Code;
            lbName.Text = productInfo.Name;
            lbOrient.Text = productInfo.Orientation;
            lbColor.Text = productInfo.Color;
            lbSize.Text = productInfo.Size;
            SavePath = savePath;

            Language language = new Language();
            language.LoadLanguageFile(Language.translateTrainingPath);
            language.ChangeLanguageControl(this, language.controlList);

            TrainingInitialize(productName);
        }
        #region Training
        private void trackbar_RGB_ValueChanged(object sender, EventArgs e)
        {
            TrackBar trackbar = sender as TrackBar;
            if (trackbar == trackBarRed)
            {
                lbRed.Text = (trackbar.Value / 10.0).ToString();
                ImgCnv.RunParams.IntensityFromWeightedRGBRedWeight = trackbar.Value / 10.0;
            }
            else if (trackbar == trackBarGreen)
            {
                lbGreen.Text = (trackbar.Value / 10.0).ToString();
                ImgCnv.RunParams.IntensityFromWeightedRGBGreenWeight = trackbar.Value / 10.0;
            }
            else if (trackbar == trackBarBlue)
            {
                lbBlue.Text = (trackbar.Value / 10.0).ToString();
                ImgCnv.RunParams.IntensityFromWeightedRGBBlueWeight = trackbar.Value / 10.0;
            }
        }
        private void trackbar_RGB_MouseUp(object sender, MouseEventArgs e)
        {
            trackbar_RGB_ValueChanged(sender, null);
            btTrainingTest_Click(null, null);
        }
        private void btTrainingTest_Click(object sender, EventArgs e)
        {
            btTrainingTest.Enabled = false;

            TbFifo.Run();

            if (TbFifo.RunStatus.Result == CogToolResultConstants.Accept)
            {
                CheckTB.Inputs["InputImage_Color"].Value = ((CogAcqFifoTool)TbFifo.Tools["CogAcqFifoTool2"]).OutputImage;
                this_Prod.TB.Inputs["InputImage"].Value = ((CogAcqFifoTool)TbFifo.Tools["CogAcqFifoTool2"]).OutputImage;
                RecogTB.Inputs["InputImage"].Value = ((CogAcqFifoTool)TbFifo.Tools["CogAcqFifoTool2"]).OutputImage;

                RecogTB.Run();

                ////Check Result
                //CheckTB.Inputs["InputImage"].Value = RecogTB.Outputs["OutputImage"].Value;
                //CogPMAlignResults Results = (CogPMAlignResults)RecogTB.Outputs["Results"].Value;
                //if (Results != null && Results.Count != 0)
                //{
                //    CheckTB.Inputs["PMAResult"].Value = Results[0].GetPose();
                //    CheckTB.Run();
                //}

                //if (PMA.Results != null)
                //    if (PMA.Results.Count != 0)
                //    {
                //        CheckTB.Run();
                //    }
            }

            btTrainingTest.Enabled = true;
        }
        private void btTrainingOK_Click(object sender, EventArgs e)
        {
            if (!PMA.Pattern.Trained)
            {
                MessageBox.Show(Mes.MesList[30].Text, Mes.MesList[30].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PMA.SearchRegion = null;
            this_Prod.Name = SavePath;
            this_Prod.Save();

            //bool isFound = false;
            //for (int i = 0; i < frmMachine.list_Config_Prod.Count; i++)
            //{
            //    if (frmMachine.list_Config_Prod[i].Name == this_Prod.Name)
            //    {
            //        frmMachine.list_Config_Prod[i] = this_Prod;
            //        isFound = true;
            //        break;
            //    }
            //}
            //if (!isFound)
            //{
            //    try { this_Prod.TB.Dispose(); }
            //    catch { }
            //}
            TrainingDispose();
            DialogResult = DialogResult.OK;
        }
        private void btTrainingCancel_Click(object sender, EventArgs e)
        {
            TrainingDispose();
            DialogResult = DialogResult.Cancel;
        }
        private void TrainingInitialize(string ProductName)
        {
            this_Prod = new Config_Prod();
            this_Prod.Name = ProductName;
            if (Config_Prod.isExist(ProductName)) this_Prod.Load();
            else
            {
                if(!VisionTool.LoadVPP(Application.StartupPath + "\\Config\\DefaultProd.vpp", out this_Prod.TB)) Error.SetErr(130);
            }


            RecogTB = (CogToolBlock)this_Prod.TB.Tools["Recognition"];
            ImgCnv = (CogImageConvertTool)RecogTB.Tools["CogImageConvertTool1"];
            PMA = cogPMAlignEditV21.Subject = (CogPMAlignTool)RecogTB.Tools["CogPMAlignTool1"];
            CheckTB = cogToolBlockEditV21.Subject = (CogToolBlock)this_Prod.TB.Tools["Check"];

            trackBarRed.Value = Convert.ToInt32(ImgCnv.RunParams.IntensityFromWeightedRGBRedWeight * 10);
            trackBarGreen.Value = Convert.ToInt32(ImgCnv.RunParams.IntensityFromWeightedRGBGreenWeight * 10);
            trackBarBlue.Value = Convert.ToInt32(ImgCnv.RunParams.IntensityFromWeightedRGBBlueWeight * 10);

            cogToolBlockEditV22.Subject = this_Prod.TB;

            Acq = (CogAcqFifoTool)TbFifo.Tools["CogAcqFifoTool2"];

        }

        private void TrainingDispose()
        {
            this_Prod = null;
            ImgCnv = null;
            RecogTB = null;
            CheckTB = null;
            PMA = null;
            Acq = null;
            GC.Collect();
        }
        #endregion

    }
}
