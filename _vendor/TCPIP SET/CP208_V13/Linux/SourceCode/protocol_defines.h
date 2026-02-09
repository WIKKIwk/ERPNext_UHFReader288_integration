#pragma once
#include <QtCore>

// 强制1字节对齐（与C#严格兼容）
#pragma pack(push, 1)

// ================= PortStruct 精确内存布局 =================
struct PortStruct {
    quint8 workMode;          // [0]
    quint8 isRandom;          // [1]
    quint8 netPort[2];        // [2-3] (大端)
    quint8 destinationIP[4];  // [4-7]
    quint8 destinationPort[2];// [8-9] (大端)
    quint8 baudRate[4];       // [10-13] (大端32位)
    quint8 dataBits;          // [14]
    quint8 stopBits;          // [15]
    quint8 checkBits;         // [16]
    quint8 phy;               // [17]
    quint8 rxLen[4];          // [18-21] (大端)
    quint8 rxTimeout[4];      // [22-25] (大端)
    quint8 retryCount;        // [26]
    quint8 resetOperation;    // [27]
    quint8 domainEnable;      // [28]
    char domain[20];          // [29-48]
    quint8 dns[4];            // [49-52]
    quint8 dnsPort[2];        // [53-54] (大端)
    quint8 reserved[8];       // [55-62]
};
static_assert(sizeof(PortStruct) == 63, "PortStruct 内存布局错误");

// ================= ConfigStruct 精确内存布局 =================
struct ConfigStruct {
    quint8 mac[6];            // [0-5]
    quint8 reserved1[6];      // [6-11]
    quint8 len;               // [12]
    quint8 type;              // [13]
    quint8 subType;           // [14]
    quint8 deviceNo;          // [15]
    quint8 hardwareVersion;   // [16]
    quint8 softwareVersion;   // [17]
    char deviceName[21];      // [18-38]
    quint8 netMac[6];         // [39-44]
    quint8 ip[4];             // [45-48]
    quint8 gateway[4];        // [49-52]
    quint8 netMask[4];        // [53-56]
    quint8 dhcp;              // [57]
    quint16 web;              // [58-59] (大端)
    char userName[8];         // [60-67]
    quint8 passwordEnable;    // [68]
    char password[8];         // [69-76]
    quint8 flag;              // [77]
    quint8 serialConfig;      // [78]
    quint8 reserved2[8];      // [79-86]
    quint8 portNo0;           // [87]
    quint8 port0Enable;       // [88]
    PortStruct port0;         // [89-151] (63 bytes)
    quint8 portNo1;           // [152]
    quint8 port1Enable;       // [153]
    PortStruct port1;         // [154-216] (63 bytes)
    quint8 reserved3[51];     // [217-267]
};
static_assert(sizeof(ConfigStruct) == 268, "ConfigStruct 内存布局错误");

#pragma pack(pop)
