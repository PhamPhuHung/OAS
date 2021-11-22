using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Vision_Guided_Robot_Application
{
    public partial class fProductPath : Form
    {
        public string InputText = null;
        List<string> collections = new List<string>()
        {
            "#1", "#1T", "#1C", "#1Y", "#1.5",
            "#2", "#2T", "#2C", "#2Y", "#2.5",
            "#3", "#3T", "#3C", "#3Y", "#3.5",
            "#4", "#4T", "#4C", "#4Y", "#4.5",
            "#5", "#5T", "#5C", "#5Y", "#5.5",
            "#6", "#6T", "#6C", "#6Y", "#6.5",
            "#7", "#7T", "#7C", "#7Y", "#7.5",
            "#8", "#8T", "#8C", "#8Y", "#8.5",
            "#9", "#9T", "#9C", "#9Y", "#9.5",
            "#10", "#10T", "#10C", "#10Y", "#10.5",
            "#11", "#11T", "#11C", "#11Y", "#11.5",
            "#12", "#12T", "#12C", "#12Y", "#12.5",
            "#13", "#13T", "#13C", "#13Y", "#13.5",
            "#14", "#14T", "#14C", "#14Y", "#14.5",
            "#15", "#15T", "#15C", "#15Y", "#15.5",
            "#16", "#16T", "#16C", "#16Y", "#16.5",
            "#17", "#17T", "#17C", "#17Y", "#17.5",
            "#18", "#18T", "#18C", "#18Y", "#18.5"
        };
        public fProductPath(int pathLevel, string code, string name, string orientation, string color, string size)
        {
            InitializeComponent();
            cbbSize.DataSource = collections;

            Language language = new Language();
            language.LoadLanguageFile(Language.translateProductPath);
            language.ChangeLanguageControl(this, language.controlList);

            tbCode.Text = code;
            tbName.Text = name;
            cbbOrientation.SelectedItem =  orientation;
            tbColor.Text = color;
            cbbSize.SelectedItem = size;

            if (pathLevel >= 1)
            {
                tbCode.Enabled = false;
                tbName.Enabled = false;
                cbbOrientation.Enabled = false;
            }
            if (pathLevel >= 2)
            {
                tbColor.Enabled = false;
            }
            if (pathLevel == 3)
            {
                cbbSize.Enabled = false;
                btOK_Click(null, null);
            }
        }


        private void cbbSize_TextChanged(object sender, EventArgs e)
        {
            // get the keyword to search
            string textToSearch = cbbSize.Text.ToLower();
            listboxSize.Visible = false; // hide the listbox, see below for why doing that
            if (String.IsNullOrEmpty(textToSearch))
                return; // return with listbox hidden if the keyword is empty
                        //search
            string[] result = (from i in collections
                               where i.ToLower().Contains(textToSearch)
                               select i).ToArray();
            if (result.Length == 0)
                return; // return with listbox hidden if nothing found

            listboxSize.Items.Clear(); // remember to Clear before Add
            listboxSize.Items.AddRange(result);
            listboxSize.Visible = true; // show the listbox again
        }

        private void listBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbSize.SelectedItem = listboxSize.SelectedItem;
            listboxSize.Visible = false;
        }
        private void btOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbCode.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text) ||
                cbbOrientation.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(tbColor.Text) ||
                cbbSize.SelectedIndex == -1)
            {
                cbbOrientation.Text = null;
                cbbSize.Text = null;
                MessageBox.Show(Mes.MesList[29].Text, Mes.MesList[29].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            InputText = tbCode.Text + "_" + tbName.Text + "_" + cbbOrientation.SelectedItem.ToString() + "\\" + tbColor.Text + "\\" + cbbSize.SelectedItem.ToString();
            char[] invalidChars = { '\\', '/', ':', '*', '?', '|', '"', '<', '>', '_', '-' };
            foreach (char c in invalidChars)
            {
                if (tbCode.Text.IndexOf(c) != -1 ||
                    tbName.Text.IndexOf(c) != -1 ||
                    tbColor.Text.IndexOf(c) != -1)
                {
                    MessageBox.Show(Mes.MesList[28].Text, Mes.MesList[28].Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            DialogResult = DialogResult.OK;
            fProductPath_FormClosing(null, null);
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            fProductPath_FormClosing(null, null);
        }
        private void fProductPath_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }


    }
}
