using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace 多设备管理系统
{
    // === 属性 ===
    public partial class DevicePanel : UserControl
    {
        public int DeviceAddress { get; private set; } // 
        private readonly Func<byte[], byte[]> _sendFunc; // 发送字符串的函数
        private readonly Action<int> _removeFunc; // "删除自己"的回调
        private DatabaseHelper _db; // 每个面板自己的数据库
        //private readonly List<DateTime> _chartTimes = new List<DateTime>(); // 时间数组
        //private readonly List<float> _chartValues = new List<float>(); // 数据数组
        private readonly List<(DateTime Time, float Value)> _chartDatas = new List<(DateTime, float)>(); // 声明一个元组列表
        private bool _chartIsTemp; // 当前图表类型
        private static readonly Pen AxisPen = new Pen(Color.FromArgb(80, 80, 80), 2f); // 坐标轴线
        private static readonly Pen GridPen = new Pen(Color.FromArgb(60, 128, 128, 128), 1f); // 网格线
        private static readonly Pen LinePen = new Pen(Color.DodgerBlue, 2f); // 数据线
        private static readonly Brush TextBrush = Brushes.Black; // 黑色笔刷
        private static readonly Font LabelFont = new Font("宋体", 12F, System.Drawing.FontStyle.Bold); // 建议使用固定字体或缓存字体对象


        public DevicePanel(int address, Func<byte[], byte[]> sendFunc, Action<int> removeFunc)
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint // 自己画
                    | ControlStyles.AllPaintingInWmPaint // 不擦背景
                    | ControlStyles.OptimizedDoubleBuffer // 双缓冲防闪烁
                    | ControlStyles.ResizeRedraw // 改变大小重绘
                    | ControlStyles.SupportsTransparentBackColor, true); // 允许透明
            this.BackColor = Color.Transparent; // 背景颜色改成随父控件

            _sendFunc = sendFunc; // 发送函数
            DeviceAddress = address; // 从机设备地址
            _removeFunc = removeFunc; // 删除从机设备函数
            _db = new DatabaseHelper(address); // 创建独立的数据库文件

            lbDevice.Text = address.ToString(); // 设备编号
            nUDAddress.Value = address; // 从机地址默认值

            lbTempeValue.Cursor = Cursors.Hand;   // 鼠标变手型，提示可点
            lbHumiValue.Cursor = Cursors.Hand;
            picChart.Paint += picChart_Paint; // 画图
        }

        public void UpdateData(byte[] buff)
        { // 更新数据窗口显示
            if (buff == null || buff.Length < 13) // 有数据且数据长度大于13
                return;

            float temperature = BitConverter.ToSingle(buff, 3); // 温度值
            float humidity = BitConverter.ToSingle(buff, 7); // 湿度值
            temperature = float.Parse(temperature.ToString("0.0")); // 精度至0.1
            humidity = float.Parse(humidity.ToString("0.0")); // 精度至0.1

            lbTempeValue.Text = temperature + "℃"; 
            lbHumiValue.Text = humidity + "%"; 

            lbHeaterlStatus.Text = ((buff[12] & 0x01) == 1) ? "开启" : "关闭";
            lbSensorStatus_T.Text = ((buff[12] & 0x02) == 2) ? "开启" : "关闭";
            lbFanStatus.Text = ((buff[12] & 0x04) == 4) ? "开启" : "关闭";
            lbHeaterhStatus.Text = ((buff[12] & 0x08) == 8) ? "开启" : "关闭";

            if ((buff[12] & 0x30) == 0x10) lbSensorStatus_P.Text = "平静";
            else if ((buff[12] & 0x30) == 0x20) lbSensorStatus_P.Text = "呼气";
            else if ((buff[12] & 0x30) == 0x30) lbSensorStatus_P.Text = "吸气";
            else lbSensorStatus_P.Text = "关闭";

            lbHeaterlStatus.BackColor = ((buff[11] & 0x01) == 1) ? Color.Red : Color.Empty;
            lbSensorStatus_T.BackColor = ((buff[11] & 0x02) == 2) ? Color.Red : Color.Empty;
            lbHeaterhStatus.BackColor = ((buff[11] & 0x04) == 4) ? Color.Red : Color.Empty;
            lbSensorStatus_P.BackColor = ((buff[11] & 0x08) == 8) ? Color.Red : Color.Empty;
            
            _db.InsertData(DateTime.Now, DeviceAddress, temperature, humidity,
                            lbSensorStatus_T.Text, lbHeaterlStatus.Text, lbHeaterhStatus.Text); // 顺便存到自己的数据库

            if (pnlChart.Visible)   // 图表开着就跟着最新数据走
            {
                LoadChartData();
                picChart.Invalidate();
            }
        }

        public void UpSencelData(byte[] buff)
        { // 更新数据窗口显示
            if (buff == null || buff.Length < 7) // 7位参数数据
                return;

            nUDTempLimit.Value = buff[5];
            nUDHumiHigh.Value = buff[3];
            nUDHumiLow.Value = buff[4];
            nUDAddress.Value = buff[6];
            nUDPresLimit.Value = (UInt16)(buff[15] | (buff[16]<<8));
        }

        public void DeviceOnline(bool statue)
        {
            if (statue)
                lbDevice.BackColor = Color.Empty;
            else
                lbDevice.BackColor = Color.Red;
        }

        private void btnValueDown_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog()) // 
            {
                dlg.Title = "选择保存位置";
                dlg.Filter = "Excel文件|*.xlsx";
                dlg.FileName = $"SensorData_{DeviceAddress}.xlsx"; // 默认文件名带设备号

                if (dlg.ShowDialog() == DialogResult.OK) { // 用户点了"保存"
                    _db.ReadSQLData(dlg.FileName); // 用选中的路径导出
                }
            }
        }

        private void btnConfigPara_Click(object sender, EventArgs e)
        { // 参数修改按键回调函数
            try {
                Task.Run(() => { // 5. 启动后台任务（不阻塞 UI）
                    byte[] dataSend = { 0x01, 0x10, 0x00, 0x05, 0x00, 0x07, 0x0E,
                        0x4B, 0x0A, 0x01, 0x02, 0x02,
                        0xEA, 0x07, 0x04, 0x15, 0x0D, 0x06, 0x01,
                        0xF4, 0x01,
                        0x93, 0x53 };
                    DateTime now = DateTime.Now;
                    dataSend[0] = (byte)nUDAddress.Value; // 构造数据包
                    dataSend[9] = (byte)nUDTempLimit.Value; // 温度阈值
                    dataSend[7] = (byte)nUDHumiHigh.Value; // 湿度上限值
                    dataSend[8] = (byte)nUDHumiLow.Value; // 湿度下限值
                    dataSend[10] = (byte)nUDAddress.Value; // 地址值
                    //dataSend[11] = (byte)nUDBaudRate.Value; // 波特率 不建议更改
                    dataSend[12] = (byte)(now.Year & 0xFF); // 年低位
                    dataSend[13] = (byte)((now.Year >> 8) & 0xFF); // 年高位
                    dataSend[14] = (byte)now.Month; // 月
                    dataSend[15] = (byte)now.Day; // 日
                    dataSend[16] = (byte)now.Hour; // 时
                    dataSend[17] = (byte)now.Minute; // 分
                    dataSend[18] = (byte)now.Second; // 秒
                    ushort limitvalue = (ushort)nUDPresLimit.Value;
                    dataSend[19] = (byte)(limitvalue & 0xFF); // 低位
                    dataSend[20] = (byte)((limitvalue >> 8) & 0xFF); // 高位
                    byte[] crc = main.CRC16_MODBUS(dataSend, dataSend.Length - 2); // 预计算 CRC (因为数据部分不变，CRC 其实也是固定的，但为了完整保留你逻辑)
                    dataSend[dataSend.Length - 2] = crc[0];
                    dataSend[dataSend.Length - 1] = crc[1];

                    byte[] buff = _sendFunc(dataSend); // 发送数据
                    if (buff == null || buff.Length < 4) 
                    {
                        MessageBox.Show("参数修改失败：设备无响应");
                        return;
                    } 
                    else if ((buff.Length > 0) && ((buff[1] & 0x80) != 0x80)) 
                    {
                        this.Invoke(new Action(() => { // UI 线程更新界面
                            crc = main.CRC16_MODBUS(buff, buff.Length - 2);
                            if (crc[0] == buff[buff.Length - 2] && crc[1] == buff[buff.Length - 1]) {
                                MessageBox.Show("参数修改成功");
                            } else {
                                MessageBox.Show("参数修改失败：校验码有误");
                            }
                        }));
                    }
                });
            } catch (Exception ex) {
                MessageBox.Show("参数配置错误：" + ex);
            }
        }

        private void btnDeviceDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"确定要删除设备{DeviceAddress}吗？", "提示",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _removeFunc(DeviceAddress); // 告诉 main："把我删掉"
                _db.CleanOldData();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Form f = FindForm();
            Image img = f?.BackgroundImage;
            if (img == null)
            {
                base.OnPaintBackground(e);   // 窗体没图就退回默认画法
                return;
            }

            // 算出本面板在窗体客户区中的绝对位置（沿父链累加 Left/Top）
            Point offset = new Point(0, 0);
            Control c = this;
            while (c != null && c != f)
            {
                offset.X += c.Left;
                offset.Y += c.Top;
                c = c.Parent;
            }

            // 把窗体那张图按窗体尺寸1:1画到对应位置（负号：窗体原点换算到本控件坐标系）
            e.Graphics.DrawImage(img,
                new Rectangle(-offset.X, -offset.Y,
                              f.ClientSize.Width, f.ClientSize.Height));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); // 调用父类逻辑，通常用来绘制里面的子控件（比如文本框、按钮）
            UiStyle.PaintGlassHighlight(e, this, 10); // 顶部高光
            UiStyle.DrawRoundBorder(e, this, 10,
                Color.FromArgb(200, 80, 80, 80), 2f); // 玻璃描边
        }

        private void lbTempeValue_Click(object sender, EventArgs e)
        { // 点温度值 → 温度图
            _chartIsTemp = true;
            LoadChartData(); // 查当日数据
            lbChartTitle.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 温度折线图";
            foreach (Control c in Controls)
                if (c != pnlChart) c.Visible = false; // 藏起参数视图
            pnlChart.Visible = true;
            pnlChart.BringToFront();
            picChart.Invalidate(); // 触发 Paint 重画
        }

        private void lbHumiValue_Click(object sender, EventArgs e)
        { // 点湿度值 → 湿度图
            _chartIsTemp = false;
            LoadChartData(); // 查当日数据
            lbChartTitle.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 湿度折线图";
            foreach (Control c in Controls)
                if (c != pnlChart) c.Visible = false; // 藏起参数视图
            pnlChart.Visible = true;
            pnlChart.BringToFront();
            picChart.Invalidate(); // 触发 Paint 重画
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HideChart(); // 返回
        }

        private void HideChart()
        {
            pnlChart.Visible = false;
            foreach (Control c in Controls)
                if (c != pnlChart) c.Visible = true;    // 恢复参数视图
        }

        private void LoadChartData()
        {
            _chartDatas.Clear();
            _db.GetTodayData(_chartIsTemp, _chartDatas);
        }

        private void picChart_Paint(object sender, PaintEventArgs e) 
        {
            var g = e.Graphics; // 获取画布
            g.SmoothingMode = SmoothingMode.AntiAlias; // 抗锯齿，线才平滑
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit; // 优化文字清晰度

            Rectangle rect = picChart.ClientRectangle; // 获取控件的客户区矩形

            if (_chartDatas == null || _chartDatas.Count <= 10)
            { // 空数据快速返回
                string msg = "当日暂无更多数据";
                SizeF sz = g.MeasureString(msg, LabelFont); // 使用 MeasureString 或固定偏移确保文字真正居中
                g.DrawString(msg, LabelFont, TextBrush,
                    (rect.Width - sz.Width) / 2,
                    (rect.Height - sz.Height) / 2); // 绘制文字到控件中间区域
                return; // 不执行后面的绘图代码
            }

            // 绘图区（留出坐标轴标签的位置）
            const int LeftMargin = 42, RightMargin = 10, TopMargin = 12, BottomMargin = 26; // 预留边距
            int plotWidth = Math.Max(0, rect.Width - LeftMargin - RightMargin); // 新绘图区域宽度
            int plotHeight = Math.Max(0, rect.Height - TopMargin - BottomMargin); // 新绘图区域高度
            if (plotWidth <= 0 || plotHeight <= 0) return; // 防止控件过小导致绘图区负数

            Rectangle plot = new Rectangle(LeftMargin, TopMargin, plotWidth, plotHeight); // 计算新的绘图区域

            // Y轴范围：最小~最大，上下各留10%；全相等时强行撑开
            float vMin = 100.0f;
            float vMax = 0.0f;
            foreach (var v in _chartDatas)
            { // 遍历当日数据库数据
                if (v.Value < vMin) vMin = v.Value;
                if (v.Value > vMax) vMax = v.Value;
            }

            float finalRange = vMax - vMin; // 预计算分母，避免后续重复减法
            if (finalRange < 0.5f)
            { // 处理数据最小显示区域
                float center = (vMax + vMin) / 2;
                vMin = center - 0.7f;
                vMax = center + 0.7f;
            }
            else
            { // 添加显示Padding
                float pad = finalRange * 0.1f; // 计算显示范围内部
                vMin -= pad;
                vMax += pad;
            }
            finalRange = vMax - vMin; // 预计算分母，避免后续重复减法

            // 坐标映射：X = 当日0:00~24:00 均匀铺满；Y = 值线性映射
            DateTime dayStart = _chartDatas[0].Time.Date;
            double secondsInDay = 86400.0; // 整天时间秒数

            // 先画所有网格线，再画所有文字，减少状态切换（虽然GDI+状态切换开销不大，但习惯要好）
            float ratio; // 栅格线位置占比
            float x; // 元素x轴坐标
            float y; // 元素y轴坐标
            SizeF labelSize;
            for (int h = 4; h < 24; h += 4)
            { // 绘制网格与 X 轴标签
                ratio = (float)h / 24f; // 当前栅格线位置占比
                x = plot.X + ratio * plot.Width; // 当前栅格线x轴坐标
                g.DrawLine(GridPen, x, plot.Y, x, plot.Bottom); // 绘制网格线

                string label = $"{h}";
                labelSize = g.MeasureString(label, LabelFont); // 计算字符串占用空间大小
                g.DrawString(label, LabelFont, TextBrush, x - labelSize.Width / 2, plot.Bottom + 5); // 绘制标签
            }

            // 右对齐文本，使其紧贴轴线左侧，更美观
            StringFormat sfRight = new StringFormat { Alignment = StringAlignment.Far };
            g.DrawString(vMax.ToString("0.0"), LabelFont, TextBrush, new PointF(plot.X - 5, plot.Y - 2), sfRight); // 最大数据标签
            g.DrawString(((vMin + vMax) / 2).ToString("0.0"), LabelFont, TextBrush, new PointF(plot.X - 5, plot.Y + plot.Height / 2f - 6), sfRight);
            g.DrawString(vMin.ToString("0.0"), LabelFont, TextBrush, new PointF(plot.X - 5, plot.Bottom - 12), sfRight); // 最小数据标签

            // 绘制坐标轴线
            g.DrawLine(AxisPen, plot.X, plot.Y, plot.X, plot.Bottom); // Y轴
            g.DrawLine(AxisPen, plot.X, plot.Bottom, plot.Right, plot.Bottom); // X轴

            // 绘制折线与数据点
            int count = _chartDatas.Count;
            var pts = new PointF[count];

            // 在循环中直接计算坐标，避免多次调用 Func 委托带来的开销
            for (int i = 0; i < count; i++)
            {
                double totalSeconds = (_chartDatas[i].Time - dayStart).TotalSeconds;
                x = plot.X + (float)(totalSeconds / secondsInDay) * plot.Width;
                y = plot.Bottom - ((_chartDatas[i].Value - vMin) / finalRange) * plotHeight;
                pts[i] = new PointF(x, y);
            }

            // 绘制连线
            if (count > 1)
            {
                g.DrawLines(LinePen, pts);
            }
        }
    }
}
