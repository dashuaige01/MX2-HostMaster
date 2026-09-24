namespace 多设备管理系统
{
    partial class DevicePanel
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDevice = new System.Windows.Forms.Label();
            this.nUDHumiLow = new System.Windows.Forms.NumericUpDown();
            this.btnValueDown = new System.Windows.Forms.Button();
            this.nUDPresLimit = new System.Windows.Forms.NumericUpDown();
            this.lbPresLimit = new System.Windows.Forms.Label();
            this.nUDBaudRate = new System.Windows.Forms.NumericUpDown();
            this.nUDAddress = new System.Windows.Forms.NumericUpDown();
            this.nUDHumiHigh = new System.Windows.Forms.NumericUpDown();
            this.nUDTempLimit = new System.Windows.Forms.NumericUpDown();
            this.btnConfigPara = new System.Windows.Forms.Button();
            this.btnTimeCheck = new System.Windows.Forms.Button();
            this.lbBaudRate = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbHumiLow = new System.Windows.Forms.Label();
            this.lbHumiHigh = new System.Windows.Forms.Label();
            this.lbTempLimit = new System.Windows.Forms.Label();
            this.lbSensorStatus_P = new System.Windows.Forms.Label();
            this.lbSensor_P = new System.Windows.Forms.Label();
            this.lbHumiValue = new System.Windows.Forms.Label();
            this.lbHumidity = new System.Windows.Forms.Label();
            this.lbHeaterhStatus = new System.Windows.Forms.Label();
            this.lbTempeValue = new System.Windows.Forms.Label();
            this.lbFanStatus = new System.Windows.Forms.Label();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.lbSensorStatus_T = new System.Windows.Forms.Label();
            this.lbHeaterlStatus = new System.Windows.Forms.Label();
            this.lbHeaterh = new System.Windows.Forms.Label();
            this.lbFan = new System.Windows.Forms.Label();
            this.lbSensor_T = new System.Windows.Forms.Label();
            this.lbHeaterl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPresLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDBaudRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTempLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // lbDevice
            // 
            this.lbDevice.AutoSize = true;
            this.lbDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDevice.Font = new System.Drawing.Font("宋体", 12F);
            this.lbDevice.Location = new System.Drawing.Point(13, 13);
            this.lbDevice.Name = "lbDevice";
            this.lbDevice.Size = new System.Drawing.Size(17, 18);
            this.lbDevice.TabIndex = 66;
            this.lbDevice.Text = "1";
            // 
            // nUDHumiLow
            // 
            this.nUDHumiLow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDHumiLow.Location = new System.Drawing.Point(102, 220);
            this.nUDHumiLow.Name = "nUDHumiLow";
            this.nUDHumiLow.Size = new System.Drawing.Size(75, 26);
            this.nUDHumiLow.TabIndex = 65;
            this.nUDHumiLow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnValueDown
            // 
            this.btnValueDown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnValueDown.Location = new System.Drawing.Point(89, 256);
            this.btnValueDown.Name = "btnValueDown";
            this.btnValueDown.Size = new System.Drawing.Size(80, 23);
            this.btnValueDown.TabIndex = 64;
            this.btnValueDown.Text = "下载";
            this.btnValueDown.UseVisualStyleBackColor = true;
            this.btnValueDown.Click += new System.EventHandler(this.btnValueDown_Click);
            // 
            // nUDPresLimit
            // 
            this.nUDPresLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDPresLimit.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUDPresLimit.Location = new System.Drawing.Point(282, 220);
            this.nUDPresLimit.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDPresLimit.Name = "nUDPresLimit";
            this.nUDPresLimit.Size = new System.Drawing.Size(75, 26);
            this.nUDPresLimit.TabIndex = 63;
            this.nUDPresLimit.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lbPresLimit
            // 
            this.lbPresLimit.AutoSize = true;
            this.lbPresLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPresLimit.Location = new System.Drawing.Point(209, 225);
            this.lbPresLimit.Name = "lbPresLimit";
            this.lbPresLimit.Size = new System.Drawing.Size(71, 16);
            this.lbPresLimit.TabIndex = 62;
            this.lbPresLimit.Text = "压力阈值";
            // 
            // nUDBaudRate
            // 
            this.nUDBaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDBaudRate.Location = new System.Drawing.Point(282, 187);
            this.nUDBaudRate.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDBaudRate.Name = "nUDBaudRate";
            this.nUDBaudRate.Size = new System.Drawing.Size(75, 26);
            this.nUDBaudRate.TabIndex = 61;
            this.nUDBaudRate.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nUDAddress
            // 
            this.nUDAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDAddress.Location = new System.Drawing.Point(282, 154);
            this.nUDAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nUDAddress.Name = "nUDAddress";
            this.nUDAddress.Size = new System.Drawing.Size(75, 26);
            this.nUDAddress.TabIndex = 60;
            this.nUDAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nUDHumiHigh
            // 
            this.nUDHumiHigh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDHumiHigh.Location = new System.Drawing.Point(102, 187);
            this.nUDHumiHigh.Name = "nUDHumiHigh";
            this.nUDHumiHigh.Size = new System.Drawing.Size(75, 26);
            this.nUDHumiHigh.TabIndex = 59;
            this.nUDHumiHigh.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // nUDTempLimit
            // 
            this.nUDTempLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDTempLimit.Location = new System.Drawing.Point(102, 154);
            this.nUDTempLimit.Name = "nUDTempLimit";
            this.nUDTempLimit.Size = new System.Drawing.Size(75, 26);
            this.nUDTempLimit.TabIndex = 58;
            this.nUDTempLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnConfigPara
            // 
            this.btnConfigPara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfigPara.Location = new System.Drawing.Point(269, 256);
            this.btnConfigPara.Name = "btnConfigPara";
            this.btnConfigPara.Size = new System.Drawing.Size(87, 23);
            this.btnConfigPara.TabIndex = 57;
            this.btnConfigPara.Text = "参数配置";
            this.btnConfigPara.UseVisualStyleBackColor = true;
            this.btnConfigPara.Click += new System.EventHandler(this.btnConfigPara_Click);
            // 
            // btnTimeCheck
            // 
            this.btnTimeCheck.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTimeCheck.Location = new System.Drawing.Point(179, 256);
            this.btnTimeCheck.Name = "btnTimeCheck";
            this.btnTimeCheck.Size = new System.Drawing.Size(80, 23);
            this.btnTimeCheck.TabIndex = 56;
            this.btnTimeCheck.Text = "对时";
            this.btnTimeCheck.UseVisualStyleBackColor = true;
            this.btnTimeCheck.Click += new System.EventHandler(this.btnTimeCheck_Click);
            // 
            // lbBaudRate
            // 
            this.lbBaudRate.AutoSize = true;
            this.lbBaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbBaudRate.Location = new System.Drawing.Point(217, 192);
            this.lbBaudRate.Name = "lbBaudRate";
            this.lbBaudRate.Size = new System.Drawing.Size(55, 16);
            this.lbBaudRate.TabIndex = 55;
            this.lbBaudRate.Text = "波特率";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddress.Location = new System.Drawing.Point(209, 159);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(71, 16);
            this.lbAddress.TabIndex = 54;
            this.lbAddress.Text = "从机地址";
            // 
            // lbHumiLow
            // 
            this.lbHumiLow.AutoSize = true;
            this.lbHumiLow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumiLow.Location = new System.Drawing.Point(29, 225);
            this.lbHumiLow.Name = "lbHumiLow";
            this.lbHumiLow.Size = new System.Drawing.Size(71, 16);
            this.lbHumiLow.TabIndex = 53;
            this.lbHumiLow.Text = "湿度下限";
            // 
            // lbHumiHigh
            // 
            this.lbHumiHigh.AutoSize = true;
            this.lbHumiHigh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumiHigh.Location = new System.Drawing.Point(29, 192);
            this.lbHumiHigh.Name = "lbHumiHigh";
            this.lbHumiHigh.Size = new System.Drawing.Size(71, 16);
            this.lbHumiHigh.TabIndex = 52;
            this.lbHumiHigh.Text = "湿度上限";
            // 
            // lbTempLimit
            // 
            this.lbTempLimit.AutoSize = true;
            this.lbTempLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTempLimit.Location = new System.Drawing.Point(29, 159);
            this.lbTempLimit.Name = "lbTempLimit";
            this.lbTempLimit.Size = new System.Drawing.Size(71, 16);
            this.lbTempLimit.TabIndex = 51;
            this.lbTempLimit.Text = "温度阈值";
            // 
            // lbSensorStatus_P
            // 
            this.lbSensorStatus_P.AutoSize = true;
            this.lbSensorStatus_P.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensorStatus_P.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbSensorStatus_P.Location = new System.Drawing.Point(304, 111);
            this.lbSensorStatus_P.Name = "lbSensorStatus_P";
            this.lbSensorStatus_P.Size = new System.Drawing.Size(49, 20);
            this.lbSensorStatus_P.TabIndex = 50;
            this.lbSensorStatus_P.Text = "关闭";
            // 
            // lbSensor_P
            // 
            this.lbSensor_P.AutoSize = true;
            this.lbSensor_P.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensor_P.Location = new System.Drawing.Point(309, 82);
            this.lbSensor_P.Name = "lbSensor_P";
            this.lbSensor_P.Size = new System.Drawing.Size(39, 16);
            this.lbSensor_P.TabIndex = 49;
            this.lbSensor_P.Text = "压传";
            // 
            // lbHumiValue
            // 
            this.lbHumiValue.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumiValue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHumiValue.Location = new System.Drawing.Point(216, 36);
            this.lbHumiValue.Name = "lbHumiValue";
            this.lbHumiValue.Size = new System.Drawing.Size(120, 29);
            this.lbHumiValue.TabIndex = 44;
            this.lbHumiValue.Text = "-- %";
            this.lbHumiValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHumidity
            // 
            this.lbHumidity.AutoSize = true;
            this.lbHumidity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumidity.Location = new System.Drawing.Point(257, 11);
            this.lbHumidity.Name = "lbHumidity";
            this.lbHumidity.Size = new System.Drawing.Size(39, 16);
            this.lbHumidity.TabIndex = 39;
            this.lbHumidity.Text = "湿度";
            // 
            // lbHeaterhStatus
            // 
            this.lbHeaterhStatus.AutoSize = true;
            this.lbHeaterhStatus.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterhStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHeaterhStatus.Location = new System.Drawing.Point(180, 111);
            this.lbHeaterhStatus.Name = "lbHeaterhStatus";
            this.lbHeaterhStatus.Size = new System.Drawing.Size(49, 20);
            this.lbHeaterhStatus.TabIndex = 48;
            this.lbHeaterhStatus.Text = "关闭";
            // 
            // lbTempeValue
            // 
            this.lbTempeValue.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTempeValue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbTempeValue.Location = new System.Drawing.Point(50, 36);
            this.lbTempeValue.Name = "lbTempeValue";
            this.lbTempeValue.Size = new System.Drawing.Size(120, 29);
            this.lbTempeValue.TabIndex = 42;
            this.lbTempeValue.Text = "-- ℃";
            this.lbTempeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFanStatus
            // 
            this.lbFanStatus.AutoSize = true;
            this.lbFanStatus.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFanStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbFanStatus.Location = new System.Drawing.Point(248, 111);
            this.lbFanStatus.Name = "lbFanStatus";
            this.lbFanStatus.Size = new System.Drawing.Size(49, 20);
            this.lbFanStatus.TabIndex = 47;
            this.lbFanStatus.Text = "关闭";
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTemperature.Location = new System.Drawing.Point(91, 11);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(39, 16);
            this.lbTemperature.TabIndex = 38;
            this.lbTemperature.Text = "温度";
            // 
            // lbSensorStatus_T
            // 
            this.lbSensorStatus_T.AutoSize = true;
            this.lbSensorStatus_T.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensorStatus_T.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbSensorStatus_T.Location = new System.Drawing.Point(112, 111);
            this.lbSensorStatus_T.Name = "lbSensorStatus_T";
            this.lbSensorStatus_T.Size = new System.Drawing.Size(49, 20);
            this.lbSensorStatus_T.TabIndex = 46;
            this.lbSensorStatus_T.Text = "关闭";
            // 
            // lbHeaterlStatus
            // 
            this.lbHeaterlStatus.AutoSize = true;
            this.lbHeaterlStatus.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterlStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHeaterlStatus.Location = new System.Drawing.Point(44, 111);
            this.lbHeaterlStatus.Name = "lbHeaterlStatus";
            this.lbHeaterlStatus.Size = new System.Drawing.Size(49, 20);
            this.lbHeaterlStatus.TabIndex = 45;
            this.lbHeaterlStatus.Text = "关闭";
            // 
            // lbHeaterh
            // 
            this.lbHeaterh.AutoSize = true;
            this.lbHeaterh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterh.Location = new System.Drawing.Point(173, 82);
            this.lbHeaterh.Name = "lbHeaterh";
            this.lbHeaterh.Size = new System.Drawing.Size(63, 16);
            this.lbHeaterh.TabIndex = 43;
            this.lbHeaterh.Text = "加热器2";
            // 
            // lbFan
            // 
            this.lbFan.AutoSize = true;
            this.lbFan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFan.Location = new System.Drawing.Point(253, 82);
            this.lbFan.Name = "lbFan";
            this.lbFan.Size = new System.Drawing.Size(39, 16);
            this.lbFan.TabIndex = 41;
            this.lbFan.Text = "风扇";
            // 
            // lbSensor_T
            // 
            this.lbSensor_T.AutoSize = true;
            this.lbSensor_T.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensor_T.Location = new System.Drawing.Point(117, 82);
            this.lbSensor_T.Name = "lbSensor_T";
            this.lbSensor_T.Size = new System.Drawing.Size(39, 16);
            this.lbSensor_T.TabIndex = 40;
            this.lbSensor_T.Text = "温传";
            // 
            // lbHeaterl
            // 
            this.lbHeaterl.AutoSize = true;
            this.lbHeaterl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterl.Location = new System.Drawing.Point(37, 82);
            this.lbHeaterl.Name = "lbHeaterl";
            this.lbHeaterl.Size = new System.Drawing.Size(63, 16);
            this.lbHeaterl.TabIndex = 37;
            this.lbHeaterl.Text = "加热器1";
            // 
            // DevicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbDevice);
            this.Controls.Add(this.nUDHumiLow);
            this.Controls.Add(this.btnValueDown);
            this.Controls.Add(this.nUDPresLimit);
            this.Controls.Add(this.lbPresLimit);
            this.Controls.Add(this.nUDBaudRate);
            this.Controls.Add(this.nUDAddress);
            this.Controls.Add(this.nUDHumiHigh);
            this.Controls.Add(this.nUDTempLimit);
            this.Controls.Add(this.btnConfigPara);
            this.Controls.Add(this.btnTimeCheck);
            this.Controls.Add(this.lbBaudRate);
            this.Controls.Add(this.lbAddress);
            this.Controls.Add(this.lbHumiLow);
            this.Controls.Add(this.lbHumiHigh);
            this.Controls.Add(this.lbTempLimit);
            this.Controls.Add(this.lbSensorStatus_P);
            this.Controls.Add(this.lbSensor_P);
            this.Controls.Add(this.lbHumiValue);
            this.Controls.Add(this.lbHumidity);
            this.Controls.Add(this.lbHeaterhStatus);
            this.Controls.Add(this.lbTempeValue);
            this.Controls.Add(this.lbFanStatus);
            this.Controls.Add(this.lbTemperature);
            this.Controls.Add(this.lbSensorStatus_T);
            this.Controls.Add(this.lbHeaterlStatus);
            this.Controls.Add(this.lbHeaterh);
            this.Controls.Add(this.lbFan);
            this.Controls.Add(this.lbSensor_T);
            this.Controls.Add(this.lbHeaterl);
            this.Name = "DevicePanel";
            this.Size = new System.Drawing.Size(384, 289);
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPresLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDBaudRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTempLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDevice;
        private System.Windows.Forms.NumericUpDown nUDHumiLow;
        private System.Windows.Forms.Button btnValueDown;
        private System.Windows.Forms.NumericUpDown nUDPresLimit;
        private System.Windows.Forms.Label lbPresLimit;
        private System.Windows.Forms.NumericUpDown nUDBaudRate;
        private System.Windows.Forms.NumericUpDown nUDAddress;
        private System.Windows.Forms.NumericUpDown nUDHumiHigh;
        private System.Windows.Forms.NumericUpDown nUDTempLimit;
        private System.Windows.Forms.Button btnConfigPara;
        private System.Windows.Forms.Button btnTimeCheck;
        private System.Windows.Forms.Label lbBaudRate;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbHumiLow;
        private System.Windows.Forms.Label lbHumiHigh;
        private System.Windows.Forms.Label lbTempLimit;
        private System.Windows.Forms.Label lbSensorStatus_P;
        private System.Windows.Forms.Label lbSensor_P;
        private System.Windows.Forms.Label lbHumiValue;
        private System.Windows.Forms.Label lbHumidity;
        private System.Windows.Forms.Label lbHeaterhStatus;
        private System.Windows.Forms.Label lbTempeValue;
        private System.Windows.Forms.Label lbFanStatus;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.Label lbSensorStatus_T;
        private System.Windows.Forms.Label lbHeaterlStatus;
        private System.Windows.Forms.Label lbHeaterh;
        private System.Windows.Forms.Label lbFan;
        private System.Windows.Forms.Label lbSensor_T;
        private System.Windows.Forms.Label lbHeaterl;
    }
}
