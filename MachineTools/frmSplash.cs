using System;
using System.Windows.Forms;

namespace MachineTools.Splash
{

    public partial class frmSplash : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);//設置此窗體為活動窗體

        public frmSplash()
        {
            InitializeComponent();
        }
        private int count = 0;
        private String strStatus;
        delegate void delStatus();


        public string Status
        {
            get
            {
                return strStatus;
            }
            set
            {
                strStatus = value;
                ChangeText();
            }
        }

        private void ChangeText()
        {
            if (this.InvokeRequired)
            {
                delStatus m = new delStatus(ChangeText);
                this.Invoke(m);
            }
            else
                lblStatus.Text = strStatus;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value >= progressBar1.Minimum & progressBar1.Value < progressBar1.Maximum)
                count++;
            else
                count = 1;
            progressBar1.Value = count;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            this.Text = "";

            SetForegroundWindow(this.Handle);
            timer1.Enabled = true;
        }

        private void frmSplash_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }


    }
}




