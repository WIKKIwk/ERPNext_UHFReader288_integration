#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QStandardItemModel>
#include <QTimer>
#include "udpskt.h"
#include "broadcastudp.h"
#include "util.h"
#include "ui_mainwindow.h"
#include "protocol_utils.h"
#include <QScreen>          // QScreen类
#include <QGuiApplication>  // QGuiApplication类

QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    struct DeviceInfo {
        QString name;
        QHostAddress ip;
        QString mac;
        QString version;

        bool operator==(const DeviceInfo& other) const {
            return mac == other.mac; // MAC地址唯一
        }
    };

    MainWindow(QWidget *parent = nullptr);
    ~MainWindow();

    void handleBroadcastData(QHostAddress addr, quint16 port, QByteArray data);

    void analysisData(const QByteArray &data);
    void handleSetConfig(const QByteArray &data);
    void handleGetConfig(const QByteArray &data);
    void handleDeviceInit(const QByteArray &data);
    void handleGetDevices(const QByteArray &data);

private slots:
    void updateTime();

    void on_btnRefresh_clicked();

    void on_cmbAdapters_currentIndexChanged(int index);

    void on_btnSearch_clicked();

    void on_dtDevices_doubleClicked(const QModelIndex &index);

    void on_btnSetConfig_clicked();

    void on_btnInitialization_clicked();

private:
    Ui::MainWindow *ui;
    udpskt *m_udpskt;
    broadcastudp *m_broadcaster;
    QStandardItemModel *model;
    QLabel *m_timeLabel; // 时间标签
    ConfigStruct m_deviceConfig;  // 设备配置
};
#endif // MAINWINDOW_H
