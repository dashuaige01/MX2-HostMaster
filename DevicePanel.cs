using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多设备管理系统
{
    // === 属性 ===
    public partial class DevicePanel : UserControl
    {
        public int DeviceAddress { get; private set; }
        private readonly Func<byte[], byte[]> _sendFunc;
        private DatabaseHelper _db;   // 每个面板自己的数据库

        public DevicePanel(int address, Func<byte[], byte[]> sendFunc)
        {
            _sendFunc = sendFunc;
            DeviceAddress = address;
            _db = new DatabaseHelper(address); // 创建独立的数据库文件
            InitializeComponent();
            lbDevice.Text = address.ToString(); // 设备编号
            nUDAddress.Value = address; // 从机地址默认值
        }

        public void UpdateData(byte[] buff)
        {
            if (buff == null || buff.Length < 13) return;

            float temperature = BitConverter.ToSingle(buff, 3);
            float humidity = BitConverter.ToSingle(buff, 7);
            temperature = float.Parse(temperature.ToString("0.0"));
            humidity = float.Parse(humidity.ToString("0.0"));

            lbTempeValue.Text = temperature + " ℃";
            lbHumiValue.Text = humidity + " %";

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
            // 顺便存到自己的数据库
            _db.InsertData(DateTime.Now, DeviceAddress, temperature, humidity,
            lbSensorStatus_T.Text, lbHeaterlStatus.Text, lbHeaterhStatus.Text);
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
            _db.ReadSQLData();
        }

        private void btnTimeCheck_Click(object sender, EventArgs e)
        {
            try {
                Task.Run(() => { // 5. 启动后台任务（不阻塞 UI）
                    DateTime now = DateTime.Now;
                    byte[] dataSend = { 0x01, 0x06, 0x00, 0x0A,
                        (byte)(now.Year & 0xFF),//年低位
                        (byte)((now.Year >> 8) & 0xFF),//年高位
                        (byte)now.Month,//月
                        (byte)now.Day,//日
                        (byte)now.Hour,//时
                        (byte)now.Minute,//分
                        (byte)now.Second,//秒
                        0x84, 0x0A };
                    dataSend[0] = (byte)DeviceAddress;// 构造数据包
                    byte[] crc = main.CRC16_MODBUS(dataSend, dataSend.Length - 2);// 预计算 CRC (因为数据部分不变，CRC 其实也是固定的，但为了完整保留你逻辑)
                    dataSend[dataSend.Length - 2] = crc[0];
                    dataSend[dataSend.Length - 1] = crc[1];

                    byte[] buff = _sendFunc(dataSend); // 发送数据
                    if (buff == null || buff.Length < 4) {
                        MessageBox.Show("对时失败：设备无响应");
                        return;
                    } else if (buff.Length > 0 && (buff[1] & 0x80) != 0x80) {
                        this.Invoke(new Action(() => { //UI 线程更新界面
                            crc = main.CRC16_MODBUS(buff, buff.Length - 2);
                            if (crc[0] == buff[buff.Length - 2] && crc[1] == buff[buff.Length - 1]) {
                                MessageBox.Show("对时成功");
                            } else {
                                MessageBox.Show("对时失败：校验码有误");
                            }
                        }));
                    }
                }); // 传入 token
            } catch (Exception ex) {
                MessageBox.Show("对时错误：" + ex);
            }
        }

        private void btnConfigPara_Click(object sender, EventArgs e)
        {
            try {
                Task.Run(() => { // 5. 启动后台任务（不阻塞 UI）
                    byte[] dataSend = { 0x01, 0x10, 0x00, 0x05, 0x00, 0x07, 0x0E,
                        0x4B, 0x0A, 0x01, 0x02, 0x03,
                        0xEA, 0x07, 0x04, 0x15, 0x0D, 0x06, 0x01,
                        0xF4, 0x01,
                        0x93, 0x53 };
                    DateTime now = DateTime.Now;
                    dataSend[0] = (byte)nUDAddress.Value; // 构造数据包
                    dataSend[9] = (byte)nUDTempLimit.Value; // 温度阈值
                    dataSend[7] = (byte)nUDHumiHigh.Value; // 湿度上限值
                    dataSend[8] = (byte)nUDHumiLow.Value; // 湿度下限值
                    dataSend[10] = (byte)nUDAddress.Value; // 地址值
                    dataSend[11] = (byte)nUDBaudRate.Value; // 波特率
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
                    if (buff == null || buff.Length < 4) {
                        MessageBox.Show("参数修改失败：设备无响应");
                        return;
                    } else if ((buff.Length > 0) && ((buff[1] & 0x80) != 0x80)) {
                        this.Invoke(new Action(() => { // UI 线程更新界面
                            crc = main.CRC16_MODBUS(buff, buff.Length - 2);
                            if (crc[0] == buff[buff.Length - 2] && crc[1] == buff[buff.Length - 1]) {
                                MessageBox.Show("参数修改成功");
                            } else {
                                MessageBox.Show("参数修改失败：校验码有误");
                            }
                        }));
                    }
                }); // 传入 token
            } catch (Exception ex) {
                MessageBox.Show("参数配置错误：" + ex);
            }
        }
    }
}
