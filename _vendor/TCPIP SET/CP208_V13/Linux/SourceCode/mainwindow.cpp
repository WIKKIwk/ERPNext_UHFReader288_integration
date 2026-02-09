#include "mainwindow.h"

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    QTimer::singleShot(50, this, [this]() {
        QScreen *screen = QGuiApplication::screenAt(QCursor::pos());
        if (!screen) screen = QGuiApplication::primaryScreen();

        QRect geom = screen->availableGeometry();
        move(
            geom.x() + (geom.width() - width()) / 2,
            geom.y() + (geom.height() - height()) / 2
        );
    });

    setWindowFlag(Qt::WindowMinimizeButtonHint, false);
    setWindowFlag(Qt::WindowMaximizeButtonHint, false);

    this->model = new QStandardItemModel;   //创建一个标准的条目模型
    this->ui->dtDevices->setModel(model);   //将tableview设置成model这个标准条目模型的模板, model设置的内容都将显示在tableview上
    this->model->setHorizontalHeaderItem(0, new QStandardItem("Name") );
    this->model->setHorizontalHeaderItem(1, new QStandardItem("IP") );
    this->model->setHorizontalHeaderItem(2, new QStandardItem("MAC"));
    this->model->setHorizontalHeaderItem(3, new QStandardItem("Version"));
    ui->dtDevices->horizontalHeader()->setMinimumSectionSize(50);  // 全局最小宽度（所有列生效）
    // 固定宽度为200像素
    ui->dtDevices->setColumnWidth(3, 50);
    // 根据内容自动调整
    ui->dtDevices->horizontalHeader()->setSectionResizeMode(1, QHeaderView::ResizeToContents);
    // 拉伸填充剩余空间
    ui->dtDevices->horizontalHeader()->setSectionResizeMode(0, QHeaderView::Stretch);
    ui->dtDevices->horizontalHeader()->setSectionResizeMode(2, QHeaderView::Stretch);
    // 设置表格视图不可编辑
    ui->dtDevices->setEditTriggers(QAbstractItemView::NoEditTriggers);
    // 设置选中模式为选中整行
    ui->dtDevices->setSelectionBehavior(QAbstractItemView::SelectRows);  // 选中整行
    ui->dtDevices->setSelectionMode(QAbstractItemView::SingleSelection); // 单选（或 ExtendedSelection 支持多选）

    ui->cmbNetworkMode->addItem("TCP SERVER",0);
    ui->cmbNetworkMode->addItem("TCP CLIENT",1);
    ui->cmbNetworkMode->addItem("UDP SERVER",2);
    ui->cmbNetworkMode->addItem("UDP CLIENT",3);
    ui->cmbNetworkMode->setCurrentIndex(-1);

    ui->cmbIPDomainName->addItem("IP",0);
    ui->cmbIPDomainName->addItem("Domain Name",1);
    ui->cmbIPDomainName->setCurrentIndex(-1);

    ui->cmbBaudRate->addItem("300",300);
    ui->cmbBaudRate->addItem("600",600);
    ui->cmbBaudRate->addItem("1200",1200);
    ui->cmbBaudRate->addItem("2400",2400);
    ui->cmbBaudRate->addItem("4800",4800);
    ui->cmbBaudRate->addItem("9600",9600);
    ui->cmbBaudRate->addItem("14400",14400);
    ui->cmbBaudRate->addItem("19600",19600);
    ui->cmbBaudRate->addItem("38400",38400);
    ui->cmbBaudRate->addItem("57600",57600);
    ui->cmbBaudRate->addItem("115200",115200);
    ui->cmbBaudRate->addItem("230400",230400);
    ui->cmbBaudRate->addItem("460800",460800);
    ui->cmbBaudRate->addItem("921600",921600);
    ui->cmbBaudRate->setCurrentIndex(-1);

    ui->cmbDataBits->addItem("5",0);
    ui->cmbDataBits->addItem("6",1);
    ui->cmbDataBits->addItem("7",2);
    ui->cmbDataBits->addItem("8",3);
    ui->cmbDataBits->setCurrentIndex(-1);

    ui->cmbStopBits->addItem("1",0);
    ui->cmbStopBits->addItem("2",1);
    ui->cmbStopBits->setCurrentIndex(-1);

    ui->cmbCheckBits->addItem("Even Check",0);
    ui->cmbCheckBits->addItem("Mask Check",1);
    ui->cmbCheckBits->addItem("Space Check",2);
    ui->cmbCheckBits->addItem("None",3);
    ui->cmbCheckBits->setCurrentIndex(-1);

    QRegExp rx("^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
    QRegExpValidator* ipValidator = new QRegExpValidator(rx, this);
    ui->txtIP->setValidator(ipValidator);
    ui->txtSubnetMask->setValidator(ipValidator);
    ui->txtGateway->setValidator(ipValidator);
    ui->txtDestinationIP->setValidator(ipValidator);

    // 初始化状态栏
    QStatusBar *statusBar = this->statusBar(); // 获取状态栏（自动创建）
    // 添加临时文本（显示在左侧，默认区域）
    statusBar->showMessage("Operation status: System Started!"); // 显示3秒后自动消失
    m_timeLabel = new QLabel(this);
    statusBar->addPermanentWidget(m_timeLabel); // 永久显示在右侧

    // 初始化定时器（每秒更新一次）
    QTimer *timer = new QTimer(this);
    connect(timer, &QTimer::timeout, this, &MainWindow::updateTime);
    timer->start(1000); // 1秒触发一次

    // 立即显示时间（避免启动后等待1秒）
    updateTime();

    // 初始化广播模块
    m_broadcaster = new broadcastudp(this);

    connect(m_broadcaster, &broadcastudp::receivedResponse,
          this, &MainWindow::handleBroadcastData);

    on_btnRefresh_clicked();  // 初始化时自动刷新
}

MainWindow::~MainWindow()
{
    delete ui;
}

void MainWindow::updateTime() {
        // 格式化时间（例如："HH:mm:ss" 或 "yyyy-MM-dd HH:mm:ss"）
        QString currentTime = QDateTime::currentDateTime().toString("yyyy-MM-dd HH:mm:ss");
        m_timeLabel->setText(currentTime);
    }

void MainWindow::handleBroadcastData(QHostAddress addr, quint16 port, QByteArray data)
{
    const QString msg = QString("[广播来自 %1:%2]\n%3\n")
            .arg(addr.toString())
            .arg(port)
            .arg(util::hexArrayToString(data));
    qDebug().noquote() << msg;
    analysisData(data);
}

void MainWindow::analysisData(const QByteArray &data){
    const int OPCODE_POS = 16;

        // 1. 检查数据有效性
        if (data.size() <= OPCODE_POS) {
            qWarning().nospace()
                << "数据长度不足 (" << data.size()
                << "), 需要至少 " << (OPCODE_POS + 1) << " 字节";
            return;
        }

        // 2. 安全获取操作码
        quint8 opCode = static_cast<quint8>(data[OPCODE_POS]);
        qDebug().nospace()
            << "解析操作码 [0x" << QString::number(opCode, 16).toUpper() << "] "
            << "数据长度: " << data.size() << " 字节";

        // 3. 分派处理逻辑
        switch (opCode) {
            case 0x81:
                handleSetConfig(data);
                break;
            case 0x82:
                handleGetConfig(data);
                break;
            case 0x83:
                handleDeviceInit(data);
                break;
            case 0x84:
                handleGetDevices(data);
                break;
            default:
                qWarning() << "未知操作码: 0x"
                          << QString::number(opCode, 16).toUpper();
                break;
        }
}
void MainWindow::handleSetConfig(const QByteArray &data){
    qDebug()<<"设置设备配置...";
    this->statusBar()->showMessage("Operation status: Set Device Configuration Successfully!");
}
void MainWindow::handleGetConfig(const QByteArray &data){
    qDebug()<<"获取设备配置...";
    // 安全校验：总数据长度需 ≥ 头部16字节 + 配置结构体大小
    const int headerSize = 17;  // 协议头长度
    const int requiredSize = headerSize + sizeof(ConfigStruct);

    if (data.size() < requiredSize) {
        qWarning() << "配置数据长度不足，期望最小长度:" << requiredSize
                  << "实际长度:" << data.size();
        return;
    }

    // 截取有效负载数据（跳过前16字节头部）
    const QByteArray payload = data.mid(headerSize);

    // 反序列化配置
    m_deviceConfig = deserializeConfigStruct(payload);

    // 验证配置完整性（可选）
    if (payload.size() < static_cast<int>(sizeof(ConfigStruct))) {
        qWarning() << "警告：配置数据不完整，部分字段可能未正确解析";
    }

    // 调试输出配置信息
    // debugDumpConfig(m_deviceConfig);
    ui->txtDeviceName->setText(getStringFromArray(m_deviceConfig.deviceName,sizeof(m_deviceConfig.deviceName)));
    ui->txtIP->setText(getIPAddress(m_deviceConfig.ip));
    ui->txtSubnetMask->setText(getIPAddress(m_deviceConfig.netMask));
    ui->txtGateway->setText(getIPAddress(m_deviceConfig.gateway));
    ui->ckbDHCP->setChecked(util::variantToBool(m_deviceConfig.dhcp));
    ui->ckbSerialPortConfig->setChecked(util::variantToBool(m_deviceConfig.serialConfig));
    const int workMode = m_deviceConfig.port1.workMode;
    if (workMode >= 0 && workMode < ui->cmbNetworkMode->count()) {
        ui->cmbNetworkMode->setCurrentIndex(workMode);
    } else {
        qWarning() << "无效的工作模式值:" << workMode;
        ui->cmbNetworkMode->setCurrentIndex(0); // 设为默认值
    }
    ui->ckbRandom->setChecked(util::variantToBool(m_deviceConfig.port1.isRandom));
    quint16 port = static_cast<quint16>(m_deviceConfig.port1.netPort[0])
            | (static_cast<quint16>(m_deviceConfig.port1.netPort[1]) << 8);
    ui->txtLocalPort->setText(QString::number(port));
    const int domainEnable = m_deviceConfig.port1.domainEnable;
    ui->cmbIPDomainName->setCurrentIndex(domainEnable);
    ui->txtDestinationIP->setText(getIPAddress(m_deviceConfig.port1.destinationIP));
    quint16 destinationPort = static_cast<quint16>(m_deviceConfig.port1.destinationPort[0])
            | (static_cast<quint16>(m_deviceConfig.port1.destinationPort[1]) << 8);
    ui->txtDestinationPort->setText(QString::number(destinationPort));
    quint32 baudRate = static_cast<quint16>(m_deviceConfig.port1.baudRate[0])
            | (static_cast<quint16>(m_deviceConfig.port1.baudRate[1]) << 8)
            | (static_cast<quint16>(m_deviceConfig.port1.baudRate[2]) << 16)
            | (static_cast<quint16>(m_deviceConfig.port1.baudRate[3]) << 24);
    ui->cmbBaudRate->setCurrentText(QString::number(baudRate));
    const int dataBits = m_deviceConfig.port1.dataBits;
    ui->cmbDataBits->setCurrentText(QString::number(dataBits));
    const int stopBits = m_deviceConfig.port1.stopBits;
    ui->cmbStopBits->setCurrentIndex(stopBits);
    int checkBits = m_deviceConfig.port1.checkBits;
    checkBits = checkBits - 1 ;
    if (checkBits >= 0 && checkBits < ui->cmbCheckBits->count()) {
        ui->cmbCheckBits->setCurrentIndex(checkBits);
    } else {
        qWarning() << "无效的校验位:" << checkBits;
        ui->cmbCheckBits->setCurrentIndex(3); // 设为默认值
    }
    ui->ckbCLoseConnection->setChecked(util::variantToBool(m_deviceConfig.port1.phy));
    quint32 rxPackingLength = static_cast<quint16>(m_deviceConfig.port1.rxLen[0])
            | (static_cast<quint16>(m_deviceConfig.port1.rxLen[1]) << 8)
            | (static_cast<quint16>(m_deviceConfig.port1.rxLen[2]) << 16)
            | (static_cast<quint16>(m_deviceConfig.port1.rxLen[3]) << 24);
    ui->txtRXPackingLength->setText(QString::number(rxPackingLength));
    quint32 rxPackingTimeout = static_cast<quint16>(m_deviceConfig.port1.rxTimeout[0])
            | (static_cast<quint16>(m_deviceConfig.port1.rxTimeout[1]) << 8)
            | (static_cast<quint16>(m_deviceConfig.port1.rxTimeout[2]) << 16)
            | (static_cast<quint16>(m_deviceConfig.port1.rxTimeout[3]) << 24);
    ui->txtRXPackingTimeout->setText(QString::number(rxPackingTimeout));
    ui->ckbClearPortData->setChecked(util::variantToBool(m_deviceConfig.port1.resetOperation));
    this->statusBar()->showMessage("Operation status: Get Device Configuration Successfully!");
}
void MainWindow::handleDeviceInit(const QByteArray &data){
    qDebug()<<"初始化设备...";
    this->statusBar()->showMessage("Operation status: Initialization Device Successfully!");
}
void MainWindow::handleGetDevices(const QByteArray &data){
    qDebug()<<"获取设备...";
    DeviceInfo device;

    // 1. 解析MAC地址（17-22字节）
    device.mac = QString::fromLatin1(data.mid(17, 6).toHex(':')).toUpper();

    // 2. 解析IP地址（30-33字节）
    device.ip = util::parseIpAddress(data.mid(30, 4));

    // 3. 解析设备名称
    const quint8 nameLength = static_cast<quint8>(data.at(29));
    if (34 + nameLength - 4 > data.size()) {
        throw std::out_of_range("设备名称长度越界");
    }
    device.name = QString::fromLatin1(data.mid(34, nameLength - 4));

    // 4. 解析版本号
    const int versionPos = 29 + nameLength + 1;
    if (versionPos >= data.size()) {
        throw std::out_of_range("版本号位置越界");
    }
    device.version = QString::number(static_cast<quint8>(data.at(versionPos)));

    QList<QStandardItem*> rowItems;
    rowItems << new QStandardItem(device.name)
             << new QStandardItem(device.ip.toString())
             << new QStandardItem(device.mac)
             << new QStandardItem(device.version);
    model->appendRow(rowItems); // 自动刷新表格显示
    this->statusBar()->showMessage("Operation status: Device Search Successfully!");
}

void MainWindow::on_btnRefresh_clicked()
{
    ui->cmbAdapters->clear();  // 清空原有项

    QList<QNetworkInterface> interfaces = QNetworkInterface::allInterfaces();

    foreach (const QNetworkInterface &interface, interfaces) {
        // 过滤无效接口（根据需求调整条件）
        if (!interface.isValid() ||
                (interface.flags() & QNetworkInterface::IsUp) == 0 ||
                interface.hardwareAddress().isEmpty())
            continue;
        // 获取第一个IPv4地址
        QString ipAddress;
        foreach (const QNetworkAddressEntry &entry, interface.addressEntries()) {
            if (entry.ip().protocol() == QAbstractSocket::IPv4Protocol) {
                ipAddress = entry.ip().toString();
                break;
            }
        }
        // 格式化显示内容
        QString itemText = QString("%1 | MAC: %2 | IP: %3")
                .arg(interface.humanReadableName())
                .arg(interface.hardwareAddress())
                .arg(ipAddress);
        // 添加到下拉框
        ui->cmbAdapters->addItem(itemText,ipAddress);
        ui->cmbAdapters->setCurrentIndex(ui->cmbAdapters->count() - 1);
        emit ui->cmbAdapters->currentIndexChanged(ui->cmbAdapters->currentIndex());
    }
    this->statusBar()->showMessage("Operation status: Adapter Refreshed Successfully!");
}

void MainWindow::on_cmbAdapters_currentIndexChanged(int index)
{
    QString ip = ui->cmbAdapters->itemData(index).toString();
    qDebug()<<ip;
}

void MainWindow::on_btnSearch_clicked()
{
    // 删除从第0行开始的所有行（保留列头）
    model->removeRows(0, model->rowCount());
    // 将文本内容转换为字节数组，并追加0x0400的二进制数据
    QByteArray data = util::CH9120_CFG_FLAG.toUtf8();
    data.append(QByteArray::fromHex("0004")); // 添加0x00 0x04

    // 发送组合后的数据包
    m_broadcaster->sendBroadcast(data, 50000);
    this->statusBar()->showMessage("Operation status: Start Search Devices...");
}

void MainWindow::on_dtDevices_doubleClicked(const QModelIndex &index)
{
    qDebug()<<"开始获取设备配置信息...";
    // 获取被双击的行号
    int row = index.row();

    // 获取模型指针（假设model是成员变量或通过其他方式获取）
    QStandardItemModel *model = qobject_cast<QStandardItemModel*>(ui->dtDevices->model());
    if (!model) return;

    // 获取MAC地址（第三列，索引2）
    QModelIndex macIndex = model->index(row, 2);
    QString mac = macIndex.data(Qt::DisplayRole).toString();

    // 使用MAC地址进行后续操作
    qDebug() << "双击的MAC地址：" << mac;

    mac.remove(':');
    QByteArray macBytes = QByteArray::fromHex(mac.toLatin1());
    QByteArray data = util::CH9120_CFG_FLAG.toUtf8();
    data.append(QByteArray::fromHex("0002")); // 添加0x00 0x02
    data.append(macBytes);
    // 发送组合后的数据包
    m_broadcaster->sendBroadcast(data, 50000);
    this->statusBar()->showMessage("Operation status: Start Get Device Configuration...");
}


void MainWindow::on_btnSetConfig_clicked()
{
    // 将控件值赋给 m_deviceConfig
    // 设备名称
    QByteArray deviceNameBytes = ui->txtDeviceName->text().toUtf8();
    qstrncpy(m_deviceConfig.deviceName, deviceNameBytes.constData(), sizeof(m_deviceConfig.deviceName));

    // IP地址
    setIPAddress(m_deviceConfig.ip,ui->txtIP->text());
    // 子网掩码
    setIPAddress(m_deviceConfig.netMask,ui->txtSubnetMask->text());
    // 网关
    setIPAddress(m_deviceConfig.gateway,ui->txtGateway->text());

    // DHCP
    m_deviceConfig.dhcp = ui->ckbDHCP->isChecked()? 1 : 0;
    // 串口配置
    m_deviceConfig.serialConfig = ui->ckbSerialPortConfig->isChecked()? 1 : 0;

    // 工作模式
    int workMode = ui->cmbNetworkMode->currentIndex();
    if (workMode >= 0 && workMode < ui->cmbNetworkMode->count()) {
        m_deviceConfig.port1.workMode = workMode;
    } else {
        qWarning() << "无效的工作模式，使用默认值";
        m_deviceConfig.port1.workMode = 0;
    }

    // 随机端口
    m_deviceConfig.port1.isRandom = ui->ckbRandom->isChecked()? 1 : 0;

    // 本地端口
    bool ok;
    quint16 localPort = ui->txtLocalPort->text().toUShort(&ok);
    if (ok) {
        m_deviceConfig.port1.netPort[0] = static_cast<quint8>(localPort & 0xFF);
        m_deviceConfig.port1.netPort[1] = static_cast<quint8>((localPort >> 8) & 0xFF);
    } else {
        qWarning() << "无效的本地端口号，使用默认值";
        m_deviceConfig.port1.netPort[0] = 0;
        m_deviceConfig.port1.netPort[1] = 0;
    }

    // 域名使能
    int domainEnable = ui->cmbIPDomainName->currentIndex();
    m_deviceConfig.port1.domainEnable = domainEnable;

    // 目标IP
    setIPAddress( m_deviceConfig.port1.destinationIP,ui->txtDestinationIP->text());

    // 目标端口
    quint16 destPort = ui->txtDestinationPort->text().toUShort(&ok);
    if (ok) {
        m_deviceConfig.port1.destinationPort[0] = static_cast<quint8>(destPort & 0xFF);
        m_deviceConfig.port1.destinationPort[1] = static_cast<quint8>((destPort >> 8) & 0xFF);
    } else {
        qWarning() << "无效的目标端口，使用默认值";
        m_deviceConfig.port1.destinationPort[0] = 0;
        m_deviceConfig.port1.destinationPort[1] = 0;
    }

    // 波特率
    quint32 baudRate = ui->cmbBaudRate->currentText().toUInt(&ok);
    if (ok) {
        m_deviceConfig.port1.baudRate[0] = static_cast<quint8>((baudRate >> 0) & 0xFF);
        m_deviceConfig.port1.baudRate[1] = static_cast<quint8>((baudRate >> 8) & 0xFF);
        m_deviceConfig.port1.baudRate[2] = static_cast<quint8>((baudRate >> 16) & 0xFF);
        m_deviceConfig.port1.baudRate[3] = static_cast<quint8>((baudRate >> 24) & 0xFF);
    } else {
        qWarning() << "无效的波特率，使用默认值";
        memset(m_deviceConfig.port1.baudRate, 0, sizeof(m_deviceConfig.port1.baudRate));
    }

    // 数据位
    int dataBits = ui->cmbDataBits->currentText().toInt(&ok);
    if (ok) {
        m_deviceConfig.port1.dataBits = dataBits;
    } else {
        qWarning() << "无效的数据位，使用默认值";
        m_deviceConfig.port1.dataBits = 8;
    }

    // 停止位
    int stopBits = ui->cmbStopBits->currentIndex();
    m_deviceConfig.port1.stopBits = stopBits;

    // 校验位
    int checkBits = ui->cmbCheckBits->currentIndex();
    if (checkBits >= 0 && checkBits < ui->cmbCheckBits->count()) {
        m_deviceConfig.port1.checkBits = checkBits + 1;
    } else {
        qWarning() << "无效的校验位，使用默认值";
        m_deviceConfig.port1.checkBits = 4;
    }

    // 关闭连接
    m_deviceConfig.port1.phy = ui->ckbCLoseConnection->isChecked()? 1 : 0;

    // RX打包长度
    quint32 rxLen = ui->txtRXPackingLength->text().toUInt(&ok);
    if (ok) {
        m_deviceConfig.port1.rxLen[0] = static_cast<quint8>((rxLen >> 0) & 0xFF);
        m_deviceConfig.port1.rxLen[1] = static_cast<quint8>((rxLen >> 8) & 0xFF);
        m_deviceConfig.port1.rxLen[2] = static_cast<quint8>((rxLen >> 16) & 0xFF);
        m_deviceConfig.port1.rxLen[3] = static_cast<quint8>((rxLen >> 24) & 0xFF);
    } else {
        qWarning() << "无效的RX打包长度，使用默认值";
        memset(m_deviceConfig.port1.rxLen, 0, sizeof(m_deviceConfig.port1.rxLen));
    }

    // RX打包超时
    quint32 rxTimeout = ui->txtRXPackingTimeout->text().toUInt(&ok);
    if (ok) {
        m_deviceConfig.port1.rxTimeout[0] = static_cast<quint8>((rxTimeout >> 0) & 0xFF);
        m_deviceConfig.port1.rxTimeout[1] = static_cast<quint8>((rxTimeout >> 8) & 0xFF);
        m_deviceConfig.port1.rxTimeout[2] = static_cast<quint8>((rxTimeout >> 16) & 0xFF);
        m_deviceConfig.port1.rxTimeout[3] = static_cast<quint8>((rxTimeout >> 24) & 0xFF);
    } else {
        qWarning() << "无效的RX打包超时，使用默认值";
        memset(m_deviceConfig.port1.rxTimeout, 0, sizeof(m_deviceConfig.port1.rxTimeout));
    }

    // 清空端口数据
    m_deviceConfig.port1.resetOperation = ui->ckbClearPortData->isChecked()? 1 : 0;

    QByteArray data = util::CH9120_CFG_FLAG.toUtf8();
    data.append(QByteArray::fromHex("0001")); // 添加0x00 0x01
    data.append(serializeConfigStruct(m_deviceConfig));
    // 发送组合后的数据包
    m_broadcaster->sendBroadcast(data, 50000);
    this->statusBar()->showMessage("Operation status: Start Set Device Configuration...");
}

void MainWindow::on_btnInitialization_clicked()
{
    QByteArray data = util::CH9120_CFG_FLAG.toUtf8();
    data.append(QByteArray::fromHex("0003")); // 添加0x00 0x03
    QByteArray macArray(reinterpret_cast<const char*>(m_deviceConfig.mac), sizeof(m_deviceConfig.mac));
    data.append(macArray);
    // 发送组合后的数据包
    m_broadcaster->sendBroadcast(data, 50000);
    this->statusBar()->showMessage("Operation status: Initialization Device...");
}

