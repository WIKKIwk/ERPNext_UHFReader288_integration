#ifndef UDPSKT_H
#define UDPSKT_H

#include <QObject>
#include <QUdpSocket>
#include <QUrl>
#include <QDebug>

class udpskt : public QObject
{
    Q_OBJECT
public:
    explicit udpskt(QObject *parent = nullptr);
    ~udpskt();

    void setUserIp(const QHostAddress &addr, quint16 port);
    void sendData(const QString &data);
signals:
    void RecvReadSignal(const QString &data,const quint16 &port);
private:
    QUdpSocket *m_socket;
    QHostAddress m_targetAddr;
    quint16 m_targetPort = 50000;
private slots:
    void udpRecvReadSlot();
};

#endif // UDPSKT_H
