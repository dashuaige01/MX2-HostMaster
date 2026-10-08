namespace 多设备管理系统
{
    partial class main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.pnlDeviceControl = new System.Windows.Forms.Panel();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.nUDAddDevice = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.lblReadInterval = new System.Windows.Forms.Label();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.nUDReadInterval = new System.Windows.Forms.NumericUpDown();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.lblBaud = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblSerialPort = new System.Windows.Forms.Label();
            this.flpDevice = new System.Windows.Forms.FlowLayoutPanel();
            this.timSerialPort = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timAutoSend = new System.Windows.Forms.Timer(this.components);
            this.timScan = new System.Windows.Forms.Timer(this.components);
            this.pnlDeviceControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAddDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDReadInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDeviceControl
            // 
            this.pnlDeviceControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDeviceControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeviceControl.Controls.Add(this.btnAddDevice);
            this.pnlDeviceControl.Controls.Add(this.nUDAddDevice);
            this.pnlDeviceControl.Controls.Add(this.btnStart);
            this.pnlDeviceControl.Controls.Add(this.lblStopBits);
            this.pnlDeviceControl.Controls.Add(this.lblReadInterval);
            this.pnlDeviceControl.Controls.Add(this.lblDataBits);
            this.pnlDeviceControl.Controls.Add(this.nUDReadInterval);
            this.pnlDeviceControl.Controls.Add(this.cmbBaudRate);
            this.pnlDeviceControl.Controls.Add(this.cmbParity);
            this.pnlDeviceControl.Controls.Add(this.lblBaud);
            this.pnlDeviceControl.Controls.Add(this.cmbStopBits);
            this.pnlDeviceControl.Controls.Add(this.lblParity);
            this.pnlDeviceControl.Controls.Add(this.cmbSerialPort);
            this.pnlDeviceControl.Controls.Add(this.cmbDataBits);
            this.pnlDeviceControl.Controls.Add(this.lblSerialPort);
            this.pnlDeviceControl.Location = new System.Drawing.Point(7, 7);
            this.pnlDeviceControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDeviceControl.Name = "pnlDeviceControl";
            this.pnlDeviceControl.Size = new System.Drawing.Size(795, 70);
            this.pnlDeviceControl.TabIndex = 1;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddDevice.Location = new System.Drawing.Point(697, 38);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(80, 23);
            this.btnAddDevice.TabIndex = 27;
            this.btnAddDevice.Text = "添加设备";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // nUDAddDevice
            // 
            this.nUDAddDevice.Font = new System.Drawing.Font("宋体", 12F);
            this.nUDAddDevice.Location = new System.Drawing.Point(583, 36);
            this.nUDAddDevice.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nUDAddDevice.Name = "nUDAddDevice";
            this.nUDAddDevice.Size = new System.Drawing.Size(100, 26);
            this.nUDAddDevice.TabIndex = 26;
            this.nUDAddDevice.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(583, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 23);
            this.btnStart.TabIndex = 25;
            this.btnStart.Text = "连接";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Font = new System.Drawing.Font("宋体", 12F);
            this.lblStopBits.Location = new System.Drawing.Point(10, 41);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(63, 16);
            this.lblStopBits.TabIndex = 18;
            this.lblStopBits.Text = "停止位:";
            // 
            // lblReadInterval
            // 
            this.lblReadInterval.AutoSize = true;
            this.lblReadInterval.Font = new System.Drawing.Font("宋体", 12F);
            this.lblReadInterval.Location = new System.Drawing.Point(367, 41);
            this.lblReadInterval.Name = "lblReadInterval";
            this.lblReadInterval.Size = new System.Drawing.Size(79, 16);
            this.lblReadInterval.TabIndex = 20;
            this.lblReadInterval.Text = "读取时间:";
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Font = new System.Drawing.Font("宋体", 12F);
            this.lblDataBits.Location = new System.Drawing.Point(375, 10);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(63, 16);
            this.lblDataBits.TabIndex = 17;
            this.lblDataBits.Text = "数据位:";
            // 
            // nUDReadInterval
            // 
            this.nUDReadInterval.Font = new System.Drawing.Font("宋体", 12F);
            this.nUDReadInterval.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUDReadInterval.Location = new System.Drawing.Point(449, 36);
            this.nUDReadInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDReadInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUDReadInterval.Name = "nUDReadInterval";
            this.nUDReadInterval.Size = new System.Drawing.Size(100, 26);
            this.nUDReadInterval.TabIndex = 24;
            this.nUDReadInterval.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDReadInterval.ValueChanged += new System.EventHandler(this.ChangeAutoSendTime);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "115200",
            "230400"});
            this.cmbBaudRate.Location = new System.Drawing.Point(254, 6);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(100, 24);
            this.cmbBaudRate.TabIndex = 11;
            this.cmbBaudRate.Text = "4800";
            // 
            // cmbParity
            // 
            this.cmbParity.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
            this.cmbParity.Location = new System.Drawing.Point(254, 37);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(100, 24);
            this.cmbParity.TabIndex = 23;
            this.cmbParity.Text = "无";
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBaud.Location = new System.Drawing.Point(188, 10);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(63, 16);
            this.lblBaud.TabIndex = 10;
            this.lblBaud.Text = "波特率:";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cmbStopBits.Location = new System.Drawing.Point(75, 37);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(100, 24);
            this.cmbStopBits.TabIndex = 22;
            this.cmbStopBits.Text = "1";
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Font = new System.Drawing.Font("宋体", 12F);
            this.lblParity.Location = new System.Drawing.Point(188, 41);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(63, 16);
            this.lblParity.TabIndex = 19;
            this.lblParity.Text = "校验位:";
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(75, 6);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(100, 24);
            this.cmbSerialPort.TabIndex = 8;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cmbDataBits.Location = new System.Drawing.Point(449, 6);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(100, 24);
            this.cmbDataBits.TabIndex = 21;
            this.cmbDataBits.Text = "8";
            // 
            // lblSerialPort
            // 
            this.lblSerialPort.AutoSize = true;
            this.lblSerialPort.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSerialPort.Location = new System.Drawing.Point(18, 10);
            this.lblSerialPort.Name = "lblSerialPort";
            this.lblSerialPort.Size = new System.Drawing.Size(47, 16);
            this.lblSerialPort.TabIndex = 4;
            this.lblSerialPort.Text = "串口:";
            // 
            // flpDevice
            // 
            this.flpDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpDevice.AutoScroll = true;
            this.flpDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpDevice.Location = new System.Drawing.Point(7, 84);
            this.flpDevice.Margin = new System.Windows.Forms.Padding(0);
            this.flpDevice.Name = "flpDevice";
            this.flpDevice.Size = new System.Drawing.Size(795, 390);
            this.flpDevice.TabIndex = 2;
            // 
            // timSerialPort
            // 
            this.timSerialPort.Enabled = true;
            this.timSerialPort.Interval = 2000;
            this.timSerialPort.Tick += new System.EventHandler(this.timSerialPort_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timAutoSend
            // 
            this.timAutoSend.Enabled = true;
            this.timAutoSend.Interval = 2000;
            this.timAutoSend.Tick += new System.EventHandler(this.timAutoSend_Tick);
            // 
            // timScan
            // 
            this.timScan.Interval = 2000;
            this.timScan.Tick += new System.EventHandler(this.timScan_Tick);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 481);
            this.Controls.Add(this.flpDevice);
            this.Controls.Add(this.pnlDeviceControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多设备管理系统";
            this.Load += new System.EventHandler(this.main_Load);
            this.pnlDeviceControl.ResumeLayout(false);
            this.pnlDeviceControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAddDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDReadInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDeviceControl;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Label lblSerialPort;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.NumericUpDown nUDReadInterval;
        private System.Windows.Forms.Label lblReadInterval;
        private System.Windows.Forms.FlowLayoutPanel flpDevice;
        private System.Windows.Forms.Timer timSerialPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timAutoSend;
        private System.Windows.Forms.Timer timScan;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.NumericUpDown nUDAddDevice;
    }
}

