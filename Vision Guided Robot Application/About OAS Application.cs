using System;
using System.Windows.Forms;

namespace Vision_Guided_Robot_Application
{
    public partial class About_OAS_Application : Form
    {
        public About_OAS_Application()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
