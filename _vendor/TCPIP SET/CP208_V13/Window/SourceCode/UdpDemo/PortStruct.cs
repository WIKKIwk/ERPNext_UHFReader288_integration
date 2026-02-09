using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PortStruct
    {
        /*
01 -- 网络工作模式: 0: TCP SERVER;1: TCP CLENT; 2: UDP SERVER 3：UDP CLIENT; 
01 -- TCP 客户端模式下随即本地端口号，1：随机 0: 不随机 
E6 07 -- 网络通讯端口号 
C0 A8 01 59 -- 目的IP地址
90 1F -- 目的端口 
00 E1 00 00 -- 串口波特率: 300---921600bps 
08 -- 串口数据位 
01 -- 串口停止位 
04 -- 串口校验位
01 -- PHY断开，Socket动作，1：关闭Socket 2、不动作
00 02 00 00 -- 串口RX数据打包长度，最大1024
00 00 00 00 -- 串口RX数据打包转发的最大等待时间,单位为: 10ms,0则表示关闭超时功能
00 -- 工作于TCP CLIENT时，连接TCP SERVER的最大重试次数
00 -- 串口复位操作: 0表示不清空串口数据缓冲区; 1表示连接时清空串口数据缓冲区 
00 -- 域名功能启用标志，1：启用 2：不启用 
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 -- 域名 
00 00 00 00 -- DNS主机
00 00 -- DNS端口 
00 00 00 00 00 00 00 00 -- 预留 
         */
        private byte _workMode;
        private byte _isRandom;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] _netPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _destinationIP;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] _destinationPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _baudRate;
        private byte _dataBits;
        private byte _stopBits;
        private byte _checkBits;
        private byte _phy;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _rxLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _rxTimeout;
        private byte _retryCount;
        private byte _resetOperation;
        private byte _domainEnable;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] _domain;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _dns;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] _dnsPort;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] _reserved;

        public byte WorkMode
        {
            get { return _workMode; }
            set { _workMode = value; }
        }

        public byte IsRandom
        {
            get { return _isRandom; }
            set { _isRandom = value; }
        }

        public long NetPort
        {
            get
            {
                long temp;
                temp = _netPort[0];
                temp += _netPort[1] << 8;
                return temp & 0xFFFF;
            }
            set
            {
                _netPort = BitConverter.GetBytes(value);
            }
        }

        public long DestinationIP
        {
            get
            {
                long temp;
                temp = _destinationIP[0];
                temp += _destinationIP[1] << 8;
                temp += _destinationIP[2] << 0x10;
                temp += _destinationIP[3] << 0x18;
                return temp & 0xFFFFFFFF;
            }
            set
            {
                _destinationIP = BitConverter.GetBytes(value);
            }
        }

        public long DestinationPort
        {
            get
            {
                long temp;
                temp = _destinationPort[0];
                temp += _destinationPort[1] << 8;
                return temp & 0xFFFF;
            }
            set
            {
                _destinationPort = BitConverter.GetBytes(value);
            }
        }

        public long BaudRate
        {
            get
            {
                long temp;
                temp = _baudRate[0];
                temp += _baudRate[1] << 8;
                temp += _baudRate[2] << 0x10;
                temp += _baudRate[3] << 0x18;
                return temp & 0xFFFFFFFF;
            }
            set
            {
                _baudRate = BitConverter.GetBytes(value);
            }
        }

        public byte DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        public byte StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        public byte CheckBits
        {
            get { return _checkBits; }
            set { _checkBits = value; }
        }

        public byte PHY
        {
            get { return _phy; }
            set { _phy = value; }
        }

        public long RxLen
        {
            get
            {
                long temp;
                temp = _rxLen[0];
                temp += _rxLen[1] << 8;
                temp += _rxLen[2] << 0x10;
                temp += _rxLen[3] << 0x18;
                return temp & 0xFFFFFFFF;
            }
            set
            {
                _rxLen = BitConverter.GetBytes(value);
            }
        }

        public long RxTimeout
        {
            get
            {
                long temp;
                temp = _rxTimeout[0];
                temp += _rxTimeout[1] << 8;
                temp += _rxTimeout[2] << 0x10;
                temp += _rxTimeout[3] << 0x18;
                return temp & 0xFFFFFFFF;
            }
            set
            {
                _rxTimeout = BitConverter.GetBytes(value);
            }
        }

        public byte RetryCount
        {
            get { return _retryCount; }
            set { _retryCount = value; }
        }

        public byte ResetOperation
        {
            get { return _resetOperation; }
            set { _resetOperation = value; }
        }

        public byte DomainEnable
        {
            get { return _domainEnable; }
            set { _domainEnable = value; }
        }

        public byte[] Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }

        public byte[] DNS
        {
            get { return _dns; }
            set { _dns = value; }
        }

        public byte[] DNSPort
        {
            get { return _dnsPort; }
            set { _dnsPort = value; }
        }

        public byte[] Reserved
        {
            get { return _reserved; }
            set { _reserved = value; }
        }
    }
}
