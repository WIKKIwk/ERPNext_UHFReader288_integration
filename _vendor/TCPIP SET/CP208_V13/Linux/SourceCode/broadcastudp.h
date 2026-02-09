#ifndef BROADCASTUDP_H
#define BROADCASTUDP_H

#include <QObject>
#include <QUdpSocket>
#include <QNetworkInterface>
#include <QAbstractSocket>
#include <sys/socket.h>

class broadcastudp: public QObject {
    Q_OBJECT
public:
    explicit broadcastudp(QObject *parent = nullptr);
    ~broadcastudp();
    void sendBroadcast(const QByteArray &data, quint16 targetPort);
    QList<QHostAddress> getValidBroadcastAddresses();

signals:
    void receivedResponse(QHostAddress sender, quint16 port, QByteArray data);

private slots:
    void handleBroadcastResponse();

private:
    QUdpSocket *m_socket;
    QString m_currentIP;
    quint16 m_listenPort = 60000;
};

#endif // BROADCASTUDP_H
