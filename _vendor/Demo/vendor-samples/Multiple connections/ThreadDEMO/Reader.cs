using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using UHF;
namespace ThreadDEMO
{
    public class Reader
    {
        public int FrmHandle = -1;
        public byte ComAddr=255;
        public int fCmdRet = -1;
        public int nPort = 0;
        public string ipAddr = "";
        public Reader()
        {
        }

       
        public static void updatelist(ListView mylist,string uid)
        {
            ListView list = mylist;
            bool inlis = false;
            for (int i = 0; i < list.Items.Count; i++)
            {
                if (list.Items[i].SubItems[1].Text == uid)
                {
                    inlis = true;
                    int ntimes = Convert.ToInt32(list.Items[i].SubItems[2].Text, 10);
                    list.Items[i].SubItems[2].Text = (ntimes + 1).ToString();
                    break;
                }
            }
            if (!inlis)
            {
                string[] btArr = new string[3];
                btArr[0] = (list.Items.Count + 1).ToString();
                btArr[1] = uid;
                btArr[2] = "1";
                ListViewItem aListItem = new ListViewItem(btArr);
                list.Items.Add(aListItem);
            }
        }
        /// <summary>
        /// 16进制数组字符串转换
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        #region
        public  byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        public  string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }
        #endregion
        /// <summary>
        /// OpenByTcp
        /// </summary>
        /// <param name="ipAddr"></param>
        /// <param name="Port"></param>
        /// <param name="ComAddr"></param>
        /// <returns></returns>
        #region 
        public int OpenByTcp(int Port, string Addr, ref byte fComAddr)
        {
            fCmdRet = RWDev.OpenNetPort(Port, Addr, ref ComAddr, ref FrmHandle);
            if (fCmdRet==0)
            {
                fComAddr = ComAddr;
                ipAddr = Addr;
                nPort = Port;
            }
            return fCmdRet;
        }
        #endregion

        /// <summary>
        /// CloseByTcp
        /// </summary>
        /// <returns></returns>
        #region 
        public int CloseByTcp()
        {
            int fCmdRet = RWDev.CloseNetPort(FrmHandle);
            FrmHandle=-1;
            return fCmdRet;
        }
        #endregion


        public void Init_CallBack(RFIDCallBack pback,bool uidback)
       {
           if (FrmHandle>0)
               RWDev.InitRFIDCallBack(pback, uidback,FrmHandle);
       }
       public int OpenByCom()
       {
           int fCmdRet = RWDev.OpenComPort(1,ref ComAddr,0,ref  FrmHandle);
               
           return fCmdRet;
       }
        
       public int CloseByCom()
       {
           int fCmdRet =RWDev.CloseSpecComPort(FrmHandle);
           FrmHandle = -1;
           return fCmdRet;
       }
        #region 
        public int Inventory()
        {
            byte Ant = 0;
            int TagNum = 0;
            int Totallen = 0;
            int EPClen, m;
            byte[] EPC = new byte[50000];
            int CardIndex;
            string temps, temp;
            temp = "";
            string sEPC;
            byte MaskMem = 0;
            byte[] MaskAdr = new byte[2];
            byte MaskLen = 0;
            byte[] MaskData = new byte[100];
            byte MaskFlag = 0;
            byte AdrTID = 0;
            byte LenTID = 0;
            AdrTID = 0;
            LenTID = 6;
            MaskFlag = 0;
            int cbtime = System.Environment.TickCount;
            int CardNum = 0;
            fCmdRet = RWDev.Inventory_G2(ref ComAddr, 4, 255, MaskMem, MaskAdr, MaskLen, MaskData, MaskFlag, AdrTID, LenTID, 0, 0, 0x81, 0, 0, EPC, ref Ant, ref Totallen, ref TagNum, FrmHandle);
            return fCmdRet;

        }
        #endregion

       

      
    }
}
