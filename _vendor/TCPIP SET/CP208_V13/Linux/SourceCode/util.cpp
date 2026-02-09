#include "util.h"

// 常量定义
const QString util::CH9120_CFG_FLAG = QStringLiteral("CH9120_CFG_FLAG");

//============== 字符串处理 ==============
QString util::removeAllWhitespace(const QString& str)
{
    QString result;
    result.reserve(str.size());
    for (QChar ch : str) {
        if (!ch.isSpace()) {
            result.append(ch);
        }
    }
    return result;
}

QByteArray util::convertEncoding(const QString& str,
                                 const QString& toCodec,
                                 const QString& fromCodec)
{
    QTextCodec* fromCodecObj = QTextCodec::codecForName(fromCodec.toLatin1());
    QTextCodec* toCodecObj = QTextCodec::codecForName(toCodec.toLatin1());

    if (!fromCodecObj || !toCodecObj) {
        return QByteArray();
    }

    QByteArray encodedData = fromCodecObj->fromUnicode(str);
    return toCodecObj->fromUnicode(encodedData);
}

//====================== 字节数组操作 ========================
void util::appendBytes(QByteArray &dst, quint8 byte)
{
    dst.append(static_cast<char>(byte));
}

void util::appendBytes(QByteArray &dst, const QByteArray &bytes)
{
    dst.append(bytes);
}

//====================== 格式转换 ========================
bool util::variantToBool(const QVariant& v, bool defaultValue)
{
    if (v.isNull()) return defaultValue;

    bool ok;
    int intValue = v.toInt(&ok);
    if (ok) return intValue != 0;

    QString strValue = v.toString().trimmed().toLower();
    if (strValue == "true" || strValue == "yes" || strValue == "on" || strValue == "1") {
        return true;
    }
    if (strValue == "false" || strValue == "no" || strValue == "off" || strValue == "0") {
        return false;
    }

    return defaultValue;
}

QByteArray util::hexStringToBytes(const QString& hexStr)
{
    QString processed = hexStr.trimmed();

    // 移除0x前缀
    if (processed.startsWith("0x", Qt::CaseInsensitive)) {
        processed = processed.mid(2);
    }

    // 移除所有空白字符
    processed = removeAllWhitespace(processed);

    // 补齐偶数长度
    if (processed.length() % 2 != 0) {
        processed.prepend('0');
    }

    return QByteArray::fromHex(processed.toLatin1());
}

QString util::hexArrayToString(const QByteArray &data,
                               bool upperCase,
                               const QString& separator,
                               bool bytePrefix)
{
    if (data.isEmpty()) return QString();

    QByteArray hexData = data.toHex();
    const int hexLength = hexData.length();

    // 处理大小写
    if (upperCase) {
        hexData = hexData.toUpper();
    } else {
        hexData = hexData.toLower();
    }

    // 计算最终字符串长度
    const int prefixLen = bytePrefix ? 2 : 0;
    const int itemCount = hexLength / 2;
    const int totalLen = itemCount * (2 + prefixLen) +
                        (itemCount - 1) * separator.length();

    QString result;
    result.reserve(totalLen);

    for (int i = 0; i < hexLength; i += 2) {
        if (i != 0) {
            result.append(separator);
        }

        if (bytePrefix) {
            result.append("0x");
        }

        result.append(hexData.at(i));
        result.append(hexData.at(i + 1));
    }

    return result;
}

QHostAddress util::parseIpAddress(const QByteArray& ip)
{
    if (ip.size() != 4) return QHostAddress();

    quint32 address =
        (static_cast<quint8>(ip[3]) << 24) |
        (static_cast<quint8>(ip[2]) << 16) |
        (static_cast<quint8>(ip[1]) << 8)  |
        static_cast<quint8>(ip[0]);

    return QHostAddress(ntohl(address));
}
