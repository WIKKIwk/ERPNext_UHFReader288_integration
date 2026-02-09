using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo
{
    [StructLayout(LayoutKind.Sequential,Pack =1)]
    public struct ConfigStruct
    {
        /*
43 48 39 31 32 30 5F 43 46 47 5F 46 4C 41 47 00 【16】
82 -- 回应的响应码 【17】
E0 4E 7A 7B 0F 57 -- 模块MAC 【23】
00 00 00 00 00 00 -- 预留，未知信息 【29】
CC -- 数据总长度 【30】
21 -- 设备类型 【31】
21 -- 设备子类型 【32】
01 -- 设备序号 【33】
02 -- 设备硬件版本号 【34】
03 -- 设备软件版本号 【35】
43 48 39 31 32 30 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 -- 模块名，21字节 【56】
E0 4E 7A 7B 10 87 -- 模块网络MAC 【62】
C0 A8 01 CB -- 模块IP地址 【66】
C0 A8 01 01 -- 模块网关ip 【70】
FF FF FF 00 -- 模块子网掩码 【74】
00 -- DHCP 使能，是否启用DHCP,1:启用，0：不启用 【75】
50 00 -- WEB网页地址 【77】
00 00 00 00 00 00 00 00 -- 用户名同模块名（恢复出厂设置后默认为61 64 6d 69 6e 00 00 00，正常全部设置为00即可）【85】
00 -- 密码使能,1:使能，0：不使能 【86】
00 00 00 00 00 00 00 00 -- 密码（恢复出厂设置后默认为08 08 08 08 08 08 08 08，正常全部设置为00即可）【94】
FF -- 固件升级标志，1：升级，0：不升级 【95】
00 -- 串口协商进入配置模式使能：1：使能，0：不使能 【96】
00 00 00 00 00 00 00 00 -- 保留字段 【104】
*********************************端口0*********************************
00 -- 端口序号 【105】
00 -- 端口启用标识，1：启用，0：不启用 【106】
02 -- 网络工作模式: 0: TCP SERVER;1: TCP CLENT; 2: UDP SERVER 3：UDP CLIENT; 【107】
01 -- TCP 客户端模式下随即本地端口号，1：随机 0: 不随机 【108】
B8 0B -- 网络通讯端口号，固定 【110】
C0 A8 01 64 -- 目的IP地址 【114】
D0 07 -- 目的端口，固定 【116】
80 25 00 00 -- 串口波特率: 300---921600bps 【120】
08 -- 串口数据位 【121】
01 -- 串口停止位 【122】
04 -- 串口校验位 【123】
01 -- PHY断开，Socket动作，1：关闭Socket 2、不动作 【124】
00 02 00 00 -- 串口RX数据打包长度，最大1024 【128】
00 00 00 00 -- 串口RX数据打包转发的最大等待时间,单位为: 10ms,0则表示关闭超时功能 【132】
00 -- 工作于TCP CLIENT时，连接TCP SERVER的最大重试次数 【133】
00 -- 串口复位操作: 0表示不清空串口数据缓冲区; 1表示连接时清空串口数据缓冲区 【134】
00 -- 域名功能启用标志，1：启用 2：不启用 【135】
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 -- 域名 【155】
00 00 00 00 -- DNS主机 【159】
00 00 -- DNS端口 【161】
00 00 00 00 00 00 00 00 -- 预留 【169】
*********************************端口1*********************************
01 -- 端口序号 【170】
01 -- 端口启用标识，1：启用，0：不启用 【171】
01 -- 网络工作模式: 0: TCP SERVER;1: TCP CLENT; 2: UDP SERVER 3：UDP CLIENT; 【172】
01 -- TCP 客户端模式下随即本地端口号，1：随机 0: 不随机 【173】
E6 07 -- 网络通讯端口号 【175】
C0 A8 01 59 -- 目的IP地址 【179】
90 1F -- 目的端口 【181】
00 E1 00 00 -- 串口波特率: 300---921600bps 【185】
08 -- 串口数据位 【186】
01 -- 串口停止位 【187】
04 -- 串口校验位 【188】
01 -- PHY断开，Socket动作，1：关闭Socket 2、不动作 【189】
00 02 00 00 -- 串口RX数据打包长度，最大1024 【193】
00 00 00 00 -- 串口RX数据打包转发的最大等待时间,单位为: 10ms,0则表示关闭超时功能 【197】
00 -- 工作于TCP CLIENT时，连接TCP SERVER的最大重试次数 【198】
00 -- 串口复位操作: 0表示不清空串口数据缓冲区; 1表示连接时清空串口数据缓冲区 【199】
00 -- 域名功能启用标志，1：启用 2：不启用 【200】
00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 -- 域名 【220】
00 00 00 00 -- DNS主机 【224】
00 00 -- DNS端口 【226】
00 00 00 00 00 00 00 00 -- 预留 【234】

55 AA 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 【285】
                 */
        // 固定头部
        // 43 48 39 31 32 30 5F 43 46 47 5F 46 4C 41 47 00
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        //private byte[] _header;
        //// 82 -- 回应的响应码 【17】
        //private byte _cmd;
        // E0 4E 7A 7B 0F 57 -- 模块MAC 【23】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private byte[] _mac;
        // 00 00 00 00 00 00 -- 预留，未知信息 【29】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private byte[] _reserved1;
        // CC -- 数据总长度 【30】
        private byte _len;
        // 21 -- 设备类型 【31】
        private byte _type;
        // 21 -- 设备子类型 【32】
        private byte _subType;
        // 01 -- 设备序号 【33】
        private byte _deviceNo;
        // 02 -- 设备硬件版本号 【34】
        private byte _hardwareVersion;
        // 03 -- 设备软件版本号 【35】
        private byte _softwareVersion;
        // 43 48 39 31 32 30 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 -- 模块名，21字节 【56】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        private byte[] _deviceName;
        // E0 4E 7A 7B 10 87 -- 模块网络MAC 【62】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        private byte[] _netMac;
        // C0 A8 01 CB -- 模块IP地址 【66】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _ip;
        // C0 A8 01 01 -- 模块网关ip 【70】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _gateway;
        // FF FF FF 00 -- 模块子网掩码 【74】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _netMask;
        // 00 -- DHCP 使能，是否启用DHCP,1:启用，0：不启用 【75】
        private byte _dhcp;
        // 50 00 -- WEB网页地址 【77】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] _web;
        // 00 00 00 00 00 00 00 00 -- 用户名同模块名（恢复出厂设置后默认为61 64 6d 69 6e 00 00 00，正常全部设置为00即可）【85】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] _userName;
        // 00 -- 密码使能,1:使能，0：不使能 【86】
        private byte _passwordEnable;
        // 00 00 00 00 00 00 00 00 -- 密码（恢复出厂设置后默认为08 08 08 08 08 08 08 08，正常全部设置为00即可）【94】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] _password;
        // FF -- 固件升级标志，1：升级，0：不升级 【95】
        private byte _flag;
        // 00 -- 串口协商进入配置模式使能：1：使能，0：不使能 【96】
        private byte _serialConfig;
        // 00 00 00 00 00 00 00 00 -- 保留字段 【104】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] _reserved2;
        // 00 -- 端口序号 【105】
        private byte _portNo0;
        // 00 -- 端口启用标识，1：启用，0：不启用 【106】
        private byte _port0Enable;
        private PortStruct _port0;
        // 01 -- 端口序号 【170】
        private byte _portNo1;
        // 01 -- 端口启用标识，1：启用，0：不启用 【171】
        private byte _port1Enable;
        private PortStruct _port1;
        // 55 AA 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 【285】
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        private byte[] _reserved3;

        //public byte[] Header
        //{
        //    get { return _header; }
        //    set { _header = value; }
        //}

        //public byte CMD
        //{
        //    get { return _cmd; }
        //    set { _cmd = value; }
        //}

        public byte[] MAC
        {
            get { return _mac; }
            set { _mac = value; }
        }

        public byte[] Reserved1
        {
            get { return _reserved1; }
            set { _reserved1 = value; }
        }

        public byte Len
        {
            get { return _len; }
            set { _len = value; }
        }

        public byte Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public byte SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }

        public byte DeviceNo
        {
            get { return _deviceNo; }
            set { _deviceNo = value; }
        }

        public byte HardwareVersion
        {
            get { return _hardwareVersion; }
            set { _hardwareVersion = value; }
        }

        public byte SoftwareVersion
        {
            get { return _softwareVersion; }
            set { _softwareVersion = value; }
        }

        public byte[] DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = value; }
        }

        public byte[] NetMAC
        {
            get { return _netMac; }
            set { _netMac = value; }
        }

        public long IP
        {
            get
            {
                long temp;
                temp = _ip[0];
                temp += _ip[1] << 8;
                temp += _ip[2] << 0x10;
                temp += _ip[3] << 0x18;
                return temp & 0xFFFFFFFF;
            }
            set
            {
                _ip = BitConverter.GetBytes(value);
            }
        }

        public long Gateway
        {
            get
            {
                long temp;
                temp = _gateway[0];
                temp += _gateway[1] << 8;
                temp += _gateway[2] << 0x10;
                temp += _gateway[3] << 0x18;
                return temp & 0xFFFFFFFF;
            }
            set
            {
                _gateway = BitConverter.GetBytes(value);
            }
        }

        public long NetMask
        {
            get
            {
                long temp;
                temp = _netMask[0];
                temp += _netMask[1] << 8;
                temp += _netMask[2] << 0x10;
                temp += _netMask[3] << 0x18;
                return temp & 0xFFFFFFFF;
            }
            set
            {
                _netMask = BitConverter.GetBytes(value);
            }
        }

        public byte DHCP
        {
            get { return _dhcp; }
            set { _dhcp = value; }
        }

        public byte[] Web
        {
            get { return _web; }
            set { _web = value; }
        }

        public byte[] UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public byte PasswordEnable
        {
            get { return _passwordEnable; }
            set { _passwordEnable = value; }
        }

        public byte[] Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public byte Flag
        {
            get { return _flag; }
            set { _flag = value; }
        }

        public byte SerialConfig
        {
            get { return _serialConfig; }
            set { _serialConfig = value; }
        }

        public byte[] Reserved2
        {
            get { return _reserved2; }
            set { _reserved2 = value; }
        }

        public byte PortNo0
        {
            get { return _portNo0; }
            set { _portNo0 = value; }
        }

        public byte Port0Enable
        {
            get { return _port0Enable; }
            set { _port0Enable = value; }
        }

        public PortStruct Port0
        {
            get { return _port0; }
            set { _port0 = value; }
        }

        public byte PortNo1
        {
            get { return _portNo1; }
            set { _portNo1 = value; }
        }

        public byte Port1Enable
        {
            get { return _port1Enable; }
            set { _port1Enable = value; }
        }

        public PortStruct Port1
        {
            get { return _port1; }
            set { _port1 = value; }
        }

        public byte[] Reserved3
        {
            get { return _reserved3; }
            set { _reserved3 = value; }
        }
    }
}
