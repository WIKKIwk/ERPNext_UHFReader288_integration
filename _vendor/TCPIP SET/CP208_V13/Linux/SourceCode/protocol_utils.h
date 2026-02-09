// protocol_utils.h
#pragma once
#include <QByteArray>
#include <QString>
#include "protocol_defines.h"  // 包含结构体定义
#include <QHostAddress>
#include <QDebug>
#include <cstring>
#include <type_traits>

// ================= 序列化/反序列化 =================
/// @brief 序列化 ConfigStruct 到字节数组
QByteArray serializeConfigStruct(const ConfigStruct& config);

/// @brief 从字节数组反序列化 ConfigStruct
/// @param data 输入数据（必须 ≥ sizeof(ConfigStruct)）
ConfigStruct deserializeConfigStruct(const QByteArray& data);


// ================= 端口配置操作 =================
/// @brief 获取端口波特率（自动转换大端序）
/// @param port 端口结构体引用
/// @return 主机字节序的波特率数值
quint32 getPortBaudRate(const PortStruct& port);

/// @brief 设置端口波特率（自动转大端序）
/// @param port 端口结构体引用
/// @param rate 主机字节序的波特率数值
void setPortBaudRate(PortStruct& port, quint32 rate);


// ================= 网络地址处理 =================
/// @brief 设置IPv4地址到字节数组
/// @param ip 目标字节数组（长度必须≥4）
/// @param address IPv4地址字符串（如"192.168.1.1"）
void setIPAddress(quint8 ip[4], const QString& address);

/// @brief 从字节数组解析IPv4地址
/// @param ip IPv4字节数组（长度必须≥4）
/// @return 点分十进制字符串
QString getIPAddress(const quint8 ip[4]);


// ================= 字符串安全处理 =================
/// @brief 安全拷贝字符串到定长数组
/// @param dest 目标数组
/// @param src 源字符串
/// @param maxLen 数组最大长度（包括终止符）
void copyStringToArray(char dest[], const QString& src, int maxLen);

/// @brief 从定长数组读取字符串
/// @param src 源数组
/// @param maxLen 数组最大长度
/// @return 自动截断的QString
QString getStringFromArray(const char src[], int maxLen);


// ================= 调试工具 =================
/// @brief 打印ConfigStruct的完整信息（调试用）
void debugDumpConfig(const ConfigStruct& config);
