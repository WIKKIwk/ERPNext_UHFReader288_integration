// protocol_utils.cpp
#include "protocol_utils.h"

// ================= 序列化/反序列化 =================
QByteArray serializeConfigStruct(const ConfigStruct& config) {
    return QByteArray(reinterpret_cast<const char*>(&config), sizeof(ConfigStruct));
}

ConfigStruct deserializeConfigStruct(const QByteArray& data) {
    ConfigStruct config;
    memset(&config, 0, sizeof(config));  // 初始化清零

    if(data.size() >= static_cast<int>(sizeof(config))) {
        memcpy(&config, data.constData(), sizeof(config));
    } else {
        qWarning() << "[Protocol] 配置结构体反序列化失败: 数据长度不足 (期望:"
                  << sizeof(config) << "实际:" << data.size() << ")";
    }
    return config;
}

// ================= 端口配置操作 =================
quint32 getPortBaudRate(const PortStruct& port) {
    if(sizeof(port.baudRate) < 4) {
        qCritical() << "波特率字段长度异常";
        return 0;
    }
    return qFromBigEndian<quint32>(*reinterpret_cast<const quint32*>(port.baudRate));
}

void setPortBaudRate(PortStruct& port, quint32 rate) {
    const quint32 beRate = qToBigEndian(rate);
    static_assert(sizeof(port.baudRate) == 4, "波特率字段长度必须为4字节");
    memcpy(port.baudRate, &beRate, sizeof(beRate));
}

// ================= 网络地址处理 =================
void setIPAddress(quint8 ip[4], const QString& address) {
    QHostAddress addr(address);
    const quint32 ipv4 = addr.toIPv4Address();
    ip[0] = (ipv4 >> 24) & 0xFF;
    ip[1] = (ipv4 >> 16) & 0xFF;
    ip[2] = (ipv4 >> 8) & 0xFF;
    ip[3] = ipv4 & 0xFF;
}

QString getIPAddress(const quint8 ip[4]) {
    return QString("%1.%2.%3.%4")
           .arg(ip[0]).arg(ip[1]).arg(ip[2]).arg(ip[3]);
}

// ================= 字符串安全处理 =================
void copyStringToArray(char dest[], const QString& src, int maxLen) {
    if(maxLen <= 0) return;

    const QByteArray utf8 = src.toUtf8();
    const int copyLen = qMin(utf8.size(), maxLen-1);  // 保留1字节给终止符

    memset(dest, 0, maxLen);
    memcpy(dest, utf8.constData(), copyLen);

    // 强制最后一个字节为终止符
    dest[copyLen] = '\0';
}

QString getStringFromArray(const char src[], int maxLen) {
    // 查找第一个'\0'的位置
    const int realLen = strnlen(src, maxLen);
    return QString::fromUtf8(src, realLen);
}

// ================= 调试工具 =================
void debugDumpConfig(const ConfigStruct& config) {
    qDebug().nospace() << "\n====== 设备配置信息 ======\n"
                      << "MAC: " << QByteArray::fromRawData(reinterpret_cast<const char*>(config.mac), 6).toHex(':') << "\n"
                      << "IP: " << getIPAddress(config.ip) << "\n"
                      << "子网掩码: " << getIPAddress(config.netMask) << "\n"
                      << "网关: " << getIPAddress(config.gateway) << "\n"
                      << "设备名称: " << getStringFromArray(config.deviceName, sizeof(config.deviceName)) << "\n"
                      << "硬件版本: " << config.hardwareVersion << "\n"
                      << "软件版本: " << config.softwareVersion << "\n"
                      << "\n====== 端口0配置 ======\n"
                      << "使能状态: " << (config.port0Enable ? "启用" : "禁用") << "\n"
                      << "工作模式: " << config.port0.workMode << "\n"
                      << "波特率: " << getPortBaudRate(config.port0) << "\n"
                      << "目标IP: " << getIPAddress(config.port0.destinationIP) << "\n"
                      << "目标端口: " << qFromBigEndian<quint16>(*reinterpret_cast<const quint16*>(config.port0.destinationPort)) << "\n"
                      << "域名: " << getStringFromArray(config.port0.domain, sizeof(config.port0.domain)) << "\n"
                      << "\n====== 端口1配置 ======\n"
                      << "使能状态: " << (config.port1Enable ? "启用" : "禁用") << "\n"
                      << "波特率: " << getPortBaudRate(config.port1) << "\n"
                      << "=================================\n";
}

// ================= 扩展工具函数 =================
quint16 getNetworkPort(const PortStruct& port) {
    return qFromBigEndian<quint16>(*reinterpret_cast<const quint16*>(port.netPort));
}

void setNetworkPort(PortStruct& port, quint16 portNumber) {
    const quint16 bePort = qToBigEndian(portNumber);
    memcpy(port.netPort, &bePort, sizeof(bePort));
}

bool validateConfig(const ConfigStruct& config) {
    // 基础校验
    if(config.type == 0 || config.subType == 0) {
        qWarning() << "无效的设备类型/子类型";
        return false;
    }

    // IP地址合法性检查
    const QString ipStr = getIPAddress(config.ip);
    if(!QHostAddress(ipStr).isNull()) {
        qWarning() << "无效的IP地址配置:" << ipStr;
        return false;
    }

    // 端口波特率范围校验
    if(getPortBaudRate(config.port0) < 1200 ||
       getPortBaudRate(config.port0) > 921600) {
        qWarning() << "端口0波特率超出允许范围";
        return false;
    }

    return true;
}
