using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ThreadDEMO;
using System.Runtime.InteropServices;
using UHF;
namespace ThreadDEMO
{
    public partial class Form1 : Form
    {
        
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(
        IntPtr hWnd, // handle to destination window 
        uint Msg, // message 
        uint wParam, // first message parameter 
        uint lParam // second message parameter 
        );

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public const int USER = 0x0400;
        public const int WM_SENDTAG1 = USER + 101;
        public const int WM_SENDTAG2 = USER + 102;
        public const int WM_SENDTAG3 = USER + 103;
        public const int WM_SENDTAG4 = USER + 104;


        private byte fComAdr = 0xff; //当前操作的ComAdr
        private int fCmdRet = 30; //所有执行指令的返回值
        private byte[] fOperEPC = new byte[100];

        private bool ComOpen1 = false;
        private bool ComOpen2 = false;
        private bool ComOpen3 = false;
        private bool ComOpen4 = false;


        private bool queryflag1 = false;
        private bool queryflag2 = false;
        private bool queryflag3 = false;
        private bool queryflag4 = false;


        public Reader Dev1 = new Reader();
        public Reader Dev2 = new Reader();
        public Reader Dev3 = new Reader();
        public Reader Dev4 = new Reader();

        Thread readThread1 =null;
        Thread readThread2 = null;
        Thread readThread3 = null;
        Thread readThread4 = null;
        class ReaderInfo
        {
            public bool IsOpen;
            public int Handle;
            public ListView lst;
        }

        List<ReaderInfo> rd = new List<ReaderInfo>();
        public Form1()
        {
            InitializeComponent();
            elegateRFIDCallBack = new RFIDCallBack(GetUid);
        }

        RFIDCallBack elegateRFIDCallBack;

        public void GetUid(IntPtr p, Int32 nEvt)
        {

            RFIDTag ce = (RFIDTag)Marshal.PtrToStructure(p, typeof(RFIDTag));
            this.Invoke((EventHandler)delegate
            {
                foreach (ReaderInfo read in rd)
                {
                    if(read.Handle == ce.Handles)
                    {
                        Reader.updatelist(read.lst, ce.UID);
                    }
                }
               
            });
                               
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            button23.Enabled = false;
            button24.Enabled = false;
            button25.Enabled = false;
            button26.Enabled = false;
        }
        /// <summary>
        /// /////////////设备1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button23_Click(object sender, EventArgs e)
        {
            if (button23.Text == "Start")
            {
                
                listView1.Items.Clear();
                readThread1 = new Thread(Inventory1);
                queryflag1 = true;
                readThread1.IsBackground = true;
                readThread1.Start();
                button23.Text = "Stop";
            }
            else
            {
                button23.Text = "Start";
                queryflag1 = false;
                if (readThread1.Join(3000))
                {
                    try
                    {
                        readThread1.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }
                readThread1 = null;
            }
        }
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }
       

        private void Inventory1()
        {
            
            while (queryflag1)
            {
                try
                {
                    int fCmdRet = Dev1.Inventory();
                    if ((fCmdRet != 0x01) && (fCmdRet != 0x02) && (fCmdRet != 0xF8) && (fCmdRet != 0xF9) && (fCmdRet != 0xEE) && (fCmdRet != 0xFF))
                    {
                        if ((Dev1.FrmHandle > 0) && (Dev1.FrmHandle < 256))
                        {
                            fCmdRet = Dev1.CloseByTcp();
                            Thread.Sleep(1000);
                        }
                        fComAdr = 255;
                        fCmdRet = Dev1.OpenByTcp(Dev1.nPort, Dev1.ipAddr, ref fComAdr);
                        if (fCmdRet == 0)
                        {
                            Dev1.Init_CallBack(elegateRFIDCallBack, true);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    ex.ToString();
                }
               
                Thread.Sleep(10);
            }

        }
        private void OpenNetPort_Click(object sender, EventArgs e)
        {
            try
            {
                int port, openresult = 0;
                string IPAddr;
                fComAdr = 255; // $FF;
                if ((textBox7.Text == "") || (textBox8.Text == ""))
                    return;
                port = Convert.ToInt32(textBox7.Text);
                IPAddr = textBox8.Text;
                openresult = Dev1.OpenByTcp(port, IPAddr, ref fComAdr);
                if ((openresult == 0x35) || (openresult == 0x30))
                {
                    MessageBox.Show("Device 1 open failed", "info");
                    Dev1.CloseByTcp();
                    ComOpen1 = false;
                    return;
                }
                if (openresult == 0)
                {
                    Dev1.Init_CallBack(elegateRFIDCallBack,true);
                    ReaderInfo read = new ReaderInfo();
                    read.Handle = Dev1.FrmHandle;
                    read.IsOpen = true;
                    read.lst = listView1;
                    rd.Add(read);
                    MessageBox.Show("Device 1 open success", "info");
                    ComOpen1 = true;
                    button23.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        private void CloseNetPort_Click(object sender, EventArgs e)
        {
            fCmdRet = Dev1.CloseByTcp();
            if (fCmdRet == 0)
            {
                ComOpen1 = false;
                button23.Enabled = false;
                listView1.Items.Clear();
                queryflag1 = false;
                button23.Text = "Start";
                if ((readThread1 != null)&&(readThread1.Join(3000)))
                {
                    try
                    {
                        readThread1.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }

                foreach (ReaderInfo read in rd)
                {
                    if (read.lst == listView1)
                    {
                        rd.Remove(read);
                        break;
                    }

                }
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
        /// <summary>
        /// /////////////设备2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int port, openresult = 0;
                string IPAddr;
                fComAdr = 255; // $FF;
                if ((textBox3.Text == "") || (textBox2.Text == ""))
                    return;
                port = Convert.ToInt32(textBox3.Text);
                IPAddr = textBox2.Text;
                openresult = Dev2.OpenByTcp(port, IPAddr, ref fComAdr);

                if ((openresult == 0x35) || (openresult == 0x30))
                {
                    MessageBox.Show("Device 2 open failed", "info");
                    Dev2.CloseByTcp();
                    ComOpen2 = false;
                    return;
                }
                if (openresult == 0)
                {
                    Dev2.Init_CallBack(elegateRFIDCallBack, true);
                    ReaderInfo read = new ReaderInfo();
                    read.Handle = Dev2.FrmHandle;
                    read.IsOpen = true;
                    read.lst = listView2;
                    rd.Add(read);
                    MessageBox.Show("Device 2 open success", "info");
                    ComOpen2 = true;
                    button24.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fCmdRet = Dev2.CloseByTcp();
            if (fCmdRet == 0)
            {
                ComOpen2 = false;
                button24.Enabled = false;
                listView2.Items.Clear();
                queryflag2 = false;
                if ((readThread2!=null)&&(readThread2.Join(3000)))
                {
                    try
                    {
                        readThread2.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }
                readThread2 = null;
                foreach(ReaderInfo read in rd)
                {
                    if (read.lst == listView2)
                    {
                        rd.Remove(read);
                        break;
                    }

                }
                button24.Text = "Start";
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (button24.Text == "Start")
            {
                listView2.Items.Clear();
                readThread2 = new Thread(new ThreadStart(Inventory2));
                queryflag2 = true;
                readThread2.IsBackground = true;
                readThread2.Start();
                button24.Text = "Stop";
            }
            else
            {
                button24.Text = "Start";
                button24.Update();
                queryflag2 = false;
                if (readThread2.Join(3000))
                {
                    try
                    {
                        readThread2.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }
            }
        }
      
        private void Inventory2()
        {
            while (queryflag2)
            {
                try
                {
                    int fCmdRet = Dev2.Inventory();
                    if ((fCmdRet != 0x01) && (fCmdRet != 0x02) && (fCmdRet != 0xF8) && (fCmdRet != 0xF9) && (fCmdRet != 0xEE) && (fCmdRet != 0xFF))
                    {
                        if ((Dev2.FrmHandle > 0) && (Dev2.FrmHandle < 256))
                        {
                            fCmdRet = Dev2.CloseByTcp();
                            Thread.Sleep(1000);
                        }
                        fComAdr = 255;
                        fCmdRet = Dev2.OpenByTcp(Dev2.nPort, Dev2.ipAddr, ref fComAdr);
                        if (fCmdRet == 0)
                        {
                            Dev2.Init_CallBack(elegateRFIDCallBack, true);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    ex.ToString();
                }
                Thread.Sleep(10);
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }
        /// <summary>
        /// /////////////设备3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int port, openresult = 0;
                string IPAddr;
                fComAdr = 255; // $FF;
                if ((textBox6.Text == "") || (textBox5.Text == ""))
                    return;
                port = Convert.ToInt32(textBox6.Text);
                IPAddr = textBox5.Text;
                openresult = Dev3.OpenByTcp(port, IPAddr, ref fComAdr);
                if ((openresult == 0x35) || (openresult == 0x30))
                {
                    MessageBox.Show("Device 3 open failed", "info");
                    Dev3.CloseByTcp();
                    ComOpen3 = false;
                    return;
                }
                if (openresult == 0)
                {
                    Dev3.Init_CallBack(elegateRFIDCallBack, true);
                    ReaderInfo read = new ReaderInfo();
                    read.Handle = Dev3.FrmHandle;
                    read.IsOpen = true;
                    read.lst = listView3;
                    rd.Add(read);
                    MessageBox.Show("Device 3 open success", "info");
                    ComOpen3 = true;
                    button25.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                return;
            int frmcomportindex = Convert.ToInt32(textBox6.Text);
            fCmdRet = Dev3.CloseByTcp();
            if (fCmdRet == 0)
            {
                ComOpen3 = false;
                button25.Enabled = false;
                listView3.Items.Clear();
                queryflag3 = false;
                if ((readThread3 != null) && (readThread3.Join(3000)))
                {
                    try
                    {
                        readThread3.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }
                readThread3 = null;
                foreach (ReaderInfo read in rd)
                {
                    if (read.lst == listView3)
                    {
                        rd.Remove(read);
                        break;
                    }

                }
                button25.Text = "Start";
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (button25.Text == "Start")
            {
                listView3.Items.Clear();
                readThread3 = new Thread(Inventory3);
                queryflag3 = true;
                readThread3.IsBackground = true;
                readThread3.Start();
                button25.Text = "Stop";
            }
            else
            {
                button25.Text = "Start";
                queryflag3 = false;
                if (readThread3.Join(3000))
                {
                    try
                    {
                        readThread3.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }
                button25.Update();
            }
        }

     
        private void Inventory3()
        {
            while (queryflag3)
            {
                try
                {
                    int fCmdRet = Dev3.Inventory();
                    if ((fCmdRet != 0x01) && (fCmdRet != 0x02) && (fCmdRet != 0xF8) && (fCmdRet != 0xF9) && (fCmdRet != 0xEE) && (fCmdRet != 0xFF))
                    {
                        if ((Dev3.FrmHandle > 0) && (Dev3.FrmHandle < 256))
                        {
                            fCmdRet = Dev3.CloseByTcp();
                            Thread.Sleep(1000);
                        }
                        fComAdr = 255;
                        fCmdRet = Dev3.OpenByTcp(Dev3.nPort, Dev3.ipAddr, ref fComAdr);
                        if (fCmdRet == 0)
                        {
                            Dev3.Init_CallBack(elegateRFIDCallBack, true);
                        }
                    }
                    
                }
                catch (System.Exception ex)
                {
                    ex.ToString();
                }
                Thread.Sleep(10);
            }

        }

        private void button37_Click(object sender, EventArgs e)
        {
            listView3.Items.Clear();
        }


        /// <summary>
        /// ///////设备4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                int port, openresult = 0;
                string IPAddr;
                fComAdr = 255; // $FF;
                if ((textBox18.Text == "") || (textBox17.Text == ""))
                    return;
                port = Convert.ToInt32(textBox18.Text);
                IPAddr = textBox17.Text;
                openresult = Dev4.OpenByTcp(port, IPAddr, ref fComAdr);
                if ((openresult == 0x35) || (openresult == 0x30))
                {
                    MessageBox.Show("Device 4 open failed", "info");
                    Dev4.CloseByTcp();
                    ComOpen4 = false;
                    return;
                }
                if (openresult == 0)
                {
                    Dev4.Init_CallBack(elegateRFIDCallBack, true);
                    ReaderInfo read = new ReaderInfo();
                    read.Handle = Dev4.FrmHandle;
                    read.IsOpen = true;
                    read.lst = listView4;
                    rd.Add(read);
                    MessageBox.Show("Device 4 open success", "info");
                    ComOpen4 = true;
                    button26.Enabled = true;
                }
            }
            catch (System.Exception ex)
            {
                ex.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
                return;
            int frmcomportindex = Convert.ToInt32(textBox18.Text);
            fCmdRet = Dev4.CloseByTcp();
            if (fCmdRet == 0)
            {
                ComOpen4 = false;
                button26.Enabled = false;
                listView4.Items.Clear();
                queryflag4 = false;
                if ((readThread4 != null) && (readThread4.Join(3000)))
                {
                    try
                    {
                        readThread4.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }
                readThread4 = null;
                foreach (ReaderInfo read in rd)
                {
                    if (read.lst == listView4)
                    {
                        rd.Remove(read);
                        break;
                    }

                }
                button26.Text = "Start";
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (button26.Text == "Start")
            {
                listView4.Items.Clear();
                readThread4 = new Thread(Inventory4);
                queryflag4 = true;
                readThread4.IsBackground = true;
                readThread4.Start();
                button26.Text = "Stop";

            }
            else
            {
                //readThread1.
                button26.Text = "Start";
                queryflag4 = false;
                if (readThread4.Join(3000))
                {
                    try
                    {
                        readThread4.Abort();//若线程无法退出，强制结束
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message, "error");
                    }
                }
            }
        }

       
        private void Inventory4()
        {
            while (queryflag4)
            {
                try
                {
                    int fCmdRet = Dev4.Inventory();
                    if ((fCmdRet != 0x01) && (fCmdRet != 0x02) && (fCmdRet != 0xF8) && (fCmdRet != 0xF9) && (fCmdRet != 0xEE) && (fCmdRet != 0xFF))
                    {
                        if ((Dev4.FrmHandle > 0) && (Dev4.FrmHandle < 256))
                        {
                            fCmdRet = Dev4.CloseByTcp();
                            Thread.Sleep(1000);
                        }
                        fComAdr = 255;
                        fCmdRet = Dev4.OpenByTcp(Dev4.nPort, Dev4.ipAddr, ref fComAdr);
                        if (fCmdRet == 0)
                        {
                            Dev4.Init_CallBack(elegateRFIDCallBack, true);
                        }
                    }
                    
                }
                catch (System.Exception ex)
                {
                    ex.ToString();
                }
                Thread.Sleep(10);
            }

        }

        private void button38_Click(object sender, EventArgs e)
        {
            listView4.Items.Clear();
        }
    
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ComOpen1)
            {
                CloseNetPort_Click(sender,e);
            }
            if (ComOpen2)
            {
                button1_Click(sender, e);
            }
            if (ComOpen3)
            {
                button3_Click(sender, e);
            }
            if (ComOpen4)
            {
                button9_Click(sender, e);
            }
          
        }

        private void button3_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }
    }
}