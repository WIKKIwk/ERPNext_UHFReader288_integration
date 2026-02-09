// broadcastudp.cpp
#include "broadcastudp.h"

broadcastudp::broadcastudp(QObject *parent) : QObject(parent) {
    m_socket = new QUdpSocket(this);

    if (m_socket->state() == QUdpSocket::BoundState) {
        m_socket->close();
        disconnect(m_socket, &QUdpSocket::readyRead,
                   this, &broadcastudp::handleBroadcastResponse);
        qDebug() << "Socket unbound";
    }

    // 1. 先绑定端口
    // 修改构造函数中的绑定代码
    if (!m_socket->bind(QHostAddress::AnyIPv4, m_listenPort,
                      QUdpSocket::ShareAddress | QUdpSocket::ReuseAddressHint)) {
        qDebug() << "[错误] 绑定端口失败:" << m_socket->errorString();
    } else {
        qDebug() << "[成功] 已绑定到端口" << m_listenPort
                 << "，本地地址：" << m_socket->localAddress().toString();
        // 2. 设置广播选项
        // 继续设置广播选项和信号槽
        m_socket->setSocketOption(QAbstractSocket::MulticastTtlOption, 15);
        int sockfd = m_socket->socketDescriptor();
        int enable = 1;
        if (setsockopt(sockfd, SOL_SOCKET, SO_BROADCAST,
                       (const char*)&enable, sizeof(enable)) == -1) {
            qDebug() << "无法设置广播选项：" << strerror(errno);
        }
    }

    auto connection = connect(
        m_socket, &QUdpSocket::readyRead,
        this, &broadcastudp::handleBroadcastResponse
    );
    if (connection) {
        qDebug() << "[成功] 信号槽已连接";
    } else {
        qDebug() << "[错误] 信号槽连接失败";
    }
}

broadcastudp::~broadcastudp() {
    qDebug() << "[调试] 析构 broadcastudp 对象";
    m_socket->close();
    delete m_socket; // 如果未设置父对象，需手动释放
}

void broadcastudp::sendBroadcast(const QByteArray &data, quint16 targetPort) {

    qint64 sent = m_socket->writeDatagram(data, QHostAddress::Broadcast, targetPort);
    if (sent == -1) {
        qDebug() << "发送到" << QHostAddress::Broadcast
                << "失败:" << m_socket->errorString();
    } else {
        qDebug() << "成功发送到" << QHostAddress::Broadcast
                << "字节数:" << sent;
    }
}

void broadcastudp::handleBroadcastResponse() {
    QUdpSocket *socket = qobject_cast<QUdpSocket*>(sender());
    if (socket) {
        qDebug() << "[调试] 信号源对象地址:" << socket;
    }
    qDebug() << "[调试] 进入 handleBroadcastResponse";
    while (m_socket->hasPendingDatagrams()) {
        QByteArray datagram;
        datagram.resize(m_socket->pendingDatagramSize());
        QHostAddress senderAddr;
        quint16 senderPort;

        qint64 readSize = m_socket->readDatagram(
            datagram.data(), datagram.size(), &senderAddr, &senderPort
        );

        if (readSize == -1) {
            qDebug() << "[错误] 接收失败:" << m_socket->errorString();
            continue;
        }

        qDebug() << "[接收] 来自" << senderAddr.toString()
                << ":" << senderPort
                << "数据：" << datagram.toHex();
        emit receivedResponse(senderAddr, senderPort, datagram);
    }
}
