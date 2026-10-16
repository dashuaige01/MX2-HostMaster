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
            this.pnlChart = new System.Windows.Forms.Panel();
            this.picChart = new System.Windows.Forms.PictureBox();
            this.lbChartTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlParams = new System.Windows.Forms.Panel();
            this.lbFan = new System.Windows.Forms.Label();
            this.lbHumidity = new System.Windows.Forms.Label();
            this.lbTemperature = new System.Windows.Forms.Label();
            this.lbDevice = new System.Windows.Forms.Label();
            this.nUDPresLimit = new System.Windows.Forms.NumericUpDown();
            this.lbPresLimit = new System.Windows.Forms.Label();
            this.nUDAddress = new System.Windows.Forms.NumericUpDown();
            this.lbAddress = new System.Windows.Forms.Label();
            this.btnValueDown = new System.Windows.Forms.Button();
            this.btnConfigPara = new System.Windows.Forms.Button();
            this.lbSensorStatus_P = new System.Windows.Forms.Label();
            this.lbSensor_P = new System.Windows.Forms.Label();
            this.lbHumiValue = new System.Windows.Forms.Label();
            this.lbHeaterhStatus = new System.Windows.Forms.Label();
            this.lbFanStatus = new System.Windows.Forms.Label();
            this.lbHeaterh = new System.Windows.Forms.Label();
            this.nUDHumiLow = new System.Windows.Forms.NumericUpDown();
            this.nUDHumiHigh = new System.Windows.Forms.NumericUpDown();
            this.nUDTempLimit = new System.Windows.Forms.NumericUpDown();
            this.btnDeviceDelete = new System.Windows.Forms.Button();
            this.lbHumiLow = new System.Windows.Forms.Label();
            this.lbHumiHigh = new System.Windows.Forms.Label();
            this.lbTempLimit = new System.Windows.Forms.Label();
            this.lbTempeValue = new System.Windows.Forms.Label();
            this.lbSensorStatus_T = new System.Windows.Forms.Label();
            this.lbHeaterlStatus = new System.Windows.Forms.Label();
            this.lbSensor_T = new System.Windows.Forms.Label();
            this.lbHeaterl = new System.Windows.Forms.Label();
            this.pnlChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).BeginInit();
            this.pnlParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPresLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiLow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiHigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTempLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlChart
            // 
            this.pnlChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChart.Controls.Add(this.picChart);
            this.pnlChart.Controls.Add(this.lbChartTitle);
            this.pnlChart.Controls.Add(this.btnBack);
            this.pnlChart.Location = new System.Drawing.Point(0, 0);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(386, 291);
            this.pnlChart.TabIndex = 73;
            this.pnlChart.Visible = false;
            // 
            // picChart
            // 
            this.picChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picChart.BackColor = System.Drawing.Color.Transparent;
            this.picChart.Location = new System.Drawing.Point(8, 40);
            this.picChart.Name = "picChart";
            this.picChart.Size = new System.Drawing.Size(370, 240);
            this.picChart.TabIndex = 2;
            this.picChart.TabStop = false;
            // 
            // lbChartTitle
            // 
            this.lbChartTitle.AutoSize = true;
            this.lbChartTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbChartTitle.Location = new System.Drawing.Point(120, 12);
            this.lbChartTitle.Name = "lbChartTitle";
            this.lbChartTitle.Size = new System.Drawing.Size(92, 16);
            this.lbChartTitle.TabIndex = 1;
            this.lbChartTitle.Text = "温度折线图";
            // 
            // btnBack
            // 
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(8, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(65, 25);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlParams
            // 
            this.pnlParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParams.Controls.Add(this.lbFan);
            this.pnlParams.Controls.Add(this.lbHumidity);
            this.pnlParams.Controls.Add(this.lbTemperature);
            this.pnlParams.Controls.Add(this.lbDevice);
            this.pnlParams.Controls.Add(this.nUDPresLimit);
            this.pnlParams.Controls.Add(this.lbPresLimit);
            this.pnlParams.Controls.Add(this.nUDAddress);
            this.pnlParams.Controls.Add(this.lbAddress);
            this.pnlParams.Controls.Add(this.btnValueDown);
            this.pnlParams.Controls.Add(this.btnConfigPara);
            this.pnlParams.Controls.Add(this.lbSensorStatus_P);
            this.pnlParams.Controls.Add(this.lbSensor_P);
            this.pnlParams.Controls.Add(this.lbHumiValue);
            this.pnlParams.Controls.Add(this.lbHeaterhStatus);
            this.pnlParams.Controls.Add(this.lbFanStatus);
            this.pnlParams.Controls.Add(this.lbHeaterh);
            this.pnlParams.Controls.Add(this.nUDHumiLow);
            this.pnlParams.Controls.Add(this.nUDHumiHigh);
            this.pnlParams.Controls.Add(this.nUDTempLimit);
            this.pnlParams.Controls.Add(this.btnDeviceDelete);
            this.pnlParams.Controls.Add(this.lbHumiLow);
            this.pnlParams.Controls.Add(this.lbHumiHigh);
            this.pnlParams.Controls.Add(this.lbTempLimit);
            this.pnlParams.Controls.Add(this.lbTempeValue);
            this.pnlParams.Controls.Add(this.lbSensorStatus_T);
            this.pnlParams.Controls.Add(this.lbHeaterlStatus);
            this.pnlParams.Controls.Add(this.lbSensor_T);
            this.pnlParams.Controls.Add(this.lbHeaterl);
            this.pnlParams.Location = new System.Drawing.Point(0, 0);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.Size = new System.Drawing.Size(386, 291);
            this.pnlParams.TabIndex = 74;
            // 
            // lbFan
            // 
            this.lbFan.AutoSize = true;
            this.lbFan.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFan.Location = new System.Drawing.Point(231, 86);
            this.lbFan.Name = "lbFan";
            this.lbFan.Size = new System.Drawing.Size(41, 16);
            this.lbFan.TabIndex = 103;
            this.lbFan.Text = "风扇";
            // 
            // lbHumidity
            // 
            this.lbHumidity.AutoSize = true;
            this.lbHumidity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumidity.Location = new System.Drawing.Point(247, 17);
            this.lbHumidity.Name = "lbHumidity";
            this.lbHumidity.Size = new System.Drawing.Size(41, 16);
            this.lbHumidity.TabIndex = 102;
            this.lbHumidity.Text = "湿度";
            // 
            // lbTemperature
            // 
            this.lbTemperature.AutoSize = true;
            this.lbTemperature.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTemperature.Location = new System.Drawing.Point(82, 17);
            this.lbTemperature.Name = "lbTemperature";
            this.lbTemperature.Size = new System.Drawing.Size(41, 16);
            this.lbTemperature.TabIndex = 101;
            this.lbTemperature.Text = "温度";
            // 
            // lbDevice
            // 
            this.lbDevice.AutoSize = true;
            this.lbDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDevice.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDevice.Location = new System.Drawing.Point(12, 12);
            this.lbDevice.Name = "lbDevice";
            this.lbDevice.Size = new System.Drawing.Size(18, 18);
            this.lbDevice.TabIndex = 100;
            this.lbDevice.Text = "1";
            // 
            // nUDPresLimit
            // 
            this.nUDPresLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDPresLimit.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nUDPresLimit.Location = new System.Drawing.Point(278, 184);
            this.nUDPresLimit.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nUDPresLimit.Name = "nUDPresLimit";
            this.nUDPresLimit.Size = new System.Drawing.Size(75, 26);
            this.nUDPresLimit.TabIndex = 97;
            this.nUDPresLimit.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lbPresLimit
            // 
            this.lbPresLimit.AutoSize = true;
            this.lbPresLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbPresLimit.Location = new System.Drawing.Point(205, 189);
            this.lbPresLimit.Name = "lbPresLimit";
            this.lbPresLimit.Size = new System.Drawing.Size(75, 16);
            this.lbPresLimit.TabIndex = 96;
            this.lbPresLimit.Text = "压力阈值";
            // 
            // nUDAddress
            // 
            this.nUDAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDAddress.Location = new System.Drawing.Point(278, 151);
            this.nUDAddress.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nUDAddress.Name = "nUDAddress";
            this.nUDAddress.Size = new System.Drawing.Size(75, 26);
            this.nUDAddress.TabIndex = 95;
            this.nUDAddress.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAddress.Location = new System.Drawing.Point(205, 156);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(75, 16);
            this.lbAddress.TabIndex = 94;
            this.lbAddress.Text = "从机地址";
            // 
            // btnValueDown
            // 
            this.btnValueDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValueDown.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnValueDown.Location = new System.Drawing.Point(180, 253);
            this.btnValueDown.Name = "btnValueDown";
            this.btnValueDown.Size = new System.Drawing.Size(80, 23);
            this.btnValueDown.TabIndex = 93;
            this.btnValueDown.Text = "下载";
            this.btnValueDown.UseVisualStyleBackColor = true;
            this.btnValueDown.Click += new System.EventHandler(this.btnValueDown_Click);
            // 
            // btnConfigPara
            // 
            this.btnConfigPara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigPara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfigPara.Location = new System.Drawing.Point(270, 253);
            this.btnConfigPara.Name = "btnConfigPara";
            this.btnConfigPara.Size = new System.Drawing.Size(87, 23);
            this.btnConfigPara.TabIndex = 92;
            this.btnConfigPara.Text = "参数配置";
            this.btnConfigPara.UseVisualStyleBackColor = true;
            this.btnConfigPara.Click += new System.EventHandler(this.btnConfigPara_Click);
            // 
            // lbSensorStatus_P
            // 
            this.lbSensorStatus_P.AutoSize = true;
            this.lbSensorStatus_P.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensorStatus_P.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbSensorStatus_P.Location = new System.Drawing.Point(286, 115);
            this.lbSensorStatus_P.Name = "lbSensorStatus_P";
            this.lbSensorStatus_P.Size = new System.Drawing.Size(51, 20);
            this.lbSensorStatus_P.TabIndex = 91;
            this.lbSensorStatus_P.Text = "关闭";
            // 
            // lbSensor_P
            // 
            this.lbSensor_P.AutoSize = true;
            this.lbSensor_P.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensor_P.Location = new System.Drawing.Point(292, 86);
            this.lbSensor_P.Name = "lbSensor_P";
            this.lbSensor_P.Size = new System.Drawing.Size(41, 16);
            this.lbSensor_P.TabIndex = 90;
            this.lbSensor_P.Text = "压传";
            // 
            // lbHumiValue
            // 
            this.lbHumiValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbHumiValue.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumiValue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHumiValue.Location = new System.Drawing.Point(207, 43);
            this.lbHumiValue.Name = "lbHumiValue";
            this.lbHumiValue.Size = new System.Drawing.Size(120, 29);
            this.lbHumiValue.TabIndex = 87;
            this.lbHumiValue.Text = "40%";
            this.lbHumiValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHumiValue.Click += new System.EventHandler(this.lbHumiValue_Click);
            // 
            // lbHeaterhStatus
            // 
            this.lbHeaterhStatus.AutoSize = true;
            this.lbHeaterhStatus.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterhStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHeaterhStatus.Location = new System.Drawing.Point(163, 115);
            this.lbHeaterhStatus.Name = "lbHeaterhStatus";
            this.lbHeaterhStatus.Size = new System.Drawing.Size(51, 20);
            this.lbHeaterhStatus.TabIndex = 89;
            this.lbHeaterhStatus.Text = "关闭";
            // 
            // lbFanStatus
            // 
            this.lbFanStatus.AutoSize = true;
            this.lbFanStatus.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFanStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbFanStatus.Location = new System.Drawing.Point(225, 115);
            this.lbFanStatus.Name = "lbFanStatus";
            this.lbFanStatus.Size = new System.Drawing.Size(51, 20);
            this.lbFanStatus.TabIndex = 88;
            this.lbFanStatus.Text = "关闭";
            // 
            // lbHeaterh
            // 
            this.lbHeaterh.AutoSize = true;
            this.lbHeaterh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterh.Location = new System.Drawing.Point(156, 86);
            this.lbHeaterh.Name = "lbHeaterh";
            this.lbHeaterh.Size = new System.Drawing.Size(67, 16);
            this.lbHeaterh.TabIndex = 86;
            this.lbHeaterh.Text = "加热器2";
            // 
            // nUDHumiLow
            // 
            this.nUDHumiLow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDHumiLow.Location = new System.Drawing.Point(99, 217);
            this.nUDHumiLow.Name = "nUDHumiLow";
            this.nUDHumiLow.Size = new System.Drawing.Size(75, 26);
            this.nUDHumiLow.TabIndex = 83;
            this.nUDHumiLow.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nUDHumiHigh
            // 
            this.nUDHumiHigh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDHumiHigh.Location = new System.Drawing.Point(99, 184);
            this.nUDHumiHigh.Name = "nUDHumiHigh";
            this.nUDHumiHigh.Size = new System.Drawing.Size(75, 26);
            this.nUDHumiHigh.TabIndex = 82;
            this.nUDHumiHigh.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            // 
            // nUDTempLimit
            // 
            this.nUDTempLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nUDTempLimit.Location = new System.Drawing.Point(99, 151);
            this.nUDTempLimit.Name = "nUDTempLimit";
            this.nUDTempLimit.Size = new System.Drawing.Size(75, 26);
            this.nUDTempLimit.TabIndex = 81;
            this.nUDTempLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnDeviceDelete
            // 
            this.btnDeviceDelete.BackColor = System.Drawing.Color.Red;
            this.btnDeviceDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeviceDelete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeviceDelete.Location = new System.Drawing.Point(87, 253);
            this.btnDeviceDelete.Name = "btnDeviceDelete";
            this.btnDeviceDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDeviceDelete.TabIndex = 80;
            this.btnDeviceDelete.Text = "删除";
            this.btnDeviceDelete.UseVisualStyleBackColor = false;
            this.btnDeviceDelete.Click += new System.EventHandler(this.btnDeviceDelete_Click);
            // 
            // lbHumiLow
            // 
            this.lbHumiLow.AutoSize = true;
            this.lbHumiLow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumiLow.Location = new System.Drawing.Point(26, 222);
            this.lbHumiLow.Name = "lbHumiLow";
            this.lbHumiLow.Size = new System.Drawing.Size(75, 16);
            this.lbHumiLow.TabIndex = 79;
            this.lbHumiLow.Text = "湿度下限";
            // 
            // lbHumiHigh
            // 
            this.lbHumiHigh.AutoSize = true;
            this.lbHumiHigh.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHumiHigh.Location = new System.Drawing.Point(26, 189);
            this.lbHumiHigh.Name = "lbHumiHigh";
            this.lbHumiHigh.Size = new System.Drawing.Size(75, 16);
            this.lbHumiHigh.TabIndex = 78;
            this.lbHumiHigh.Text = "湿度上限";
            // 
            // lbTempLimit
            // 
            this.lbTempLimit.AutoSize = true;
            this.lbTempLimit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTempLimit.Location = new System.Drawing.Point(26, 156);
            this.lbTempLimit.Name = "lbTempLimit";
            this.lbTempLimit.Size = new System.Drawing.Size(75, 16);
            this.lbTempLimit.TabIndex = 77;
            this.lbTempLimit.Text = "温度阈值";
            // 
            // lbTempeValue
            // 
            this.lbTempeValue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTempeValue.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTempeValue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbTempeValue.Location = new System.Drawing.Point(47, 43);
            this.lbTempeValue.Name = "lbTempeValue";
            this.lbTempeValue.Size = new System.Drawing.Size(120, 29);
            this.lbTempeValue.TabIndex = 74;
            this.lbTempeValue.Text = "30℃";
            this.lbTempeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTempeValue.Click += new System.EventHandler(this.lbTempeValue_Click);
            // 
            // lbSensorStatus_T
            // 
            this.lbSensorStatus_T.AutoSize = true;
            this.lbSensorStatus_T.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensorStatus_T.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbSensorStatus_T.Location = new System.Drawing.Point(103, 115);
            this.lbSensorStatus_T.Name = "lbSensorStatus_T";
            this.lbSensorStatus_T.Size = new System.Drawing.Size(51, 20);
            this.lbSensorStatus_T.TabIndex = 76;
            this.lbSensorStatus_T.Text = "关闭";
            // 
            // lbHeaterlStatus
            // 
            this.lbHeaterlStatus.AutoSize = true;
            this.lbHeaterlStatus.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterlStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbHeaterlStatus.Location = new System.Drawing.Point(41, 115);
            this.lbHeaterlStatus.Name = "lbHeaterlStatus";
            this.lbHeaterlStatus.Size = new System.Drawing.Size(51, 20);
            this.lbHeaterlStatus.TabIndex = 75;
            this.lbHeaterlStatus.Text = "关闭";
            // 
            // lbSensor_T
            // 
            this.lbSensor_T.AutoSize = true;
            this.lbSensor_T.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSensor_T.Location = new System.Drawing.Point(108, 86);
            this.lbSensor_T.Name = "lbSensor_T";
            this.lbSensor_T.Size = new System.Drawing.Size(41, 16);
            this.lbSensor_T.TabIndex = 73;
            this.lbSensor_T.Text = "温传";
            // 
            // lbHeaterl
            // 
            this.lbHeaterl.AutoSize = true;
            this.lbHeaterl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHeaterl.Location = new System.Drawing.Point(34, 86);
            this.lbHeaterl.Name = "lbHeaterl";
            this.lbHeaterl.Size = new System.Drawing.Size(67, 16);
            this.lbHeaterl.TabIndex = 71;
            this.lbHeaterl.Text = "加热器1";
            // 
            // DevicePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnlParams);
            this.Controls.Add(this.pnlChart);
            this.Name = "DevicePanel";
            this.Size = new System.Drawing.Size(386, 291);
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChart)).EndInit();
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPresLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiLow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDHumiHigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTempLimit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.PictureBox picChart;
        private System.Windows.Forms.Label lbChartTitle;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlParams;
        private System.Windows.Forms.Label lbFan;
        private System.Windows.Forms.Label lbHumidity;
        private System.Windows.Forms.Label lbTemperature;
        private System.Windows.Forms.Label lbDevice;
        private System.Windows.Forms.NumericUpDown nUDPresLimit;
        private System.Windows.Forms.Label lbPresLimit;
        private System.Windows.Forms.NumericUpDown nUDAddress;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Button btnValueDown;
        private System.Windows.Forms.Button btnConfigPara;
        private System.Windows.Forms.Label lbSensorStatus_P;
        private System.Windows.Forms.Label lbSensor_P;
        private System.Windows.Forms.Label lbHumiValue;
        private System.Windows.Forms.Label lbHeaterhStatus;
        private System.Windows.Forms.Label lbFanStatus;
        private System.Windows.Forms.Label lbHeaterh;
        private System.Windows.Forms.NumericUpDown nUDHumiLow;
        private System.Windows.Forms.NumericUpDown nUDHumiHigh;
        private System.Windows.Forms.NumericUpDown nUDTempLimit;
        private System.Windows.Forms.Button btnDeviceDelete;
        private System.Windows.Forms.Label lbHumiLow;
        private System.Windows.Forms.Label lbHumiHigh;
        private System.Windows.Forms.Label lbTempLimit;
        private System.Windows.Forms.Label lbTempeValue;
        private System.Windows.Forms.Label lbSensorStatus_T;
        private System.Windows.Forms.Label lbHeaterlStatus;
        private System.Windows.Forms.Label lbSensor_T;
        private System.Windows.Forms.Label lbHeaterl;
    }
}
