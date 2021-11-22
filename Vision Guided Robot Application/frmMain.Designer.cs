using System.Timers;

namespace Vision_Guided_Robot_Application
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.pbSystemAlarm = new System.Windows.Forms.PictureBox();
            this.lbSystemAlarm = new System.Windows.Forms.Label();
            this.pbSystemReady = new System.Windows.Forms.PictureBox();
            this.lbSystemReady = new System.Windows.Forms.Label();
            this.pbSystemOn = new System.Windows.Forms.PictureBox();
            this.lbSystemOn = new System.Windows.Forms.Label();
            this.splcScreen = new System.Windows.Forms.SplitContainer();
            this.splcStatus = new System.Windows.Forms.SplitContainer();
            this.btAbout = new System.Windows.Forms.Button();
            this.gbUser = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbUser = new System.Windows.Forms.Label();
            this.cbbUserID = new System.Windows.Forms.ComboBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btManageUser = new System.Windows.Forms.Button();
            this.btLogIn = new System.Windows.Forms.Button();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.gbModeSwitch = new System.Windows.Forms.GroupBox();
            this.btErrMode = new System.Windows.Forms.Button();
            this.btManualMode = new System.Windows.Forms.Button();
            this.btAutoMode = new System.Windows.Forms.Button();
            this.panel16 = new System.Windows.Forms.Panel();
            this.btReset = new System.Windows.Forms.Button();
            this.btConfig = new System.Windows.Forms.Button();
            this.gbMode = new System.Windows.Forms.GroupBox();
            this.pbErrMode = new System.Windows.Forms.PictureBox();
            this.lbErrorMode = new System.Windows.Forms.Label();
            this.pbManualMode = new System.Windows.Forms.PictureBox();
            this.lbManualMode = new System.Windows.Forms.Label();
            this.pbAutoMode = new System.Windows.Forms.PictureBox();
            this.lbAutoMode = new System.Windows.Forms.Label();
            this.splcMainScreen = new System.Windows.Forms.SplitContainer();
            this.gbMainScreen = new System.Windows.Forms.GroupBox();
            this.tcMainScreen = new System.Windows.Forms.TabControl();
            this.tpAuto = new System.Windows.Forms.TabPage();
            this.splcAuto = new System.Windows.Forms.SplitContainer();
            this.cRD = new Cognex.VisionPro.CogRecordDisplay();
            this.pnCRR = new System.Windows.Forms.Panel();
            this.lbRight = new System.Windows.Forms.Label();
            this.pnCRL = new System.Windows.Forms.Panel();
            this.lbLeft = new System.Windows.Forms.Label();
            this.lbSeparate_R = new System.Windows.Forms.Label();
            this.lbSeparate_L = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.gbPosInfo = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvPosInfo = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClearPosInfo = new System.Windows.Forms.Button();
            this.gbProductionStatus = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbSystemStatus = new System.Windows.Forms.Label();
            this.lbRecog = new System.Windows.Forms.Label();
            this.lbFinished = new System.Windows.Forms.Label();
            this.lbFail = new System.Windows.Forms.Label();
            this.lbConveyorSpeed = new System.Windows.Forms.Label();
            this.lbCT = new System.Windows.Forms.Label();
            this.lbSystemStatusR = new System.Windows.Forms.Label();
            this.lbRecogR = new System.Windows.Forms.Label();
            this.lbFinishedR = new System.Windows.Forms.Label();
            this.lbFailR = new System.Windows.Forms.Label();
            this.lbConveyorSpeedR = new System.Windows.Forms.Label();
            this.lbCTR = new System.Windows.Forms.Label();
            this.gbRun = new System.Windows.Forms.GroupBox();
            this.btTakePicture = new System.Windows.Forms.Button();
            this.btRun = new System.Windows.Forms.Button();
            this.tpManual = new System.Windows.Forms.TabPage();
            this.splcManual_Calib = new System.Windows.Forms.SplitContainer();
            this.splcManual = new System.Windows.Forms.SplitContainer();
            this.gbTestPrint = new System.Windows.Forms.GroupBox();
            this.btTestPrint = new System.Windows.Forms.Button();
            this.gbMoveToPos = new System.Windows.Forms.GroupBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbMoveX = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tbMoveY = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tbMoveR = new System.Windows.Forms.TextBox();
            this.btManualMove = new System.Windows.Forms.Button();
            this.gbPosition = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lbPosX = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lbPosY = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lbPosR = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lbEnc = new System.Windows.Forms.Label();
            this.gbManualMove = new System.Windows.Forms.GroupBox();
            this.btJogNegX = new System.Windows.Forms.Button();
            this.btJogPosX = new System.Windows.Forms.Button();
            this.btJogPosY = new System.Windows.Forms.Button();
            this.btJogNegY = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btJogNegR = new System.Windows.Forms.Button();
            this.btJogPosR = new System.Windows.Forms.Button();
            this.gbHome = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.btJogHomeX = new System.Windows.Forms.Button();
            this.btJogHomeY = new System.Windows.Forms.Button();
            this.btJogHomeR = new System.Windows.Forms.Button();
            this.btJogHome = new System.Windows.Forms.Button();
            this.gbSpeed = new System.Windows.Forms.GroupBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.trackbarJogSpeedY = new System.Windows.Forms.TrackBar();
            this.trackbarJogSpeedX = new System.Windows.Forms.TrackBar();
            this.trackbarJogSpeedR = new System.Windows.Forms.TrackBar();
            this.btSetSpeed = new System.Windows.Forms.Button();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.tbJogSpeedX = new System.Windows.Forms.TextBox();
            this.tbJogSpeedY = new System.Windows.Forms.TextBox();
            this.tbJogSpeedR = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.gbCalibrate = new System.Windows.Forms.GroupBox();
            this.splcCalib = new System.Windows.Forms.SplitContainer();
            this.dgvCalibData = new System.Windows.Forms.DataGridView();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvCalibResult = new System.Windows.Forms.DataGridView();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.pnCalib = new System.Windows.Forms.Panel();
            this.btCalibSave = new System.Windows.Forms.Button();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.btCalib = new System.Windows.Forms.Button();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.btCalibXYRobot = new System.Windows.Forms.Button();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.btCalibCamera = new System.Windows.Forms.Button();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.btCalibEnc = new System.Windows.Forms.Button();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbCalibInitialize = new System.Windows.Forms.TextBox();
            this.lbCalibInitialize = new System.Windows.Forms.Label();
            this.btCalibReset = new System.Windows.Forms.Button();
            this.btCalibInitialize = new System.Windows.Forms.Button();
            this.cogToolBlockEditCalib = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.tpWaiting = new System.Windows.Forms.TabPage();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.splc_Lived_Error = new System.Windows.Forms.SplitContainer();
            this.gbAnimation = new System.Windows.Forms.GroupBox();
            this.pnConveyor = new System.Windows.Forms.Panel();
            this.flpLivedLegend = new System.Windows.Forms.FlowLayoutPanel();
            this.cbLivedRobot = new System.Windows.Forms.CheckBox();
            this.cbLivedObject = new System.Windows.Forms.CheckBox();
            this.cbLivedPrinting = new System.Windows.Forms.CheckBox();
            this.pbXAxis = new System.Windows.Forms.PictureBox();
            this.pbYAxis = new System.Windows.Forms.PictureBox();
            this.gbError = new System.Windows.Forms.GroupBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.dgvError = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClearErr = new System.Windows.Forms.Button();
            this.gbRecipe = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.Column27 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column26 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbCameraRegion = new System.Windows.Forms.PictureBox();
            this.btSaveCameraRegion = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerAuto = new System.Windows.Forms.Timer(this.components);
            this.timerManual = new System.Windows.Forms.Timer(this.components);
            this.gbStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSystemAlarm)).BeginInit();
            this.pbSystemAlarm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSystemReady)).BeginInit();
            this.pbSystemReady.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSystemOn)).BeginInit();
            this.pbSystemOn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcScreen)).BeginInit();
            this.splcScreen.Panel1.SuspendLayout();
            this.splcScreen.Panel2.SuspendLayout();
            this.splcScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcStatus)).BeginInit();
            this.splcStatus.Panel1.SuspendLayout();
            this.splcStatus.Panel2.SuspendLayout();
            this.splcStatus.SuspendLayout();
            this.gbUser.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            this.gbModeSwitch.SuspendLayout();
            this.panel16.SuspendLayout();
            this.gbMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbErrMode)).BeginInit();
            this.pbErrMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbManualMode)).BeginInit();
            this.pbManualMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoMode)).BeginInit();
            this.pbAutoMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcMainScreen)).BeginInit();
            this.splcMainScreen.Panel1.SuspendLayout();
            this.splcMainScreen.Panel2.SuspendLayout();
            this.splcMainScreen.SuspendLayout();
            this.gbMainScreen.SuspendLayout();
            this.tcMainScreen.SuspendLayout();
            this.tpAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcAuto)).BeginInit();
            this.splcAuto.Panel1.SuspendLayout();
            this.splcAuto.Panel2.SuspendLayout();
            this.splcAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRD)).BeginInit();
            this.cRD.SuspendLayout();
            this.pnCRR.SuspendLayout();
            this.pnCRL.SuspendLayout();
            this.panel8.SuspendLayout();
            this.gbPosInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosInfo)).BeginInit();
            this.gbProductionStatus.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbRun.SuspendLayout();
            this.tpManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcManual_Calib)).BeginInit();
            this.splcManual_Calib.Panel1.SuspendLayout();
            this.splcManual_Calib.Panel2.SuspendLayout();
            this.splcManual_Calib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcManual)).BeginInit();
            this.splcManual.Panel1.SuspendLayout();
            this.splcManual.Panel2.SuspendLayout();
            this.splcManual.SuspendLayout();
            this.gbTestPrint.SuspendLayout();
            this.gbMoveToPos.SuspendLayout();
            this.panel14.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.gbPosition.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.gbManualMove.SuspendLayout();
            this.panel15.SuspendLayout();
            this.gbHome.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.gbSpeed.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarJogSpeedY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarJogSpeedX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarJogSpeedR)).BeginInit();
            this.flowLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel10.SuspendLayout();
            this.gbCalibrate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splcCalib)).BeginInit();
            this.splcCalib.Panel1.SuspendLayout();
            this.splcCalib.Panel2.SuspendLayout();
            this.splcCalib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibResult)).BeginInit();
            this.pnCalib.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditCalib)).BeginInit();
            this.tpWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splc_Lived_Error)).BeginInit();
            this.splc_Lived_Error.Panel1.SuspendLayout();
            this.splc_Lived_Error.Panel2.SuspendLayout();
            this.splc_Lived_Error.SuspendLayout();
            this.gbAnimation.SuspendLayout();
            this.pnConveyor.SuspendLayout();
            this.flpLivedLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYAxis)).BeginInit();
            this.gbError.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).BeginInit();
            this.gbRecipe.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraRegion)).BeginInit();
            this.pbCameraRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerMain
            // 
            this.timerMain.Enabled = true;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.pbSystemAlarm);
            this.gbStatus.Controls.Add(this.pbSystemReady);
            this.gbStatus.Controls.Add(this.pbSystemOn);
            this.gbStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStatus.Location = new System.Drawing.Point(0, 0);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(293, 208);
            this.gbStatus.TabIndex = 0;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "SYSTEM STATUS";
            // 
            // pbSystemAlarm
            // 
            this.pbSystemAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSystemAlarm.Controls.Add(this.lbSystemAlarm);
            this.pbSystemAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSystemAlarm.Image = global::Vision_Guided_Robot_Application.Properties.Resources.BLACKLIGHT;
            this.pbSystemAlarm.InitialImage = null;
            this.pbSystemAlarm.Location = new System.Drawing.Point(3, 147);
            this.pbSystemAlarm.Name = "pbSystemAlarm";
            this.pbSystemAlarm.Size = new System.Drawing.Size(287, 60);
            this.pbSystemAlarm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSystemAlarm.TabIndex = 20;
            this.pbSystemAlarm.TabStop = false;
            this.pbSystemAlarm.Tag = "3";
            // 
            // lbSystemAlarm
            // 
            this.lbSystemAlarm.BackColor = System.Drawing.Color.Transparent;
            this.lbSystemAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSystemAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbSystemAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSystemAlarm.ForeColor = System.Drawing.Color.White;
            this.lbSystemAlarm.Location = new System.Drawing.Point(0, 0);
            this.lbSystemAlarm.Name = "lbSystemAlarm";
            this.lbSystemAlarm.Size = new System.Drawing.Size(287, 60);
            this.lbSystemAlarm.TabIndex = 2;
            this.lbSystemAlarm.Text = "SYSTEM ALARM";
            this.lbSystemAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSystemReady
            // 
            this.pbSystemReady.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSystemReady.Controls.Add(this.lbSystemReady);
            this.pbSystemReady.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSystemReady.Image = global::Vision_Guided_Robot_Application.Properties.Resources.BLACKLIGHT;
            this.pbSystemReady.Location = new System.Drawing.Point(3, 87);
            this.pbSystemReady.Name = "pbSystemReady";
            this.pbSystemReady.Size = new System.Drawing.Size(287, 60);
            this.pbSystemReady.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSystemReady.TabIndex = 19;
            this.pbSystemReady.TabStop = false;
            this.pbSystemReady.Tag = "1";
            // 
            // lbSystemReady
            // 
            this.lbSystemReady.BackColor = System.Drawing.Color.Transparent;
            this.lbSystemReady.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSystemReady.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbSystemReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSystemReady.ForeColor = System.Drawing.Color.White;
            this.lbSystemReady.Location = new System.Drawing.Point(0, 0);
            this.lbSystemReady.Name = "lbSystemReady";
            this.lbSystemReady.Size = new System.Drawing.Size(287, 60);
            this.lbSystemReady.TabIndex = 1;
            this.lbSystemReady.Text = "SYSTEM READY";
            this.lbSystemReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbSystemOn
            // 
            this.pbSystemOn.BackColor = System.Drawing.Color.Transparent;
            this.pbSystemOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbSystemOn.Controls.Add(this.lbSystemOn);
            this.pbSystemOn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbSystemOn.Image = global::Vision_Guided_Robot_Application.Properties.Resources.BLACKLIGHT;
            this.pbSystemOn.Location = new System.Drawing.Point(3, 27);
            this.pbSystemOn.Name = "pbSystemOn";
            this.pbSystemOn.Size = new System.Drawing.Size(287, 60);
            this.pbSystemOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSystemOn.TabIndex = 15;
            this.pbSystemOn.TabStop = false;
            this.pbSystemOn.Tag = "0";
            // 
            // lbSystemOn
            // 
            this.lbSystemOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSystemOn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbSystemOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSystemOn.ForeColor = System.Drawing.Color.White;
            this.lbSystemOn.Location = new System.Drawing.Point(0, 0);
            this.lbSystemOn.Name = "lbSystemOn";
            this.lbSystemOn.Size = new System.Drawing.Size(287, 60);
            this.lbSystemOn.TabIndex = 18;
            this.lbSystemOn.Text = "SYSTEM ON";
            this.lbSystemOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splcScreen
            // 
            this.splcScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcScreen.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splcScreen.IsSplitterFixed = true;
            this.splcScreen.Location = new System.Drawing.Point(0, 0);
            this.splcScreen.Name = "splcScreen";
            // 
            // splcScreen.Panel1
            // 
            this.splcScreen.Panel1.Controls.Add(this.splcStatus);
            // 
            // splcScreen.Panel2
            // 
            this.splcScreen.Panel2.Controls.Add(this.splcMainScreen);
            this.splcScreen.Size = new System.Drawing.Size(1584, 962);
            this.splcScreen.SplitterDistance = 293;
            this.splcScreen.TabIndex = 9;
            // 
            // splcStatus
            // 
            this.splcStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcStatus.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splcStatus.Location = new System.Drawing.Point(0, 0);
            this.splcStatus.Name = "splcStatus";
            this.splcStatus.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcStatus.Panel1
            // 
            this.splcStatus.Panel1.Controls.Add(this.btAbout);
            this.splcStatus.Panel1.Controls.Add(this.gbUser);
            this.splcStatus.Panel1.Controls.Add(this.pictureBox17);
            // 
            // splcStatus.Panel2
            // 
            this.splcStatus.Panel2.Controls.Add(this.gbModeSwitch);
            this.splcStatus.Panel2.Controls.Add(this.panel16);
            this.splcStatus.Panel2.Controls.Add(this.gbMode);
            this.splcStatus.Panel2.Controls.Add(this.gbStatus);
            this.splcStatus.Size = new System.Drawing.Size(293, 962);
            this.splcStatus.SplitterDistance = 239;
            this.splcStatus.TabIndex = 0;
            // 
            // btAbout
            // 
            this.btAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAbout.Location = new System.Drawing.Point(206, 52);
            this.btAbout.Name = "btAbout";
            this.btAbout.Size = new System.Drawing.Size(84, 30);
            this.btAbout.TabIndex = 1;
            this.btAbout.Text = "About";
            this.btAbout.UseVisualStyleBackColor = true;
            this.btAbout.Click += new System.EventHandler(this.btAbout_Click);
            // 
            // gbUser
            // 
            this.gbUser.Controls.Add(this.flowLayoutPanel4);
            this.gbUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbUser.Location = new System.Drawing.Point(0, 84);
            this.gbUser.Name = "gbUser";
            this.gbUser.Size = new System.Drawing.Size(293, 155);
            this.gbUser.TabIndex = 0;
            this.gbUser.TabStop = false;
            this.gbUser.Text = "USER";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.lbUser);
            this.flowLayoutPanel4.Controls.Add(this.cbbUserID);
            this.flowLayoutPanel4.Controls.Add(this.lbPassword);
            this.flowLayoutPanel4.Controls.Add(this.tbPassword);
            this.flowLayoutPanel4.Controls.Add(this.panel11);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(287, 125);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // lbUser
            // 
            this.lbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(3, 0);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(98, 30);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "Users:";
            this.lbUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbUserID
            // 
            this.cbbUserID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUserID.FormattingEnabled = true;
            this.cbbUserID.Location = new System.Drawing.Point(107, 3);
            this.cbbUserID.Name = "cbbUserID";
            this.cbbUserID.Size = new System.Drawing.Size(174, 28);
            this.cbbUserID.TabIndex = 2;
            // 
            // lbPassword
            // 
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(3, 34);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(98, 30);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.Text = "Password:";
            this.lbPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(107, 37);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(174, 26);
            this.tbPassword.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btManageUser);
            this.panel11.Controls.Add(this.btLogIn);
            this.panel11.Location = new System.Drawing.Point(3, 69);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(276, 54);
            this.panel11.TabIndex = 4;
            // 
            // btManageUser
            // 
            this.btManageUser.BackColor = System.Drawing.Color.Transparent;
            this.btManageUser.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.user;
            this.btManageUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btManageUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btManageUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btManageUser.Location = new System.Drawing.Point(0, 0);
            this.btManageUser.Name = "btManageUser";
            this.btManageUser.Size = new System.Drawing.Size(184, 54);
            this.btManageUser.TabIndex = 4;
            this.btManageUser.Text = "Manage Users";
            this.btManageUser.UseVisualStyleBackColor = false;
            this.btManageUser.Visible = false;
            this.btManageUser.Click += new System.EventHandler(this.btManageUser_Click);
            // 
            // btLogIn
            // 
            this.btLogIn.BackColor = System.Drawing.Color.Transparent;
            this.btLogIn.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Lock;
            this.btLogIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btLogIn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLogIn.Location = new System.Drawing.Point(184, 0);
            this.btLogIn.Name = "btLogIn";
            this.btLogIn.Size = new System.Drawing.Size(92, 54);
            this.btLogIn.TabIndex = 5;
            this.btLogIn.UseVisualStyleBackColor = false;
            this.btLogIn.Click += new System.EventHandler(this.btLogIn_Click);
            // 
            // pictureBox17
            // 
            this.pictureBox17.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox17.Image = global::Vision_Guided_Robot_Application.Properties.Resources.RDLogo;
            this.pictureBox17.Location = new System.Drawing.Point(0, 0);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(293, 84);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox17.TabIndex = 0;
            this.pictureBox17.TabStop = false;
            // 
            // gbModeSwitch
            // 
            this.gbModeSwitch.Controls.Add(this.btErrMode);
            this.gbModeSwitch.Controls.Add(this.btManualMode);
            this.gbModeSwitch.Controls.Add(this.btAutoMode);
            this.gbModeSwitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbModeSwitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbModeSwitch.Location = new System.Drawing.Point(0, 424);
            this.gbModeSwitch.Name = "gbModeSwitch";
            this.gbModeSwitch.Size = new System.Drawing.Size(293, 210);
            this.gbModeSwitch.TabIndex = 6;
            this.gbModeSwitch.TabStop = false;
            this.gbModeSwitch.Text = "MODE SWITCH";
            // 
            // btErrMode
            // 
            this.btErrMode.BackColor = System.Drawing.Color.Transparent;
            this.btErrMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btErrMode.BackgroundImage")));
            this.btErrMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btErrMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btErrMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btErrMode.ForeColor = System.Drawing.Color.Black;
            this.btErrMode.Location = new System.Drawing.Point(3, 147);
            this.btErrMode.Name = "btErrMode";
            this.btErrMode.Size = new System.Drawing.Size(287, 60);
            this.btErrMode.TabIndex = 2;
            this.btErrMode.Tag = "8203";
            this.btErrMode.Text = "ACKNOLEDGE MODE";
            this.btErrMode.UseVisualStyleBackColor = false;
            this.btErrMode.Click += new System.EventHandler(this.btErrMode_Click);
            // 
            // btManualMode
            // 
            this.btManualMode.BackColor = System.Drawing.Color.Transparent;
            this.btManualMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btManualMode.BackgroundImage")));
            this.btManualMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btManualMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btManualMode.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.btManualMode.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.btManualMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btManualMode.ForeColor = System.Drawing.Color.Black;
            this.btManualMode.Location = new System.Drawing.Point(3, 87);
            this.btManualMode.Name = "btManualMode";
            this.btManualMode.Size = new System.Drawing.Size(287, 60);
            this.btManualMode.TabIndex = 1;
            this.btManualMode.Tag = "8197";
            this.btManualMode.Text = "MANUAL MODE";
            this.btManualMode.UseVisualStyleBackColor = false;
            this.btManualMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_Mode_MouseDown);
            this.btManualMode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_Mode_MouseUp);
            // 
            // btAutoMode
            // 
            this.btAutoMode.BackColor = System.Drawing.Color.Transparent;
            this.btAutoMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btAutoMode.BackgroundImage")));
            this.btAutoMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btAutoMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.btAutoMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAutoMode.ForeColor = System.Drawing.Color.Black;
            this.btAutoMode.Location = new System.Drawing.Point(3, 27);
            this.btAutoMode.Name = "btAutoMode";
            this.btAutoMode.Size = new System.Drawing.Size(287, 60);
            this.btAutoMode.TabIndex = 0;
            this.btAutoMode.Tag = "8196";
            this.btAutoMode.Text = "AUTO MODE";
            this.btAutoMode.UseVisualStyleBackColor = false;
            this.btAutoMode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bt_Mode_MouseDown);
            this.btAutoMode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_Mode_MouseUp);
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.btReset);
            this.panel16.Controls.Add(this.btConfig);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel16.Location = new System.Drawing.Point(0, 643);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(293, 76);
            this.panel16.TabIndex = 5;
            // 
            // btReset
            // 
            this.btReset.BackColor = System.Drawing.Color.Transparent;
            this.btReset.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.BtResetOff;
            this.btReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btReset.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btReset.ForeColor = System.Drawing.Color.Black;
            this.btReset.Location = new System.Drawing.Point(207, 0);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(86, 76);
            this.btReset.TabIndex = 9;
            this.btReset.Text = "RESET";
            this.btReset.UseVisualStyleBackColor = false;
            this.btReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btReset_MouseDown);
            this.btReset.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btReset_MouseUp);
            // 
            // btConfig
            // 
            this.btConfig.BackColor = System.Drawing.Color.Transparent;
            this.btConfig.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Setting;
            this.btConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.btConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfig.ForeColor = System.Drawing.Color.White;
            this.btConfig.Location = new System.Drawing.Point(0, 0);
            this.btConfig.Name = "btConfig";
            this.btConfig.Size = new System.Drawing.Size(207, 76);
            this.btConfig.TabIndex = 8;
            this.btConfig.Text = "         SETTINGS";
            this.btConfig.UseVisualStyleBackColor = false;
            this.btConfig.Click += new System.EventHandler(this.btConfig_Click);
            // 
            // gbMode
            // 
            this.gbMode.Controls.Add(this.pbErrMode);
            this.gbMode.Controls.Add(this.pbManualMode);
            this.gbMode.Controls.Add(this.pbAutoMode);
            this.gbMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMode.Location = new System.Drawing.Point(0, 208);
            this.gbMode.Name = "gbMode";
            this.gbMode.Size = new System.Drawing.Size(293, 216);
            this.gbMode.TabIndex = 3;
            this.gbMode.TabStop = false;
            this.gbMode.Text = "MODE STATUS";
            // 
            // pbErrMode
            // 
            this.pbErrMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbErrMode.BackgroundImage")));
            this.pbErrMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbErrMode.Controls.Add(this.lbErrorMode);
            this.pbErrMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbErrMode.Image = ((System.Drawing.Image)(resources.GetObject("pbErrMode.Image")));
            this.pbErrMode.Location = new System.Drawing.Point(3, 147);
            this.pbErrMode.Name = "pbErrMode";
            this.pbErrMode.Size = new System.Drawing.Size(287, 60);
            this.pbErrMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbErrMode.TabIndex = 11;
            this.pbErrMode.TabStop = false;
            this.pbErrMode.Tag = "11";
            // 
            // lbErrorMode
            // 
            this.lbErrorMode.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbErrorMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbErrorMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorMode.ForeColor = System.Drawing.Color.White;
            this.lbErrorMode.Location = new System.Drawing.Point(0, 0);
            this.lbErrorMode.Name = "lbErrorMode";
            this.lbErrorMode.Size = new System.Drawing.Size(287, 60);
            this.lbErrorMode.TabIndex = 13;
            this.lbErrorMode.Text = "ACKNOWLEDGE MODE";
            this.lbErrorMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbManualMode
            // 
            this.pbManualMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbManualMode.BackgroundImage")));
            this.pbManualMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbManualMode.Controls.Add(this.lbManualMode);
            this.pbManualMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbManualMode.Image = ((System.Drawing.Image)(resources.GetObject("pbManualMode.Image")));
            this.pbManualMode.Location = new System.Drawing.Point(3, 87);
            this.pbManualMode.Name = "pbManualMode";
            this.pbManualMode.Size = new System.Drawing.Size(287, 60);
            this.pbManualMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbManualMode.TabIndex = 10;
            this.pbManualMode.TabStop = false;
            this.pbManualMode.Tag = "7";
            // 
            // lbManualMode
            // 
            this.lbManualMode.BackColor = System.Drawing.Color.Transparent;
            this.lbManualMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbManualMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbManualMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManualMode.ForeColor = System.Drawing.Color.White;
            this.lbManualMode.Location = new System.Drawing.Point(0, 0);
            this.lbManualMode.Name = "lbManualMode";
            this.lbManualMode.Size = new System.Drawing.Size(287, 60);
            this.lbManualMode.TabIndex = 12;
            this.lbManualMode.Text = "MANUAL MODE";
            this.lbManualMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbAutoMode
            // 
            this.pbAutoMode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbAutoMode.BackgroundImage")));
            this.pbAutoMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAutoMode.Controls.Add(this.lbAutoMode);
            this.pbAutoMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbAutoMode.Image = ((System.Drawing.Image)(resources.GetObject("pbAutoMode.Image")));
            this.pbAutoMode.Location = new System.Drawing.Point(3, 27);
            this.pbAutoMode.Name = "pbAutoMode";
            this.pbAutoMode.Size = new System.Drawing.Size(287, 60);
            this.pbAutoMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAutoMode.TabIndex = 7;
            this.pbAutoMode.TabStop = false;
            this.pbAutoMode.Tag = "6";
            // 
            // lbAutoMode
            // 
            this.lbAutoMode.BackColor = System.Drawing.Color.Transparent;
            this.lbAutoMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAutoMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbAutoMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAutoMode.ForeColor = System.Drawing.Color.White;
            this.lbAutoMode.Location = new System.Drawing.Point(0, 0);
            this.lbAutoMode.Name = "lbAutoMode";
            this.lbAutoMode.Size = new System.Drawing.Size(287, 60);
            this.lbAutoMode.TabIndex = 11;
            this.lbAutoMode.Text = "AUTO MODE";
            this.lbAutoMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splcMainScreen
            // 
            this.splcMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcMainScreen.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splcMainScreen.IsSplitterFixed = true;
            this.splcMainScreen.Location = new System.Drawing.Point(0, 0);
            this.splcMainScreen.Name = "splcMainScreen";
            // 
            // splcMainScreen.Panel1
            // 
            this.splcMainScreen.Panel1.Controls.Add(this.gbMainScreen);
            // 
            // splcMainScreen.Panel2
            // 
            this.splcMainScreen.Panel2.Controls.Add(this.splc_Lived_Error);
            this.splcMainScreen.Panel2.Controls.Add(this.gbRecipe);
            this.splcMainScreen.Size = new System.Drawing.Size(1287, 962);
            this.splcMainScreen.SplitterDistance = 887;
            this.splcMainScreen.TabIndex = 6;
            // 
            // gbMainScreen
            // 
            this.gbMainScreen.Controls.Add(this.tcMainScreen);
            this.gbMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMainScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMainScreen.Location = new System.Drawing.Point(0, 0);
            this.gbMainScreen.Name = "gbMainScreen";
            this.gbMainScreen.Size = new System.Drawing.Size(887, 962);
            this.gbMainScreen.TabIndex = 1;
            this.gbMainScreen.TabStop = false;
            this.gbMainScreen.Text = "MAIN SCREEN";
            // 
            // tcMainScreen
            // 
            this.tcMainScreen.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcMainScreen.Controls.Add(this.tpAuto);
            this.tcMainScreen.Controls.Add(this.tpManual);
            this.tcMainScreen.Controls.Add(this.tpWaiting);
            this.tcMainScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMainScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMainScreen.ItemSize = new System.Drawing.Size(30, 30);
            this.tcMainScreen.Location = new System.Drawing.Point(3, 27);
            this.tcMainScreen.Name = "tcMainScreen";
            this.tcMainScreen.SelectedIndex = 0;
            this.tcMainScreen.Size = new System.Drawing.Size(881, 932);
            this.tcMainScreen.TabIndex = 0;
            // 
            // tpAuto
            // 
            this.tpAuto.BackColor = System.Drawing.Color.White;
            this.tpAuto.Controls.Add(this.splcAuto);
            this.tpAuto.Location = new System.Drawing.Point(4, 34);
            this.tpAuto.Name = "tpAuto";
            this.tpAuto.Padding = new System.Windows.Forms.Padding(3);
            this.tpAuto.Size = new System.Drawing.Size(873, 894);
            this.tpAuto.TabIndex = 0;
            this.tpAuto.Text = "AUTO";
            // 
            // splcAuto
            // 
            this.splcAuto.BackColor = System.Drawing.Color.Transparent;
            this.splcAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcAuto.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splcAuto.IsSplitterFixed = true;
            this.splcAuto.Location = new System.Drawing.Point(3, 3);
            this.splcAuto.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.splcAuto.Name = "splcAuto";
            this.splcAuto.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcAuto.Panel1
            // 
            this.splcAuto.Panel1.Controls.Add(this.cRD);
            // 
            // splcAuto.Panel2
            // 
            this.splcAuto.Panel2.Controls.Add(this.panel8);
            this.splcAuto.Panel2.Controls.Add(this.gbProductionStatus);
            this.splcAuto.Panel2.Controls.Add(this.gbRun);
            this.splcAuto.Size = new System.Drawing.Size(867, 888);
            this.splcAuto.SplitterDistance = 534;
            this.splcAuto.TabIndex = 0;
            // 
            // cRD
            // 
            this.cRD.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cRD.ColorMapLowerRoiLimit = 0D;
            this.cRD.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cRD.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cRD.ColorMapUpperRoiLimit = 1D;
            this.cRD.Controls.Add(this.pnCRR);
            this.cRD.Controls.Add(this.pnCRL);
            this.cRD.Controls.Add(this.lbSeparate_R);
            this.cRD.Controls.Add(this.lbSeparate_L);
            this.cRD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cRD.DoubleTapZoomCycleLength = 2;
            this.cRD.DoubleTapZoomSensitivity = 2.5D;
            this.cRD.Location = new System.Drawing.Point(0, 0);
            this.cRD.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cRD.MouseWheelSensitivity = 1D;
            this.cRD.Name = "cRD";
            this.cRD.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cRD.OcxState")));
            this.cRD.Size = new System.Drawing.Size(867, 534);
            this.cRD.TabIndex = 2;
            // 
            // pnCRR
            // 
            this.pnCRR.Controls.Add(this.lbRight);
            this.pnCRR.Location = new System.Drawing.Point(550, 4);
            this.pnCRR.Name = "pnCRR";
            this.pnCRR.Size = new System.Drawing.Size(150, 26);
            this.pnCRR.TabIndex = 33;
            // 
            // lbRight
            // 
            this.lbRight.BackColor = System.Drawing.Color.White;
            this.lbRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRight.ForeColor = System.Drawing.Color.Red;
            this.lbRight.Location = new System.Drawing.Point(0, 0);
            this.lbRight.Name = "lbRight";
            this.lbRight.Size = new System.Drawing.Size(150, 26);
            this.lbRight.TabIndex = 37;
            this.lbRight.Text = "L - RIGHT";
            this.lbRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCRL
            // 
            this.pnCRL.Controls.Add(this.lbLeft);
            this.pnCRL.Location = new System.Drawing.Point(125, 4);
            this.pnCRL.Name = "pnCRL";
            this.pnCRL.Size = new System.Drawing.Size(150, 26);
            this.pnCRL.TabIndex = 2;
            // 
            // lbLeft
            // 
            this.lbLeft.BackColor = System.Drawing.Color.White;
            this.lbLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLeft.ForeColor = System.Drawing.Color.Green;
            this.lbLeft.Location = new System.Drawing.Point(0, 0);
            this.lbLeft.Name = "lbLeft";
            this.lbLeft.Size = new System.Drawing.Size(150, 26);
            this.lbLeft.TabIndex = 36;
            this.lbLeft.Text = "L - LEFT";
            this.lbLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSeparate_R
            // 
            this.lbSeparate_R.BackColor = System.Drawing.Color.Red;
            this.lbSeparate_R.Location = new System.Drawing.Point(101, 35);
            this.lbSeparate_R.Name = "lbSeparate_R";
            this.lbSeparate_R.Size = new System.Drawing.Size(2, 603);
            this.lbSeparate_R.TabIndex = 3;
            this.lbSeparate_R.Text = "label8";
            // 
            // lbSeparate_L
            // 
            this.lbSeparate_L.BackColor = System.Drawing.Color.Green;
            this.lbSeparate_L.Location = new System.Drawing.Point(444, 0);
            this.lbSeparate_L.Name = "lbSeparate_L";
            this.lbSeparate_L.Size = new System.Drawing.Size(2, 603);
            this.lbSeparate_L.TabIndex = 1;
            this.lbSeparate_L.Text = "label8";
            // 
            // panel8
            // 
            this.panel8.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Logo;
            this.panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel8.Controls.Add(this.gbPosInfo);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(147, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(293, 350);
            this.panel8.TabIndex = 3;
            // 
            // gbPosInfo
            // 
            this.gbPosInfo.Controls.Add(this.panel2);
            this.gbPosInfo.Controls.Add(this.btClearPosInfo);
            this.gbPosInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbPosInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPosInfo.Location = new System.Drawing.Point(0, 0);
            this.gbPosInfo.Name = "gbPosInfo";
            this.gbPosInfo.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.gbPosInfo.Size = new System.Drawing.Size(293, 350);
            this.gbPosInfo.TabIndex = 2;
            this.gbPosInfo.TabStop = false;
            this.gbPosInfo.Text = "POS INFO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 287);
            this.panel2.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvPosInfo);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(287, 287);
            this.panel6.TabIndex = 0;
            // 
            // dgvPosInfo
            // 
            this.dgvPosInfo.AllowUserToAddRows = false;
            this.dgvPosInfo.AllowUserToDeleteRows = false;
            this.dgvPosInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPosInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvPosInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPosInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column11});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPosInfo.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvPosInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPosInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvPosInfo.Name = "dgvPosInfo";
            this.dgvPosInfo.ReadOnly = true;
            this.dgvPosInfo.RowHeadersVisible = false;
            this.dgvPosInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPosInfo.RowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvPosInfo.Size = new System.Drawing.Size(287, 287);
            this.dgvPosInfo.TabIndex = 1;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 60.19688F;
            this.Column3.HeaderText = "No.";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.FillWeight = 84.59891F;
            this.Column4.HeaderText = "Index";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle12;
            this.Column5.FillWeight = 110.8105F;
            this.Column5.HeaderText = "X";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column6.FillWeight = 106.599F;
            this.Column6.HeaderText = "Y";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle14;
            this.Column7.FillWeight = 121.8458F;
            this.Column7.HeaderText = "R";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column11
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle15;
            this.Column11.FillWeight = 115.949F;
            this.Column11.HeaderText = "Enc";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // btClearPosInfo
            // 
            this.btClearPosInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btClearPosInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClearPosInfo.Location = new System.Drawing.Point(3, 314);
            this.btClearPosInfo.Name = "btClearPosInfo";
            this.btClearPosInfo.Size = new System.Drawing.Size(287, 36);
            this.btClearPosInfo.TabIndex = 0;
            this.btClearPosInfo.Text = "Clear Pos Info";
            this.btClearPosInfo.UseVisualStyleBackColor = true;
            this.btClearPosInfo.Click += new System.EventHandler(this.btClearPosInfo_Click);
            // 
            // gbProductionStatus
            // 
            this.gbProductionStatus.Controls.Add(this.flowLayoutPanel1);
            this.gbProductionStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbProductionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProductionStatus.Location = new System.Drawing.Point(440, 0);
            this.gbProductionStatus.Name = "gbProductionStatus";
            this.gbProductionStatus.Size = new System.Drawing.Size(427, 350);
            this.gbProductionStatus.TabIndex = 2;
            this.gbProductionStatus.TabStop = false;
            this.gbProductionStatus.Text = "PRODUCTION STATUS";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lbSystemStatus);
            this.flowLayoutPanel1.Controls.Add(this.lbRecog);
            this.flowLayoutPanel1.Controls.Add(this.lbFinished);
            this.flowLayoutPanel1.Controls.Add(this.lbFail);
            this.flowLayoutPanel1.Controls.Add(this.lbConveyorSpeed);
            this.flowLayoutPanel1.Controls.Add(this.lbCT);
            this.flowLayoutPanel1.Controls.Add(this.lbSystemStatusR);
            this.flowLayoutPanel1.Controls.Add(this.lbRecogR);
            this.flowLayoutPanel1.Controls.Add(this.lbFinishedR);
            this.flowLayoutPanel1.Controls.Add(this.lbFailR);
            this.flowLayoutPanel1.Controls.Add(this.lbConveyorSpeedR);
            this.flowLayoutPanel1.Controls.Add(this.lbCTR);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(421, 320);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lbSystemStatus
            // 
            this.lbSystemStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSystemStatus.Location = new System.Drawing.Point(3, 0);
            this.lbSystemStatus.Name = "lbSystemStatus";
            this.lbSystemStatus.Size = new System.Drawing.Size(180, 53);
            this.lbSystemStatus.TabIndex = 0;
            this.lbSystemStatus.Text = "System Status";
            this.lbSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbRecog
            // 
            this.lbRecog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRecog.Location = new System.Drawing.Point(3, 53);
            this.lbRecog.Name = "lbRecog";
            this.lbRecog.Size = new System.Drawing.Size(180, 53);
            this.lbRecog.TabIndex = 2;
            this.lbRecog.Text = "Recognition (pcs)";
            this.lbRecog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFinished
            // 
            this.lbFinished.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbFinished.Location = new System.Drawing.Point(3, 106);
            this.lbFinished.Name = "lbFinished";
            this.lbFinished.Size = new System.Drawing.Size(180, 53);
            this.lbFinished.TabIndex = 3;
            this.lbFinished.Text = "Finished (pcs)";
            this.lbFinished.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFail
            // 
            this.lbFail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbFail.Location = new System.Drawing.Point(3, 159);
            this.lbFail.Name = "lbFail";
            this.lbFail.Size = new System.Drawing.Size(180, 53);
            this.lbFail.TabIndex = 4;
            this.lbFail.Text = "Failed (pcs)";
            this.lbFail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbConveyorSpeed
            // 
            this.lbConveyorSpeed.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbConveyorSpeed.Location = new System.Drawing.Point(3, 212);
            this.lbConveyorSpeed.Name = "lbConveyorSpeed";
            this.lbConveyorSpeed.Size = new System.Drawing.Size(180, 53);
            this.lbConveyorSpeed.TabIndex = 6;
            this.lbConveyorSpeed.Text = "Conveyor Speed (mm/s)";
            this.lbConveyorSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCT
            // 
            this.lbCT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCT.Location = new System.Drawing.Point(3, 265);
            this.lbCT.Name = "lbCT";
            this.lbCT.Size = new System.Drawing.Size(180, 53);
            this.lbCT.TabIndex = 7;
            this.lbCT.Text = "CT (ms/frame)";
            this.lbCT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSystemStatusR
            // 
            this.lbSystemStatusR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSystemStatusR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSystemStatusR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbSystemStatusR.Location = new System.Drawing.Point(189, 0);
            this.lbSystemStatusR.Name = "lbSystemStatusR";
            this.lbSystemStatusR.Size = new System.Drawing.Size(229, 53);
            this.lbSystemStatusR.TabIndex = 8;
            this.lbSystemStatusR.Text = "Ready for Auto Mode";
            this.lbSystemStatusR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRecogR
            // 
            this.lbRecogR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbRecogR.Location = new System.Drawing.Point(189, 53);
            this.lbRecogR.Name = "lbRecogR";
            this.lbRecogR.Size = new System.Drawing.Size(229, 53);
            this.lbRecogR.TabIndex = 10;
            this.lbRecogR.Text = "0";
            this.lbRecogR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFinishedR
            // 
            this.lbFinishedR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbFinishedR.Location = new System.Drawing.Point(189, 106);
            this.lbFinishedR.Name = "lbFinishedR";
            this.lbFinishedR.Size = new System.Drawing.Size(229, 53);
            this.lbFinishedR.TabIndex = 11;
            this.lbFinishedR.Text = "0";
            this.lbFinishedR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFailR
            // 
            this.lbFailR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbFailR.Location = new System.Drawing.Point(189, 159);
            this.lbFailR.Name = "lbFailR";
            this.lbFailR.Size = new System.Drawing.Size(229, 53);
            this.lbFailR.TabIndex = 12;
            this.lbFailR.Text = "0";
            this.lbFailR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbConveyorSpeedR
            // 
            this.lbConveyorSpeedR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbConveyorSpeedR.Location = new System.Drawing.Point(189, 212);
            this.lbConveyorSpeedR.Name = "lbConveyorSpeedR";
            this.lbConveyorSpeedR.Size = new System.Drawing.Size(229, 53);
            this.lbConveyorSpeedR.TabIndex = 14;
            this.lbConveyorSpeedR.Text = "0";
            this.lbConveyorSpeedR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCTR
            // 
            this.lbCTR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbCTR.Location = new System.Drawing.Point(189, 265);
            this.lbCTR.Name = "lbCTR";
            this.lbCTR.Size = new System.Drawing.Size(229, 53);
            this.lbCTR.TabIndex = 15;
            this.lbCTR.Text = "0";
            this.lbCTR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbRun
            // 
            this.gbRun.Controls.Add(this.btTakePicture);
            this.gbRun.Controls.Add(this.btRun);
            this.gbRun.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRun.Location = new System.Drawing.Point(0, 0);
            this.gbRun.Name = "gbRun";
            this.gbRun.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.gbRun.Size = new System.Drawing.Size(147, 350);
            this.gbRun.TabIndex = 0;
            this.gbRun.TabStop = false;
            this.gbRun.Text = "RUN";
            // 
            // btTakePicture
            // 
            this.btTakePicture.BackColor = System.Drawing.Color.Transparent;
            this.btTakePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btTakePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTakePicture.Location = new System.Drawing.Point(10, 314);
            this.btTakePicture.Name = "btTakePicture";
            this.btTakePicture.Size = new System.Drawing.Size(127, 36);
            this.btTakePicture.TabIndex = 14;
            this.btTakePicture.Text = "Take Pic";
            this.btTakePicture.UseVisualStyleBackColor = false;
            this.btTakePicture.Click += new System.EventHandler(this.btTakePicture_Click);
            // 
            // btRun
            // 
            this.btRun.BackColor = System.Drawing.Color.Transparent;
            this.btRun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btRun.BackgroundImage")));
            this.btRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.btRun.Location = new System.Drawing.Point(10, 26);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(127, 288);
            this.btRun.TabIndex = 13;
            this.btRun.UseVisualStyleBackColor = false;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);
            // 
            // tpManual
            // 
            this.tpManual.BackColor = System.Drawing.Color.White;
            this.tpManual.Controls.Add(this.splcManual_Calib);
            this.tpManual.Location = new System.Drawing.Point(4, 34);
            this.tpManual.Name = "tpManual";
            this.tpManual.Padding = new System.Windows.Forms.Padding(3);
            this.tpManual.Size = new System.Drawing.Size(873, 894);
            this.tpManual.TabIndex = 1;
            this.tpManual.Text = "MANUAL";
            // 
            // splcManual_Calib
            // 
            this.splcManual_Calib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcManual_Calib.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splcManual_Calib.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splcManual_Calib.IsSplitterFixed = true;
            this.splcManual_Calib.Location = new System.Drawing.Point(3, 3);
            this.splcManual_Calib.Name = "splcManual_Calib";
            // 
            // splcManual_Calib.Panel1
            // 
            this.splcManual_Calib.Panel1.Controls.Add(this.splcManual);
            // 
            // splcManual_Calib.Panel2
            // 
            this.splcManual_Calib.Panel2.Controls.Add(this.cogToolBlockEditCalib);
            this.splcManual_Calib.Panel2Collapsed = true;
            this.splcManual_Calib.Size = new System.Drawing.Size(867, 888);
            this.splcManual_Calib.SplitterDistance = 393;
            this.splcManual_Calib.TabIndex = 23;
            // 
            // splcManual
            // 
            this.splcManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcManual.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splcManual.Location = new System.Drawing.Point(0, 0);
            this.splcManual.Name = "splcManual";
            this.splcManual.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splcManual.Panel1
            // 
            this.splcManual.Panel1.Controls.Add(this.gbTestPrint);
            this.splcManual.Panel1.Controls.Add(this.gbMoveToPos);
            this.splcManual.Panel1.Controls.Add(this.gbPosition);
            this.splcManual.Panel1.Controls.Add(this.gbManualMove);
            this.splcManual.Panel1.Controls.Add(this.gbSpeed);
            // 
            // splcManual.Panel2
            // 
            this.splcManual.Panel2.Controls.Add(this.panel10);
            this.splcManual.Size = new System.Drawing.Size(867, 888);
            this.splcManual.SplitterDistance = 500;
            this.splcManual.TabIndex = 22;
            // 
            // gbTestPrint
            // 
            this.gbTestPrint.Controls.Add(this.btTestPrint);
            this.gbTestPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTestPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestPrint.Location = new System.Drawing.Point(488, 269);
            this.gbTestPrint.Name = "gbTestPrint";
            this.gbTestPrint.Size = new System.Drawing.Size(379, 231);
            this.gbTestPrint.TabIndex = 42;
            this.gbTestPrint.TabStop = false;
            this.gbTestPrint.Text = "TEST PRINT";
            // 
            // btTestPrint
            // 
            this.btTestPrint.BackColor = System.Drawing.Color.Transparent;
            this.btTestPrint.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.TestPrint;
            this.btTestPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btTestPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btTestPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btTestPrint.Location = new System.Drawing.Point(3, 27);
            this.btTestPrint.Name = "btTestPrint";
            this.btTestPrint.Size = new System.Drawing.Size(373, 201);
            this.btTestPrint.TabIndex = 0;
            this.btTestPrint.Tag = "8224";
            this.btTestPrint.UseVisualStyleBackColor = false;
            this.btTestPrint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btTestPrint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btTestPrint_MouseUp);
            // 
            // gbMoveToPos
            // 
            this.gbMoveToPos.Controls.Add(this.panel14);
            this.gbMoveToPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMoveToPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMoveToPos.Location = new System.Drawing.Point(488, 136);
            this.gbMoveToPos.Name = "gbMoveToPos";
            this.gbMoveToPos.Size = new System.Drawing.Size(379, 133);
            this.gbMoveToPos.TabIndex = 41;
            this.gbMoveToPos.TabStop = false;
            this.gbMoveToPos.Text = "MOVE TO POSITION";
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.flowLayoutPanel7);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(3, 27);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(373, 103);
            this.panel14.TabIndex = 2;
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel7.Controls.Add(this.tbMoveX);
            this.flowLayoutPanel7.Controls.Add(this.pictureBox2);
            this.flowLayoutPanel7.Controls.Add(this.tbMoveY);
            this.flowLayoutPanel7.Controls.Add(this.pictureBox3);
            this.flowLayoutPanel7.Controls.Add(this.tbMoveR);
            this.flowLayoutPanel7.Controls.Add(this.btManualMove);
            this.flowLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(373, 103);
            this.flowLayoutPanel7.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.UpDown;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // tbMoveX
            // 
            this.tbMoveX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMoveX.Location = new System.Drawing.Point(3, 69);
            this.tbMoveX.Name = "tbMoveX";
            this.tbMoveX.Size = new System.Drawing.Size(60, 26);
            this.tbMoveX.TabIndex = 40;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.LeftRight;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(69, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.TabIndex = 43;
            this.pictureBox2.TabStop = false;
            // 
            // tbMoveY
            // 
            this.tbMoveY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMoveY.Location = new System.Drawing.Point(69, 69);
            this.tbMoveY.Name = "tbMoveY";
            this.tbMoveY.Size = new System.Drawing.Size(60, 26);
            this.tbMoveY.TabIndex = 46;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Rotate;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(135, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.TabIndex = 48;
            this.pictureBox3.TabStop = false;
            // 
            // tbMoveR
            // 
            this.tbMoveR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMoveR.Location = new System.Drawing.Point(135, 69);
            this.tbMoveR.Name = "tbMoveR";
            this.tbMoveR.Size = new System.Drawing.Size(60, 26);
            this.tbMoveR.TabIndex = 50;
            // 
            // btManualMove
            // 
            this.btManualMove.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel7.SetFlowBreak(this.btManualMove, true);
            this.btManualMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btManualMove.Location = new System.Drawing.Point(201, 3);
            this.btManualMove.Name = "btManualMove";
            this.btManualMove.Size = new System.Drawing.Size(98, 92);
            this.btManualMove.TabIndex = 51;
            this.btManualMove.Text = "Move";
            this.btManualMove.UseVisualStyleBackColor = false;
            this.btManualMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btManualMove_MouseDown);
            this.btManualMove.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btManualMove_MouseUp);
            // 
            // gbPosition
            // 
            this.gbPosition.Controls.Add(this.panel3);
            this.gbPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPosition.Location = new System.Drawing.Point(488, 0);
            this.gbPosition.Name = "gbPosition";
            this.gbPosition.Size = new System.Drawing.Size(379, 136);
            this.gbPosition.TabIndex = 40;
            this.gbPosition.TabStop = false;
            this.gbPosition.Text = "POSITION";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 106);
            this.panel3.TabIndex = 2;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.pictureBox4);
            this.flowLayoutPanel6.Controls.Add(this.lbPosX);
            this.flowLayoutPanel6.Controls.Add(this.pictureBox5);
            this.flowLayoutPanel6.Controls.Add(this.lbPosY);
            this.flowLayoutPanel6.Controls.Add(this.pictureBox6);
            this.flowLayoutPanel6.Controls.Add(this.lbPosR);
            this.flowLayoutPanel6.Controls.Add(this.pictureBox7);
            this.flowLayoutPanel6.Controls.Add(this.lbEnc);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(373, 106);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.UpDown;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(3, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 60);
            this.pictureBox4.TabIndex = 33;
            this.pictureBox4.TabStop = false;
            // 
            // lbPosX
            // 
            this.lbPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosX.Location = new System.Drawing.Point(3, 66);
            this.lbPosX.Name = "lbPosX";
            this.lbPosX.Size = new System.Drawing.Size(60, 34);
            this.lbPosX.TabIndex = 36;
            this.lbPosX.Text = "0";
            this.lbPosX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.LeftRight;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(69, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(60, 60);
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            // 
            // lbPosY
            // 
            this.lbPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosY.Location = new System.Drawing.Point(69, 66);
            this.lbPosY.Name = "lbPosY";
            this.lbPosY.Size = new System.Drawing.Size(60, 34);
            this.lbPosY.TabIndex = 37;
            this.lbPosY.Text = "0";
            this.lbPosY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Rotate;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Location = new System.Drawing.Point(135, 3);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(60, 60);
            this.pictureBox6.TabIndex = 35;
            this.pictureBox6.TabStop = false;
            // 
            // lbPosR
            // 
            this.lbPosR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPosR.Location = new System.Drawing.Point(135, 66);
            this.lbPosR.Name = "lbPosR";
            this.lbPosR.Size = new System.Drawing.Size(60, 34);
            this.lbPosR.TabIndex = 38;
            this.lbPosR.Text = "0";
            this.lbPosR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Encoder;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(201, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(98, 60);
            this.pictureBox7.TabIndex = 39;
            this.pictureBox7.TabStop = false;
            // 
            // lbEnc
            // 
            this.lbEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEnc.Location = new System.Drawing.Point(201, 66);
            this.lbEnc.Name = "lbEnc";
            this.lbEnc.Size = new System.Drawing.Size(98, 34);
            this.lbEnc.TabIndex = 40;
            this.lbEnc.Text = "0";
            this.lbEnc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbManualMove
            // 
            this.gbManualMove.Controls.Add(this.btJogNegX);
            this.gbManualMove.Controls.Add(this.btJogPosX);
            this.gbManualMove.Controls.Add(this.btJogPosY);
            this.gbManualMove.Controls.Add(this.btJogNegY);
            this.gbManualMove.Controls.Add(this.panel15);
            this.gbManualMove.Controls.Add(this.gbHome);
            this.gbManualMove.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbManualMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbManualMove.Location = new System.Drawing.Point(211, 0);
            this.gbManualMove.Name = "gbManualMove";
            this.gbManualMove.Size = new System.Drawing.Size(277, 500);
            this.gbManualMove.TabIndex = 39;
            this.gbManualMove.TabStop = false;
            this.gbManualMove.Text = "JOG";
            // 
            // btJogNegX
            // 
            this.btJogNegX.AccessibleDescription = "Jog Neg X";
            this.btJogNegX.BackColor = System.Drawing.Color.Transparent;
            this.btJogNegX.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Up;
            this.btJogNegX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogNegX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogNegX.Location = new System.Drawing.Point(109, 25);
            this.btJogNegX.Name = "btJogNegX";
            this.btJogNegX.Size = new System.Drawing.Size(60, 60);
            this.btJogNegX.TabIndex = 32;
            this.btJogNegX.Tag = "8218";
            this.btJogNegX.Text = "X-";
            this.btJogNegX.UseVisualStyleBackColor = false;
            this.btJogNegX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogNegX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Jog_MouseUp);
            // 
            // btJogPosX
            // 
            this.btJogPosX.AccessibleDescription = "Jog Pox X";
            this.btJogPosX.BackColor = System.Drawing.Color.Transparent;
            this.btJogPosX.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Down;
            this.btJogPosX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogPosX.Location = new System.Drawing.Point(108, 243);
            this.btJogPosX.Name = "btJogPosX";
            this.btJogPosX.Size = new System.Drawing.Size(60, 60);
            this.btJogPosX.TabIndex = 31;
            this.btJogPosX.Tag = "8217";
            this.btJogPosX.Text = "X+";
            this.btJogPosX.UseVisualStyleBackColor = false;
            this.btJogPosX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogPosX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Jog_MouseUp);
            // 
            // btJogPosY
            // 
            this.btJogPosY.BackColor = System.Drawing.Color.Transparent;
            this.btJogPosY.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Left;
            this.btJogPosY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogPosY.Location = new System.Drawing.Point(9, 134);
            this.btJogPosY.Name = "btJogPosY";
            this.btJogPosY.Size = new System.Drawing.Size(60, 60);
            this.btJogPosY.TabIndex = 30;
            this.btJogPosY.Tag = "8219";
            this.btJogPosY.Text = "Y+";
            this.btJogPosY.UseVisualStyleBackColor = false;
            this.btJogPosY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogPosY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Jog_MouseUp);
            // 
            // btJogNegY
            // 
            this.btJogNegY.AccessibleName = "Jog Neg Y";
            this.btJogNegY.BackColor = System.Drawing.Color.Transparent;
            this.btJogNegY.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Right;
            this.btJogNegY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogNegY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogNegY.Location = new System.Drawing.Point(209, 136);
            this.btJogNegY.Name = "btJogNegY";
            this.btJogNegY.Size = new System.Drawing.Size(60, 60);
            this.btJogNegY.TabIndex = 29;
            this.btJogNegY.Tag = "8220";
            this.btJogNegY.Text = " Y-";
            this.btJogNegY.UseVisualStyleBackColor = false;
            this.btJogNegY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogNegY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Jog_MouseUp);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.btJogNegR);
            this.panel15.Controls.Add(this.btJogPosR);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel15.Location = new System.Drawing.Point(3, 345);
            this.panel15.Name = "panel15";
            this.panel15.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.panel15.Size = new System.Drawing.Size(271, 60);
            this.panel15.TabIndex = 6;
            // 
            // btJogNegR
            // 
            this.btJogNegR.AccessibleDescription = "Jog Neg R";
            this.btJogNegR.BackColor = System.Drawing.Color.Transparent;
            this.btJogNegR.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Clockwise;
            this.btJogNegR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogNegR.Dock = System.Windows.Forms.DockStyle.Left;
            this.btJogNegR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogNegR.Location = new System.Drawing.Point(5, 0);
            this.btJogNegR.Name = "btJogNegR";
            this.btJogNegR.Size = new System.Drawing.Size(60, 60);
            this.btJogNegR.TabIndex = 6;
            this.btJogNegR.Tag = "8222";
            this.btJogNegR.Text = "R-";
            this.btJogNegR.UseVisualStyleBackColor = false;
            this.btJogNegR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogNegR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Jog_MouseUp);
            // 
            // btJogPosR
            // 
            this.btJogPosR.AccessibleDescription = "Jog Pos R";
            this.btJogPosR.BackColor = System.Drawing.Color.Transparent;
            this.btJogPosR.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.AntiClockwise;
            this.btJogPosR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogPosR.Dock = System.Windows.Forms.DockStyle.Right;
            this.btJogPosR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogPosR.Location = new System.Drawing.Point(206, 0);
            this.btJogPosR.Name = "btJogPosR";
            this.btJogPosR.Size = new System.Drawing.Size(60, 60);
            this.btJogPosR.TabIndex = 5;
            this.btJogPosR.Tag = "8221";
            this.btJogPosR.Text = "R+";
            this.btJogPosR.UseVisualStyleBackColor = false;
            this.btJogPosR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogPosR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Jog_MouseUp);
            // 
            // gbHome
            // 
            this.gbHome.Controls.Add(this.flowLayoutPanel5);
            this.gbHome.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHome.Location = new System.Drawing.Point(3, 405);
            this.gbHome.Name = "gbHome";
            this.gbHome.Size = new System.Drawing.Size(271, 92);
            this.gbHome.TabIndex = 27;
            this.gbHome.TabStop = false;
            this.gbHome.Text = "HOME";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.btJogHomeX);
            this.flowLayoutPanel5.Controls.Add(this.btJogHomeY);
            this.flowLayoutPanel5.Controls.Add(this.btJogHomeR);
            this.flowLayoutPanel5.Controls.Add(this.btJogHome);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(265, 62);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // btJogHomeX
            // 
            this.btJogHomeX.AccessibleDescription = "Jog Home X";
            this.btJogHomeX.BackColor = System.Drawing.Color.Transparent;
            this.btJogHomeX.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.UpDown;
            this.btJogHomeX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogHomeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogHomeX.Location = new System.Drawing.Point(3, 3);
            this.btJogHomeX.Name = "btJogHomeX";
            this.btJogHomeX.Size = new System.Drawing.Size(60, 60);
            this.btJogHomeX.TabIndex = 10;
            this.btJogHomeX.Tag = "8212";
            this.btJogHomeX.Text = "X";
            this.btJogHomeX.UseVisualStyleBackColor = false;
            this.btJogHomeX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogHomeX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_Home_MouseUp);
            // 
            // btJogHomeY
            // 
            this.btJogHomeY.AccessibleDescription = "Jog Home Y";
            this.btJogHomeY.BackColor = System.Drawing.Color.Transparent;
            this.btJogHomeY.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.LeftRight;
            this.btJogHomeY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogHomeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogHomeY.Location = new System.Drawing.Point(69, 3);
            this.btJogHomeY.Name = "btJogHomeY";
            this.btJogHomeY.Size = new System.Drawing.Size(60, 60);
            this.btJogHomeY.TabIndex = 9;
            this.btJogHomeY.Tag = "8213";
            this.btJogHomeY.Text = "Y";
            this.btJogHomeY.UseVisualStyleBackColor = false;
            this.btJogHomeY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogHomeY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_Home_MouseUp);
            // 
            // btJogHomeR
            // 
            this.btJogHomeR.AccessibleDescription = "Jog Home R";
            this.btJogHomeR.BackColor = System.Drawing.Color.Transparent;
            this.btJogHomeR.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Rotate;
            this.btJogHomeR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogHomeR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogHomeR.Location = new System.Drawing.Point(135, 3);
            this.btJogHomeR.Name = "btJogHomeR";
            this.btJogHomeR.Size = new System.Drawing.Size(60, 60);
            this.btJogHomeR.TabIndex = 7;
            this.btJogHomeR.Tag = "8214";
            this.btJogHomeR.Text = "R";
            this.btJogHomeR.UseVisualStyleBackColor = false;
            this.btJogHomeR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogHomeR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_Home_MouseUp);
            // 
            // btJogHome
            // 
            this.btJogHome.AccessibleDescription = "Jog Home";
            this.btJogHome.BackColor = System.Drawing.Color.Transparent;
            this.btJogHome.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Home;
            this.btJogHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btJogHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJogHome.Location = new System.Drawing.Point(201, 3);
            this.btJogHome.Name = "btJogHome";
            this.btJogHome.Size = new System.Drawing.Size(60, 60);
            this.btJogHome.TabIndex = 8;
            this.btJogHome.Tag = "8215";
            this.btJogHome.Text = "ALL";
            this.btJogHome.UseVisualStyleBackColor = false;
            this.btJogHome.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_JogHome_MouseDown);
            this.btJogHome.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bt_Home_MouseUp);
            // 
            // gbSpeed
            // 
            this.gbSpeed.Controls.Add(this.panel12);
            this.gbSpeed.Controls.Add(this.btSetSpeed);
            this.gbSpeed.Controls.Add(this.flowLayoutPanel8);
            this.gbSpeed.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSpeed.Location = new System.Drawing.Point(0, 0);
            this.gbSpeed.Name = "gbSpeed";
            this.gbSpeed.Size = new System.Drawing.Size(211, 500);
            this.gbSpeed.TabIndex = 30;
            this.gbSpeed.TabStop = false;
            this.gbSpeed.Text = "SPEED";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Controls.Add(this.trackbarJogSpeedX);
            this.panel12.Controls.Add(this.trackbarJogSpeedR);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(3, 127);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.panel12.Size = new System.Drawing.Size(205, 308);
            this.panel12.TabIndex = 22;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.trackbarJogSpeedY);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(60, 0);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel13.Size = new System.Drawing.Size(85, 308);
            this.panel13.TabIndex = 36;
            // 
            // trackbarJogSpeedY
            // 
            this.trackbarJogSpeedY.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackbarJogSpeedY.LargeChange = 500;
            this.trackbarJogSpeedY.Location = new System.Drawing.Point(20, 0);
            this.trackbarJogSpeedY.Maximum = 400000;
            this.trackbarJogSpeedY.Name = "trackbarJogSpeedY";
            this.trackbarJogSpeedY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackbarJogSpeedY.Size = new System.Drawing.Size(45, 308);
            this.trackbarJogSpeedY.SmallChange = 100;
            this.trackbarJogSpeedY.TabIndex = 24;
            this.trackbarJogSpeedY.TickFrequency = 10000;
            this.trackbarJogSpeedY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackbarJogSpeedY.ValueChanged += new System.EventHandler(this.trackbarJogSpeed_ValueChanged);
            // 
            // trackbarJogSpeedX
            // 
            this.trackbarJogSpeedX.Dock = System.Windows.Forms.DockStyle.Left;
            this.trackbarJogSpeedX.LargeChange = 500;
            this.trackbarJogSpeedX.Location = new System.Drawing.Point(15, 0);
            this.trackbarJogSpeedX.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.trackbarJogSpeedX.Maximum = 400000;
            this.trackbarJogSpeedX.Name = "trackbarJogSpeedX";
            this.trackbarJogSpeedX.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackbarJogSpeedX.Size = new System.Drawing.Size(45, 308);
            this.trackbarJogSpeedX.SmallChange = 100;
            this.trackbarJogSpeedX.TabIndex = 35;
            this.trackbarJogSpeedX.TickFrequency = 10000;
            this.trackbarJogSpeedX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackbarJogSpeedX.ValueChanged += new System.EventHandler(this.trackbarJogSpeed_ValueChanged);
            // 
            // trackbarJogSpeedR
            // 
            this.trackbarJogSpeedR.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackbarJogSpeedR.LargeChange = 500;
            this.trackbarJogSpeedR.Location = new System.Drawing.Point(145, 0);
            this.trackbarJogSpeedR.Maximum = 200000;
            this.trackbarJogSpeedR.Name = "trackbarJogSpeedR";
            this.trackbarJogSpeedR.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackbarJogSpeedR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackbarJogSpeedR.Size = new System.Drawing.Size(45, 308);
            this.trackbarJogSpeedR.SmallChange = 100;
            this.trackbarJogSpeedR.TabIndex = 33;
            this.trackbarJogSpeedR.TickFrequency = 10000;
            this.trackbarJogSpeedR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackbarJogSpeedR.Value = 10;
            this.trackbarJogSpeedR.ValueChanged += new System.EventHandler(this.trackbarJogSpeed_ValueChanged);
            // 
            // btSetSpeed
            // 
            this.btSetSpeed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btSetSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSetSpeed.Location = new System.Drawing.Point(3, 435);
            this.btSetSpeed.Name = "btSetSpeed";
            this.btSetSpeed.Size = new System.Drawing.Size(205, 62);
            this.btSetSpeed.TabIndex = 21;
            this.btSetSpeed.Text = "Set Speed";
            this.btSetSpeed.UseVisualStyleBackColor = true;
            this.btSetSpeed.Click += new System.EventHandler(this.btSetSpeed_Click);
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.pictureBox8);
            this.flowLayoutPanel8.Controls.Add(this.pictureBox9);
            this.flowLayoutPanel8.Controls.Add(this.pictureBox10);
            this.flowLayoutPanel8.Controls.Add(this.tbJogSpeedX);
            this.flowLayoutPanel8.Controls.Add(this.tbJogSpeedY);
            this.flowLayoutPanel8.Controls.Add(this.tbJogSpeedR);
            this.flowLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(205, 100);
            this.flowLayoutPanel8.TabIndex = 19;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.UpDown;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Location = new System.Drawing.Point(3, 3);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(60, 60);
            this.pictureBox8.TabIndex = 28;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.LeftRight;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(69, 3);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(60, 60);
            this.pictureBox9.TabIndex = 29;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Rotate;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(135, 3);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(60, 60);
            this.pictureBox10.TabIndex = 30;
            this.pictureBox10.TabStop = false;
            // 
            // tbJogSpeedX
            // 
            this.tbJogSpeedX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJogSpeedX.Location = new System.Drawing.Point(3, 69);
            this.tbJogSpeedX.Name = "tbJogSpeedX";
            this.tbJogSpeedX.Size = new System.Drawing.Size(60, 22);
            this.tbJogSpeedX.TabIndex = 15;
            this.tbJogSpeedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbJogSpeedX.TextChanged += new System.EventHandler(this.tbSpeed_TextChanged);
            // 
            // tbJogSpeedY
            // 
            this.tbJogSpeedY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJogSpeedY.Location = new System.Drawing.Point(69, 69);
            this.tbJogSpeedY.Name = "tbJogSpeedY";
            this.tbJogSpeedY.Size = new System.Drawing.Size(60, 22);
            this.tbJogSpeedY.TabIndex = 31;
            this.tbJogSpeedY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbJogSpeedY.TextChanged += new System.EventHandler(this.tbSpeed_TextChanged);
            // 
            // tbJogSpeedR
            // 
            this.tbJogSpeedR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJogSpeedR.Location = new System.Drawing.Point(135, 69);
            this.tbJogSpeedR.Name = "tbJogSpeedR";
            this.tbJogSpeedR.Size = new System.Drawing.Size(60, 22);
            this.tbJogSpeedR.TabIndex = 34;
            this.tbJogSpeedR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbJogSpeedR.TextChanged += new System.EventHandler(this.tbSpeed_TextChanged);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.gbCalibrate);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(867, 384);
            this.panel10.TabIndex = 1;
            // 
            // gbCalibrate
            // 
            this.gbCalibrate.Controls.Add(this.splcCalib);
            this.gbCalibrate.Controls.Add(this.pnCalib);
            this.gbCalibrate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCalibrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCalibrate.Location = new System.Drawing.Point(0, 0);
            this.gbCalibrate.Name = "gbCalibrate";
            this.gbCalibrate.Size = new System.Drawing.Size(867, 384);
            this.gbCalibrate.TabIndex = 1;
            this.gbCalibrate.TabStop = false;
            this.gbCalibrate.Text = "CALIBRATE";
            // 
            // splcCalib
            // 
            this.splcCalib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splcCalib.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splcCalib.Location = new System.Drawing.Point(3, 84);
            this.splcCalib.Name = "splcCalib";
            // 
            // splcCalib.Panel1
            // 
            this.splcCalib.Panel1.Controls.Add(this.dgvCalibData);
            this.splcCalib.Panel1.Controls.Add(this.label5);
            this.splcCalib.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splcCalib.Panel2
            // 
            this.splcCalib.Panel2.Controls.Add(this.dgvCalibResult);
            this.splcCalib.Panel2.Controls.Add(this.label6);
            this.splcCalib.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splcCalib.Size = new System.Drawing.Size(861, 297);
            this.splcCalib.SplitterDistance = 567;
            this.splcCalib.TabIndex = 3;
            // 
            // dgvCalibData
            // 
            this.dgvCalibData.AllowUserToDeleteRows = false;
            this.dgvCalibData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalibData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column13,
            this.Column12,
            this.Column14,
            this.Column25,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22});
            this.dgvCalibData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalibData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCalibData.Location = new System.Drawing.Point(5, 25);
            this.dgvCalibData.Name = "dgvCalibData";
            this.dgvCalibData.RowHeadersVisible = false;
            this.dgvCalibData.Size = new System.Drawing.Size(557, 267);
            this.dgvCalibData.TabIndex = 1;
            // 
            // Column13
            // 
            this.Column13.FillWeight = 120.7301F;
            this.Column13.Frozen = true;
            this.Column13.HeaderText = "No.";
            this.Column13.Name = "Column13";
            this.Column13.Width = 30;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 100.2032F;
            this.Column12.HeaderText = "E0";
            this.Column12.Name = "Column12";
            this.Column12.Width = 90;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "X0";
            this.Column14.Name = "Column14";
            this.Column14.Width = 70;
            // 
            // Column25
            // 
            this.Column25.HeaderText = "Y0";
            this.Column25.Name = "Column25";
            this.Column25.Width = 70;
            // 
            // Column15
            // 
            this.Column15.FillWeight = 9.386523F;
            this.Column15.HeaderText = "";
            this.Column15.MinimumWidth = 2;
            this.Column15.Name = "Column15";
            this.Column15.Width = 4;
            // 
            // Column16
            // 
            this.Column16.FillWeight = 116.2473F;
            this.Column16.HeaderText = "E1";
            this.Column16.Name = "Column16";
            this.Column16.Width = 90;
            // 
            // Column17
            // 
            this.Column17.FillWeight = 116.2473F;
            this.Column17.HeaderText = "X1";
            this.Column17.Name = "Column17";
            this.Column17.Width = 70;
            // 
            // Column18
            // 
            this.Column18.FillWeight = 116.2473F;
            this.Column18.HeaderText = "Y1";
            this.Column18.Name = "Column18";
            this.Column18.Width = 70;
            // 
            // Column19
            // 
            this.Column19.FillWeight = 24.16155F;
            this.Column19.HeaderText = "";
            this.Column19.Name = "Column19";
            this.Column19.Width = 5;
            // 
            // Column20
            // 
            this.Column20.FillWeight = 116.2473F;
            this.Column20.HeaderText = "E2";
            this.Column20.Name = "Column20";
            this.Column20.Width = 90;
            // 
            // Column21
            // 
            this.Column21.FillWeight = 116.2473F;
            this.Column21.HeaderText = "X2";
            this.Column21.Name = "Column21";
            this.Column21.Width = 70;
            // 
            // Column22
            // 
            this.Column22.FillWeight = 116.2473F;
            this.Column22.HeaderText = "Y2";
            this.Column22.Name = "Column22";
            this.Column22.Width = 70;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(557, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "DATA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvCalibResult
            // 
            this.dgvCalibResult.AllowUserToDeleteRows = false;
            this.dgvCalibResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCalibResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalibResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column23,
            this.Column24});
            this.dgvCalibResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCalibResult.Location = new System.Drawing.Point(5, 25);
            this.dgvCalibResult.Name = "dgvCalibResult";
            this.dgvCalibResult.RowHeadersVisible = false;
            this.dgvCalibResult.Size = new System.Drawing.Size(280, 267);
            this.dgvCalibResult.TabIndex = 2;
            // 
            // Column23
            // 
            this.Column23.FillWeight = 121.8274F;
            this.Column23.HeaderText = "Properties";
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.FillWeight = 78.17259F;
            this.Column24.HeaderText = "Value";
            this.Column24.Name = "Column24";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(280, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "RESULT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnCalib
            // 
            this.pnCalib.Controls.Add(this.btCalibSave);
            this.pnCalib.Controls.Add(this.pictureBox15);
            this.pnCalib.Controls.Add(this.btCalib);
            this.pnCalib.Controls.Add(this.pictureBox14);
            this.pnCalib.Controls.Add(this.btCalibXYRobot);
            this.pnCalib.Controls.Add(this.pictureBox13);
            this.pnCalib.Controls.Add(this.btCalibCamera);
            this.pnCalib.Controls.Add(this.pictureBox12);
            this.pnCalib.Controls.Add(this.btCalibEnc);
            this.pnCalib.Controls.Add(this.pictureBox11);
            this.pnCalib.Controls.Add(this.panel7);
            this.pnCalib.Controls.Add(this.btCalibReset);
            this.pnCalib.Controls.Add(this.btCalibInitialize);
            this.pnCalib.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCalib.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnCalib.Location = new System.Drawing.Point(3, 27);
            this.pnCalib.Name = "pnCalib";
            this.pnCalib.Size = new System.Drawing.Size(861, 57);
            this.pnCalib.TabIndex = 2;
            // 
            // btCalibSave
            // 
            this.btCalibSave.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCalibSave.Enabled = false;
            this.btCalibSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalibSave.Location = new System.Drawing.Point(703, 0);
            this.btCalibSave.Name = "btCalibSave";
            this.btCalibSave.Size = new System.Drawing.Size(85, 57);
            this.btCalibSave.TabIndex = 23;
            this.btCalibSave.Text = "Save";
            this.btCalibSave.UseVisualStyleBackColor = true;
            this.btCalibSave.Click += new System.EventHandler(this.btCalibSave_Click);
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Right;
            this.pictureBox15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox15.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox15.Location = new System.Drawing.Point(688, 0);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(15, 57);
            this.pictureBox15.TabIndex = 22;
            this.pictureBox15.TabStop = false;
            // 
            // btCalib
            // 
            this.btCalib.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCalib.Enabled = false;
            this.btCalib.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalib.Location = new System.Drawing.Point(603, 0);
            this.btCalib.Name = "btCalib";
            this.btCalib.Size = new System.Drawing.Size(85, 57);
            this.btCalib.TabIndex = 21;
            this.btCalib.Text = "4. Calibrate";
            this.btCalib.UseVisualStyleBackColor = true;
            this.btCalib.Click += new System.EventHandler(this.btCalib_Click);
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Right;
            this.pictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox14.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox14.Location = new System.Drawing.Point(588, 0);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(15, 57);
            this.pictureBox14.TabIndex = 20;
            this.pictureBox14.TabStop = false;
            // 
            // btCalibXYRobot
            // 
            this.btCalibXYRobot.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCalibXYRobot.Enabled = false;
            this.btCalibXYRobot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalibXYRobot.Location = new System.Drawing.Point(503, 0);
            this.btCalibXYRobot.Name = "btCalibXYRobot";
            this.btCalibXYRobot.Size = new System.Drawing.Size(85, 57);
            this.btCalibXYRobot.TabIndex = 19;
            this.btCalibXYRobot.Text = "3. XYRobot";
            this.btCalibXYRobot.UseVisualStyleBackColor = true;
            this.btCalibXYRobot.Click += new System.EventHandler(this.btCalibXYRobot_Click);
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Right;
            this.pictureBox13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox13.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox13.Location = new System.Drawing.Point(488, 0);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(15, 57);
            this.pictureBox13.TabIndex = 18;
            this.pictureBox13.TabStop = false;
            // 
            // btCalibCamera
            // 
            this.btCalibCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCalibCamera.Enabled = false;
            this.btCalibCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalibCamera.Location = new System.Drawing.Point(403, 0);
            this.btCalibCamera.Name = "btCalibCamera";
            this.btCalibCamera.Size = new System.Drawing.Size(85, 57);
            this.btCalibCamera.TabIndex = 17;
            this.btCalibCamera.Text = "2. Camera";
            this.btCalibCamera.UseVisualStyleBackColor = true;
            this.btCalibCamera.Click += new System.EventHandler(this.btCalibCamera_Click);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Right;
            this.pictureBox12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox12.Location = new System.Drawing.Point(388, 0);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(15, 57);
            this.pictureBox12.TabIndex = 16;
            this.pictureBox12.TabStop = false;
            // 
            // btCalibEnc
            // 
            this.btCalibEnc.BackColor = System.Drawing.Color.Transparent;
            this.btCalibEnc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCalibEnc.Enabled = false;
            this.btCalibEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalibEnc.Location = new System.Drawing.Point(303, 0);
            this.btCalibEnc.Name = "btCalibEnc";
            this.btCalibEnc.Size = new System.Drawing.Size(85, 57);
            this.btCalibEnc.TabIndex = 15;
            this.btCalibEnc.Text = "1. Encoder";
            this.btCalibEnc.UseVisualStyleBackColor = false;
            this.btCalibEnc.Click += new System.EventHandler(this.btCalibEnc_Click);
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Right;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox11.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox11.Location = new System.Drawing.Point(288, 0);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(15, 57);
            this.pictureBox11.TabIndex = 14;
            this.pictureBox11.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbCalibInitialize);
            this.panel7.Controls.Add(this.lbCalibInitialize);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(170, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(118, 57);
            this.panel7.TabIndex = 13;
            // 
            // tbCalibInitialize
            // 
            this.tbCalibInitialize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCalibInitialize.Location = new System.Drawing.Point(0, 34);
            this.tbCalibInitialize.Name = "tbCalibInitialize";
            this.tbCalibInitialize.Size = new System.Drawing.Size(118, 26);
            this.tbCalibInitialize.TabIndex = 1;
            // 
            // lbCalibInitialize
            // 
            this.lbCalibInitialize.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCalibInitialize.Location = new System.Drawing.Point(0, 0);
            this.lbCalibInitialize.Name = "lbCalibInitialize";
            this.lbCalibInitialize.Size = new System.Drawing.Size(118, 34);
            this.lbCalibInitialize.TabIndex = 0;
            this.lbCalibInitialize.Text = "Initialize Value";
            this.lbCalibInitialize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCalibReset
            // 
            this.btCalibReset.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCalibReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalibReset.Location = new System.Drawing.Point(85, 0);
            this.btCalibReset.Name = "btCalibReset";
            this.btCalibReset.Size = new System.Drawing.Size(85, 57);
            this.btCalibReset.TabIndex = 12;
            this.btCalibReset.Text = "Reset";
            this.btCalibReset.UseVisualStyleBackColor = true;
            this.btCalibReset.Click += new System.EventHandler(this.btCalibReset_Click);
            // 
            // btCalibInitialize
            // 
            this.btCalibInitialize.Dock = System.Windows.Forms.DockStyle.Left;
            this.btCalibInitialize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCalibInitialize.Location = new System.Drawing.Point(0, 0);
            this.btCalibInitialize.Name = "btCalibInitialize";
            this.btCalibInitialize.Size = new System.Drawing.Size(85, 57);
            this.btCalibInitialize.TabIndex = 0;
            this.btCalibInitialize.Text = "Initialize";
            this.btCalibInitialize.UseVisualStyleBackColor = true;
            this.btCalibInitialize.Click += new System.EventHandler(this.btCalibInitialize_Click);
            // 
            // cogToolBlockEditCalib
            // 
            this.cogToolBlockEditCalib.AllowDrop = true;
            this.cogToolBlockEditCalib.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.cogToolBlockEditCalib.ContextMenuCustomizer = null;
            this.cogToolBlockEditCalib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogToolBlockEditCalib.LocalDisplayVisible = false;
            this.cogToolBlockEditCalib.Location = new System.Drawing.Point(0, 0);
            this.cogToolBlockEditCalib.Margin = new System.Windows.Forms.Padding(0);
            this.cogToolBlockEditCalib.MinimumSize = new System.Drawing.Size(11537535, 0);
            this.cogToolBlockEditCalib.Name = "cogToolBlockEditCalib";
            this.cogToolBlockEditCalib.ShowNodeToolTips = true;
            this.cogToolBlockEditCalib.Size = new System.Drawing.Size(65535, 100);
            this.cogToolBlockEditCalib.SuspendElectricRuns = false;
            this.cogToolBlockEditCalib.TabIndex = 0;
            // 
            // tpWaiting
            // 
            this.tpWaiting.BackColor = System.Drawing.Color.White;
            this.tpWaiting.Controls.Add(this.pictureBox16);
            this.tpWaiting.Location = new System.Drawing.Point(4, 34);
            this.tpWaiting.Name = "tpWaiting";
            this.tpWaiting.Padding = new System.Windows.Forms.Padding(3);
            this.tpWaiting.Size = new System.Drawing.Size(873, 894);
            this.tpWaiting.TabIndex = 2;
            this.tpWaiting.Text = "WAITING";
            // 
            // pictureBox16
            // 
            this.pictureBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox16.Image = global::Vision_Guided_Robot_Application.Properties.Resources.Background;
            this.pictureBox16.Location = new System.Drawing.Point(3, 3);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(867, 888);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox16.TabIndex = 0;
            this.pictureBox16.TabStop = false;
            // 
            // splc_Lived_Error
            // 
            this.splc_Lived_Error.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splc_Lived_Error.Location = new System.Drawing.Point(0, 0);
            this.splc_Lived_Error.Name = "splc_Lived_Error";
            this.splc_Lived_Error.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splc_Lived_Error.Panel1
            // 
            this.splc_Lived_Error.Panel1.Controls.Add(this.gbAnimation);
            // 
            // splc_Lived_Error.Panel2
            // 
            this.splc_Lived_Error.Panel2.Controls.Add(this.gbError);
            this.splc_Lived_Error.Size = new System.Drawing.Size(396, 602);
            this.splc_Lived_Error.SplitterDistance = 397;
            this.splc_Lived_Error.TabIndex = 6;
            // 
            // gbAnimation
            // 
            this.gbAnimation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gbAnimation.Controls.Add(this.pnConveyor);
            this.gbAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAnimation.Location = new System.Drawing.Point(0, 0);
            this.gbAnimation.Name = "gbAnimation";
            this.gbAnimation.Size = new System.Drawing.Size(396, 397);
            this.gbAnimation.TabIndex = 1;
            this.gbAnimation.TabStop = false;
            this.gbAnimation.Text = "REAL-TIME SCRREN";
            // 
            // pnConveyor
            // 
            this.pnConveyor.BackColor = System.Drawing.Color.Transparent;
            this.pnConveyor.BackgroundImage = global::Vision_Guided_Robot_Application.Properties.Resources.Conveyor;
            this.pnConveyor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnConveyor.Controls.Add(this.flpLivedLegend);
            this.pnConveyor.Controls.Add(this.pbXAxis);
            this.pnConveyor.Controls.Add(this.pbYAxis);
            this.pnConveyor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnConveyor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnConveyor.Location = new System.Drawing.Point(3, 27);
            this.pnConveyor.Name = "pnConveyor";
            this.pnConveyor.Size = new System.Drawing.Size(390, 367);
            this.pnConveyor.TabIndex = 6;
            // 
            // flpLivedLegend
            // 
            this.flpLivedLegend.BackColor = System.Drawing.Color.Transparent;
            this.flpLivedLegend.Controls.Add(this.cbLivedRobot);
            this.flpLivedLegend.Controls.Add(this.cbLivedObject);
            this.flpLivedLegend.Controls.Add(this.cbLivedPrinting);
            this.flpLivedLegend.Location = new System.Drawing.Point(0, 0);
            this.flpLivedLegend.Name = "flpLivedLegend";
            this.flpLivedLegend.Size = new System.Drawing.Size(139, 86);
            this.flpLivedLegend.TabIndex = 5;
            // 
            // cbLivedRobot
            // 
            this.cbLivedRobot.AutoSize = true;
            this.cbLivedRobot.BackColor = System.Drawing.Color.Transparent;
            this.cbLivedRobot.Checked = true;
            this.cbLivedRobot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLivedRobot.FlatAppearance.BorderSize = 5;
            this.cbLivedRobot.Location = new System.Drawing.Point(3, 3);
            this.cbLivedRobot.Name = "cbLivedRobot";
            this.cbLivedRobot.Size = new System.Drawing.Size(72, 24);
            this.cbLivedRobot.TabIndex = 13;
            this.cbLivedRobot.Text = "Robot";
            this.cbLivedRobot.UseVisualStyleBackColor = false;
            // 
            // cbLivedObject
            // 
            this.cbLivedObject.AutoSize = true;
            this.cbLivedObject.BackColor = System.Drawing.Color.Transparent;
            this.cbLivedObject.FlatAppearance.BorderSize = 5;
            this.cbLivedObject.Location = new System.Drawing.Point(3, 33);
            this.cbLivedObject.Name = "cbLivedObject";
            this.cbLivedObject.Size = new System.Drawing.Size(74, 24);
            this.cbLivedObject.TabIndex = 14;
            this.cbLivedObject.Text = "Object";
            this.cbLivedObject.UseVisualStyleBackColor = false;
            // 
            // cbLivedPrinting
            // 
            this.cbLivedPrinting.AutoSize = true;
            this.cbLivedPrinting.BackColor = System.Drawing.Color.Transparent;
            this.cbLivedPrinting.FlatAppearance.BorderSize = 5;
            this.cbLivedPrinting.Location = new System.Drawing.Point(3, 63);
            this.cbLivedPrinting.Name = "cbLivedPrinting";
            this.cbLivedPrinting.Size = new System.Drawing.Size(129, 24);
            this.cbLivedPrinting.TabIndex = 15;
            this.cbLivedPrinting.Text = "Printing status";
            this.cbLivedPrinting.UseVisualStyleBackColor = false;
            // 
            // pbXAxis
            // 
            this.pbXAxis.BackColor = System.Drawing.Color.Transparent;
            this.pbXAxis.Image = global::Vision_Guided_Robot_Application.Properties.Resources.xAxis;
            this.pbXAxis.Location = new System.Drawing.Point(85, 174);
            this.pbXAxis.Name = "pbXAxis";
            this.pbXAxis.Size = new System.Drawing.Size(41, 112);
            this.pbXAxis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbXAxis.TabIndex = 1;
            this.pbXAxis.TabStop = false;
            // 
            // pbYAxis
            // 
            this.pbYAxis.BackColor = System.Drawing.Color.Transparent;
            this.pbYAxis.Image = global::Vision_Guided_Robot_Application.Properties.Resources.yAxis;
            this.pbYAxis.Location = new System.Drawing.Point(0, 189);
            this.pbYAxis.Name = "pbYAxis";
            this.pbYAxis.Size = new System.Drawing.Size(385, 121);
            this.pbYAxis.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbYAxis.TabIndex = 0;
            this.pbYAxis.TabStop = false;
            // 
            // gbError
            // 
            this.gbError.Controls.Add(this.panel18);
            this.gbError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbError.Location = new System.Drawing.Point(0, 0);
            this.gbError.Name = "gbError";
            this.gbError.Size = new System.Drawing.Size(396, 201);
            this.gbError.TabIndex = 6;
            this.gbError.TabStop = false;
            this.gbError.Text = "ERROR";
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.dgvError);
            this.panel18.Controls.Add(this.btnClearErr);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel18.Location = new System.Drawing.Point(3, 27);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(390, 171);
            this.panel18.TabIndex = 0;
            // 
            // dgvError
            // 
            this.dgvError.AllowUserToAddRows = false;
            this.dgvError.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgvError.BackgroundColor = System.Drawing.Color.White;
            this.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Description});
            this.dgvError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvError.Location = new System.Drawing.Point(0, 0);
            this.dgvError.Name = "dgvError";
            this.dgvError.ReadOnly = true;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvError.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvError.RowTemplate.Height = 27;
            this.dgvError.Size = new System.Drawing.Size(390, 131);
            this.dgvError.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Num";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnClearErr
            // 
            this.btnClearErr.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClearErr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearErr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearErr.Location = new System.Drawing.Point(0, 131);
            this.btnClearErr.Name = "btnClearErr";
            this.btnClearErr.Size = new System.Drawing.Size(390, 40);
            this.btnClearErr.TabIndex = 1;
            this.btnClearErr.Text = "Clear Error";
            this.btnClearErr.UseVisualStyleBackColor = false;
            this.btnClearErr.Click += new System.EventHandler(this.btnClearErr_Click);
            // 
            // gbRecipe
            // 
            this.gbRecipe.Controls.Add(this.panel4);
            this.gbRecipe.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRecipe.Location = new System.Drawing.Point(0, 602);
            this.gbRecipe.Name = "gbRecipe";
            this.gbRecipe.Size = new System.Drawing.Size(396, 360);
            this.gbRecipe.TabIndex = 5;
            this.gbRecipe.TabStop = false;
            this.gbRecipe.Text = "RECIPE";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvRecipe);
            this.panel4.Controls.Add(this.pbCameraRegion);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(390, 330);
            this.panel4.TabIndex = 1;
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AllowUserToAddRows = false;
            this.dgvRecipe.AllowUserToDeleteRows = false;
            this.dgvRecipe.AllowUserToResizeColumns = false;
            this.dgvRecipe.AllowUserToResizeRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvRecipe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvRecipe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecipe.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column27,
            this.Column26,
            this.Num,
            this.Index,
            this.Column2,
            this.Column8});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecipe.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecipe.Location = new System.Drawing.Point(0, 0);
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.RowHeadersVisible = false;
            this.dgvRecipe.RowHeadersWidth = 40;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecipe.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvRecipe.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvRecipe.Size = new System.Drawing.Size(390, 293);
            this.dgvRecipe.TabIndex = 7;
            this.dgvRecipe.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRecipe_CurrentCellDirtyStateChanged);
            // 
            // Column27
            // 
            this.Column27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column27.HeaderText = "Used";
            this.Column27.Name = "Column27";
            this.Column27.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column27.Width = 50;
            // 
            // Column26
            // 
            this.Column26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column26.FillWeight = 152.6764F;
            this.Column26.HeaderText = "CR";
            this.Column26.Items.AddRange(new object[] {
            "N",
            "L",
            "R"});
            this.Column26.Name = "Column26";
            this.Column26.Width = 35;
            // 
            // Num
            // 
            this.Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Num.FillWeight = 27.8546F;
            this.Num.HeaderText = "No.";
            this.Num.Name = "Num";
            this.Num.ReadOnly = true;
            this.Num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Num.Width = 35;
            // 
            // Index
            // 
            this.Index.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Index.DefaultCellStyle = dataGridViewCellStyle20;
            this.Index.FillWeight = 46.79192F;
            this.Index.HeaderText = "Recipes";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "Parts";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 50;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column8.HeaderText = "Qty";
            this.Column8.Name = "Column8";
            this.Column8.Width = 60;
            // 
            // pbCameraRegion
            // 
            this.pbCameraRegion.Controls.Add(this.btSaveCameraRegion);
            this.pbCameraRegion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbCameraRegion.Image = global::Vision_Guided_Robot_Application.Properties.Resources.Blink;
            this.pbCameraRegion.Location = new System.Drawing.Point(0, 293);
            this.pbCameraRegion.Name = "pbCameraRegion";
            this.pbCameraRegion.Size = new System.Drawing.Size(390, 37);
            this.pbCameraRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCameraRegion.TabIndex = 6;
            this.pbCameraRegion.TabStop = false;
            // 
            // btSaveCameraRegion
            // 
            this.btSaveCameraRegion.BackColor = System.Drawing.Color.Transparent;
            this.btSaveCameraRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btSaveCameraRegion.Enabled = false;
            this.btSaveCameraRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSaveCameraRegion.Location = new System.Drawing.Point(0, 0);
            this.btSaveCameraRegion.Name = "btSaveCameraRegion";
            this.btSaveCameraRegion.Size = new System.Drawing.Size(390, 37);
            this.btSaveCameraRegion.TabIndex = 4;
            this.btSaveCameraRegion.Text = "Set up Recipe";
            this.btSaveCameraRegion.UseVisualStyleBackColor = false;
            this.btSaveCameraRegion.Click += new System.EventHandler(this.btSaveCameraRegion_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Index";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // R
            // 
            this.R.HeaderText = "R";
            this.R.Name = "R";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "No.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // timerAuto
            // 
            this.timerAuto.Tick += new System.EventHandler(this.timerAuto_Tick);
            // 
            // timerManual
            // 
            this.timerManual.Tick += new System.EventHandler(this.timerManual_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1584, 962);
            this.Controls.Add(this.splcScreen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "OUTSOLE AUTO STAMPING";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSystemAlarm)).EndInit();
            this.pbSystemAlarm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSystemReady)).EndInit();
            this.pbSystemReady.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSystemOn)).EndInit();
            this.pbSystemOn.ResumeLayout(false);
            this.splcScreen.Panel1.ResumeLayout(false);
            this.splcScreen.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcScreen)).EndInit();
            this.splcScreen.ResumeLayout(false);
            this.splcStatus.Panel1.ResumeLayout(false);
            this.splcStatus.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcStatus)).EndInit();
            this.splcStatus.ResumeLayout(false);
            this.gbUser.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            this.gbModeSwitch.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.gbMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbErrMode)).EndInit();
            this.pbErrMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbManualMode)).EndInit();
            this.pbManualMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAutoMode)).EndInit();
            this.pbAutoMode.ResumeLayout(false);
            this.splcMainScreen.Panel1.ResumeLayout(false);
            this.splcMainScreen.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcMainScreen)).EndInit();
            this.splcMainScreen.ResumeLayout(false);
            this.gbMainScreen.ResumeLayout(false);
            this.tcMainScreen.ResumeLayout(false);
            this.tpAuto.ResumeLayout(false);
            this.splcAuto.Panel1.ResumeLayout(false);
            this.splcAuto.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcAuto)).EndInit();
            this.splcAuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cRD)).EndInit();
            this.cRD.ResumeLayout(false);
            this.pnCRR.ResumeLayout(false);
            this.pnCRL.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.gbPosInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosInfo)).EndInit();
            this.gbProductionStatus.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbRun.ResumeLayout(false);
            this.tpManual.ResumeLayout(false);
            this.splcManual_Calib.Panel1.ResumeLayout(false);
            this.splcManual_Calib.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcManual_Calib)).EndInit();
            this.splcManual_Calib.ResumeLayout(false);
            this.splcManual.Panel1.ResumeLayout(false);
            this.splcManual.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcManual)).EndInit();
            this.splcManual.ResumeLayout(false);
            this.gbTestPrint.ResumeLayout(false);
            this.gbMoveToPos.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.gbPosition.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.gbManualMove.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.gbHome.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.gbSpeed.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarJogSpeedY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarJogSpeedX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarJogSpeedR)).EndInit();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel10.ResumeLayout(false);
            this.gbCalibrate.ResumeLayout(false);
            this.splcCalib.Panel1.ResumeLayout(false);
            this.splcCalib.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splcCalib)).EndInit();
            this.splcCalib.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalibResult)).EndInit();
            this.pnCalib.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditCalib)).EndInit();
            this.tpWaiting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            this.splc_Lived_Error.Panel1.ResumeLayout(false);
            this.splc_Lived_Error.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splc_Lived_Error)).EndInit();
            this.splc_Lived_Error.ResumeLayout(false);
            this.gbAnimation.ResumeLayout(false);
            this.pnConveyor.ResumeLayout(false);
            this.flpLivedLegend.ResumeLayout(false);
            this.flpLivedLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYAxis)).EndInit();
            this.gbError.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).EndInit();
            this.gbRecipe.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCameraRegion)).EndInit();
            this.pbCameraRegion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.SplitContainer splcScreen;
        private System.Windows.Forms.SplitContainer splcStatus;
        private System.Windows.Forms.GroupBox gbUser;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.ComboBox cbbUserID;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btManageUser;
        private System.Windows.Forms.Button btLogIn;
        private System.Windows.Forms.GroupBox gbMainScreen;
        private System.Windows.Forms.TabControl tcMainScreen;
        private System.Windows.Forms.TabPage tpAuto;
        private System.Windows.Forms.TabPage tpManual;
        private System.Windows.Forms.GroupBox gbPosInfo;
        private System.Windows.Forms.DataGridView dgvPosInfo;
        private System.Windows.Forms.Button btClearPosInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Timer timerAuto;
        private System.Windows.Forms.Timer timerManual;
        private System.Windows.Forms.Button btAutoMode;
        private System.Windows.Forms.Button btManualMode;
        private System.Windows.Forms.Button btErrMode;
        private System.Windows.Forms.GroupBox gbMode;
        private System.Windows.Forms.SplitContainer splcMainScreen;
        private System.Windows.Forms.GroupBox gbError;
        private System.Windows.Forms.GroupBox gbRecipe;
        private System.Windows.Forms.SplitContainer splcAuto;
        private System.Windows.Forms.Button btnClearErr;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.SplitContainer splcManual;
        private System.Windows.Forms.GroupBox gbSpeed;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TrackBar trackbarJogSpeedR;
        private System.Windows.Forms.Button btSetSpeed;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.TextBox tbJogSpeedX;
        private System.Windows.Forms.TextBox tbJogSpeedY;
        private System.Windows.Forms.TextBox tbJogSpeedR;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.GroupBox gbCalibrate;
        private System.Windows.Forms.SplitContainer splcCalib;
        private System.Windows.Forms.DataGridView dgvCalibData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvCalibResult;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnCalib;
        private System.Windows.Forms.Button btCalibInitialize;
        private System.Windows.Forms.GroupBox gbProductionStatus;
        private System.Windows.Forms.GroupBox gbRun;
        private System.Windows.Forms.SplitContainer splcManual_Calib;
        private System.Windows.Forms.GroupBox gbTestPrint;
        private System.Windows.Forms.Button btTestPrint;
        private System.Windows.Forms.GroupBox gbMoveToPos;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbPosition;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbPosX;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lbPosY;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lbPosR;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lbEnc;
        private System.Windows.Forms.GroupBox gbManualMove;
        private System.Windows.Forms.Button btJogNegX;
        private System.Windows.Forms.Button btJogPosX;
        private System.Windows.Forms.Button btJogPosY;
        private System.Windows.Forms.Button btJogNegY;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Button btJogNegR;
        private System.Windows.Forms.Button btJogPosR;
        private System.Windows.Forms.GroupBox gbHome;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Button btJogHomeX;
        private System.Windows.Forms.Button btJogHomeY;
        private System.Windows.Forms.Button btJogHomeR;
        private System.Windows.Forms.Button btJogHome;
        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditCalib;
        private System.Windows.Forms.Button btCalibSave;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Button btCalib;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Button btCalibXYRobot;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Button btCalibCamera;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Button btCalibEnc;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbCalibInitialize;
        private System.Windows.Forms.Label lbCalibInitialize;
        private System.Windows.Forms.Button btCalibReset;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TrackBar trackbarJogSpeedY;
        private System.Windows.Forms.TrackBar trackbarJogSpeedX;
        private System.Windows.Forms.Button btTakePicture;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button btConfig;
        private System.Windows.Forms.TextBox tbMoveX;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox tbMoveY;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox tbMoveR;
        private System.Windows.Forms.Button btManualMove;
        private System.Windows.Forms.Panel pnConveyor;
        private System.Windows.Forms.PictureBox pbXAxis;
        private System.Windows.Forms.PictureBox pbYAxis;
        private System.Windows.Forms.GroupBox gbAnimation;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.SplitContainer splc_Lived_Error;
        private System.Windows.Forms.TabPage tpWaiting;
        private System.Windows.Forms.GroupBox gbModeSwitch;
        private System.Windows.Forms.DataGridView dgvError;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.PictureBox pictureBox17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.Button btSaveCameraRegion;
        private System.Windows.Forms.PictureBox pbCameraRegion;
        private System.Windows.Forms.DataGridView dgvRecipe;
        private System.Windows.Forms.Button btAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column22;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column24;
        private System.Windows.Forms.FlowLayoutPanel flpLivedLegend;
        private System.Windows.Forms.CheckBox cbLivedRobot;
        private System.Windows.Forms.CheckBox cbLivedObject;
        private System.Windows.Forms.CheckBox cbLivedPrinting;
        private System.Windows.Forms.PictureBox pbSystemAlarm;
        private System.Windows.Forms.Label lbSystemAlarm;
        private System.Windows.Forms.PictureBox pbSystemReady;
        private System.Windows.Forms.Label lbSystemReady;
        private System.Windows.Forms.PictureBox pbSystemOn;
        private System.Windows.Forms.Label lbSystemOn;
        private System.Windows.Forms.PictureBox pbErrMode;
        private System.Windows.Forms.Label lbErrorMode;
        private System.Windows.Forms.PictureBox pbManualMode;
        private System.Windows.Forms.Label lbManualMode;
        private System.Windows.Forms.PictureBox pbAutoMode;
        private System.Windows.Forms.Label lbAutoMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbSystemStatus;
        private System.Windows.Forms.Label lbRecog;
        private System.Windows.Forms.Label lbFinished;
        private System.Windows.Forms.Label lbFail;
        private System.Windows.Forms.Label lbConveyorSpeed;
        private System.Windows.Forms.Label lbCT;
        private System.Windows.Forms.Label lbSystemStatusR;
        private System.Windows.Forms.Label lbRecogR;
        private System.Windows.Forms.Label lbFinishedR;
        private System.Windows.Forms.Label lbFailR;
        private System.Windows.Forms.Label lbConveyorSpeedR;
        private System.Windows.Forms.Label lbCTR;
        private Cognex.VisionPro.CogRecordDisplay cRD;
        private System.Windows.Forms.Label lbSeparate_L;
        private System.Windows.Forms.Panel pnCRR;
        private System.Windows.Forms.Panel pnCRL;
        private System.Windows.Forms.Label lbRight;
        private System.Windows.Forms.Label lbLeft;
        private System.Windows.Forms.Label lbSeparate_R;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column27;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column26;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}

