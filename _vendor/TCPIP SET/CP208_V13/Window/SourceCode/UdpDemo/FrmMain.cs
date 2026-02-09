using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UdpDemo
{
    public partial class FrmMain : Form
    {
        string _ip;
        UdpClient _sender;
        List<string> _localIPs = new List<string>();
        List<NetworkModel> networks = new List<NetworkModel>();
        IPEndPoint _broadcastEP = new IPEndPoint(IPAddress.Broadcast, 50000);
        bool _prot0Enable = false;

        byte[] _cmdHeader = new byte[] { 0x43, 0x48, 0x39, 0x31, 0x32, 0x30, 0x5f, 0x43, 0x46, 0x47, 0x5f, 0x46, 0x4c, 0x41, 0x47, 0x00 };
        ConfigStruct _config = new ConfigStruct();

        public FrmMain()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            IPAddress[] ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in ipAddresses)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    _localIPs.Add(ip.ToString());
            }

            _prot0Enable = true;
            tabControl1.SelectedIndex = 1;
            _prot0Enable = false;
            btnRefreshAdapter.PerformClick();
        }

        private List<string> GetIPv4Addresses(NetworkInterface adapter)
        {
            return adapter.GetIPProperties().UnicastAddresses
                .Where(addr => addr.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                .Select(addr => addr.Address.ToString())
                .ToList();
        }

        private string GetFormattedMacAddress(PhysicalAddress address)
        {
            if (address == null || address.GetAddressBytes().Length == 0)
                return "N/A";

            byte[] bytes = address.GetAddressBytes();
            return string.Join(":", bytes.Select(b => b.ToString("X2")));
        }

        private void GenerateSender()
        {
            if (_sender != null)
            {
                _sender.Close();
                _sender = null;
            }
            _sender = new UdpClient(new IPEndPoint(IPAddress.Parse(_ip), 60000));
        }

        private byte[] GenerateCommand(params object[] parts)
        {
            // 1. 计算总长度
            int totalAppendLength = 0;
            foreach (var part in parts)
            {
                if (part is byte b)
                    totalAppendLength += 1;
                else if (part is byte[] arr)
                    totalAppendLength += arr.Length;
                else
                    throw new ArgumentException("参数必须是 byte 或 byte[] 类型");
            }

            // 2. 创建结果数组（固定头 + 追加部分）
            byte[] result = new byte[_cmdHeader.Length + totalAppendLength];
            Array.Copy(_cmdHeader, result, _cmdHeader.Length);

            // 3. 逐个复制追加内容
            int offset = _cmdHeader.Length;
            foreach (var part in parts)
            {
                if (part is byte b)
                {
                    result[offset] = b;
                    offset += 1;
                }
                else if (part is byte[] arr)
                {
                    Array.Copy(arr, 0, result, offset, arr.Length);
                    offset += arr.Length;
                }
            }

            return result;
        }

        private long ConvertToLongManual(string ipAddress)
        {
            IPAddress address = IPAddress.Parse(ipAddress);
            if (address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
                throw new ArgumentException("仅支持IPv4地址");

            byte[] bytes = address.GetAddressBytes();
            // 将字节按大端序转换为uint，再转为long
            uint result = (uint)((bytes[3] << 24) | (bytes[2] << 16) | (bytes[1] << 8) | bytes[0]);
            return (long)result;
        }

        private void btnRefreshAdapter_Click(object sender, EventArgs e)
        {
            try
            {
                networks.Clear();
                int index = 1;
                foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (adapter.NetworkInterfaceType.ToString() == "Loopback") continue;

                    var ipAddresses = GetIPv4Addresses(adapter);
                    var macAddress = GetFormattedMacAddress(adapter.GetPhysicalAddress());

                    networks.Add(new NetworkModel()
                    {
                        Index = index,
                        AdapterName = adapter.Name,
                        Type = adapter.NetworkInterfaceType.ToString(),
                        Status = adapter.OperationalStatus.ToString(),
                        IP = ipAddresses.Any() ? string.Join(", ", ipAddresses) : "N/A",
                        MAC = macAddress,
                        Description = adapter.Description
                    });
                    index++;
                }
                cmbAdapter.Items.Clear();
                if (networks.Count > 0)
                {
                    networks.ForEach(n => cmbAdapter.Items.Add(n.Index + ". " + n.Description));
                    cmbAdapter.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"刷新网络适配器时出错: {ex.Message}");
            }
        }

        private void cmbAdapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ip = networks[cmbAdapter.SelectedIndex].IP;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateSender();
                lvDevices.Items.Clear();
                byte[] searchCmd = GenerateCommand((byte)0x04);
                // 发送广播消息
                _sender.Send(searchCmd, searchCmd.Length, _broadcastEP);
                // 异步接收响应
                _sender.BeginReceive(ReceiveSearchCallback, null);
                lblLog.Text = "操作状态：设备搜索完成！";
            }
            catch (Exception ex)
            {

            }
        }

        private void ReceiveSearchCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 50000);
                byte[] response = _sender.EndReceive(ar, ref remoteEP);
                DeviceModel device = new DeviceModel();
                byte[] mac = new byte[6];
                Array.Copy(response, 17, mac, 0, 6);
                device.MAC = mac.HexArray2String().Trim().Replace(" ", ":");
                byte[] ip = new byte[4];
                Array.Copy(response, 30, ip, 0, 4);
                long temp;
                temp = ip[0];
                temp += ip[1] << 8;
                temp += ip[2] << 0x10;
                temp += ip[3] << 0x18;
                device.IP = new IPAddress(temp & 0xFFFFFFFF).ToString();
                int len = (int)response[29];
                byte[] name = new byte[len - 4];
                Array.Copy(response, 34, name, 0, len - 4);
                device.Name = Encoding.ASCII.GetString(name);
                device.Version = ((int)response[29 + len + 1]).ToString();
                ListViewItem lvItem = new ListViewItem(new string[] { device.Name, device.IP, device.MAC, device.Version });
                lvDevices.Items.Add(lvItem);
                _sender.BeginReceive(ReceiveSearchCallback, null);
            }
            catch (Exception ex)
            {

            }
        }

        private void lvDevices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                // 获取双击位置的项
                ListViewItem clickedItem = lvDevices.GetItemAt(e.X, e.Y);
                if (clickedItem != null)
                {
                    byte[] mac = clickedItem.SubItems[2].Text.Replace(":", "").String2HexArray();
                    GenerateSender();
                    byte[] getConfigCmd = GenerateCommand((byte)0x02, mac);
                    // 发送广播消息
                    _sender.Send(getConfigCmd, getConfigCmd.Length, _broadcastEP);
                    // 异步接收响应
                    _sender.BeginReceive(ReceiveGetConfigCallback, null);
                    lblLog.Text = "操作状态：获取配置成功！";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ReceiveGetConfigCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 50000);
                byte[] response = _sender.EndReceive(ar, ref remoteEP);
                byte[] buf = new byte[response.Length - 17];
                Array.Copy(response, 17, buf, 0, buf.Length);
                _config = buf.ByteArray2Struct<ConfigStruct>();
                txtDeviceName.Text = Encoding.ASCII.GetString(_config.DeviceName);
                ckbDHCP.Checked = _config.DHCP == 0x01;
                txtDeviceIP.Text = new IPAddress(_config.IP & 0xFFFFFFFF).ToString();
                txtGateway.Text = new IPAddress(_config.Gateway & 0xFFFFFFFF).ToString();
                txtNetMask.Text = new IPAddress(_config.NetMask & 0xFFFFFFFF).ToString();
                ckbSerialConfig.Checked = _config.SerialConfig == 0x01;
                if (_config.Port0Enable == 0x01)
                {
                    _prot0Enable = true;
                    cmbNetMode1.SelectedIndex = _config.Port0.WorkMode;
                    ckbRandom1.Checked = _config.Port0.IsRandom == 0x01;
                    txtLocalPort1.Text = _config.Port0.NetPort.ToString();
                    cmbDestinationIPDomainName1.SelectedIndex = _config.Port0.DomainEnable == 0x01 ? 1 : 0;
                    txtDestinationIP1.Text = new IPAddress(_config.Port0.DestinationIP & 0xFFFFFFFF).ToString();
                    txtDestinationPort1.Text = _config.Port0.DestinationPort.ToString();
                    switch (_config.Port0.BaudRate)
                    {
                        case 300:
                            cmbBaudRate1.SelectedIndex = 0;
                            break;
                        case 600:
                            cmbBaudRate1.SelectedIndex = 1;
                            break;
                        case 1200:
                            cmbBaudRate1.SelectedIndex = 2;
                            break;
                        case 2400:
                            cmbBaudRate1.SelectedIndex = 3;
                            break;
                        case 4800:
                            cmbBaudRate1.SelectedIndex = 4;
                            break;
                        case 9600:
                            cmbBaudRate1.SelectedIndex = 5;
                            break;
                        case 14400:
                            cmbBaudRate1.SelectedIndex = 6;
                            break;
                        case 19200:
                            cmbBaudRate1.SelectedIndex = 7;
                            break;
                        case 38400:
                            cmbBaudRate1.SelectedIndex = 8;
                            break;
                        case 57600:
                            cmbBaudRate1.SelectedIndex = 9;
                            break;
                        case 115200:
                            cmbBaudRate1.SelectedIndex = 10;
                            break;
                        case 230400:
                            cmbBaudRate1.SelectedIndex = 11;
                            break;
                        case 460800:
                            cmbBaudRate1.SelectedIndex = 12;
                            break;
                        case 921600:
                            cmbBaudRate1.SelectedIndex = 13;
                            break;
                    }
                    switch (_config.Port0.DataBits)
                    {
                        case 5:
                            cmbDataBits1.SelectedIndex = 0;
                            break;
                        case 6:
                            cmbDataBits1.SelectedIndex = 1;
                            break;
                        case 7:
                            cmbDataBits1.SelectedIndex = 2;
                            break;
                        case 8:
                            cmbDataBits1.SelectedIndex = 3;
                            break;
                    }
                    switch (_config.Port0.StopBits)
                    {
                        case 1:
                            cmbStopBits1.SelectedIndex = 0;
                            break;
                        case 2:
                            cmbStopBits1.SelectedIndex = 1;
                            break;
                    }
                    cmbCheckBits1.SelectedIndex = _config.Port0.CheckBits - 1;
                    ckbNetworkDisconnect1.Checked = _config.Port0.PHY == 0x01;
                    txtRXLen1.Text = _config.Port0.RxLen.ToString();
                    txtRXTimeout1.Text = _config.Port0.RxTimeout.ToString();
                    ckbClear1.Checked = _config.Port0.ResetOperation == 0x01;
                }
                if (_config.Port1Enable == 0x01)
                {
                    cmbNetMode2.SelectedIndex = _config.Port1.WorkMode;
                    ckbRandom2.Checked = _config.Port1.IsRandom == 0x01;
                    txtLocalPort2.Text = _config.Port1.NetPort.ToString();
                    cmbDestinationIPDomainName2.SelectedIndex = _config.Port1.DomainEnable == 0x01 ? 1 : 0;
                    txtDestinationIP2.Text = new IPAddress(_config.Port1.DestinationIP & 0xFFFFFFFF).ToString();
                    txtDestinationPort2.Text = _config.Port1.DestinationPort.ToString();
                    switch (_config.Port1.BaudRate)
                    {
                        case 300:
                            cmbBaudRate2.SelectedIndex = 0;
                            break;
                        case 600:
                            cmbBaudRate2.SelectedIndex = 1;
                            break;
                        case 1200:
                            cmbBaudRate2.SelectedIndex = 2;
                            break;
                        case 2400:
                            cmbBaudRate2.SelectedIndex = 3;
                            break;
                        case 4800:
                            cmbBaudRate2.SelectedIndex = 4;
                            break;
                        case 9600:
                            cmbBaudRate2.SelectedIndex = 5;
                            break;
                        case 14400:
                            cmbBaudRate2.SelectedIndex = 6;
                            break;
                        case 19200:
                            cmbBaudRate2.SelectedIndex = 7;
                            break;
                        case 38400:
                            cmbBaudRate2.SelectedIndex = 8;
                            break;
                        case 57600:
                            cmbBaudRate2.SelectedIndex = 9;
                            break;
                        case 115200:
                            cmbBaudRate2.SelectedIndex = 10;
                            break;
                        case 230400:
                            cmbBaudRate2.SelectedIndex = 11;
                            break;
                        case 460800:
                            cmbBaudRate2.SelectedIndex = 12;
                            break;
                        case 921600:
                            cmbBaudRate2.SelectedIndex = 13;
                            break;
                    }
                    switch (_config.Port1.DataBits)
                    {
                        case 5:
                            cmbDataBits2.SelectedIndex = 0;
                            break;
                        case 6:
                            cmbDataBits2.SelectedIndex = 1;
                            break;
                        case 7:
                            cmbDataBits2.SelectedIndex = 2;
                            break;
                        case 8:
                            cmbDataBits2.SelectedIndex = 3;
                            break;
                    }
                    switch (_config.Port1.StopBits)
                    {
                        case 1:
                            cmbStopBits2.SelectedIndex = 0;
                            break;
                        case 2:
                            cmbStopBits2.SelectedIndex = 1;
                            break;
                    }
                    cmbCheckBits2.SelectedIndex = _config.Port1.CheckBits - 1;
                    ckbNetworkDisconnect2.Checked = _config.Port1.PHY == 0x01;
                    txtRXLen2.Text = _config.Port1.RxLen.ToString();
                    txtRXTimeout2.Text = _config.Port1.RxTimeout.ToString();
                    ckbClear2.Checked = _config.Port1.ResetOperation == 0x01;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                if (_config.MAC == null) return;
                GenerateSender();
                _config.DeviceName = Encoding.ASCII.GetBytes(txtDeviceName.Text).FillZero(21);
                _config.DHCP = ckbDHCP.Checked ? (byte)0x01 : (byte)0x00;
                _config.IP = ConvertToLongManual(txtDeviceIP.Text);
                _config.Gateway = ConvertToLongManual(txtGateway.Text);
                _config.NetMask = ConvertToLongManual(txtNetMask.Text);
                _config.SerialConfig = ckbSerialConfig.Checked ? (byte)0x01 : (byte)0x00;
                if (_prot0Enable)
                {
                    _config.Port0Enable = (byte)0x01;
                    PortStruct port0 = _config.Port0;
                    port0.WorkMode = (byte)cmbNetMode1.SelectedIndex;
                    port0.IsRandom = ckbRandom1.Checked ? (byte)0x01 : (byte)0x00;
                    port0.NetPort = long.Parse(txtLocalPort1.Text);
                    port0.DomainEnable = cmbDestinationIPDomainName1.SelectedIndex == 1 ? (byte)0x01 : (byte)0x00;
                    port0.DestinationIP = ConvertToLongManual(txtDestinationIP1.Text);
                    port0.DestinationPort = long.Parse(txtDestinationPort1.Text);
                    switch (cmbBaudRate1.SelectedIndex)
                    {
                        case 0:
                            port0.BaudRate = 300;
                            break;
                        case 1:
                            port0.BaudRate = 600;
                            break;
                        case 2:
                            port0.BaudRate = 1200;
                            break;
                        case 3:
                            port0.BaudRate = 2400;
                            break;
                        case 4:
                            port0.BaudRate = 4800;
                            break;
                        case 5:
                            port0.BaudRate = 9600;
                            break;
                        case 6:
                            port0.BaudRate = 14400;
                            break;
                        case 7:
                            port0.BaudRate = 19200;
                            break;
                        case 8:
                            port0.BaudRate = 38400;
                            break;
                        case 9:
                            port0.BaudRate = 57600;
                            break;
                        case 10:
                            port0.BaudRate = 115200;
                            break;
                        case 11:
                            port0.BaudRate = 230400;
                            break;
                        case 12:
                            port0.BaudRate = 460800;
                            break;
                        case 13:
                            port0.BaudRate = 921600;
                            break;
                    }
                    switch (cmbDataBits1.SelectedIndex)
                    {
                        case 0:
                            port0.DataBits = 5;
                            break;
                        case 1:
                            port0.DataBits = 6;
                            break;
                        case 2:
                            port0.DataBits = 7;
                            break;
                        case 3:
                            port0.DataBits = 8;
                            break;
                    }
                    switch (cmbStopBits1.SelectedIndex)
                    {
                        case 0:
                            port0.StopBits = 1;
                            break;
                        case 1:
                            port0.StopBits = 2;
                            break;
                    }
                    port0.CheckBits = (byte)(cmbCheckBits1.SelectedIndex + 1);
                    port0.PHY = ckbNetworkDisconnect1.Checked ? (byte)0x01 : (byte)0x00;
                    port0.RxLen = long.Parse(txtRXLen1.Text);
                    port0.RxTimeout = long.Parse(txtRXTimeout1.Text);
                    port0.ResetOperation = ckbClear1.Checked ? (byte)0x01 : (byte)0x00;
                    _config.Port0 = port0;
                }
                else
                    _config.Port0Enable = (byte)0x00;

                _config.Port1Enable = (byte)0x01;
                PortStruct port1 = _config.Port1;
                port1.WorkMode = (byte)cmbNetMode2.SelectedIndex;
                port1.IsRandom = ckbRandom2.Checked ? (byte)0x01 : (byte)0x00;
                port1.NetPort = long.Parse(txtLocalPort2.Text);
                port1.DomainEnable = cmbDestinationIPDomainName2.SelectedIndex == 1 ? (byte)0x01 : (byte)0x00;
                port1.DestinationIP = ConvertToLongManual(txtDestinationIP2.Text);
                port1.DestinationPort = long.Parse(txtDestinationPort2.Text);
                switch (cmbBaudRate2.SelectedIndex)
                {
                    case 0:
                        port1.BaudRate = 300;
                        break;
                    case 1:
                        port1.BaudRate = 600;
                        break;
                    case 2:
                        port1.BaudRate = 1200;
                        break;
                    case 3:
                        port1.BaudRate = 2400;
                        break;
                    case 4:
                        port1.BaudRate = 4800;
                        break;
                    case 5:
                        port1.BaudRate = 9600;
                        break;
                    case 6:
                        port1.BaudRate = 14400;
                        break;
                    case 7:
                        port1.BaudRate = 19200;
                        break;
                    case 8:
                        port1.BaudRate = 38400;
                        break;
                    case 9:
                        port1.BaudRate = 57600;
                        break;
                    case 10:
                        port1.BaudRate = 115200;
                        break;
                    case 11:
                        port1.BaudRate = 230400;
                        break;
                    case 12:
                        port1.BaudRate = 460800;
                        break;
                    case 13:
                        port1.BaudRate = 921600;
                        break;
                }
                switch (cmbDataBits2.SelectedIndex)
                {
                    case 0:
                        port1.DataBits = 5;
                        break;
                    case 1:
                        port1.DataBits = 6;
                        break;
                    case 2:
                        port1.DataBits = 7;
                        break;
                    case 3:
                        port1.DataBits = 8;
                        break;
                }
                switch (cmbStopBits2.SelectedIndex)
                {
                    case 0:
                        port1.StopBits = 1;
                        break;
                    case 1:
                        port1.StopBits = 2;
                        break;
                }
                port1.CheckBits = (byte)(cmbCheckBits2.SelectedIndex + 1);
                port1.PHY = ckbNetworkDisconnect2.Checked ? (byte)0x01 : (byte)0x00;
                port1.RxLen = long.Parse(txtRXLen2.Text);
                port1.RxTimeout = long.Parse(txtRXTimeout2.Text);
                port1.ResetOperation = ckbClear2.Checked ? (byte)0x01 : (byte)0x00;
                _config.Port1 = port1;
                byte[] searchCmd = GenerateCommand((byte)0x01, _config.Struct2ByteArray());
                // 发送广播消息
                _sender.Send(searchCmd, searchCmd.Length, _broadcastEP);
                // 异步接收响应
                _sender.BeginReceive(ReceiveSetConfigCallback, null);
                lblLog.Text = "操作状态：配置成功！";
            }
            catch (Exception ex)
            {

            }
        }

        private void ReceiveSetConfigCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 50000);
                byte[] response = _sender.EndReceive(ar, ref remoteEP);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_config.MAC == null) return;
                GenerateSender();
                byte[] searchCmd = GenerateCommand((byte)0x03, _config.MAC);
                // 发送广播消息
                _sender.Send(searchCmd, searchCmd.Length, _broadcastEP);
                // 异步接收响应
                _sender.BeginReceive(ReceiveInitCallback, null);
                lblLog.Text = "操作状态：复位成功！";
            }
            catch (Exception ex)
            {

            }
        }

        private void ReceiveInitCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 50000);
                byte[] response = _sender.EndReceive(ar, ref remoteEP);
            }
            catch (Exception ex)
            {

            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!_prot0Enable)
                e.Cancel = true;
        }
    }
}
