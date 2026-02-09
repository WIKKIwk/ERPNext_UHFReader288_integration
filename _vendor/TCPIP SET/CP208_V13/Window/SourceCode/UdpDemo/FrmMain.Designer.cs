namespace UdpDemo
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lblAdapter = new System.Windows.Forms.Label();
            this.cmbAdapter = new System.Windows.Forms.ComboBox();
            this.btnRefreshAdapter = new System.Windows.Forms.Button();
            this.gbDevices = new System.Windows.Forms.GroupBox();
            this.lvDevices = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnLoading = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblDHCP = new System.Windows.Forms.Label();
            this.lblDeviceIP = new System.Windows.Forms.Label();
            this.lblNetMask = new System.Windows.Forms.Label();
            this.lblSerialConfig = new System.Windows.Forms.Label();
            this.lblGateway = new System.Windows.Forms.Label();
            this.ckbSerialConfig = new System.Windows.Forms.CheckBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.ckbDHCP = new System.Windows.Forms.CheckBox();
            this.txtDeviceIP = new IPAddressControlLib.IPAddressControl();
            this.txtNetMask = new IPAddressControlLib.IPAddressControl();
            this.txtGateway = new IPAddressControlLib.IPAddressControl();
            this.gbBasicSetting = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLog = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ckbClear2 = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRXTimeout2 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtRXLen2 = new System.Windows.Forms.TextBox();
            this.ckbNetworkDisconnect2 = new System.Windows.Forms.CheckBox();
            this.cmbCheckBits2 = new System.Windows.Forms.ComboBox();
            this.cmbStopBits2 = new System.Windows.Forms.ComboBox();
            this.cmbDataBits2 = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate2 = new System.Windows.Forms.ComboBox();
            this.txtDestinationPort2 = new System.Windows.Forms.TextBox();
            this.txtDestinationIP2 = new IPAddressControlLib.IPAddressControl();
            this.cmbDestinationIPDomainName2 = new System.Windows.Forms.ComboBox();
            this.txtLocalPort2 = new System.Windows.Forms.TextBox();
            this.ckbRandom2 = new System.Windows.Forms.CheckBox();
            this.cmbNetMode2 = new System.Windows.Forms.ComboBox();
            this.lblNetworkConneting2 = new System.Windows.Forms.Label();
            this.lblRXTimeout2 = new System.Windows.Forms.Label();
            this.lblRXLen2 = new System.Windows.Forms.Label();
            this.lblNetworkDisconnect2 = new System.Windows.Forms.Label();
            this.lblCheckBits2 = new System.Windows.Forms.Label();
            this.lblStopBits2 = new System.Windows.Forms.Label();
            this.lblDataBits2 = new System.Windows.Forms.Label();
            this.lblBaudRate2 = new System.Windows.Forms.Label();
            this.lblDestinationPort2 = new System.Windows.Forms.Label();
            this.lblDestinationIP2 = new System.Windows.Forms.Label();
            this.lblDestinationIPDomainName2 = new System.Windows.Forms.Label();
            this.lblLocalPort2 = new System.Windows.Forms.Label();
            this.lblNetMode2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ckbClear1 = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtRXTimeout1 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtRXLen1 = new System.Windows.Forms.TextBox();
            this.ckbNetworkDisconnect1 = new System.Windows.Forms.CheckBox();
            this.cmbCheckBits1 = new System.Windows.Forms.ComboBox();
            this.cmbStopBits1 = new System.Windows.Forms.ComboBox();
            this.cmbDataBits1 = new System.Windows.Forms.ComboBox();
            this.cmbBaudRate1 = new System.Windows.Forms.ComboBox();
            this.txtDestinationPort1 = new System.Windows.Forms.TextBox();
            this.txtDestinationIP1 = new IPAddressControlLib.IPAddressControl();
            this.cmbDestinationIPDomainName1 = new System.Windows.Forms.ComboBox();
            this.txtLocalPort1 = new System.Windows.Forms.TextBox();
            this.ckbRandom1 = new System.Windows.Forms.CheckBox();
            this.cmbNetMode1 = new System.Windows.Forms.ComboBox();
            this.lblNetworkConneting1 = new System.Windows.Forms.Label();
            this.lblRXTimeout1 = new System.Windows.Forms.Label();
            this.lblRXLen1 = new System.Windows.Forms.Label();
            this.lblNetworkDisconnect1 = new System.Windows.Forms.Label();
            this.lblCheckBits1 = new System.Windows.Forms.Label();
            this.lblStopBits1 = new System.Windows.Forms.Label();
            this.lblDataBits1 = new System.Windows.Forms.Label();
            this.lblBaudRate1 = new System.Windows.Forms.Label();
            this.lblDestinationPort1 = new System.Windows.Forms.Label();
            this.lblDestinationIP1 = new System.Windows.Forms.Label();
            this.lblDestinationIPDomainName1 = new System.Windows.Forms.Label();
            this.lblLocalPort1 = new System.Windows.Forms.Label();
            this.lblNetMode1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnConfig = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChineseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDevices.SuspendLayout();
            this.gbBasicSetting.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAdapter
            // 
            this.lblAdapter.AutoSize = true;
            this.lblAdapter.Location = new System.Drawing.Point(12, 10);
            this.lblAdapter.Name = "lblAdapter";
            this.lblAdapter.Size = new System.Drawing.Size(53, 12);
            this.lblAdapter.TabIndex = 0;
            this.lblAdapter.Text = "适配器：";
            // 
            // cmbAdapter
            // 
            this.cmbAdapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAdapter.FormattingEnabled = true;
            this.cmbAdapter.Location = new System.Drawing.Point(65, 6);
            this.cmbAdapter.Name = "cmbAdapter";
            this.cmbAdapter.Size = new System.Drawing.Size(754, 20);
            this.cmbAdapter.TabIndex = 1;
            this.cmbAdapter.SelectedIndexChanged += new System.EventHandler(this.cmbAdapter_SelectedIndexChanged);
            // 
            // btnRefreshAdapter
            // 
            this.btnRefreshAdapter.Location = new System.Drawing.Point(825, 5);
            this.btnRefreshAdapter.Name = "btnRefreshAdapter";
            this.btnRefreshAdapter.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshAdapter.TabIndex = 2;
            this.btnRefreshAdapter.Text = "刷新网卡";
            this.btnRefreshAdapter.UseVisualStyleBackColor = true;
            this.btnRefreshAdapter.Click += new System.EventHandler(this.btnRefreshAdapter_Click);
            // 
            // gbDevices
            // 
            this.gbDevices.Controls.Add(this.lvDevices);
            this.gbDevices.Location = new System.Drawing.Point(14, 32);
            this.gbDevices.Name = "gbDevices";
            this.gbDevices.Size = new System.Drawing.Size(459, 164);
            this.gbDevices.TabIndex = 3;
            this.gbDevices.TabStop = false;
            this.gbDevices.Text = "设备列表（双击设备列表中的设备，可以获取对应的配置）";
            // 
            // lvDevices
            // 
            this.lvDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colIP,
            this.colMAC,
            this.colVersion});
            this.lvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDevices.FullRowSelect = true;
            this.lvDevices.GridLines = true;
            this.lvDevices.HideSelection = false;
            this.lvDevices.Location = new System.Drawing.Point(3, 17);
            this.lvDevices.Name = "lvDevices";
            this.lvDevices.Size = new System.Drawing.Size(453, 144);
            this.lvDevices.TabIndex = 0;
            this.lvDevices.UseCompatibleStateImageBehavior = false;
            this.lvDevices.View = System.Windows.Forms.View.Details;
            this.lvDevices.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvDevices_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "设备名";
            this.colName.Width = 140;
            // 
            // colIP
            // 
            this.colIP.Text = "设备IP";
            this.colIP.Width = 110;
            // 
            // colMAC
            // 
            this.colMAC.Text = "设备MAC";
            this.colMAC.Width = 140;
            // 
            // colVersion
            // 
            this.colVersion.Text = "版本号";
            this.colVersion.Width = 50;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(17, 202);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(456, 40);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "搜索设备";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(17, 248);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(147, 23);
            this.btnInit.TabIndex = 5;
            this.btnInit.Text = "恢复出厂设置";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnLoading
            // 
            this.btnLoading.Location = new System.Drawing.Point(170, 248);
            this.btnLoading.Name = "btnLoading";
            this.btnLoading.Size = new System.Drawing.Size(147, 23);
            this.btnLoading.TabIndex = 6;
            this.btnLoading.Text = "加载配置文件";
            this.btnLoading.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(323, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(147, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "保存配置文件";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeviceName.Location = new System.Drawing.Point(13, 20);
            this.lblDeviceName.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(89, 25);
            this.lblDeviceName.TabIndex = 0;
            this.lblDeviceName.Text = "设备名：";
            this.lblDeviceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDHCP
            // 
            this.lblDHCP.AutoSize = true;
            this.lblDHCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDHCP.Location = new System.Drawing.Point(13, 45);
            this.lblDHCP.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDHCP.Name = "lblDHCP";
            this.lblDHCP.Size = new System.Drawing.Size(89, 25);
            this.lblDHCP.TabIndex = 1;
            this.lblDHCP.Text = "DHCP：";
            this.lblDHCP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDeviceIP
            // 
            this.lblDeviceIP.AutoSize = true;
            this.lblDeviceIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeviceIP.Location = new System.Drawing.Point(13, 70);
            this.lblDeviceIP.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDeviceIP.Name = "lblDeviceIP";
            this.lblDeviceIP.Size = new System.Drawing.Size(89, 25);
            this.lblDeviceIP.TabIndex = 2;
            this.lblDeviceIP.Text = "设备IP：";
            this.lblDeviceIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetMask
            // 
            this.lblNetMask.AutoSize = true;
            this.lblNetMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetMask.Location = new System.Drawing.Point(13, 95);
            this.lblNetMask.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblNetMask.Name = "lblNetMask";
            this.lblNetMask.Size = new System.Drawing.Size(89, 25);
            this.lblNetMask.TabIndex = 3;
            this.lblNetMask.Text = "子网掩码：";
            this.lblNetMask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSerialConfig
            // 
            this.lblSerialConfig.AutoSize = true;
            this.lblSerialConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSerialConfig.Location = new System.Drawing.Point(13, 145);
            this.lblSerialConfig.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblSerialConfig.Name = "lblSerialConfig";
            this.lblSerialConfig.Size = new System.Drawing.Size(89, 25);
            this.lblSerialConfig.TabIndex = 4;
            this.lblSerialConfig.Text = "串口协商配置：";
            this.lblSerialConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGateway
            // 
            this.lblGateway.AutoSize = true;
            this.lblGateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGateway.Location = new System.Drawing.Point(13, 120);
            this.lblGateway.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblGateway.Name = "lblGateway";
            this.lblGateway.Size = new System.Drawing.Size(89, 25);
            this.lblGateway.TabIndex = 5;
            this.lblGateway.Text = "网关：";
            this.lblGateway.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ckbSerialConfig
            // 
            this.ckbSerialConfig.AutoSize = true;
            this.ckbSerialConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbSerialConfig.Location = new System.Drawing.Point(110, 148);
            this.ckbSerialConfig.Name = "ckbSerialConfig";
            this.ckbSerialConfig.Size = new System.Drawing.Size(237, 19);
            this.ckbSerialConfig.TabIndex = 6;
            this.ckbSerialConfig.Text = "开启";
            this.ckbSerialConfig.UseVisualStyleBackColor = true;
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeviceName.Location = new System.Drawing.Point(110, 23);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.Size = new System.Drawing.Size(237, 21);
            this.txtDeviceName.TabIndex = 7;
            // 
            // ckbDHCP
            // 
            this.ckbDHCP.AutoSize = true;
            this.ckbDHCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbDHCP.Location = new System.Drawing.Point(110, 48);
            this.ckbDHCP.Name = "ckbDHCP";
            this.ckbDHCP.Size = new System.Drawing.Size(237, 19);
            this.ckbDHCP.TabIndex = 8;
            this.ckbDHCP.Text = "开启";
            this.ckbDHCP.UseVisualStyleBackColor = true;
            // 
            // txtDeviceIP
            // 
            this.txtDeviceIP.AllowInternalTab = false;
            this.txtDeviceIP.AutoHeight = true;
            this.txtDeviceIP.BackColor = System.Drawing.SystemColors.Window;
            this.txtDeviceIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDeviceIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDeviceIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDeviceIP.Location = new System.Drawing.Point(110, 73);
            this.txtDeviceIP.MinimumSize = new System.Drawing.Size(96, 21);
            this.txtDeviceIP.Name = "txtDeviceIP";
            this.txtDeviceIP.ReadOnly = false;
            this.txtDeviceIP.Size = new System.Drawing.Size(237, 21);
            this.txtDeviceIP.TabIndex = 9;
            this.txtDeviceIP.Text = "...";
            // 
            // txtNetMask
            // 
            this.txtNetMask.AllowInternalTab = false;
            this.txtNetMask.AutoHeight = true;
            this.txtNetMask.BackColor = System.Drawing.SystemColors.Window;
            this.txtNetMask.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtNetMask.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNetMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNetMask.Location = new System.Drawing.Point(110, 98);
            this.txtNetMask.MinimumSize = new System.Drawing.Size(96, 21);
            this.txtNetMask.Name = "txtNetMask";
            this.txtNetMask.ReadOnly = false;
            this.txtNetMask.Size = new System.Drawing.Size(237, 21);
            this.txtNetMask.TabIndex = 10;
            this.txtNetMask.Text = "...";
            // 
            // txtGateway
            // 
            this.txtGateway.AllowInternalTab = false;
            this.txtGateway.AutoHeight = true;
            this.txtGateway.BackColor = System.Drawing.SystemColors.Window;
            this.txtGateway.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtGateway.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGateway.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGateway.Location = new System.Drawing.Point(110, 123);
            this.txtGateway.MinimumSize = new System.Drawing.Size(96, 21);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.ReadOnly = false;
            this.txtGateway.Size = new System.Drawing.Size(237, 21);
            this.txtGateway.TabIndex = 11;
            this.txtGateway.Text = "...";
            // 
            // gbBasicSetting
            // 
            this.gbBasicSetting.Controls.Add(this.tableLayoutPanel3);
            this.gbBasicSetting.Location = new System.Drawing.Point(17, 277);
            this.gbBasicSetting.Name = "gbBasicSetting";
            this.gbBasicSetting.Size = new System.Drawing.Size(456, 215);
            this.gbBasicSetting.TabIndex = 8;
            this.gbBasicSetting.TabStop = false;
            this.gbBasicSetting.Text = "基础设置";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblDeviceName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblSerialConfig, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.lblGateway, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.ckbSerialConfig, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.txtGateway, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.lblNetMask, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtDeviceName, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblDeviceIP, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblDHCP, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.ckbDHCP, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtDeviceIP, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtNetMask, 1, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(450, 195);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // lblLog
            // 
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLog.Location = new System.Drawing.Point(0, 0);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(873, 42);
            this.lblLog.TabIndex = 0;
            this.lblLog.Text = "操作状态：";
            this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(413, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "端口1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ckbClear2, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.label22, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.txtRXTimeout2, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label21, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtRXLen2, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.ckbNetworkDisconnect2, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.cmbCheckBits2, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cmbStopBits2, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cmbDataBits2, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbBaudRate2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtDestinationPort2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDestinationIP2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbDestinationIPDomainName2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtLocalPort2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ckbRandom2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbNetMode2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNetworkConneting2, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.lblRXTimeout2, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.lblRXLen2, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblNetworkDisconnect2, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblCheckBits2, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblStopBits2, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblDataBits2, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblBaudRate2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDestinationPort2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblDestinationIP2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblDestinationIPDomainName2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblLocalPort2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblNetMode2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 382);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ckbClear2
            // 
            this.ckbClear2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ckbClear2, 3);
            this.ckbClear2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbClear2.Location = new System.Drawing.Point(104, 344);
            this.ckbClear2.Name = "ckbClear2";
            this.ckbClear2.Size = new System.Drawing.Size(250, 22);
            this.ckbClear2.TabIndex = 15;
            this.ckbClear2.Text = "清空串口数据";
            this.ckbClear2.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Location = new System.Drawing.Point(307, 313);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 28);
            this.label22.TabIndex = 30;
            this.label22.Text = "(10ms)";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRXTimeout2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtRXTimeout2, 2);
            this.txtRXTimeout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRXTimeout2.Location = new System.Drawing.Point(104, 316);
            this.txtRXTimeout2.Name = "txtRXTimeout2";
            this.txtRXTimeout2.Size = new System.Drawing.Size(197, 21);
            this.txtRXTimeout2.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(307, 285);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 28);
            this.label21.TabIndex = 29;
            this.label21.Text = "(<=512)";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRXLen2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtRXLen2, 2);
            this.txtRXLen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRXLen2.Location = new System.Drawing.Point(104, 288);
            this.txtRXLen2.Name = "txtRXLen2";
            this.txtRXLen2.Size = new System.Drawing.Size(197, 21);
            this.txtRXLen2.TabIndex = 17;
            // 
            // ckbNetworkDisconnect2
            // 
            this.ckbNetworkDisconnect2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.ckbNetworkDisconnect2, 3);
            this.ckbNetworkDisconnect2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbNetworkDisconnect2.Location = new System.Drawing.Point(104, 260);
            this.ckbNetworkDisconnect2.Name = "ckbNetworkDisconnect2";
            this.ckbNetworkDisconnect2.Size = new System.Drawing.Size(250, 22);
            this.ckbNetworkDisconnect2.TabIndex = 18;
            this.ckbNetworkDisconnect2.Text = "关闭网络连接";
            this.ckbNetworkDisconnect2.UseVisualStyleBackColor = true;
            // 
            // cmbCheckBits2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbCheckBits2, 3);
            this.cmbCheckBits2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCheckBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckBits2.FormattingEnabled = true;
            this.cmbCheckBits2.Items.AddRange(new object[] {
            "偶校验",
            "Mark 校验",
            "Space 校验",
            "无校验"});
            this.cmbCheckBits2.Location = new System.Drawing.Point(104, 232);
            this.cmbCheckBits2.Name = "cmbCheckBits2";
            this.cmbCheckBits2.Size = new System.Drawing.Size(250, 20);
            this.cmbCheckBits2.TabIndex = 19;
            // 
            // cmbStopBits2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbStopBits2, 3);
            this.cmbStopBits2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStopBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits2.FormattingEnabled = true;
            this.cmbStopBits2.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbStopBits2.Location = new System.Drawing.Point(104, 204);
            this.cmbStopBits2.Name = "cmbStopBits2";
            this.cmbStopBits2.Size = new System.Drawing.Size(250, 20);
            this.cmbStopBits2.TabIndex = 20;
            // 
            // cmbDataBits2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbDataBits2, 3);
            this.cmbDataBits2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDataBits2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits2.FormattingEnabled = true;
            this.cmbDataBits2.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits2.Location = new System.Drawing.Point(104, 176);
            this.cmbDataBits2.Name = "cmbDataBits2";
            this.cmbDataBits2.Size = new System.Drawing.Size(250, 20);
            this.cmbDataBits2.TabIndex = 21;
            // 
            // cmbBaudRate2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbBaudRate2, 3);
            this.cmbBaudRate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBaudRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate2.FormattingEnabled = true;
            this.cmbBaudRate2.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19600",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cmbBaudRate2.Location = new System.Drawing.Point(104, 148);
            this.cmbBaudRate2.Name = "cmbBaudRate2";
            this.cmbBaudRate2.Size = new System.Drawing.Size(250, 20);
            this.cmbBaudRate2.TabIndex = 22;
            // 
            // txtDestinationPort2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDestinationPort2, 3);
            this.txtDestinationPort2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestinationPort2.Location = new System.Drawing.Point(104, 120);
            this.txtDestinationPort2.Name = "txtDestinationPort2";
            this.txtDestinationPort2.Size = new System.Drawing.Size(250, 21);
            this.txtDestinationPort2.TabIndex = 23;
            // 
            // txtDestinationIP2
            // 
            this.txtDestinationIP2.AllowInternalTab = false;
            this.txtDestinationIP2.AutoHeight = true;
            this.txtDestinationIP2.BackColor = System.Drawing.SystemColors.Window;
            this.txtDestinationIP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDestinationIP2, 3);
            this.txtDestinationIP2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDestinationIP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestinationIP2.Location = new System.Drawing.Point(104, 92);
            this.txtDestinationIP2.MinimumSize = new System.Drawing.Size(96, 21);
            this.txtDestinationIP2.Name = "txtDestinationIP2";
            this.txtDestinationIP2.ReadOnly = false;
            this.txtDestinationIP2.Size = new System.Drawing.Size(250, 21);
            this.txtDestinationIP2.TabIndex = 24;
            this.txtDestinationIP2.Text = "...";
            // 
            // cmbDestinationIPDomainName2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbDestinationIPDomainName2, 3);
            this.cmbDestinationIPDomainName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDestinationIPDomainName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationIPDomainName2.FormattingEnabled = true;
            this.cmbDestinationIPDomainName2.Items.AddRange(new object[] {
            "IP",
            "域名"});
            this.cmbDestinationIPDomainName2.Location = new System.Drawing.Point(104, 64);
            this.cmbDestinationIPDomainName2.Name = "cmbDestinationIPDomainName2";
            this.cmbDestinationIPDomainName2.Size = new System.Drawing.Size(250, 20);
            this.cmbDestinationIPDomainName2.TabIndex = 25;
            // 
            // txtLocalPort2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtLocalPort2, 2);
            this.txtLocalPort2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocalPort2.Location = new System.Drawing.Point(158, 36);
            this.txtLocalPort2.Name = "txtLocalPort2";
            this.txtLocalPort2.Size = new System.Drawing.Size(196, 21);
            this.txtLocalPort2.TabIndex = 27;
            // 
            // ckbRandom2
            // 
            this.ckbRandom2.AutoSize = true;
            this.ckbRandom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbRandom2.Location = new System.Drawing.Point(104, 36);
            this.ckbRandom2.Name = "ckbRandom2";
            this.ckbRandom2.Size = new System.Drawing.Size(48, 22);
            this.ckbRandom2.TabIndex = 26;
            this.ckbRandom2.Text = "随机";
            this.ckbRandom2.UseVisualStyleBackColor = true;
            // 
            // cmbNetMode2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbNetMode2, 3);
            this.cmbNetMode2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNetMode2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetMode2.FormattingEnabled = true;
            this.cmbNetMode2.Items.AddRange(new object[] {
            "TCP SERVER",
            "TCP CLIENT",
            "UDP SERVER",
            "UDP CLIENT"});
            this.cmbNetMode2.Location = new System.Drawing.Point(104, 8);
            this.cmbNetMode2.Name = "cmbNetMode2";
            this.cmbNetMode2.Size = new System.Drawing.Size(250, 20);
            this.cmbNetMode2.TabIndex = 28;
            // 
            // lblNetworkConneting2
            // 
            this.lblNetworkConneting2.AutoSize = true;
            this.lblNetworkConneting2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetworkConneting2.Location = new System.Drawing.Point(13, 341);
            this.lblNetworkConneting2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblNetworkConneting2.Name = "lblNetworkConneting2";
            this.lblNetworkConneting2.Size = new System.Drawing.Size(83, 28);
            this.lblNetworkConneting2.TabIndex = 14;
            this.lblNetworkConneting2.Text = "网络连接时：";
            this.lblNetworkConneting2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRXTimeout2
            // 
            this.lblRXTimeout2.AutoSize = true;
            this.lblRXTimeout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRXTimeout2.Location = new System.Drawing.Point(13, 313);
            this.lblRXTimeout2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblRXTimeout2.Name = "lblRXTimeout2";
            this.lblRXTimeout2.Size = new System.Drawing.Size(83, 28);
            this.lblRXTimeout2.TabIndex = 13;
            this.lblRXTimeout2.Text = "RX打包超时：";
            this.lblRXTimeout2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRXLen2
            // 
            this.lblRXLen2.AutoSize = true;
            this.lblRXLen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRXLen2.Location = new System.Drawing.Point(13, 285);
            this.lblRXLen2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblRXLen2.Name = "lblRXLen2";
            this.lblRXLen2.Size = new System.Drawing.Size(83, 28);
            this.lblRXLen2.TabIndex = 12;
            this.lblRXLen2.Text = "RX打包长度：";
            this.lblRXLen2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetworkDisconnect2
            // 
            this.lblNetworkDisconnect2.AutoSize = true;
            this.lblNetworkDisconnect2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetworkDisconnect2.Location = new System.Drawing.Point(13, 257);
            this.lblNetworkDisconnect2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblNetworkDisconnect2.Name = "lblNetworkDisconnect2";
            this.lblNetworkDisconnect2.Size = new System.Drawing.Size(83, 28);
            this.lblNetworkDisconnect2.TabIndex = 12;
            this.lblNetworkDisconnect2.Text = "网线断开：";
            this.lblNetworkDisconnect2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCheckBits2
            // 
            this.lblCheckBits2.AutoSize = true;
            this.lblCheckBits2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckBits2.Location = new System.Drawing.Point(13, 229);
            this.lblCheckBits2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblCheckBits2.Name = "lblCheckBits2";
            this.lblCheckBits2.Size = new System.Drawing.Size(83, 28);
            this.lblCheckBits2.TabIndex = 12;
            this.lblCheckBits2.Text = "串口校验位：";
            this.lblCheckBits2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStopBits2
            // 
            this.lblStopBits2.AutoSize = true;
            this.lblStopBits2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStopBits2.Location = new System.Drawing.Point(13, 201);
            this.lblStopBits2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblStopBits2.Name = "lblStopBits2";
            this.lblStopBits2.Size = new System.Drawing.Size(83, 28);
            this.lblStopBits2.TabIndex = 12;
            this.lblStopBits2.Text = "串口停止位：";
            this.lblStopBits2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataBits2
            // 
            this.lblDataBits2.AutoSize = true;
            this.lblDataBits2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataBits2.Location = new System.Drawing.Point(13, 173);
            this.lblDataBits2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDataBits2.Name = "lblDataBits2";
            this.lblDataBits2.Size = new System.Drawing.Size(83, 28);
            this.lblDataBits2.TabIndex = 12;
            this.lblDataBits2.Text = "串口数据位：";
            this.lblDataBits2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaudRate2
            // 
            this.lblBaudRate2.AutoSize = true;
            this.lblBaudRate2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaudRate2.Location = new System.Drawing.Point(13, 145);
            this.lblBaudRate2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblBaudRate2.Name = "lblBaudRate2";
            this.lblBaudRate2.Size = new System.Drawing.Size(83, 28);
            this.lblBaudRate2.TabIndex = 12;
            this.lblBaudRate2.Text = "串口波特率：";
            this.lblBaudRate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestinationPort2
            // 
            this.lblDestinationPort2.AutoSize = true;
            this.lblDestinationPort2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationPort2.Location = new System.Drawing.Point(13, 117);
            this.lblDestinationPort2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDestinationPort2.Name = "lblDestinationPort2";
            this.lblDestinationPort2.Size = new System.Drawing.Size(83, 28);
            this.lblDestinationPort2.TabIndex = 12;
            this.lblDestinationPort2.Text = "目的端口号：";
            this.lblDestinationPort2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestinationIP2
            // 
            this.lblDestinationIP2.AutoSize = true;
            this.lblDestinationIP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationIP2.Location = new System.Drawing.Point(13, 89);
            this.lblDestinationIP2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDestinationIP2.Name = "lblDestinationIP2";
            this.lblDestinationIP2.Size = new System.Drawing.Size(83, 28);
            this.lblDestinationIP2.TabIndex = 12;
            this.lblDestinationIP2.Text = "目的IP：";
            this.lblDestinationIP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestinationIPDomainName2
            // 
            this.lblDestinationIPDomainName2.AutoSize = true;
            this.lblDestinationIPDomainName2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationIPDomainName2.Location = new System.Drawing.Point(13, 61);
            this.lblDestinationIPDomainName2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDestinationIPDomainName2.Name = "lblDestinationIPDomainName2";
            this.lblDestinationIPDomainName2.Size = new System.Drawing.Size(83, 28);
            this.lblDestinationIPDomainName2.TabIndex = 12;
            this.lblDestinationIPDomainName2.Text = "目的IP/域名：";
            this.lblDestinationIPDomainName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocalPort2
            // 
            this.lblLocalPort2.AutoSize = true;
            this.lblLocalPort2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocalPort2.Location = new System.Drawing.Point(13, 33);
            this.lblLocalPort2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblLocalPort2.Name = "lblLocalPort2";
            this.lblLocalPort2.Size = new System.Drawing.Size(83, 28);
            this.lblLocalPort2.TabIndex = 12;
            this.lblLocalPort2.Text = "本地端口：";
            this.lblLocalPort2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetMode2
            // 
            this.lblNetMode2.AutoSize = true;
            this.lblNetMode2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetMode2.Location = new System.Drawing.Point(13, 5);
            this.lblNetMode2.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblNetMode2.Name = "lblNetMode2";
            this.lblNetMode2.Size = new System.Drawing.Size(83, 28);
            this.lblNetMode2.TabIndex = 12;
            this.lblNetMode2.Text = "网络模式：";
            this.lblNetMode2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(413, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "端口0";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ckbClear1, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.label23, 3, 12);
            this.tableLayoutPanel2.Controls.Add(this.txtRXTimeout1, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.label24, 3, 11);
            this.tableLayoutPanel2.Controls.Add(this.txtRXLen1, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.ckbNetworkDisconnect1, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.cmbCheckBits1, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.cmbStopBits1, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.cmbDataBits1, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.cmbBaudRate1, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtDestinationPort1, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtDestinationIP1, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.cmbDestinationIPDomainName1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtLocalPort1, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.ckbRandom1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cmbNetMode1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblNetworkConneting1, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.lblRXTimeout1, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.lblRXLen1, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.lblNetworkDisconnect1, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.lblCheckBits1, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.lblStopBits1, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.lblDataBits1, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.lblBaudRate1, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblDestinationPort1, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblDestinationIP1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblDestinationIPDomainName1, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblLocalPort1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNetMode1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 15;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692308F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(407, 382);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // ckbClear1
            // 
            this.ckbClear1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.ckbClear1, 3);
            this.ckbClear1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbClear1.Location = new System.Drawing.Point(104, 344);
            this.ckbClear1.Name = "ckbClear1";
            this.ckbClear1.Size = new System.Drawing.Size(250, 22);
            this.ckbClear1.TabIndex = 15;
            this.ckbClear1.Text = "清空串口数据";
            this.ckbClear1.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.Location = new System.Drawing.Point(307, 313);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 28);
            this.label23.TabIndex = 30;
            this.label23.Text = "(10ms)";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRXTimeout1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRXTimeout1, 2);
            this.txtRXTimeout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRXTimeout1.Location = new System.Drawing.Point(104, 316);
            this.txtRXTimeout1.Name = "txtRXTimeout1";
            this.txtRXTimeout1.Size = new System.Drawing.Size(197, 21);
            this.txtRXTimeout1.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.Location = new System.Drawing.Point(307, 285);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 28);
            this.label24.TabIndex = 29;
            this.label24.Text = "(<=512)";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRXLen1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRXLen1, 2);
            this.txtRXLen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRXLen1.Location = new System.Drawing.Point(104, 288);
            this.txtRXLen1.Name = "txtRXLen1";
            this.txtRXLen1.Size = new System.Drawing.Size(197, 21);
            this.txtRXLen1.TabIndex = 17;
            // 
            // ckbNetworkDisconnect1
            // 
            this.ckbNetworkDisconnect1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.ckbNetworkDisconnect1, 3);
            this.ckbNetworkDisconnect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbNetworkDisconnect1.Location = new System.Drawing.Point(104, 260);
            this.ckbNetworkDisconnect1.Name = "ckbNetworkDisconnect1";
            this.ckbNetworkDisconnect1.Size = new System.Drawing.Size(250, 22);
            this.ckbNetworkDisconnect1.TabIndex = 18;
            this.ckbNetworkDisconnect1.Text = "关闭网络连接";
            this.ckbNetworkDisconnect1.UseVisualStyleBackColor = true;
            // 
            // cmbCheckBits1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbCheckBits1, 3);
            this.cmbCheckBits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCheckBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCheckBits1.FormattingEnabled = true;
            this.cmbCheckBits1.Items.AddRange(new object[] {
            "偶校验",
            "Mark 校验",
            "Space 校验",
            "无校验"});
            this.cmbCheckBits1.Location = new System.Drawing.Point(104, 232);
            this.cmbCheckBits1.Name = "cmbCheckBits1";
            this.cmbCheckBits1.Size = new System.Drawing.Size(250, 20);
            this.cmbCheckBits1.TabIndex = 19;
            // 
            // cmbStopBits1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbStopBits1, 3);
            this.cmbStopBits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStopBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits1.FormattingEnabled = true;
            this.cmbStopBits1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbStopBits1.Location = new System.Drawing.Point(104, 204);
            this.cmbStopBits1.Name = "cmbStopBits1";
            this.cmbStopBits1.Size = new System.Drawing.Size(250, 20);
            this.cmbStopBits1.TabIndex = 20;
            // 
            // cmbDataBits1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbDataBits1, 3);
            this.cmbDataBits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDataBits1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits1.FormattingEnabled = true;
            this.cmbDataBits1.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits1.Location = new System.Drawing.Point(104, 176);
            this.cmbDataBits1.Name = "cmbDataBits1";
            this.cmbDataBits1.Size = new System.Drawing.Size(250, 20);
            this.cmbDataBits1.TabIndex = 21;
            // 
            // cmbBaudRate1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbBaudRate1, 3);
            this.cmbBaudRate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBaudRate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate1.FormattingEnabled = true;
            this.cmbBaudRate1.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cmbBaudRate1.Location = new System.Drawing.Point(104, 148);
            this.cmbBaudRate1.Name = "cmbBaudRate1";
            this.cmbBaudRate1.Size = new System.Drawing.Size(250, 20);
            this.cmbBaudRate1.TabIndex = 22;
            // 
            // txtDestinationPort1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtDestinationPort1, 3);
            this.txtDestinationPort1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestinationPort1.Location = new System.Drawing.Point(104, 120);
            this.txtDestinationPort1.Name = "txtDestinationPort1";
            this.txtDestinationPort1.Size = new System.Drawing.Size(250, 21);
            this.txtDestinationPort1.TabIndex = 23;
            // 
            // txtDestinationIP1
            // 
            this.txtDestinationIP1.AllowInternalTab = false;
            this.txtDestinationIP1.AutoHeight = true;
            this.txtDestinationIP1.BackColor = System.Drawing.SystemColors.Window;
            this.txtDestinationIP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel2.SetColumnSpan(this.txtDestinationIP1, 3);
            this.txtDestinationIP1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDestinationIP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestinationIP1.Location = new System.Drawing.Point(104, 92);
            this.txtDestinationIP1.MinimumSize = new System.Drawing.Size(96, 21);
            this.txtDestinationIP1.Name = "txtDestinationIP1";
            this.txtDestinationIP1.ReadOnly = false;
            this.txtDestinationIP1.Size = new System.Drawing.Size(250, 21);
            this.txtDestinationIP1.TabIndex = 24;
            this.txtDestinationIP1.Text = "...";
            // 
            // cmbDestinationIPDomainName1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbDestinationIPDomainName1, 3);
            this.cmbDestinationIPDomainName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDestinationIPDomainName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestinationIPDomainName1.FormattingEnabled = true;
            this.cmbDestinationIPDomainName1.Items.AddRange(new object[] {
            "IP",
            "域名"});
            this.cmbDestinationIPDomainName1.Location = new System.Drawing.Point(104, 64);
            this.cmbDestinationIPDomainName1.Name = "cmbDestinationIPDomainName1";
            this.cmbDestinationIPDomainName1.Size = new System.Drawing.Size(250, 20);
            this.cmbDestinationIPDomainName1.TabIndex = 25;
            // 
            // txtLocalPort1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtLocalPort1, 2);
            this.txtLocalPort1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLocalPort1.Location = new System.Drawing.Point(158, 36);
            this.txtLocalPort1.Name = "txtLocalPort1";
            this.txtLocalPort1.Size = new System.Drawing.Size(196, 21);
            this.txtLocalPort1.TabIndex = 27;
            // 
            // ckbRandom1
            // 
            this.ckbRandom1.AutoSize = true;
            this.ckbRandom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckbRandom1.Location = new System.Drawing.Point(104, 36);
            this.ckbRandom1.Name = "ckbRandom1";
            this.ckbRandom1.Size = new System.Drawing.Size(48, 22);
            this.ckbRandom1.TabIndex = 26;
            this.ckbRandom1.Text = "随机";
            this.ckbRandom1.UseVisualStyleBackColor = true;
            // 
            // cmbNetMode1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.cmbNetMode1, 3);
            this.cmbNetMode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbNetMode1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNetMode1.FormattingEnabled = true;
            this.cmbNetMode1.Items.AddRange(new object[] {
            "TCP SERVER",
            "TCP CLIENT",
            "UDP SERVER",
            "UDP CLIENT"});
            this.cmbNetMode1.Location = new System.Drawing.Point(104, 8);
            this.cmbNetMode1.Name = "cmbNetMode1";
            this.cmbNetMode1.Size = new System.Drawing.Size(250, 20);
            this.cmbNetMode1.TabIndex = 28;
            // 
            // lblNetworkConneting1
            // 
            this.lblNetworkConneting1.AutoSize = true;
            this.lblNetworkConneting1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetworkConneting1.Location = new System.Drawing.Point(13, 341);
            this.lblNetworkConneting1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblNetworkConneting1.Name = "lblNetworkConneting1";
            this.lblNetworkConneting1.Size = new System.Drawing.Size(83, 28);
            this.lblNetworkConneting1.TabIndex = 14;
            this.lblNetworkConneting1.Text = "网络连接时：";
            this.lblNetworkConneting1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRXTimeout1
            // 
            this.lblRXTimeout1.AutoSize = true;
            this.lblRXTimeout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRXTimeout1.Location = new System.Drawing.Point(13, 313);
            this.lblRXTimeout1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblRXTimeout1.Name = "lblRXTimeout1";
            this.lblRXTimeout1.Size = new System.Drawing.Size(83, 28);
            this.lblRXTimeout1.TabIndex = 13;
            this.lblRXTimeout1.Text = "RX打包超时：";
            this.lblRXTimeout1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRXLen1
            // 
            this.lblRXLen1.AutoSize = true;
            this.lblRXLen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRXLen1.Location = new System.Drawing.Point(13, 285);
            this.lblRXLen1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblRXLen1.Name = "lblRXLen1";
            this.lblRXLen1.Size = new System.Drawing.Size(83, 28);
            this.lblRXLen1.TabIndex = 12;
            this.lblRXLen1.Text = "RX打包长度：";
            this.lblRXLen1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetworkDisconnect1
            // 
            this.lblNetworkDisconnect1.AutoSize = true;
            this.lblNetworkDisconnect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetworkDisconnect1.Location = new System.Drawing.Point(13, 257);
            this.lblNetworkDisconnect1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblNetworkDisconnect1.Name = "lblNetworkDisconnect1";
            this.lblNetworkDisconnect1.Size = new System.Drawing.Size(83, 28);
            this.lblNetworkDisconnect1.TabIndex = 12;
            this.lblNetworkDisconnect1.Text = "网线断开：";
            this.lblNetworkDisconnect1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCheckBits1
            // 
            this.lblCheckBits1.AutoSize = true;
            this.lblCheckBits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCheckBits1.Location = new System.Drawing.Point(13, 229);
            this.lblCheckBits1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblCheckBits1.Name = "lblCheckBits1";
            this.lblCheckBits1.Size = new System.Drawing.Size(83, 28);
            this.lblCheckBits1.TabIndex = 12;
            this.lblCheckBits1.Text = "串口校验位：";
            this.lblCheckBits1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStopBits1
            // 
            this.lblStopBits1.AutoSize = true;
            this.lblStopBits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStopBits1.Location = new System.Drawing.Point(13, 201);
            this.lblStopBits1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblStopBits1.Name = "lblStopBits1";
            this.lblStopBits1.Size = new System.Drawing.Size(83, 28);
            this.lblStopBits1.TabIndex = 12;
            this.lblStopBits1.Text = "串口停止位：";
            this.lblStopBits1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDataBits1
            // 
            this.lblDataBits1.AutoSize = true;
            this.lblDataBits1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataBits1.Location = new System.Drawing.Point(13, 173);
            this.lblDataBits1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDataBits1.Name = "lblDataBits1";
            this.lblDataBits1.Size = new System.Drawing.Size(83, 28);
            this.lblDataBits1.TabIndex = 12;
            this.lblDataBits1.Text = "串口数据位：";
            this.lblDataBits1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBaudRate1
            // 
            this.lblBaudRate1.AutoSize = true;
            this.lblBaudRate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaudRate1.Location = new System.Drawing.Point(13, 145);
            this.lblBaudRate1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblBaudRate1.Name = "lblBaudRate1";
            this.lblBaudRate1.Size = new System.Drawing.Size(83, 28);
            this.lblBaudRate1.TabIndex = 12;
            this.lblBaudRate1.Text = "串口波特率：";
            this.lblBaudRate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestinationPort1
            // 
            this.lblDestinationPort1.AutoSize = true;
            this.lblDestinationPort1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationPort1.Location = new System.Drawing.Point(13, 117);
            this.lblDestinationPort1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDestinationPort1.Name = "lblDestinationPort1";
            this.lblDestinationPort1.Size = new System.Drawing.Size(83, 28);
            this.lblDestinationPort1.TabIndex = 12;
            this.lblDestinationPort1.Text = "目的端口号：";
            this.lblDestinationPort1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestinationIP1
            // 
            this.lblDestinationIP1.AutoSize = true;
            this.lblDestinationIP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationIP1.Location = new System.Drawing.Point(13, 89);
            this.lblDestinationIP1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDestinationIP1.Name = "lblDestinationIP1";
            this.lblDestinationIP1.Size = new System.Drawing.Size(83, 28);
            this.lblDestinationIP1.TabIndex = 12;
            this.lblDestinationIP1.Text = "目的IP：";
            this.lblDestinationIP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDestinationIPDomainName1
            // 
            this.lblDestinationIPDomainName1.AutoSize = true;
            this.lblDestinationIPDomainName1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDestinationIPDomainName1.Location = new System.Drawing.Point(13, 61);
            this.lblDestinationIPDomainName1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblDestinationIPDomainName1.Name = "lblDestinationIPDomainName1";
            this.lblDestinationIPDomainName1.Size = new System.Drawing.Size(83, 28);
            this.lblDestinationIPDomainName1.TabIndex = 12;
            this.lblDestinationIPDomainName1.Text = "目的IP/域名：";
            this.lblDestinationIPDomainName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLocalPort1
            // 
            this.lblLocalPort1.AutoSize = true;
            this.lblLocalPort1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLocalPort1.Location = new System.Drawing.Point(13, 33);
            this.lblLocalPort1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblLocalPort1.Name = "lblLocalPort1";
            this.lblLocalPort1.Size = new System.Drawing.Size(83, 28);
            this.lblLocalPort1.TabIndex = 12;
            this.lblLocalPort1.Text = "本地端口：";
            this.lblLocalPort1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNetMode1
            // 
            this.lblNetMode1.AutoSize = true;
            this.lblNetMode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNetMode1.Location = new System.Drawing.Point(13, 5);
            this.lblNetMode1.Margin = new System.Windows.Forms.Padding(13, 0, 5, 0);
            this.lblNetMode1.Name = "lblNetMode1";
            this.lblNetMode1.Size = new System.Drawing.Size(83, 28);
            this.lblNetMode1.TabIndex = 12;
            this.lblNetMode1.Text = "网络模式：";
            this.lblNetMode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(479, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(421, 414);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(479, 452);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(421, 40);
            this.btnConfig.TabIndex = 11;
            this.btnConfig.Text = "配置设备参数";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblAdapter);
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.cmbAdapter);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.btnRefreshAdapter);
            this.panel1.Controls.Add(this.gbDevices);
            this.panel1.Controls.Add(this.gbBasicSetting);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnInit);
            this.panel1.Controls.Add(this.btnLoading);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(912, 552);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLog);
            this.panel2.Location = new System.Drawing.Point(20, 498);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(873, 42);
            this.panel2.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(912, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool1
            // 
            this.tool1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tool1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.ChineseToolStripMenuItem});
            this.tool1.Image = ((System.Drawing.Image)(resources.GetObject("tool1.Image")));
            this.tool1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.tool1.Name = "tool1";
            this.tool1.Size = new System.Drawing.Size(84, 22);
            this.tool1.Text = "Languages";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.englishToolStripMenuItem.Text = "English";
            // 
            // ChineseToolStripMenuItem
            // 
            this.ChineseToolStripMenuItem.Name = "ChineseToolStripMenuItem";
            this.ChineseToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.ChineseToolStripMenuItem.Text = "中文";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 577);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(928, 616);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(928, 616);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDP Demo";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gbDevices.ResumeLayout(false);
            this.gbBasicSetting.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdapter;
        private System.Windows.Forms.ComboBox cmbAdapter;
        private System.Windows.Forms.Button btnRefreshAdapter;
        private System.Windows.Forms.GroupBox gbDevices;
        private System.Windows.Forms.ListView lvDevices;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colIP;
        private System.Windows.Forms.ColumnHeader colMAC;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnLoading;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblDHCP;
        private System.Windows.Forms.Label lblDeviceIP;
        private System.Windows.Forms.Label lblNetMask;
        private System.Windows.Forms.Label lblSerialConfig;
        private System.Windows.Forms.Label lblGateway;
        private System.Windows.Forms.CheckBox ckbSerialConfig;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.CheckBox ckbDHCP;
        private IPAddressControlLib.IPAddressControl txtDeviceIP;
        private IPAddressControlLib.IPAddressControl txtNetMask;
        private IPAddressControlLib.IPAddressControl txtGateway;
        private System.Windows.Forms.GroupBox gbBasicSetting;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton tool1;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChineseToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNetMode2;
        private System.Windows.Forms.CheckBox ckbRandom2;
        private System.Windows.Forms.ComboBox cmbNetMode2;
        private System.Windows.Forms.Label lblNetworkConneting2;
        private System.Windows.Forms.Label lblRXTimeout2;
        private System.Windows.Forms.Label lblRXLen2;
        private System.Windows.Forms.Label lblNetworkDisconnect2;
        private System.Windows.Forms.Label lblCheckBits2;
        private System.Windows.Forms.Label lblStopBits2;
        private System.Windows.Forms.Label lblDataBits2;
        private System.Windows.Forms.Label lblBaudRate2;
        private System.Windows.Forms.Label lblDestinationPort2;
        private System.Windows.Forms.Label lblDestinationIP2;
        private System.Windows.Forms.Label lblDestinationIPDomainName2;
        private System.Windows.Forms.Label lblLocalPort2;
        private System.Windows.Forms.CheckBox ckbClear2;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtRXTimeout2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtRXLen2;
        private System.Windows.Forms.CheckBox ckbNetworkDisconnect2;
        private System.Windows.Forms.ComboBox cmbCheckBits2;
        private System.Windows.Forms.ComboBox cmbStopBits2;
        private System.Windows.Forms.ComboBox cmbDataBits2;
        private System.Windows.Forms.ComboBox cmbBaudRate2;
        private System.Windows.Forms.TextBox txtDestinationPort2;
        private IPAddressControlLib.IPAddressControl txtDestinationIP2;
        private System.Windows.Forms.ComboBox cmbDestinationIPDomainName2;
        private System.Windows.Forms.TextBox txtLocalPort2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox ckbClear1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtRXTimeout1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtRXLen1;
        private System.Windows.Forms.CheckBox ckbNetworkDisconnect1;
        private System.Windows.Forms.ComboBox cmbCheckBits1;
        private System.Windows.Forms.ComboBox cmbStopBits1;
        private System.Windows.Forms.ComboBox cmbDataBits1;
        private System.Windows.Forms.ComboBox cmbBaudRate1;
        private System.Windows.Forms.TextBox txtDestinationPort1;
        private IPAddressControlLib.IPAddressControl txtDestinationIP1;
        private System.Windows.Forms.ComboBox cmbDestinationIPDomainName1;
        private System.Windows.Forms.TextBox txtLocalPort1;
        private System.Windows.Forms.CheckBox ckbRandom1;
        private System.Windows.Forms.ComboBox cmbNetMode1;
        private System.Windows.Forms.Label lblNetworkConneting1;
        private System.Windows.Forms.Label lblRXTimeout1;
        private System.Windows.Forms.Label lblRXLen1;
        private System.Windows.Forms.Label lblNetworkDisconnect1;
        private System.Windows.Forms.Label lblCheckBits1;
        private System.Windows.Forms.Label lblStopBits1;
        private System.Windows.Forms.Label lblDataBits1;
        private System.Windows.Forms.Label lblBaudRate1;
        private System.Windows.Forms.Label lblDestinationPort1;
        private System.Windows.Forms.Label lblDestinationIP1;
        private System.Windows.Forms.Label lblDestinationIPDomainName1;
        private System.Windows.Forms.Label lblLocalPort1;
        private System.Windows.Forms.Label lblNetMode1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.Panel panel2;
    }
}

