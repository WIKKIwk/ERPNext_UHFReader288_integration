/********************************************************************************
** Form generated from reading UI file 'mainwindow.ui'
**
** Created by: Qt User Interface Compiler version 5.12.12
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_MAINWINDOW_H
#define UI_MAINWINDOW_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QCheckBox>
#include <QtWidgets/QComboBox>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTableView>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_MainWindow
{
public:
    QWidget *centralwidget;
    QLabel *label;
    QComboBox *cmbAdapters;
    QPushButton *btnRefresh;
    QGroupBox *groupBox;
    QTableView *dtDevices;
    QPushButton *btnSearch;
    QGroupBox *groupBox_2;
    QLabel *label_2;
    QLabel *label_3;
    QLineEdit *txtIP;
    QLineEdit *txtDeviceName;
    QLabel *label_4;
    QLabel *label_5;
    QLineEdit *txtGateway;
    QLineEdit *txtSubnetMask;
    QCheckBox *ckbDHCP;
    QCheckBox *ckbSerialPortConfig;
    QPushButton *btnInitialization;
    QPushButton *pushButton_2;
    QPushButton *pushButton_3;
    QGroupBox *groupBox_3;
    QLabel *label_6;
    QLabel *label_7;
    QLabel *label_8;
    QLabel *label_9;
    QLabel *label_10;
    QLabel *label_11;
    QLabel *label_12;
    QLabel *label_13;
    QLabel *label_14;
    QLabel *label_15;
    QLabel *label_16;
    QLabel *label_17;
    QLabel *label_18;
    QCheckBox *ckbCLoseConnection;
    QCheckBox *ckbClearPortData;
    QLabel *label_19;
    QLabel *label_20;
    QLineEdit *txtRXPackingTimeout;
    QLineEdit *txtRXPackingLength;
    QLineEdit *txtDestinationPort;
    QLineEdit *txtDestinationIP;
    QLineEdit *txtLocalPort;
    QCheckBox *ckbRandom;
    QComboBox *cmbNetworkMode;
    QComboBox *cmbIPDomainName;
    QComboBox *cmbBaudRate;
    QComboBox *cmbDataBits;
    QComboBox *cmbStopBits;
    QComboBox *cmbCheckBits;
    QPushButton *btnSetConfig;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *MainWindow)
    {
        if (MainWindow->objectName().isEmpty())
            MainWindow->setObjectName(QString::fromUtf8("MainWindow"));
        MainWindow->resize(861, 599);
        centralwidget = new QWidget(MainWindow);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        label = new QLabel(centralwidget);
        label->setObjectName(QString::fromUtf8("label"));
        label->setGeometry(QRect(10, 10, 63, 20));
        cmbAdapters = new QComboBox(centralwidget);
        cmbAdapters->setObjectName(QString::fromUtf8("cmbAdapters"));
        cmbAdapters->setGeometry(QRect(70, 4, 701, 28));
        btnRefresh = new QPushButton(centralwidget);
        btnRefresh->setObjectName(QString::fromUtf8("btnRefresh"));
        btnRefresh->setGeometry(QRect(780, 4, 71, 28));
        groupBox = new QGroupBox(centralwidget);
        groupBox->setObjectName(QString::fromUtf8("groupBox"));
        groupBox->setGeometry(QRect(10, 40, 521, 261));
        dtDevices = new QTableView(groupBox);
        dtDevices->setObjectName(QString::fromUtf8("dtDevices"));
        dtDevices->setGeometry(QRect(0, 20, 521, 241));
        btnSearch = new QPushButton(centralwidget);
        btnSearch->setObjectName(QString::fromUtf8("btnSearch"));
        btnSearch->setGeometry(QRect(10, 310, 521, 28));
        groupBox_2 = new QGroupBox(centralwidget);
        groupBox_2->setObjectName(QString::fromUtf8("groupBox_2"));
        groupBox_2->setGeometry(QRect(10, 380, 521, 161));
        label_2 = new QLabel(groupBox_2);
        label_2->setObjectName(QString::fromUtf8("label_2"));
        label_2->setGeometry(QRect(10, 40, 101, 20));
        label_3 = new QLabel(groupBox_2);
        label_3->setObjectName(QString::fromUtf8("label_3"));
        label_3->setGeometry(QRect(260, 40, 71, 20));
        txtIP = new QLineEdit(groupBox_2);
        txtIP->setObjectName(QString::fromUtf8("txtIP"));
        txtIP->setGeometry(QRect(330, 32, 181, 28));
        txtIP->setAlignment(Qt::AlignLeading|Qt::AlignLeft|Qt::AlignVCenter);
        txtDeviceName = new QLineEdit(groupBox_2);
        txtDeviceName->setObjectName(QString::fromUtf8("txtDeviceName"));
        txtDeviceName->setGeometry(QRect(103, 33, 151, 28));
        label_4 = new QLabel(groupBox_2);
        label_4->setObjectName(QString::fromUtf8("label_4"));
        label_4->setGeometry(QRect(10, 90, 91, 20));
        label_5 = new QLabel(groupBox_2);
        label_5->setObjectName(QString::fromUtf8("label_5"));
        label_5->setGeometry(QRect(260, 90, 71, 20));
        txtGateway = new QLineEdit(groupBox_2);
        txtGateway->setObjectName(QString::fromUtf8("txtGateway"));
        txtGateway->setGeometry(QRect(330, 82, 181, 28));
        txtSubnetMask = new QLineEdit(groupBox_2);
        txtSubnetMask->setObjectName(QString::fromUtf8("txtSubnetMask"));
        txtSubnetMask->setGeometry(QRect(103, 82, 151, 28));
        ckbDHCP = new QCheckBox(groupBox_2);
        ckbDHCP->setObjectName(QString::fromUtf8("ckbDHCP"));
        ckbDHCP->setGeometry(QRect(10, 124, 91, 26));
        ckbSerialPortConfig = new QCheckBox(groupBox_2);
        ckbSerialPortConfig->setObjectName(QString::fromUtf8("ckbSerialPortConfig"));
        ckbSerialPortConfig->setGeometry(QRect(250, 125, 261, 26));
        btnInitialization = new QPushButton(centralwidget);
        btnInitialization->setObjectName(QString::fromUtf8("btnInitialization"));
        btnInitialization->setGeometry(QRect(10, 340, 171, 28));
        pushButton_2 = new QPushButton(centralwidget);
        pushButton_2->setObjectName(QString::fromUtf8("pushButton_2"));
        pushButton_2->setGeometry(QRect(185, 340, 171, 28));
        pushButton_3 = new QPushButton(centralwidget);
        pushButton_3->setObjectName(QString::fromUtf8("pushButton_3"));
        pushButton_3->setGeometry(QRect(360, 340, 171, 28));
        groupBox_3 = new QGroupBox(centralwidget);
        groupBox_3->setObjectName(QString::fromUtf8("groupBox_3"));
        groupBox_3->setGeometry(QRect(540, 40, 311, 461));
        label_6 = new QLabel(groupBox_3);
        label_6->setObjectName(QString::fromUtf8("label_6"));
        label_6->setGeometry(QRect(11, 41, 121, 20));
        label_7 = new QLabel(groupBox_3);
        label_7->setObjectName(QString::fromUtf8("label_7"));
        label_7->setGeometry(QRect(11, 73, 81, 20));
        label_8 = new QLabel(groupBox_3);
        label_8->setObjectName(QString::fromUtf8("label_8"));
        label_8->setGeometry(QRect(11, 105, 121, 20));
        label_9 = new QLabel(groupBox_3);
        label_9->setObjectName(QString::fromUtf8("label_9"));
        label_9->setGeometry(QRect(11, 137, 101, 20));
        label_10 = new QLabel(groupBox_3);
        label_10->setObjectName(QString::fromUtf8("label_10"));
        label_10->setGeometry(QRect(11, 169, 121, 20));
        label_11 = new QLabel(groupBox_3);
        label_11->setObjectName(QString::fromUtf8("label_11"));
        label_11->setGeometry(QRect(11, 201, 81, 20));
        label_12 = new QLabel(groupBox_3);
        label_12->setObjectName(QString::fromUtf8("label_12"));
        label_12->setGeometry(QRect(11, 233, 71, 20));
        label_13 = new QLabel(groupBox_3);
        label_13->setObjectName(QString::fromUtf8("label_13"));
        label_13->setGeometry(QRect(11, 264, 81, 20));
        label_14 = new QLabel(groupBox_3);
        label_14->setObjectName(QString::fromUtf8("label_14"));
        label_14->setGeometry(QRect(11, 296, 81, 20));
        label_15 = new QLabel(groupBox_3);
        label_15->setObjectName(QString::fromUtf8("label_15"));
        label_15->setGeometry(QRect(11, 328, 161, 20));
        label_16 = new QLabel(groupBox_3);
        label_16->setObjectName(QString::fromUtf8("label_16"));
        label_16->setGeometry(QRect(11, 360, 131, 20));
        label_17 = new QLabel(groupBox_3);
        label_17->setObjectName(QString::fromUtf8("label_17"));
        label_17->setGeometry(QRect(11, 392, 141, 20));
        label_18 = new QLabel(groupBox_3);
        label_18->setObjectName(QString::fromUtf8("label_18"));
        label_18->setGeometry(QRect(11, 424, 141, 20));
        ckbCLoseConnection = new QCheckBox(groupBox_3);
        ckbCLoseConnection->setObjectName(QString::fromUtf8("ckbCLoseConnection"));
        ckbCLoseConnection->setGeometry(QRect(170, 325, 141, 26));
        ckbClearPortData = new QCheckBox(groupBox_3);
        ckbClearPortData->setObjectName(QString::fromUtf8("ckbClearPortData"));
        ckbClearPortData->setGeometry(QRect(160, 420, 141, 26));
        label_19 = new QLabel(groupBox_3);
        label_19->setObjectName(QString::fromUtf8("label_19"));
        label_19->setGeometry(QRect(250, 390, 51, 20));
        label_20 = new QLabel(groupBox_3);
        label_20->setObjectName(QString::fromUtf8("label_20"));
        label_20->setGeometry(QRect(250, 360, 61, 20));
        txtRXPackingTimeout = new QLineEdit(groupBox_3);
        txtRXPackingTimeout->setObjectName(QString::fromUtf8("txtRXPackingTimeout"));
        txtRXPackingTimeout->setGeometry(QRect(150, 390, 91, 28));
        txtRXPackingLength = new QLineEdit(groupBox_3);
        txtRXPackingLength->setObjectName(QString::fromUtf8("txtRXPackingLength"));
        txtRXPackingLength->setGeometry(QRect(140, 354, 101, 28));
        txtDestinationPort = new QLineEdit(groupBox_3);
        txtDestinationPort->setObjectName(QString::fromUtf8("txtDestinationPort"));
        txtDestinationPort->setGeometry(QRect(130, 163, 171, 28));
        txtDestinationIP = new QLineEdit(groupBox_3);
        txtDestinationIP->setObjectName(QString::fromUtf8("txtDestinationIP"));
        txtDestinationIP->setGeometry(QRect(130, 132, 171, 28));
        txtLocalPort = new QLineEdit(groupBox_3);
        txtLocalPort->setObjectName(QString::fromUtf8("txtLocalPort"));
        txtLocalPort->setGeometry(QRect(170, 70, 131, 28));
        ckbRandom = new QCheckBox(groupBox_3);
        ckbRandom->setObjectName(QString::fromUtf8("ckbRandom"));
        ckbRandom->setGeometry(QRect(90, 70, 81, 26));
        cmbNetworkMode = new QComboBox(groupBox_3);
        cmbNetworkMode->setObjectName(QString::fromUtf8("cmbNetworkMode"));
        cmbNetworkMode->setGeometry(QRect(120, 37, 181, 28));
        cmbIPDomainName = new QComboBox(groupBox_3);
        cmbIPDomainName->setObjectName(QString::fromUtf8("cmbIPDomainName"));
        cmbIPDomainName->setGeometry(QRect(130, 100, 171, 28));
        cmbBaudRate = new QComboBox(groupBox_3);
        cmbBaudRate->setObjectName(QString::fromUtf8("cmbBaudRate"));
        cmbBaudRate->setGeometry(QRect(90, 196, 211, 28));
        cmbDataBits = new QComboBox(groupBox_3);
        cmbDataBits->setObjectName(QString::fromUtf8("cmbDataBits"));
        cmbDataBits->setGeometry(QRect(90, 230, 211, 28));
        cmbStopBits = new QComboBox(groupBox_3);
        cmbStopBits->setObjectName(QString::fromUtf8("cmbStopBits"));
        cmbStopBits->setGeometry(QRect(90, 261, 211, 28));
        cmbCheckBits = new QComboBox(groupBox_3);
        cmbCheckBits->setObjectName(QString::fromUtf8("cmbCheckBits"));
        cmbCheckBits->setGeometry(QRect(90, 294, 211, 28));
        btnSetConfig = new QPushButton(centralwidget);
        btnSetConfig->setObjectName(QString::fromUtf8("btnSetConfig"));
        btnSetConfig->setGeometry(QRect(540, 510, 311, 28));
        MainWindow->setCentralWidget(centralwidget);
        menubar = new QMenuBar(MainWindow);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 861, 25));
        MainWindow->setMenuBar(menubar);
        statusbar = new QStatusBar(MainWindow);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        MainWindow->setStatusBar(statusbar);

        retranslateUi(MainWindow);

        QMetaObject::connectSlotsByName(MainWindow);
    } // setupUi

    void retranslateUi(QMainWindow *MainWindow)
    {
        MainWindow->setWindowTitle(QApplication::translate("MainWindow", "CF815 Linux Demo", nullptr));
        label->setText(QApplication::translate("MainWindow", "Adapter:", nullptr));
        btnRefresh->setText(QApplication::translate("MainWindow", "Refresh", nullptr));
        groupBox->setTitle(QApplication::translate("MainWindow", "Device list (Double click the device list to get the device configuration))", nullptr));
        btnSearch->setText(QApplication::translate("MainWindow", "Search Devices", nullptr));
        groupBox_2->setTitle(QApplication::translate("MainWindow", "Basic Settings", nullptr));
        label_2->setText(QApplication::translate("MainWindow", "Device Name:", nullptr));
        label_3->setText(QApplication::translate("MainWindow", "Device IP:", nullptr));
        txtIP->setInputMask(QString());
        label_4->setText(QApplication::translate("MainWindow", "Subnet Mask:", nullptr));
        label_5->setText(QApplication::translate("MainWindow", "Gateway:", nullptr));
        ckbDHCP->setText(QApplication::translate("MainWindow", "DHCP", nullptr));
        ckbSerialPortConfig->setText(QApplication::translate("MainWindow", "Serial port negotiation configuration", nullptr));
        btnInitialization->setText(QApplication::translate("MainWindow", "Initialization", nullptr));
        pushButton_2->setText(QApplication::translate("MainWindow", "Load Config File", nullptr));
        pushButton_3->setText(QApplication::translate("MainWindow", "Export Profile", nullptr));
        groupBox_3->setTitle(QApplication::translate("MainWindow", "Port 1", nullptr));
        label_6->setText(QApplication::translate("MainWindow", "Network Mode:", nullptr));
        label_7->setText(QApplication::translate("MainWindow", "Local Port:", nullptr));
        label_8->setText(QApplication::translate("MainWindow", "IP/Domain Name:", nullptr));
        label_9->setText(QApplication::translate("MainWindow", "Destination IP:", nullptr));
        label_10->setText(QApplication::translate("MainWindow", "Destination Port:", nullptr));
        label_11->setText(QApplication::translate("MainWindow", "Baud Rate:", nullptr));
        label_12->setText(QApplication::translate("MainWindow", "Data Bits:", nullptr));
        label_13->setText(QApplication::translate("MainWindow", "Stop Bits:", nullptr));
        label_14->setText(QApplication::translate("MainWindow", "Check Bits:", nullptr));
        label_15->setText(QApplication::translate("MainWindow", "Network Disconnected:", nullptr));
        label_16->setText(QApplication::translate("MainWindow", "RX Packing Length:", nullptr));
        label_17->setText(QApplication::translate("MainWindow", "RX Packing Timeout:", nullptr));
        label_18->setText(QApplication::translate("MainWindow", "Network Connected:", nullptr));
        ckbCLoseConnection->setText(QApplication::translate("MainWindow", "Close Connection", nullptr));
        ckbClearPortData->setText(QApplication::translate("MainWindow", "Clear Port Data", nullptr));
        label_19->setText(QApplication::translate("MainWindow", "(10ms)", nullptr));
        label_20->setText(QApplication::translate("MainWindow", "(<=512)", nullptr));
        ckbRandom->setText(QApplication::translate("MainWindow", "Random", nullptr));
        btnSetConfig->setText(QApplication::translate("MainWindow", "Set Configuration", nullptr));
    } // retranslateUi

};

namespace Ui {
    class MainWindow: public Ui_MainWindow {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_MAINWINDOW_H
