using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MachineTools
{
    public partial class frmUserConfig : Form
    {
        DataSet dataSet1 = new DataSet();
        DataTable dt;
        const string DBName="DBName";
        public List<string> listUserName;

        public frmUserConfig()
        {
            InitializeComponent();
            CreateDB_Table();
            ReadData();
            LoadListUsername();

        }
        void CreateDB_Table()
        {
            SQLiteConnection sqlite_connect;
            SQLiteCommand sqlite_cmd;
            if (!File.Exists(Application.StartupPath + "\\" + DBName))
            {
                SQLiteConnection.CreateFile(DBName);
            }

            sqlite_connect = new SQLiteConnection("Data source=" + DBName);
            //建立資料庫連線

            sqlite_connect.Open();// Open
            sqlite_cmd = sqlite_connect.CreateCommand();//create command

            sqlite_cmd.CommandText = @"CREATE TABLE IF NOT EXISTS UserData" +
                "(num INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Password TEXT, UserLimit INTEGER)";
            //create table header
            //INTEGER PRIMARY KEY AUTOINCREMENT=>auto increase index
            sqlite_cmd.ExecuteNonQuery(); //using behind every write cmd

            //sqlite_cmd.CommandText = "INSERT INTO phone VALUES (null, '" + name + "','" + phone_number + "');";
            //sqlite_cmd.ExecuteNonQuery();//using behind every write cmd

            sqlite_connect.Close();
        }

        void ReadData()
        {
            SQLiteConnection mDbConn;

            SQLiteDataAdapter dataAdapter;
            mDbConn = new SQLiteConnection("Data source=" +  DBName);
            mDbConn.Open();
            dataAdapter = new SQLiteDataAdapter("SELECT * FROM UserData;", mDbConn);//讀數據庫
            dataAdapter.FillSchema(dataSet1, SchemaType.Source, "UserData");//將數據庫表student的架構信息（此時為主鍵約束）填充到dataSet1的student表中
            dataAdapter.Fill(dataSet1, "UserData");//填充DataSet控件
            dt = dataSet1.Tables[0];
            dataGridView1.DataSource = dataSet1.Tables[0];//註意，DataSet中的數據表依次為Table, Table1, Table2...
            mDbConn.Close();
        }

        void LoadListUsername()
        {
            listUserName = new List<string>();
            for (int i = 0; i < dataGridView1.RowCount-1;i++)
            {
                listUserName.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
            }
        }
        void SaveData()
        {
            SQLiteConnection mDbConn = new SQLiteConnection("Data source=" + DBName);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM UserData;", mDbConn);//讀數據庫
            SQLiteCommandBuilder cmdbl = new SQLiteCommandBuilder(dataAdapter);
            dataAdapter.Update(dataSet1.Tables[0]);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveData();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public static int LoginLev(string ID, string Password)
        {
            SQLiteConnection mDbConn;

            mDbConn = new SQLiteConnection("Data source=" + DBName);
            mDbConn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.CommandText = "SELECT * FROM UserData " +
                "WHERE Name='" + ID + "' AND Password='" +
                Password + "';";
            cmd.Connection = mDbConn;
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.StepCount == 0)
            {
                //關閉所有連接
                mDbConn.Close();
                return -1;
            }

            reader.Read();
            object o = reader.GetValue(3);
            int result = int.Parse(reader.GetValue(3).ToString());
            //關閉所有連接
            mDbConn.Close();
            return result;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
        }
    }




}
