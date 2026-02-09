using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpDemo
{
    public class NetworkModel
    {
        private int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private string _adapterName;
        /// <summary>
        /// 适配器名称
        /// </summary>
        public string AdapterName
        {
            get { return _adapterName; }
            set { _adapterName = value; }
        }

        private string _type;
        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _status;
        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _ip;
        /// <summary>
        /// IPv4地址
        /// </summary>
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _mac;
        /// <summary>
        /// MAC地址
        /// </summary>
        public string MAC
        {
            get { return _mac; }
            set { _mac = value; }
        }

        private string _description;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
