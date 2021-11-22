using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using MachineTools;

namespace Vision_Guided_Robot_Application
{
    public class Barcode
    {
        #region Properties
        private Config_Connection config_Conn;
        private Config_HardWare config_HW;
        private frmMain f;
        private DataGridView dgvRecipe;

        public Config_Connection Config_Conn { get => config_Conn; set => config_Conn = value; }
        public Config_HardWare Config_HW { get => config_HW; set => config_HW = value; }
        public frmMain F { get => f; set => f = value; }
        public DataGridView DgvRecipe { get => dgvRecipe; set => dgvRecipe = value; }

        public static SerialPort spBarcode;
        public static Timer timerBarcode;

        public class Info
        {
            public int RecipeIndex;
            public int CR;
        }
        public List<Info> infoList;
        public static string code128;
        public static bool isAutoModeRunning;
        private bool barcodeDetect = true;
        public static bool isAutoChangeRecipe;

        #endregion

        #region Initialize
        public Barcode(Config_Connection config_Conn, Config_HardWare config_HW, frmMain f, DataGridView dgvRecipe)
        {
            this.Config_Conn = config_Conn;
            this.Config_HW = config_HW;
            this.F = f;
            this.DgvRecipe = dgvRecipe;

            timerBarcode = new Timer() { Interval = Config_HW.BarcodeDetectTime };
            spBarcode = new SerialPort()
            {
                BaudRate = 9600,
                DataBits = 8,
                DtrEnable = true,
                Parity = Parity.None,
                StopBits = StopBits.One,
                RtsEnable = true,
            };

            timerBarcode.Tick += TimerBarcode_Tick;
            spBarcode.DataReceived += SpBarcode_DataReceived;
        }

        private void SpBarcode_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            code128 += spBarcode.ReadExisting();

            if (!isAutoModeRunning) return;

            if (barcodeDetect)
            {
                code128 = null;
                barcodeDetect = false;

                F.Invoke(new MethodInvoker(delegate ()
                {
                    timerBarcode.Start();
                }));
            }
            

        }

        private void TimerBarcode_Tick(object sender, EventArgs e)
        {
            isAutoChangeRecipe = true;
            F.btRun_Click(null, null);

            barcodeDetect = true;
            timerBarcode.Stop();
            if(ChangeRecipes())
            {
                F.btSaveCameraRegion_Click(null, null);
            }

            if (!isAutoModeRunning) F.btRun_Click(null, null);
            isAutoChangeRecipe = false;
        }
        #endregion

        #region Terminate
        ~Barcode()
        {
            spBarcode.Close();
        }


        #endregion

        #region Methods
        public void Connect()
        {
            try
            {
                if (spBarcode.IsOpen) spBarcode.Close();
                spBarcode.PortName = Config_Conn.BarcodePort;
                spBarcode.Open();
            }
            catch
            {
                Error.SetErr(170);
            }
        }

        public void Encode()
        {
            infoList = new List<Info>();
            if (string.IsNullOrWhiteSpace(code128)) return;

            code128 = code128.Remove(code128.Length - 1);
            String[] recipes = code128.Split('\r');

            List<string> recipeList = recipes.ToList();
            //if (recipeList.Count() > 2) recipeList.RemoveRange(2, recipeList.Count - 2);

            for (int i = 0; i < recipeList.Count(); i++)
            {
                try
                {
                    Info info = new Info
                    {
                        CR = Convert.ToInt32(recipeList[i][recipeList[i].Count() - 1].ToString()),
                        RecipeIndex = Convert.ToInt32(recipeList[i].Remove(recipeList[i].Count() - 1, 1))
                    };
                    if(info.RecipeIndex>=1&&info.RecipeIndex<=12 &&info.CR>=0&&info.CR<=2) infoList.Add(info);
                }
                catch { }
               
                if (infoList.Count() >= 2) break;
            }
        }

        public bool ChangeRecipes()
        {
            bool noRecipe = true;
            Encode();
            if (infoList.Count == 0) return false;

            for (int i = 0; i < DgvRecipe.RowCount; i++)
            {
                for (int j = 0; j < infoList.Count; j++)
                {
                    if ((i + 1) == infoList[j].RecipeIndex)
                    {
                        DgvRecipe.Rows[i].Cells[0].Value = true;
                        DgvRecipe.Rows[i].Cells[1].Value = (DgvRecipe.Rows[i].Cells[1] as DataGridViewComboBoxCell).Items[infoList[j].CR];
                        noRecipe = false;
                        break;
                    }
                    else DgvRecipe.Rows[i].Cells[0].Value = false;
                }
            }
            if (noRecipe) return false;
            return true;
        }
        #endregion
    }
}
