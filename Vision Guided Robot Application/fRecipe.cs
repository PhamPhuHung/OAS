using System;
using System.Windows.Forms;

namespace Vision_Guided_Robot_Application
{
    public partial class fRecipe : Form
    {
        public string RName;


        public fRecipe()
        {
            InitializeComponent();

            Language language = new Language();
            language.LoadLanguageFile(Language.translateRecipePath);
            language.ChangeLanguageControl(this, language.controlList);
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRecipeName.Text))
            {
                return;
            }
            
            char[] invalidChars = { '\\', '/', ':', '*', '?', '|', '"', '<', '>', '_', '-' };
            foreach (char c in invalidChars)
            {
                if (tbRecipeName.Text.IndexOf(c) != -1)
                {
                    MessageBox.Show(Mes.MesList[28].Text, Mes.MesList[28].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            RName = tbRecipeName.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbRecipeName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbRecipeName.Text)) btOk.Visible = false;
            else btOk.Visible = true;
        }
    }
}
