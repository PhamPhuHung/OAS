using System;
using System.Text;
using System.IO;
using System.Threading;

namespace MachineTools
{
    public class Log
    {
        public string Header;
        public string SaveFolder;
        StringBuilder SB = new StringBuilder();
        
        object Lock_Obj=new object();
        public Log(string _SaveFolder,string _Header)
        {
            SaveFolder = _SaveFolder[_SaveFolder .Length -1]!='\\' ?
               _SaveFolder+"\\":_SaveFolder;
            Header = _Header;

            Thread th = new Thread(SaveLog);
            th.IsBackground = true;
            th.Priority = ThreadPriority.Normal;
            th.Start();
            


        }
        public void ADDLog(string strLog)
        {
            lock (Lock_Obj)
                SB.AppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + "\t" + strLog);
        }
        void SaveLog()
        {
            while (true)
            {
                if (!Directory.Exists(SaveFolder))
                {
                    Directory.CreateDirectory(SaveFolder);
                }
                if (SB.Length > 0)
                {
                    lock (Lock_Obj)
                    {
                        File.AppendAllText(SaveFolder+Header+" "+ DateTime.Now.ToString("yyyyMMdd")+".txt", SB.ToString());
                        SB.Clear();
                    }
                }

                Thread.Sleep(100);
                
            }
        }


    }
}
