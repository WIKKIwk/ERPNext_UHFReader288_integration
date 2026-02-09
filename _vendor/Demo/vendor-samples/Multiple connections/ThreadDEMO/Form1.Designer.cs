namespace ThreadDEMO
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox41 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.button23 = new System.Windows.Forms.Button();
            this.CloseNetPort = new System.Windows.Forms.Button();
            this.OpenNetPort = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.button24 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.button25 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listView4 = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.groupBox41.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox41
            // 
            this.groupBox41.Controls.Add(this.listView1);
            this.groupBox41.Controls.Add(this.button23);
            this.groupBox41.Controls.Add(this.CloseNetPort);
            this.groupBox41.Controls.Add(this.OpenNetPort);
            this.groupBox41.Controls.Add(this.textBox8);
            this.groupBox41.Controls.Add(this.label62);
            this.groupBox41.Controls.Add(this.textBox7);
            this.groupBox41.Controls.Add(this.label61);
            this.groupBox41.Location = new System.Drawing.Point(3, 3);
            this.groupBox41.Name = "groupBox41";
            this.groupBox41.Size = new System.Drawing.Size(562, 283);
            this.groupBox41.TabIndex = 51;
            this.groupBox41.TabStop = false;
            this.groupBox41.Text = "Device 1";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(128, 15);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(426, 253);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "UID";
            this.columnHeader2.Width = 280;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Times";
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(9, 134);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(113, 23);
            this.button23.TabIndex = 8;
            this.button23.Text = "Start";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.button23_Click);
            // 
            // CloseNetPort
            // 
            this.CloseNetPort.Location = new System.Drawing.Point(9, 105);
            this.CloseNetPort.Name = "CloseNetPort";
            this.CloseNetPort.Size = new System.Drawing.Size(113, 23);
            this.CloseNetPort.TabIndex = 7;
            this.CloseNetPort.Text = "Close";
            this.CloseNetPort.UseVisualStyleBackColor = true;
            this.CloseNetPort.Click += new System.EventHandler(this.CloseNetPort_Click);
            // 
            // OpenNetPort
            // 
            this.OpenNetPort.Location = new System.Drawing.Point(9, 74);
            this.OpenNetPort.Name = "OpenNetPort";
            this.OpenNetPort.Size = new System.Drawing.Size(113, 23);
            this.OpenNetPort.TabIndex = 6;
            this.OpenNetPort.Text = "Open";
            this.OpenNetPort.UseVisualStyleBackColor = true;
            this.OpenNetPort.Click += new System.EventHandler(this.OpenNetPort_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(33, 43);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(88, 21);
            this.textBox8.TabIndex = 3;
            this.textBox8.Text = "192.168.0.250";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(7, 52);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(29, 12);
            this.label62.TabIndex = 2;
            this.label62.Text = "IP：";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(40, 16);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(82, 21);
            this.textBox7.TabIndex = 1;
            this.textBox7.Text = "27011";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(6, 25);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(35, 12);
            this.label61.TabIndex = 0;
            this.label61.Text = "Port:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView2);
            this.groupBox1.Controls.Add(this.button24);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(571, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 283);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device 2";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(127, 15);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(426, 253);
            this.listView2.TabIndex = 10;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "No.";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "UID";
            this.columnHeader5.Width = 280;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Times";
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(9, 134);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(113, 23);
            this.button24.TabIndex = 9;
            this.button24.Text = "Start";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.button24_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(33, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 21);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "192.168.0.251";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(40, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(82, 21);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "27012";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView3);
            this.groupBox2.Controls.Add(this.button25);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(3, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(562, 282);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device 3";
            // 
            // listView3
            // 
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView3.GridLines = true;
            this.listView3.Location = new System.Drawing.Point(128, 16);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(426, 253);
            this.listView3.TabIndex = 10;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "No.";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "UID";
            this.columnHeader8.Width = 280;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Times";
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(9, 134);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(113, 23);
            this.button25.TabIndex = 9;
            this.button25.Text = "Start";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.button25_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 105);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.button3_ChangeUICues);
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 74);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Open";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(33, 43);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(88, 21);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "192.168.0.252";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "IP：";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(40, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(82, 21);
            this.textBox6.TabIndex = 1;
            this.textBox6.Text = "27013";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Port:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "Port:";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(40, 16);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(82, 21);
            this.textBox18.TabIndex = 1;
            this.textBox18.Text = "27014";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 2;
            this.label14.Text = "IP：";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(33, 43);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(88, 21);
            this.textBox17.TabIndex = 3;
            this.textBox17.Text = "192.168.0.253";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(8, 76);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(113, 23);
            this.button10.TabIndex = 6;
            this.button10.Text = "Open";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(8, 107);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(113, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "Close";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(9, 136);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(113, 23);
            this.button26.TabIndex = 9;
            this.button26.Text = "Start";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.button26_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listView4);
            this.groupBox5.Controls.Add(this.button26);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.textBox17);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.textBox18);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Location = new System.Drawing.Point(570, 291);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(562, 282);
            this.groupBox5.TabIndex = 54;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Device 4";
            // 
            // listView4
            // 
            this.listView4.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView4.GridLines = true;
            this.listView4.Location = new System.Drawing.Point(128, 16);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(426, 253);
            this.listView4.TabIndex = 10;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "No.";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "UID";
            this.columnHeader11.Width = 280;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Times";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 588);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox41);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "R2000 multithreading demo V1.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox41.ResumeLayout(false);
            this.groupBox41.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox41;
        private System.Windows.Forms.Button CloseNetPort;
        private System.Windows.Forms.Button OpenNetPort;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
    }
}

