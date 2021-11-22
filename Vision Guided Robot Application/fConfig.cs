using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using MachineTools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Vision_Guided_Robot_Application.Config_Prod;

namespace Vision_Guided_Robot_Application
{
    public partial class fConfig : Form
    {
        #region Properties
        string FilePathConn;
        string FilePathHW;
        string FilePathOP;

        public int ConfigIndex;
        private bool IsOperator;

        //BarcodeLib.Barcode code128;

        private Config_Connection conn;
        private Config_HardWare hw;
        private CogToolBlock tbFifo;
        private PickPlaceDeltaRobot_Communication rB;
        private Language languageInfo;

        public Config_Connection CONN { get => conn; set => conn = value; }
        public Config_HardWare HW { get => hw; set => hw = value; }
        public CogToolBlock TbFifo { get => tbFifo; set => tbFifo = value; }
        public PickPlaceDeltaRobot_Communication RB { get => rB; set => rB = value; }
        public Config_Operational OP { get; set; }
        public Language LanguageInfo { get => languageInfo; set => languageInfo = value; }

        #endregion

        #region Initialize
        public fConfig(Config_Connection conn, Config_HardWare hw, CogToolBlock tbFifo, PickPlaceDeltaRobot_Communication rB, Config_Operational op, Language languageInfo, bool isOperator, List<string> configList)
        {
            InitializeComponent();
            this.CONN = conn;
            this.HW = hw;
            this.TbFifo = tbFifo;
            this.RB = rB;
            this.OP = op;
            this.LanguageInfo = languageInfo;
            IsOperator = isOperator;

            FilePathConn = CONN.FilePath;
            FilePathHW = HW.FilePath;
            FilePathOP = OP.FilePath;

            cbbConfig.DataSource = configList;
            tcConfig.ItemSize = new Size(0, 1);

            Language language = new Language();
            language.LoadLanguageFile(Language.translateConfigPath);
            language.ChangeLanguageControl(this, language.controlList);

            //code128 = new BarcodeLib.Barcode();
        }
        #endregion

        #region ChooseConfig & SaveConfig
        private void cbbConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvConfig.Rows.Clear();
            ShowConfig(cbbConfig.SelectedIndex);
        }
        private void ShowConfig(int configIndex)
        {
            switch (configIndex)
            {
                case 0://Recipe & Product
                    if (IsOperator) CollaspScreen(Collasp.Recipe_Operator);
                    else
                    {
                        CollaspScreen(Collasp.Recipe_Technician);
                        LoadAllPRoduct();
                    }
                    break;
                case 1://Language
                    CollaspScreen(Collasp.Language);
                    if (!LoadLanguage()) Error.SetErr(110);
                    break;
                   
                case 2://Hardware
                    CollaspScreen(Collasp.Hardware);
                    if(!LoadConfigHW(FilePathHW)) Error.SetErr(55); ;
                    break;
                case 3://Camera
                    CollaspScreen(Collasp.Camera);
                    cTBE.Subject = (CogToolBlock)CogSerializer.DeepCopyObject(TbFifo);
                    break;
                case 4://Connection
                    CollaspScreen(Collasp.Connection);
                    if(!LoadConfigHW(FilePathConn)) Error.SetErr(54);
                    break;
                case 5: //Robot
                    CollaspScreen(Collasp.Robot);
                    LoadConfigRobot();
                    break;
                default:
                    break;
            }
        }
        private void btSaveConfig_Click(object sender, EventArgs e)
        {
            switch (cbbConfig.SelectedIndex)
            {
                case 0://Recipe & Product
                    if (SaveConfigOP(FilePathOP) == false)
                    {
                        MessageBox.Show(Mes.MesList[38].Text, Mes.MesList[38].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ConfigIndex = 0;
                    break;
                case 1://Language
                    LanguageInfo.SaveLangaugeIndex(Language.LanguageIndex);
                    ConfigIndex = 1;
                    break;
                case 2://Hardware
                    SaveConfigHW(FilePathHW);
                    ConfigIndex = 2;
                    break;
                case 3://Camera
                    TbFifo = cTBE.Subject;
                    VisionTool.SaveVpp(Application.StartupPath + @"\Config\Fifo.vpp", TbFifo);
                    ConfigIndex = 3;
                    break;
                case 4://Connection
                    SaveConfigHW(FilePathConn);
                    ConfigIndex = 4;
                    break;
                case 5: //Robot
                    SaveConfigRobot();
                    ConfigIndex = 5;
                    break;
                default:
                    break;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void fConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }
        #endregion

        #region Config Language
        private bool LoadLanguage()
        {
            flpConfigLanguage.Controls.Clear();
            try
            {
                foreach (string language in LanguageInfo.languageList)
                {
                    RadioButton rb = new RadioButton() { Text = language };
                    rb.CheckedChanged += Rb_CheckedChanged;
                    flpConfigLanguage.Controls.Add(rb);
                }
                int i = 0;
                foreach (RadioButton rb in flpConfigLanguage.Controls)
                {
                    if (i == Language.LanguageIndex)
                    {
                        rb.Checked = true;
                        break;
                    }
                    i++;
                }
                return true;
            }
            catch
            {
                return false;
            }
         
          
        }
        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            int i = 0;
            foreach (RadioButton radiobutton in flpConfigLanguage.Controls)
            {
                if (radiobutton == rb)
                {
                    Language.LanguageIndex = i;
                    break;
                }
                i++;
            }
        }
        #endregion

        #region Config HW & Config Connection
        public bool LoadConfigHW(string filePath)
        {
            try
            {
                SortedList<string, string> configs = Tools.XMLLoad(filePath);
                dgvConfig.Rows.Insert(0, configs.Count);
                int i = 0;
                foreach (KeyValuePair<string, string> kvp in configs)
                {
                    dgvConfig.Rows[i].Cells[0].Value = kvp.Key;
                    dgvConfig.Rows[i].Cells[1].Value = kvp.Value;
                    i++;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveConfigHW(string filePath)
        {
            try
            {
                Tools.Param_Class[] xmlHW = new Tools.Param_Class[dgvConfig.RowCount];
                for (int i = 0; i < xmlHW.Count(); i++)
                {
                    xmlHW[i] = new Tools.Param_Class
                    {
                        ElementName = dgvConfig.Rows[i].Cells[0].Value.ToString(),
                        Element = dgvConfig.Rows[i].Cells[1].Value.ToString()
                    };
                }
                Tools.XMLSave(filePath, xmlHW);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        #endregion

        #region Config Robot
        public bool LoadConfigRobot()
        {
            try
            {
                RB.ReadRBParameter();
                dgvConfig.Rows.Insert(0, 8);
                dgvConfig.Rows[0].Cells[0].Value = "V_ROBOT_XY_MAXSPEED_SETTING";
                dgvConfig.Rows[1].Cells[0].Value = "V_ROBOT_RAxis_SPEED_SETTING";
                dgvConfig.Rows[2].Cells[0].Value = "PosX_LIMITPOSITIVE_SETTING";
                dgvConfig.Rows[3].Cells[0].Value = "PosX_LIMITNEGATIVE_SETTING";
                dgvConfig.Rows[4].Cells[0].Value = "PosY_LIMITPOSITIVE_SETTING";
                dgvConfig.Rows[5].Cells[0].Value = "PosY_LIMITNEGATIVE_SETTING";
                dgvConfig.Rows[6].Cells[0].Value = "PRINT_DISTANCE_XY_SETTING";
                dgvConfig.Rows[7].Cells[0].Value = "PRINT_SPEED_XY_SETTING";

                dgvConfig.Rows[0].Cells[1].Value = RB.RBLimit[0].ToString("0.000");
                dgvConfig.Rows[1].Cells[1].Value = RB.RBLimit[1].ToString("0.000");
                dgvConfig.Rows[2].Cells[1].Value = RB.RBLimit[2].ToString("0.000");
                dgvConfig.Rows[3].Cells[1].Value = RB.RBLimit[3].ToString("0.000");
                dgvConfig.Rows[4].Cells[1].Value = RB.RBLimit[4].ToString("0.000");
                dgvConfig.Rows[5].Cells[1].Value = RB.RBLimit[5].ToString("0.000");
                dgvConfig.Rows[6].Cells[1].Value = RB.RBPrint[0].ToString("0.000");
                dgvConfig.Rows[7].Cells[1].Value = RB.RBPrint[1].ToString("0.000");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveConfigRobot()
        {
            try
            {
                Single.TryParse(dgvConfig.Rows[0].Cells[1].Value.ToString(), out RB.RBLimit[0]);
                Single.TryParse(dgvConfig.Rows[1].Cells[1].Value.ToString(), out RB.RBLimit[1]);
                Single.TryParse(dgvConfig.Rows[2].Cells[1].Value.ToString(), out RB.RBLimit[2]);
                Single.TryParse(dgvConfig.Rows[3].Cells[1].Value.ToString(), out RB.RBLimit[3]);
                Single.TryParse(dgvConfig.Rows[4].Cells[1].Value.ToString(), out RB.RBLimit[4]);
                Single.TryParse(dgvConfig.Rows[5].Cells[1].Value.ToString(), out RB.RBLimit[5]);
                Single.TryParse(dgvConfig.Rows[6].Cells[1].Value.ToString(), out RB.RBPrint[0]);
                Single.TryParse(dgvConfig.Rows[7].Cells[1].Value.ToString(), out RB.RBPrint[1]);
                RB.WriteRBParameter();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Config OP
        public bool SaveConfigOP(string filePath)
        {
            try
            {
                Tools.Param_Class[] xmlOP = new Tools.Param_Class[dgvChosenRecipes.RowCount*4];
                int j = 0;
                int prodCount = 0, recipeCount = 0;
                for (int i = 0; i < xmlOP.Count(); i+=4)
                {
                    xmlOP[i] = new Tools.Param_Class
                    {
                        ElementName = "Used" + j.ToString(),
                        Element = dgvChosenRecipes.Rows[j].Cells[0].Value.ToString()
                    };

                    xmlOP[i + 1] = new Tools.Param_Class
                    {
                        ElementName = "RecipeName" + j.ToString(),
                        Element = dgvChosenRecipes.Rows[j].Cells[3].Value.ToString()
                    };

                    xmlOP[i + 2] = new Tools.Param_Class
                    {
                        ElementName = "Qty" + j.ToString(),
                        Element = dgvChosenRecipes.Rows[j].Cells[4].Value.ToString()
                    };

                    xmlOP[i + 3] = new Tools.Param_Class
                    {
                        ElementName = "CR" + j.ToString(),
                        Element = (dgvChosenRecipes.Rows[j].Cells[1] as DataGridViewComboBoxCell).Items.IndexOf(dgvChosenRecipes.Rows[j].Cells[1].Value).ToString()
                    };

                    if (Convert.ToBoolean(dgvChosenRecipes.Rows[j].Cells[0].Value) == true)
                    {
                        prodCount += Convert.ToInt32(dgvChosenRecipes.Rows[j].Cells[4].Value);
                        recipeCount++;
                    }

                    j++;
                }
                if (prodCount > 12 || prodCount <= 0 || recipeCount <= 0 || recipeCount > 2)  return false;
                Tools.XMLSave(filePath, xmlOP);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
        #endregion

        #region Model
        string rootFolder = Application.StartupPath + "\\Training\\";
        void LoadAllPRoduct()
        {
            tvProductList.Nodes.Clear();
            if (Directory.Exists(rootFolder))
            {
                TreeNode root = new TreeNode() { Text = "Products" };
                tvProductList.Nodes.Add(root);
                LoadExplorer(root, 0);
                tvProductList.Nodes[0].Expand();
            }
        }
        void LoadExplorer(TreeNode root, int imageIndex)
        {
            if (root == null)
                return;
            try
            {
                var folderlist = new DirectoryInfo(rootFolder + "\\" + root.FullPath).GetDirectories();
                if (folderlist.Count() == 0)
                    return;

                foreach (DirectoryInfo item in folderlist)
                {
                    TreeNode node = new TreeNode()
                    {
                        Text = Path.GetFileName(item.FullName),
                        SelectedImageIndex = imageIndex,
                        ImageIndex = imageIndex,
                    };
                    root.Nodes.Add(node);
                    LoadExplorer(node, imageIndex + 1);
                }
            }
            catch
            {
                return;
            }
        }
        private void btSearch_Click(object sender, EventArgs e)
        {
            btSearch.Enabled = false;
            btDeleteSearch.Enabled = true;
            for (int i = 0; i < tvProductList.Nodes[0].Nodes.Count; i++)
            {
                String nodeText = tvProductList.Nodes[0].Nodes[i].Text.ToLower();
                String searchText = tbSearch.Text.ToLower();
                if (nodeText.Contains(searchText) == false)
                {
                    tvProductList.Nodes[0].Nodes.RemoveAt(i);
                    i--;
                }
            }
        }
        private void btDeleteSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            LoadAllPRoduct();
            btDeleteSearch.Enabled = false;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tvProductList.SelectedNode == null)
            {
                MessageBox.Show(Mes.MesList[36].Text, Mes.MesList[36].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgvRecipe.RowCount >= 6)
            {
                MessageBox.Show(Mes.MesList[4].Text, Mes.MesList[4].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbChosenRecipe.Text))
            {
                MessageBox.Show(Mes.MesList[5].Text, Mes.MesList[5].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string recipe = rootFolder + "\\" + tvProductList.SelectedNode.FullPath;
            if (string.IsNullOrEmpty(recipe)) return;
            FolderInfo folderInfo = CheckModelFolderPath(recipe);
            if (folderInfo.Level != 3)
            {
                MessageBox.Show(Mes.MesList[6].Text, Mes.MesList[6].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadProduct(folderInfo);
            btSaveRecipe.FlatStyle = FlatStyle.Popup;
        }
        private void btRemove_Click(object sender, EventArgs e)
        {
            if (dgvRecipe.SelectedRows == null) return;
            if (string.IsNullOrWhiteSpace(tbChosenRecipe.Text))
            {
                MessageBox.Show(Mes.MesList[5].Text, Mes.MesList[5].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvRecipe.Rows.RemoveAt(dgvRecipe.CurrentRow.Index);
            btSaveRecipe.FlatStyle = FlatStyle.Popup;
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSearch.Text) == false) btSearch.Enabled = true;
        }
        private void tbSearch_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btSearch;
            //this.CancelButton = btDeleteSearch;
        }
        private void tbSearch_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = btSaveConfig;
            //this.CancelButton = btCancel;
        }
        private void btCreateModel_Click(object sender, EventArgs e)
        {
            string recipe;
            if (tvProductList.SelectedNode == null) recipe = rootFolder + "Products";
            else recipe = rootFolder + tvProductList.SelectedNode.FullPath;

            if (string.IsNullOrEmpty(recipe)) return;
            FolderInfo folderInfo = CheckModelFolderPath(recipe);

            switch (folderInfo.Level)
            {
                case 3: // Have all info Code-Name-Orient-Color-Size
                    MessageBox.Show(Mes.MesList[9].Text, Mes.MesList[9].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 4: // Not in Product folder
                    MessageBox.Show(Mes.MesList[8].Text, Mes.MesList[8].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 5: // DefaultValue Item
                    MessageBox.Show(Mes.MesList[7].Text, Mes.MesList[7].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                default:
                    break;
            }

            fProductPath formProductPath = new fProductPath(folderInfo.Level, folderInfo.Code, folderInfo.Name, folderInfo.Orientation, folderInfo.Color, folderInfo.Size);
            formProductPath.ShowDialog();
            if (formProductPath.DialogResult == DialogResult.OK)
            {
                if (Config_Prod.isExist(formProductPath.InputText))
                {
                    MessageBox.Show(Mes.MesList[9].Text, Mes.MesList[9].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Splasher sp = new Splasher();
                sp.Show("Training loading...");
                fTraining frmTraining = new fTraining(TbFifo, formProductPath.InputText, formProductPath.InputText);
                sp.Close();
                frmTraining.ShowDialog();


                if (frmTraining.DialogResult == DialogResult.OK) LoadAllPRoduct();
            }
        }
        private void btEditModel_Click(object sender, EventArgs e)
        {
            if (tvProductList.SelectedNode == null)
            {
                MessageBox.Show(Mes.MesList[5].Text, Mes.MesList[5].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string recipe = rootFolder + "\\" + tvProductList.SelectedNode.FullPath;
            if (string.IsNullOrEmpty(recipe)) return;
            FolderInfo folderInfo = CheckModelFolderPath(recipe);

            if (folderInfo.Level != 3)
            {
                MessageBox.Show(Mes.MesList[6].Text, Mes.MesList[6].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fProductPath formProductPath = new fProductPath(folderInfo.Level, folderInfo.Code, folderInfo.Name, folderInfo.Orientation, folderInfo.Color, folderInfo.Size);

            if (formProductPath.DialogResult == DialogResult.OK)
            {
                Splasher sp = new Splasher();
                sp.Show("Training loading...");
                fTraining frmTraining = new fTraining(TbFifo, formProductPath.InputText, formProductPath.InputText);
                sp.Close();
                frmTraining.ShowDialog();

            }
        }
         private void btCloneModel_Click(object sender, EventArgs e)
        {
                if (tvProductList.SelectedNode == null)
            {
                MessageBox.Show(Mes.MesList[5].Text, Mes.MesList[5].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string recipe = rootFolder + "\\" + tvProductList.SelectedNode.FullPath;
            if (string.IsNullOrEmpty(recipe)) return;
            FolderInfo folderInfo = CheckModelFolderPath(recipe);

            if (folderInfo.Level != 3)
            {
                MessageBox.Show(Mes.MesList[6].Text, Mes.MesList[6].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fProductPath formProductPath = new fProductPath(0 , folderInfo.Code, folderInfo.Name, folderInfo.Orientation, folderInfo.Color, folderInfo.Size);
            formProductPath.ShowDialog();
            if (formProductPath.DialogResult == DialogResult.OK)
            {
                string openPath = folderInfo.Code + "_" + folderInfo.Name + "_" + folderInfo.Orientation + "\\" + folderInfo.Color + "\\" + folderInfo.Size;

                Splasher sp = new Splasher();
                sp.Show("Training Loading...");
                fTraining frmTraining = new fTraining(TbFifo, openPath, formProductPath.InputText);
                sp.Close();
                frmTraining.ShowDialog();
                

                if (frmTraining.DialogResult == DialogResult.OK) LoadAllPRoduct();
            }
        }
        private void btDeleteModel_Click(object sender, EventArgs e)
        {
            string recipe = rootFolder + "\\" + tvProductList.SelectedNode.FullPath;
            if (string.IsNullOrEmpty(recipe)) return;
            FolderInfo folderInfo = CheckModelFolderPath(recipe);
            if (folderInfo.Level == 5)
            {
                MessageBox.Show(Mes.MesList[7].Text, Mes.MesList[7].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (folderInfo.Level == 4)
            {
                MessageBox.Show(Mes.MesList[8].Text, Mes.MesList[8].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show(Mes.MesList[13].Text, Mes.MesList[13].Caption, MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                DeleteProduct(recipe);
                tvProductList.Nodes[0].Nodes.Remove(tvProductList.SelectedNode);
            }
        }
        private void DeleteProduct(string recipe)
        {
            DirectoryInfo di = new DirectoryInfo(recipe);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }
            Directory.Delete(recipe);
        }
        private void btClearAllModel_Click(object sender, EventArgs e)
        {
            dgvRecipe.Rows.Clear();
        }
        private void LoadProduct(FolderInfo productInfo)
        {
            dgvRecipe.Rows.Add();
            dgvRecipe.Rows[dgvRecipe.RowCount - 1].Cells[0].Value = dgvRecipe.RowCount;
            dgvRecipe.Rows[dgvRecipe.RowCount - 1].Cells[1].Value = productInfo.Code;
            dgvRecipe.Rows[dgvRecipe.RowCount - 1].Cells[2].Value = productInfo.Name;
            dgvRecipe.Rows[dgvRecipe.RowCount - 1].Cells[3].Value = productInfo.Orientation;
            dgvRecipe.Rows[dgvRecipe.RowCount - 1].Cells[4].Value = productInfo.Color;
            dgvRecipe.Rows[dgvRecipe.RowCount - 1].Cells[5].Value = productInfo.Size;
            dgvRecipe.FirstDisplayedScrollingRowIndex = dgvRecipe.RowCount - 1;
        }
        private FolderInfo CheckModelFolderPath(string path)
        {
            FolderInfo folderInfo = new FolderInfo() { Level = 0 };
            string pathClone = path.Clone().ToString();
            if (string.Compare(pathClone + "\\", Config_Prod.SetFolder) == 0) folderInfo.Level = 0;
            else if (pathClone == Config_Prod.SetFolder + "\\DefaultValue") folderInfo.Level = 5;
            else
            {
                bool isSetFolder = false;
                while (!isSetFolder)
                {
                    DirectoryInfo di = Directory.GetParent(pathClone);
                    if (di == null || folderInfo.Level >= 4)
                    {
                        isSetFolder = true;
                        folderInfo.Level = 4;
                    }
                    else
                    {
                        folderInfo.Level++;
                        pathClone = di.ToString();
                        if (string.Compare(pathClone + "\\", Config_Prod.SetFolder) == 0) isSetFolder = true;
                    }
                }
                if (folderInfo.Level == 1)
                {
                    string[] s = Path.GetFileName(path).Split('_');
                    folderInfo.Code = s[0];
                    folderInfo.Name = s[1];
                    folderInfo.Orientation = s[2];
                    folderInfo.Color = null;
                    folderInfo.Size = null;
                }
                else if (folderInfo.Level == 2)
                {
                    string[] s = Path.GetFileName(Directory.GetParent(path).ToString()).Split('_');
                    folderInfo.Code = s[0];
                    folderInfo.Name = s[1];
                    folderInfo.Orientation = s[2];
                    folderInfo.Color = Path.GetFileName(path);
                    folderInfo.Size = null;
                }
                else if (folderInfo.Level == 3)
                {
                    string[] s = Path.GetFileName(Directory.GetParent(Directory.GetParent(path).ToString()).ToString()).Split('_');
                    folderInfo.Code = s[0];
                    folderInfo.Name = s[1];
                    folderInfo.Orientation = s[2];
                    folderInfo.Color = Path.GetFileName(Directory.GetParent(path).ToString());
                    folderInfo.Size = Path.GetFileName(path);
                }
            }
            return folderInfo;
        }
        #endregion

        #region Recipe
        Config_Recipe config_Recipe = new Config_Recipe();
        List<string> recipeList = new List<string>();
        public void LoadRecipeList()
        {
            recipeList.Clear();
            for (int i = 0; i < dgvRecipeCollection.RowCount; i++)
            {
                recipeList.Add(dgvRecipeCollection.Rows[i].Cells[0].Value.ToString());
            }
        }
        private void LoadAllRecipe()
        {
            string[] recipeCollection = Config_Recipe.FindAll();
            if (recipeCollection.Count() <= 0) return;
            dgvRecipeCollection.Rows.Clear();
            dgvRecipeCollection.Rows.Insert(0, recipeCollection.Count());
            for (int i = 0; i < recipeCollection.Count(); i++)
            {
                dgvRecipeCollection.Rows[i].Cells[0].Value = recipeCollection[i];
            }
            dgvRecipeCollection.CurrentCell = null;
            dgvRecipe.Rows.Clear();
        }
        private void btCreateRecipe_Click(object sender, EventArgs e)
        {
            LoadRecipeList();
            fRecipe frmRecipe = new fRecipe();
            frmRecipe.ShowDialog();
            if (frmRecipe.DialogResult == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(frmRecipe.RName))
                {
                    MessageBox.Show(Mes.MesList[0].Text, Mes.MesList[0].Caption, MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    foreach (string recipeName in recipeList)
                    {
                        if (recipeName.Equals(frmRecipe.RName))
                        {
                            MessageBox.Show(Mes.MesList[1].Text, Mes.MesList[1].Caption, MessageBoxButtons.OK);
                            return;
                        }
                    }
                }
                dgvRecipeCollection.Rows.Add();
                dgvRecipeCollection.Rows[dgvRecipeCollection.RowCount - 1].Cells[0].Value = frmRecipe.RName;
                dgvRecipeCollection.CurrentCell = dgvRecipeCollection.Rows[dgvRecipeCollection.RowCount - 1].Cells[0];
                dgvRecipe.Rows.Clear();

                config_Recipe.Name = frmRecipe.RName;
                config_Recipe.RunObj.Clear();
                tbChosenRecipe.Text = config_Recipe.Name;

                CollaspScreen(Collasp.Recipe_Create);
            }
            
        }
        private void dgvRecipeCollection_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            config_Recipe.Name = dgvRecipeCollection.CurrentCell.Value.ToString();
            tbChosenRecipe.Text = config_Recipe.Name;
            config_Recipe.Load(config_Recipe.Name);
            dgvRecipe.Rows.Clear();
            btSaveRecipe.FlatStyle = FlatStyle.Standard;
            for (int i = 0; i < config_Recipe.RunObj.Count(); i++)
            {
                FolderInfo folderInfo = CheckModelFolderPath(Config_Prod.SetFolder + config_Recipe.RunObj[i]);
                LoadProduct(folderInfo);
            }

        }
        private void btDeleteRecipe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChosenRecipe.Text)) return;

            DialogResult dr = MessageBox.Show(Mes.MesList[14].Text, Mes.MesList[14].Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                if (dgvRecipeCollection.CurrentCell.Value.ToString().Equals("Production") == true)
                {
                    MessageBox.Show(Mes.MesList[15].Text, Mes.MesList[15].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Config_Recipe.Del(dgvRecipeCollection.Rows[dgvRecipeCollection.CurrentRow.Index].Cells[0].Value.ToString());
                LoadAllRecipe();
            }

        }
        private void btSaveRecipe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChosenRecipe.Text)) return;

            DialogResult dr = MessageBox.Show(Mes.MesList[16].Text, Mes.MesList[16].Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                config_Recipe.RunObj.Clear();
                for (int i = 0; i < dgvRecipe.RowCount; i++)
                {
                    FolderInfo folderInfo = new FolderInfo()
                    {
                        Level = 3,
                        Code = dgvRecipe.Rows[i].Cells[1].Value.ToString(),
                        Name = dgvRecipe.Rows[i].Cells[2].Value.ToString(),
                        Orientation = dgvRecipe.Rows[i].Cells[3].Value.ToString(),
                        Color = dgvRecipe.Rows[i].Cells[4].Value.ToString(),
                        Size = dgvRecipe.Rows[i].Cells[5].Value.ToString(),
                    };
                    fProductPath formProductPath = new fProductPath(folderInfo.Level, folderInfo.Code, folderInfo.Name, folderInfo.Orientation, folderInfo.Color, folderInfo.Size);
                    if (formProductPath.DialogResult == DialogResult.OK)
                    {
                        config_Recipe.RunObj.Add(formProductPath.InputText);
                    }
                }
                config_Recipe.Save(config_Recipe.Name);

                string FilePath = Application.StartupPath + "\\Recipe\\" + config_Recipe.Name + ".xml";

                MessageBox.Show(Mes.MesList[17].Text, Mes.MesList[17].Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllRecipe();
                CollaspScreen(Collasp.Recipe_Save);
            }
        }
        private void btDeleteAllRecipe_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Mes.MesList[18].Text, Mes.MesList[18].Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                LoadRecipeList();
                foreach (string recipe in recipeList)
                {
                    if (recipe.Equals("Production") == false) Config_Recipe.Del(dgvRecipeCollection.Rows[dgvRecipeCollection.CurrentRow.Index].Cells[0].Value.ToString());
                }
                LoadAllRecipe();
            }
        }
        private void btDeleteAllProducts_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Mes.MesList[19].Text, Mes.MesList[19].Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                foreach (TreeNode item in tvProductList.Nodes[0].Nodes)
                {
                    DeleteProduct(rootFolder + "\\" + item.FullPath);
                }
                LoadAllPRoduct();
            }
        }
        private void btChooseRecipe_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChosenRecipe.Text))
            {
                MessageBox.Show(Mes.MesList[5].Text, Mes.MesList[5].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(dgvChosenRecipes.RowCount >= 12)
            {
                MessageBox.Show(Mes.MesList[37].Text, Mes.MesList[37].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvChosenRecipes.Rows.Add();
            dgvChosenRecipes.Rows[dgvChosenRecipes.RowCount - 1].Cells[0].Value = false;
            dgvChosenRecipes.Rows[dgvChosenRecipes.RowCount - 1].Cells[1].Value = (dgvChosenRecipes.Rows[dgvChosenRecipes.RowCount - 1].Cells[1] as DataGridViewComboBoxCell).Items[0];
            dgvChosenRecipes.Rows[dgvChosenRecipes.RowCount - 1].Cells[2].Value = dgvChosenRecipes.RowCount;
            dgvChosenRecipes.Rows[dgvChosenRecipes.RowCount - 1].Cells[3].Value = config_Recipe.Name;
            dgvChosenRecipes.Rows[dgvChosenRecipes.RowCount - 1].Cells[4].Value = config_Recipe.RunObj.Count();

        }
        private void btRemoveRecipe_Click(object sender, EventArgs e)
        {
            if (dgvChosenRecipes.SelectedRows == null || dgvChosenRecipes.CurrentRow == null || dgvChosenRecipes.RowCount == 0) return;
            dgvChosenRecipes.Rows.RemoveAt(dgvChosenRecipes.CurrentRow.Index);
        }

        private void btSearchRecipe_Click(object sender, EventArgs e)
        {
            btSearchRecipe.Enabled = false;
            btDeleteSearchRecipe.Enabled = true;
            for (int i = 0; i < dgvRecipeCollection.RowCount; i++)
            {
                string text = dgvRecipeCollection.Rows[i].Cells[0].Value.ToString().ToLower();
                string searchText = tbChosenRecipe.Text.ToLower();
                if (text.Contains(searchText) == false)
                {
                    dgvRecipeCollection.Rows.RemoveAt(i);
                    i--;
                }
            }
        }

        private void btDeleteSearchRecipe_Click(object sender, EventArgs e)
        {
            tbChosenRecipe.Text = "";
            LoadAllRecipe();
            btDeleteSearchRecipe.Enabled = false;
        }

        private void tbChosenRecipe_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChosenRecipe.Text) == false) btSearchRecipe.Enabled = true;
        }

        private void LoadCurrentRecipes()
        {
            if (OP.RecipeName.Count() <= 0) return;
            dgvChosenRecipes.Rows.Clear();
            dgvChosenRecipes.Rows.Insert(0, OP.RecipeName.Count());
            for (int i = 0; i < dgvChosenRecipes.RowCount; i++)
            {
                dgvChosenRecipes.Rows[i].Cells[0].Value = OP.Used[i];
                dgvChosenRecipes.Rows[i].Cells[1].Value = (dgvChosenRecipes.Rows[i].Cells[1] as DataGridViewComboBoxCell).Items[OP.CR[i]];
                dgvChosenRecipes.Rows[i].Cells[2].Value = i + 1;
                dgvChosenRecipes.Rows[i].Cells[3].Value = OP.RecipeName[i];
                dgvChosenRecipes.Rows[i].Cells[4].Value = OP.fileQty_of_Recipe[i];
            }
        }

        private void btClearAllChosenRecipe_Click(object sender, EventArgs e)
        {
            dgvChosenRecipes.Rows.Clear();
        }
        #endregion

        #region SplitContainer
        private enum Collasp
        {
            Language,
            Recipe_Operator,
            Recipe_Technician,
            Recipe_Create,
            Recipe_Save,
            Hardware,
            Camera,
            Connection,
            Robot,
        }

        private void CollaspScreen(Collasp circumtance)
        {
            switch (circumtance)
            {
                case Collasp.Language:
                    tcConfig.SelectedIndex = 0;
                    this.Size = new Size(555, 800);
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    break;
                case Collasp.Recipe_Operator:
                    tcConfig.SelectedIndex = 3;
                    this.Size = new Size(900, 800);
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    splcRecipe.Panel1Collapsed = true;
                    pnRecipeManipulation.Visible = false;
                    btClearAllModel.Visible = false;
                    LoadAllRecipe();
                    LoadCurrentRecipes();
                    break;
                case Collasp.Recipe_Technician:
                    tcConfig.SelectedIndex = 3;
                    this.Size = new Size(1350, 800);
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    splcRecipe.Panel1Collapsed = false;
                    splcRecipe.SplitterDistance = 458;
                    pnRecipeManipulation.Visible = true;
                    btClearAllModel.Visible = true;
                    LoadAllRecipe();
                    LoadCurrentRecipes();
                    break;
                case Collasp.Recipe_Create:
                    btCreateModel.Enabled = false;
                    btEditModel.Enabled = false;
                    btCloneModel.Enabled = false;
                    btDeleteModel.Enabled = false;

                    btCreateRecipe.Enabled = false;
                    btDeleteRecipe.Enabled = false;

                    btChooseRecipe.Enabled = false;
                    btRemoveRecipe.Enabled = false;

                    btSaveConfig.Enabled = false;
                    dgvRecipeCollection.Enabled = false;
                    btSaveRecipe.FlatStyle = FlatStyle.Popup;
                    break;
                case Collasp.Recipe_Save:
                    btCreateModel.Enabled = true;
                    btEditModel.Enabled = true;
                    btCloneModel.Enabled = true;
                    btDeleteModel.Enabled = true;

                    btCreateRecipe.Enabled = true;
                    btDeleteRecipe.Enabled = true;

                    btChooseRecipe.Enabled = true;
                    btRemoveRecipe.Enabled = true;

                    btSaveConfig.Enabled = true;
                    dgvRecipeCollection.Enabled = true;
                    btSaveRecipe.FlatStyle = FlatStyle.Standard;
                    break;
                case Collasp.Hardware:
                    tcConfig.SelectedIndex = 1;
                    this.Size = new Size(555, 800);
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    break;
                case Collasp.Camera:
                    tcConfig.SelectedIndex = 2;
                    this.Size = new Size(1250, 800);
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    break;
                case Collasp.Connection:
                    tcConfig.SelectedIndex = 1;
                    this.Size = new Size(555, 800);
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    break;
                case Collasp.Robot:
                    tcConfig.SelectedIndex = 1;
                    this.Size = new Size(555, 800);
                    this.FormBorderStyle = FormBorderStyle.Fixed3D;
                    break;
                default:
                    break;
            }
        }
        //private void btBCGenerate_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(tbChosenRecipe.Text))
        //    {
        //        MessageBox.Show(Mes.MesList[5].Text, Mes.MesList[5].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    Splasher sp = new Splasher();
        //    sp.Show("Barcode generating...");

        //    List<string> barcodeFileName = new List<string>();
        //    barcodeFileName.Add(tbChosenRecipe.Text + "0");
        //    barcodeFileName.Add(tbChosenRecipe.Text + "1");
        //    barcodeFileName.Add(tbChosenRecipe.Text + "2");

        //    foreach (string item in barcodeFileName)
        //    {
        //        Image img = code128.Encode(TYPE.CODE128, item, 800, 600);
        //        img.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + item + ".jpg", ImageFormat.Jpeg);
        //    }
        //    sp.Close();
        //}
        #endregion

    }
}
