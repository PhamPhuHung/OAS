using System;
using System.Collections.Generic;
using System.IO;
using MachineTools.Splash;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Xml;

namespace MachineTools
{
    public class Tools
    {
        public static string[] GetDirList(string GetPath)
        {
            List<string> NameList = new List<string>();
            if (Directory.Exists(GetPath))
            {
                NameList.Clear();
                DirectoryInfo DI = new DirectoryInfo(GetPath);
                DirectoryInfo[] DIChild = DI.GetDirectories();
                foreach (DirectoryInfo d in DIChild)
                {
                    NameList.Add(d.Name);
                }

            }
            return NameList.ToArray();
        }

        public static string[] GetFileList_WithoutExtension(string GetPath)
        {
            List<string> NameList = new List<string>();
            if (Directory.Exists(GetPath))
            {
                NameList.Clear();
                DirectoryInfo DI = new DirectoryInfo(GetPath);
                FileInfo[] FI= DI.GetFiles();
                foreach (FileInfo f in FI)
                {
                    NameList.Add(Path.GetFileNameWithoutExtension( f.FullName));
                }

            }
            return NameList.ToArray();
        }
        /// <summary>找尋CC內所有的類型為"T"的CONTROLS，將其加入到OBJLIST
        /// 
        /// </summary>
        /// <typeparam name="T">要找尋的類型</typeparam>
        /// <param name="CC">容器</param>
        /// <param name="ObjList">找到的清單</param>
        public static void searchControl<T>(Control CC, ref List<object> ObjList)
        {
            foreach (Control c in CC.Controls)
            {
                if (c.HasChildren)
                    searchControl<T>(c, ref ObjList);
                if (c is T)
                    ObjList.Add(c);
            }
        }

        public static bool SaveSetting(Control SaveControl, string FilePath)
        {
            List<object> ObjList = new List<object>();
            searchControl<SettingTextBox>(SaveControl, ref ObjList);
            try
            {
                List<object> list_O = new List<object>();
                List<Param_Class> List_P = new List<Param_Class>();

                if (list_O.Count > 0)
                {
                    //更新目前的設定到datatable
                    foreach (TextBox txt in list_O)
                    {
                        List_P.Add(new Param_Class(txt.Name, txt.Text));
                    }
                    XMLSave(FilePath, List_P.ToArray());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadSetting(Control SaveControl, string FilePath)
        {
            try
            {
                List<object> list_O = new List<object>();
                SortedList<string, string> sl;
                searchControl<SettingTextBox>(SaveControl, ref list_O);
                if (list_O.Count > 0)
                {
                    sl = XMLLoad(FilePath);
                    //更新目前的設定到datatable
                    foreach (TextBox txt in list_O)
                    {
                        if (sl.ContainsKey(txt.Name))
                        {
                            txt.Text = (string)sl[txt.Name];
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void XMLSave(string FilePath, Param_Class[] P)
        {

            XmlDocument doc = new XmlDocument();
            //建立根節點
            XmlElement company = doc.CreateElement("Parameter");
            doc.AppendChild(company);
            //建立子節點
            foreach (Param_Class p in P)
            {
                XmlElement department = doc.CreateElement(p.ElementName);
                department.SetAttribute("Value", p.Element);                     //設定屬性
                company.AppendChild(department);                                  //加入至company節點底下
            }
            if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            doc.Save(FilePath);
        }

        public static SortedList<string, string> XMLLoad(string FilePath)
        {
            SortedList<string, string> sl = new SortedList<string, string>();
            if (File.Exists(FilePath))
            {
                XmlDocument doc = new XmlDocument();
                XmlElement XE;
                string XValue;
                doc.Load(FilePath);
                //選擇節點
                XmlNode XN = doc.SelectSingleNode("Parameter");
                if (XN == null)
                    return sl;
                //找子節點丟到hashtable裡
                foreach (XmlNode xnA in XN)
                {
                    XE = (XmlElement)xnA;
                    XValue = XE.GetAttribute("Value");

                    sl.Add(XE.Name, XValue);
                }
            }
            return sl;
        }
        public class Param_Class
        {
            public Param_Class()
            { }
            public Param_Class(string _ElementName, string _Element)
            {
                ElementName = _ElementName;
                Element = _Element;

            }
            public string ElementName;
            public string Element;
        }
    }
    public class Splasher
    {
        private frmSplash MySplashForm;

        private Thread MySplashThread;
        private void ShowThread()
        {
            Application.Run(MySplashForm);
        }
        DateTime dt = DateTime.Now;
        public string mStatus
        {
            get
            {
                if (MySplashForm == null)
                    return "";
                else
                    return MySplashForm.Status;
            }
            set
            {
                if (MySplashForm == null)
                    return;
                MySplashForm.Status = value;
            }
        }

        public void Show(string strName)
        {
            if (MySplashThread != null)
                return;


            MySplashForm = new frmSplash();
            this.mStatus = strName;

            MySplashThread = new Thread(new ThreadStart(ShowThread));
            MySplashThread.IsBackground = true;
            MySplashThread.SetApartmentState(ApartmentState.STA);
            MySplashThread.Start();
            dt = DateTime.Now;
        }

        public void Close()
        {
            while ((DateTime.Now - dt).TotalMilliseconds < 200)
            {
                Thread.Sleep(10);
            }


            if (MySplashThread == null)
                return;

            if (MySplashForm == null)
                return;

            try
            {
                MySplashForm.Invoke(new MethodInvoker(MySplashForm.Close));
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show(ex.Message);
            }

            MySplashForm = null;
            MySplashThread = null;
        }

        
    }

}
[Designer(typeof(System.Windows.Forms.Design.ControlDesigner))]
public class SettingTextBox : TextBox
{
    public SettingTextBox()
    {
        isNumber = true;
        this.Text = "0";
        this.LostFocus += RecipeTextBox_LostFocus;
    }
    //[Browsable(true), Category("#Parameter"), Description("Title Label")]
    //public Label Title { get; set; }
    [Browsable(true), Category("#Parameter"), Description("Number")]
    public bool isNumber { get; set; }

    private void RecipeTextBox_LostFocus(object sender, EventArgs e)
    {
        double dbl;
        if (isNumber)
        {
            if (this.Text.Trim() == "")
            {
                this.Text = "0";
            }
            if (!double.TryParse(this.Text, out dbl))
            {
                this.Undo();
            }
        }
    }
}
