#ifndef UTIL_H
#define UTIL_H

#include <QObject>
#include <QString>
#include <QByteArray>
#include <QFile>
#include <QDateTime>
#include <QCryptographicHash>
#include <QTextCodec>
#include <QVariant>
#include <QNetworkInterface>
#include <arpa/inet.h>

class util
{
public:
    static const QString CH9120_CFG_FLAG;

    //======================== 字符串处理 ========================
    /// 去除所有空白字符（高效实现）
    static QString removeAllWhitespace(const QString& str);

    /// 转换字符串编码（支持常见编码转换）
    static QByteArray convertEncoding(const QString& str,
                                      const QString& toCodec,
                                      const QString& fromCodec = "UTF-8");
    //====================== 字节数组操作 ========================
    /// 追加单个字节或字节数组（支持链式调用）
    static void appendBytes(QByteArray &dst, quint8 byte);
    static void appendBytes(QByteArray &dst, const QByteArray &bytes);

    //======================== 类型转换 ========================
    /// QVariant 转 bool（支持多种表示形式）
    static bool variantToBool(const QVariant& v, bool defaultValue = false);

    /// 十六进制字符串转字节数组（自动处理0x前缀和空格）
    static QByteArray hexStringToBytes(const QString& hexStr);

    /// 字节数组转十六进制字符串（可定制格式）
    /// @param upperCase 是否大写字母
    /// @param separator 分隔符（如 " ", ":", "0x"）
    /// @param bytePrefix 是否每个字节加前缀（如 "0x"）
    static QString hexArrayToString(const QByteArray &data,
                                    bool upperCase = true,
                                    const QString& separator = " ",
                                    bool bytePrefix = false);

    static QHostAddress parseIpAddress(const QByteArray& ip);

private:
    // 禁用构造函数
    util() = delete;
    ~util() = delete;
    Q_DISABLE_COPY(util)
};

#endif // UTIL_H
