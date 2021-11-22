using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EasyModbus;

namespace Vision_Guided_Robot_Application
{
    public class PickPlaceDeltaRobot_Communication
    {
        #region Properties
        private string ip;
        private Config_HardWare config_HW;

        public string IP { get => ip; set => ip = value; }
        public Config_HardWare Config_HW { get => config_HW; set => config_HW = value; }

        public static ModbusClient modbusClient;    //
        public static ModbusClient modbusClient2;   //for read Status of PLC
        int modbusTimeout=100;

        //public bool isBusy;
        //public bool isConnect;
        public bool Connect()
        {
           try
           {
                modbusClient.ConnectionTimeout = modbusTimeout;
                modbusClient.Disconnect();
                Thread.Sleep(300);
                modbusClient.Connect();
           }
           catch
           {
                Error.SetErr(20);
                return false;
            }
            if (modbusClient.Connected)
            {
                return true;
            }
            return false;
        }
        public bool Connect2(ModbusClient _modbusClient)
        {
            try
            {
                _modbusClient.ConnectionTimeout = modbusTimeout;
                _modbusClient.Disconnect();
                Thread.Sleep(300);
                _modbusClient.Connect();
            }
            catch
            {
                Error.SetErr(20);
                return false;
            }
            if (_modbusClient.Connected)
            {
                return true;
            }
            return false;
        }
        public bool isConnected()
        {
            if (modbusClient.Connected) return true;
            return false;
        }
        public bool isAuto;
        public int BufferFlag;
        public int ConveyorEncoder;
        public float[] RBLimit = new float[6];
        public float[] RBPrint = new float[2];
        public int[] RB_Pos_Speed = new int[6];
        public int[] RB_ProductionStatus = new int[6];
        public bool[] BitStatus = new bool[11];
        public bool[] ErrorStatus = new bool[21];
        public bool[] WarningStatus = new bool[10];

        public List<Product_Data> list_Prods = new List<Product_Data>();
        public List<Product_Data> list_Prods_AlreadySend = new List<Product_Data>();

        public int[] DataReceived=new int[10];
        #endregion

        #region Initialize
        public PickPlaceDeltaRobot_Communication(string ip, Config_HardWare config_HW)
        {
            this.Config_HW = config_HW;
            this.IP = ip;
            modbusClient = new ModbusClient(IP, 502);

            Thread th = new Thread(() =>
            {
                modbusClient2 = new ModbusClient(IP, 502);
                modbusClient2.ConnectionTimeout = 500;  //time out=500ms
                try { modbusClient2.Connect(); }
                catch {Error.SetErr(20);};

                while (true) //temp
                {
                    ReadSystemStatus(modbusClient2);
                    Thread.Sleep(Config_HW.LivedResolution);
                }
            })
            {
                IsBackground = true
            };
            th.Start();         
        }
        #endregion

        #region Terminate
        //void getRBError(ref List<RBError> list_Error, string[,] staError_New)
        //{
        //    bool isNew = false;
        //    for (int i = 0; i < (staError_New.Length) / 3; i++)
        //    {
        //        if (!list_Error.Exists(x => x.strNum == staError_New[i, 0]))//檢查有沒新的
        //        {
        //            list_Error.Add(new RBError(staError_New[i, 0], staError_New[i, 1], staError_New[i, 0]));
        //            RBErrLog.ADDLog(staError_New[i, 0] + "," + staError_New[i, 1] + "," + staError_New[i, 2]);
        //            isNew = true;
        //        }
        //    }

        //    bool isExist = false; ;
        //    for (int i = 0; i < list_Error.Count; i++)
        //    {
        //        isExist = false;
        //        for (int j = 0; j < (staError_New.Length) / 3; j++)
        //            if (staError_New[j, 0] == list_Error[i].strNum)
        //            {
        //                isExist = true;
        //                break;
        //            }
        //        if (!isExist)
        //        {
        //            isNew = true;
        //            break;
        //        }
        //    }
        //    if (!isExist)
        //    {
        //        list_Error.Clear();
        //        for (int i = 0; i < staError_New.Length / 3; i++)
        //        {
        //            list_Error.Add(new RBError(staError_New[i, 0], staError_New[i, 1], staError_New[i, 0]));
        //        }

        //    }
        //    if (isNew)
        //    {
        //        OnRBErrorChange?.Invoke();
        //    }
        //}

        ~PickPlaceDeltaRobot_Communication()
        {
            modbusClient.Disconnect();
            modbusClient2.Disconnect();
        }
        #endregion

        #region Methods of Read / Write Modbus

        public bool PLC1_Command(int address, bool command)
        {
            try
            {
                modbusClient.WriteSingleCoil(address, command);
                return true;
            }
            catch
            {
                Error.SetErr(23);
                return false;
            }
        }
        public bool PLC1_Command(int address, bool[] command)
        {
            try
            {
                modbusClient.WriteMultipleCoils(address, command);
                return true;
            }
            catch
            {
                Error.SetErr(23);
                return false;
            }
        }
        public bool PLC2_Command(int address, bool command)
        {
            try
            {
                modbusClient2.WriteSingleCoil(address, command);
                return true;
            }
            catch
            {
                Error.SetErr(23);
                return false;
            }
        }
        public bool PLC2_Command(int address, bool[] command)
        {
            try
            {
                modbusClient2.WriteMultipleCoils(address, command);
                return true;
            }
            catch
            {
                Error.SetErr(23);
                return false;
            }
        }
    
        int[] SendVal = new int[30];
        int[] SendType = new int[10];

        public void ReadSystemStatus(ModbusClient _modbusClient)
        {
            try
            {
                BitStatus = _modbusClient.ReadCoils(8192, 11);  //read bit satus
                RB_Pos_Speed = ReadDoubleWordIntData(62, 6);   //read RB Position & Speed
                RB_ProductionStatus = ReadDoubleWordIntData(50, 6); // read RB Production Status

                PLC2_Command(8205, true);
                PLC2_Command(8206, Error.SoftwareError);
                PLC2_Command(8207, Error.SoftwareWarning);

                if(BitStatus[3]) ReadErrorStatus();
                else ErrorStatus = new bool[21];
                if(BitStatus[9]) ReadWarningStatus();
                else WarningStatus = new bool[10];

            }
            catch
            {
                Error.SetErr(23);
                //isConnect = Connect2(_modbusClient);
                return;
            }
            //isConnect = true;
        }
        public void ReadErrorStatus()
        {
            try
            {
                ErrorStatus = modbusClient2.ReadCoils(8292, 21);
            }
            catch
            {
                Error.SetErr(23);
                //isConnect = Connect2(modbusClient2);
                return;
            }
            //isConnect = true;
        }
        public void ReadWarningStatus()
        {
            try
            {
                WarningStatus = modbusClient2.ReadCoils(8313, 10);
            }
            catch
            {
                Error.SetErr(23);
                //isConnect = Connect2(modbusClient2);
                return;
            }
            //isConnect = true;
        }
        public void ReadRBParameter()
        {
            try
            {
                RBLimit = ReadDoubleWordRealData(0, 6);        //read RBLimit parameter
                RBPrint = ReadDoubleWordRealData(12, 2);        //read RBPrint parameter
            }
            catch
            {
                Error.SetErr(23);
                //isConnect = Connect2(modbusClient2);
                return;
            }
            //isConnect = true;
        }
        public void WriteRBParameter()
        {
            try
            {
                WriteSignRealData(RBLimit, 0);
                WriteSignRealData(RBPrint, 12);
            }
            catch
            {
                Error.SetErr(23);
                //isConnect = Connect2(modbusClient2);
                return;
            }
            //isConnect = true;
        }
        public int[] ReadDoubleWordIntData(int addressStart,int length)
        {
            int[] result = new int[length];
            try
            {
                int[] readHoldingRegisters = modbusClient2.ReadHoldingRegisters(addressStart, length*2);
                for (int i = 0; i < result.Length; i++)
                {
                    int[] Slice = new List<int>(readHoldingRegisters).GetRange(i * 2, 2).ToArray();
                    result[i] = ModbusClient.ConvertRegistersToInt(Slice);
                }
            }
            catch
            {
                Error.SetErr(23);
            }
            return (result);
        }
        public float[] ReadDoubleWordRealData(int addressStart, int length)
        {
            float[] result = new float[length];
            try
            {
                int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(addressStart, length * 2);
                for (int i = 0; i < result.Length; i++)
                {
                    int[] Slice = new List<int>(readHoldingRegisters).GetRange(i * 2, 2).ToArray();
                    result[i] = ModbusClient.ConvertRegistersToFloat(Slice);
                }
            }
            catch
            {
                Error.SetErr(23);
            }
            return (result);
        }
        public bool WriteSignIntergerData(int[] Data, int Address)
        {
            var myList = new List<int>();
            for (int i = 0; i < Data.Length; i++)
            {
                myList.AddRange(ModbusClient.ConvertIntToRegisters(Data[i]));
            }
            try
            {
                modbusClient.WriteMultipleRegisters(Address, myList.ToArray());
            }
            catch
            {
                Error.SetErr(23);
                return (false);
            }
            return (true);
        }
        public bool WriteSignRealData(float[] Data, int Address)
        {
            var myList = new List<int>();
            for (int i = 0; i < Data.Length; i++)
            {
                myList.AddRange(ModbusClient.ConvertFloatToRegisters(Data[i]));
            }
            try
            {
                modbusClient.WriteMultipleRegisters(Address, myList.ToArray());
            }
            catch
            {
                Error.SetErr(23);
                return (false);
            }
            return (true);
        }
        public bool WriteSingleSignIntergerData(int Data, int Address)
        {
            var myList = new List<int>();
            myList.AddRange(ModbusClient.ConvertIntToRegisters(Data));
            try
            {
                modbusClient.WriteMultipleRegisters(Address, myList.ToArray());
            }
            catch
            {
                Error.SetErr(23);
                return (false);
            }
            return (true);
        }
        public bool ReadNowEnc()
        {
            if (modbusClient.Connected)
            {
                int[] readHoldingRegisters= {0,0 };
                try
                {
                    readHoldingRegisters = modbusClient.ReadHoldingRegisters(60, 2);
                }
                catch
                {
                    Error.SetErr(21);
                    return false;
                }
                ConveyorEncoder = (ModbusClient.ConvertRegistersToInt(readHoldingRegisters));
                return true;
            }
            try
            {
                modbusClient.ConnectionTimeout = modbusTimeout;
                modbusClient.Disconnect();
                modbusClient.Connect();
            }
            catch
            {
                Error.SetErr(20);
                return false;
            }
            return false;
        }

        private bool printDirection = false;
        public bool SendData(double timeOffset1, double offsetX, double offsetY, double region)
        {
            int[] sendValueX = new int[1];
            int[] sendValueY = new int[1];
            byte[] byaReadValues = { };

            DateTime dt0 = DateTime.Now;

            #region Object Sorting
            double maxY = list_Prods.Max(Product_Data => Product_Data.Y);
            double minY = list_Prods.Min(Product_Data => Product_Data.Y);

            for (int i = 0; i < list_Prods.Count - 1; i++)
            {              
                for (int j = i + 1; j < list_Prods.Count; j++)
                {
                    if(maxY - minY > 150)
                    {
                        //Sort by Y (Y max first)
                        if (list_Prods[j].Y > list_Prods[i].Y)
                        {
                            Product_Data p = new Product_Data();
                            p = list_Prods[i];
                            list_Prods[i] = list_Prods[j];
                            list_Prods[j] = p;
                        }
                    }
                    else
                    {
                        //Sort by X (Xmin first and then X max first)
                        if ((list_Prods[j].X < list_Prods[i].X && printDirection == false) || (list_Prods[j].X > list_Prods[i].X && printDirection == true))
                        {
                            Product_Data p = new Product_Data();
                            p = list_Prods[i];
                            list_Prods[i] = list_Prods[j];
                            list_Prods[j] = p;
                        }
                    }
                }
            }
            printDirection = list_Prods[list_Prods.Count()-1].X < region ? false : true;

            #endregion

            #region Object position converting
            SendVal = new int[31];
            SendVal[0] = list_Prods.Count;

            for (int i = 0; i < list_Prods.Count; i++)
            {
                //Calculate X, Y
                SendVal[1 + i * 3] = (int)Math.Round((list_Prods[i].X * 1000 + offsetX * 1000));
                SendVal[1 + i * 3 + 1] = (int)Math.Round((list_Prods[i].Y * 1000 + offsetY * 1000));

                //Calculate R
                if (list_Prods[i].U >= (double)0)
                {
                    SendVal[1 + i * 3 + 2] = (int)Math.Round((360 - (list_Prods[i].U)) * 1000);
                    if (SendVal[1 + i * 3 + 2] < 0) SendVal[1 + i * 3 + 2] += 360000;
                }
                if (list_Prods[i].U < (double)0)
                {
                    SendVal[1 + i * 3 + 2] = (int)Math.Round((-(list_Prods[i].U)) * 1000);
                    if (SendVal[1 + i * 3 + 2] > 360000) SendVal[1 + i * 3 + 2] -= 360000;
                }

                //Adjust X, Y, R if R is out of limit
                if (SendVal[1 + i * 3 + 2] >= (double)0 && SendVal[1 + i * 3 + 2] <= (double)90000)
                {
                    SendVal[1 + i * 3] += Math.Abs(Convert.ToInt32(Config_HW.Print_Distance_XY_Setting * Math.Sin(SendVal[1 + i * 3 + 2] / 180000.0 * Math.PI)));
                    SendVal[1 + i * 3 + 1] += Math.Abs(Convert.ToInt32(Config_HW.Print_Distance_XY_Setting * Math.Cos(SendVal[1 + i * 3 + 2] / 180000.0 * Math.PI)));
                    SendVal[1 + i * 3 + 2] += 180000;
                }
                else if (SendVal[1 + i * 3 + 2] >= (double)270000 && SendVal[1 + i * 3 + 2] <= (double)360000)
                {
                    SendVal[1 + i * 3] -= Math.Abs(Convert.ToInt32(Config_HW.Print_Distance_XY_Setting * Math.Sin(SendVal[1 + i * 3 + 2] / 180000.0 * Math.PI)));
                    SendVal[1 + i * 3 + 1] += Math.Abs(Convert.ToInt32(Config_HW.Print_Distance_XY_Setting * Math.Cos(SendVal[1 + i * 3 + 2] / 180000.0 * Math.PI)));
                    SendVal[1 + i * 3 + 2] -= 180000;
                }
            }
            #endregion

            #region Send data
            var myList = new List<int>();
            for (int i=0;i<SendVal.Length;i++)
            {
                myList.AddRange(ModbusClient.ConvertIntToRegisters(SendVal[i]));
            }
            try
            {
                modbusClient.WriteMultipleRegisters(100, myList.ToArray());     //write number of objects and objects data
            }
            catch
            {
                Error.SetErr(23);
                return false;
            }
            try
            {
                modbusClient.WriteSingleCoil(8202, true);   //Enable vision flag
            }
            catch
            {
                Error.SetErr(22);
                return false;
            }
            #endregion

            return true;
        }
        #endregion
    }
    public class Product_Data
    {
        public double X, Y, U;
        public int ObjType;
        public bool isSend;
        public int EC;

        public Product_Data()
        { }
        public Product_Data(double _X, double _Y, double _U, int _ObjType,int _EC)
        {
            X = _X;
            Y = _Y;
            U = _U;
            ObjType = _ObjType;
            EC = _EC;
        }

        public Product_Data Clone()
        {
            return new Product_Data(this.X, this.Y, this.U, this.ObjType,this.EC);
        }
      
    }
}
