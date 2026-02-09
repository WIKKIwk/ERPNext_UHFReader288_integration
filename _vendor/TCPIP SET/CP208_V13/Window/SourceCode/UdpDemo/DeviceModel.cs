using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo
{
    public class DeviceModel
    {
        private string _mac;
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MAC
        {
            get { return _mac; }
            set { _mac = value; }
        }

        private string _ip;
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _version;
        /// <summary>
        /// 版本
        /// </summary>
        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }
    }
}
