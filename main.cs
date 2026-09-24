using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多设备管理系统
{
    public partial class main : Form
    {
        private ManualResetEvent _dataReceivedEvent = new ManualResetEvent(false); // 485数据传递给显示串口的信号量
        private Dictionary<int, DevicePanel> devices = new Dictionary<int, DevicePanel>(); // 存放个子设备显示串口的字典
        private int _lastScanIndex = 1; // 最后一个子设备地址索引
        private readonly object _serialLock = new object(); // 防止获取设备数据和找设备的定时器冲突的锁
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            get_Serial_port();
            cmbSerialPort.Text = cmbSerialPort.Items[0].ToString();

            flpDevice.Controls.Clear(); // 清除设计器里残留的旧面板
        }

        private void get_Serial_port() // 获取电脑当前可用串口并更新下拉列表
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames(); // 获得当前系统可用的串口名称数组
            bool changed = false; // 标记串口列表是否发生变化

            foreach (string port in ports) { // 遍历所有可用串口，添加新出现的串口
                if (!cmbSerialPort.Items.Contains(port)) { // 如果下拉框中不存在该串口
                    cmbSerialPort.Items.Add(port); // 添加到下拉框
                    changed = true; // 标记已变化
                }
            }

            for (int i = cmbSerialPort.Items.Count - 1; i >= 0; i--) { // 倒序遍历，移除已不存在的串口
                if (!ports.Contains(cmbSerialPort.Items[i].ToString())) { // 如果下拉框中的串口已不可用
                    cmbSerialPort.Items.RemoveAt(i); // 从下拉框中移除
                    changed = true; // 标记已变化
                }
            }

            if (changed && cmbSerialPort.SelectedItem != null 
                && !ports.Contains(cmbSerialPort.SelectedItem.ToString())) { // 如果当前选中的串口已不可用
                cmbSerialPort.SelectedIndex = -1; // 取消选中
            }
        }

        private bool ChangeAddr(Int16 addr)
        {
            bool received = false;
            lock (_serialLock) {
                byte[] dataSend = { 0x01, 0x06, 0x00, 0x08, 0x02, 0x84, 0x0A };
                dataSend[4] = (byte)addr;
                byte[] crc = CRC16_MODBUS(dataSend, dataSend.Length - 2);
                dataSend[dataSend.Length - 2] = crc[0];
                dataSend[dataSend.Length - 1] = crc[1]; 
                _dataReceivedEvent.Reset(); // 发送前重置信号
                serialPort1.DiscardInBuffer();
                serialPort1.Write(dataSend, 0, dataSend.Length); // 发送数据
                received = _dataReceivedEvent.WaitOne(500); // 等待接收事件发出信号(最多等待 500ms)
            }
            if (received) // 检查串口是否收到了数据
                return true;
            else 
                return false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try {
                if (btnStart.Text == "连接") { // 当前为打开操作
                    serialPort1.PortName = cmbSerialPort.Text; // 获取要打开的串口号
                    serialPort1.BaudRate = int.Parse(cmbBaudRate.Text); // 获取用户选择的波特率值
                    serialPort1.DataBits = int.Parse(cmbDataBits.Text); // 应用数据位
                    if (cmbStopBits.Text == "1") { // 应用停止位
                        serialPort1.StopBits = System.IO.Ports.StopBits.One;
                    } else if (cmbStopBits.Text == "1.5") {
                        serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                    } else if (cmbStopBits.Text == "2") {
                        serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                    }

                    if (cmbParity.Text == "无") { // 校验位
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                    } else if (cmbParity.Text == "奇校验") {
                        serialPort1.Parity = System.IO.Ports.Parity.Odd;
                    } else if (cmbParity.Text == "偶校验") {
                        serialPort1.Parity = System.IO.Ports.Parity.Even;
                    }

                    serialPort1.Open(); // 打开串口
                } else if (btnStart.Text == "断开") { // 当前为关闭操作
                    serialPort1.Close(); // 关闭串口
                }

                if (serialPort1.IsOpen) {
                    btnStart.Text = "断开"; // 切换按钮文字
                    btnStart.BackColor = Color.DodgerBlue; // 按钮变红色表示串口已打开
                    cmbSerialPort.Enabled = false; // 禁用串口号下拉框
                    cmbBaudRate.Enabled = false; // 禁用波特率下拉框
                    cmbDataBits.Enabled = false; // 禁用数据位下拉框
                    cmbStopBits.Enabled = false; // 禁用停止位下拉框
                    cmbParity.Enabled = false; // 禁用校验位下拉框
                    timScan.Start();
                } else {
                    btnStart.Text = "连接"; // 切换按钮文字
                    btnStart.BackColor = Color.Empty; // 恢复按钮默认颜色
                    cmbSerialPort.Enabled = true; // 启用串口号下拉框
                    cmbBaudRate.Enabled = true; // 启用波特率下拉框
                    cmbDataBits.Enabled = true; // 启用数据位下拉框
                    cmbStopBits.Enabled = true; // 启用停止位下拉框
                    cmbParity.Enabled = true; // 启用校验位下拉框
                    timScan.Stop();
                }
            } catch (Exception err) { // 捕获打开/关闭串口时的异常
                MessageBox.Show("打开失败" + err.ToString(), "提示！"); // 弹出错误提示
            }
        }

        private void timSerialPort_Tick(object sender, EventArgs e)
        {
            get_Serial_port(); // 获取电脑当前可用串口列表
        }

        private async void timAutoSend_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen || devices.Count == 0) 
                return;

            ((System.Windows.Forms.Timer)sender).Stop(); // 防止重复进入

            var snapshot = devices.ToList();
            foreach (var kvp in snapshot) {
                int addr = kvp.Key;
                DevicePanel panel = kvp.Value;

                byte[] dataSend = { 0x01, 0x03, 0x00, 0x01, 0x00, 0x04, 0x04, 0x08 };
                dataSend[0] = (byte)addr;

                byte[] crc = CRC16_MODBUS(dataSend, dataSend.Length - 2);
                dataSend[dataSend.Length - 2] = crc[0];
                dataSend[dataSend.Length - 1] = crc[1];

                byte[] buff = await Task.Run(() => SendAndReceive(dataSend)); // 后台收发

                if (buff != null && buff[0] == (byte)addr) {
                    byte[] checkCrc = CRC16_MODBUS(buff, buff.Length - 2);
                    if (checkCrc[0] == buff[buff.Length - 2] && checkCrc[1] == buff[buff.Length - 1]) {
                        panel.UpdateData(buff); // 回到UI线程，直接改界面
                        panel.DeviceOnline(true);
                    }
                } else {
                    panel.DeviceOnline(false);
                }

                await Task.Delay(50); // 非阻塞等待，替代 Thread.Sleep
            }

            ((System.Windows.Forms.Timer)sender).Start();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _dataReceivedEvent.Set(); // 发出信号，通知扫描任务
        }

        public static byte[] CRC16_MODBUS(byte[] data, int length) // CRC-16校验计算，data为数据数组，length为参与计算的长度
        {
            ushort crc = 0xFFFF; // 初始值为0xFFFF
            for (int i = 0; i < length; i++) { // 遍历指定长度的数据 
                crc ^= data[i]; // 与当前字节异或
                for (int j = 0; j < 8; j++) { // 处理8位
                    if ((crc & 0x0001) != 0) { // 如果最低位为1
                        crc >>= 1; // 右移一位
                        crc ^= 0xA001; // 异或多项式0xA001
                    } else {
                        crc >>= 1; // 仅右移一位
                    }
                }
            }
            return new byte[] { (byte)(crc & 0xFF), (byte)(crc >> 8) }; // 返回低位在前、高位在后的CRC值
        }

        private async void timScan_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
                return;

            ((System.Windows.Forms.Timer)sender).Stop(); // 防止重复进入

            try {
                byte[] dataSend = { 0x01, 0x03, 0x00, 0x01, 0x00, 0x04, 0x04, 0x08 };

                byte[] buff = await Task.Run(() => SendAndReceive(dataSend)); // 后台收发

                if (buff == null || buff.Length < 4)   // null 检查（没发现新设备的正常情况）
                    return;

                byte[] crc = CRC16_MODBUS(buff, buff.Length - 2);
                if (crc[0] != buff[buff.Length - 2] || crc[1] != buff[buff.Length - 1])
                    return;

                _lastScanIndex++;
                if (!ChangeAddr((Int16)_lastScanIndex)) {
                    _lastScanIndex--;
                    return;
                }

                DevicePanel panel = new DevicePanel(_lastScanIndex, SendAndReceive);
                devices[_lastScanIndex] = panel;
                flpDevice.Controls.Add(panel);
            } finally {
                ((System.Windows.Forms.Timer)sender).Start();  // 无论成功失败都重启扫描
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            int Index = (int)nUDAddDevice.Value;
            if (!devices.ContainsKey(Index)) {
                if (_lastScanIndex < Index)
                    _lastScanIndex = Index;
                DevicePanel panel = new DevicePanel(_lastScanIndex, SendAndReceive);
                devices[Index] = panel;
                flpDevice.Controls.Add(panel);
            }
        }

        public byte[] SendAndReceive(byte[] data)
        {
            if (!serialPort1.IsOpen) { // 1. 检查串口是否打开
                //MessageBox.Show("请先打开串口！");
                return null;
            }

            lock (_serialLock) { // 锁只在 main.cs 内部，外部碰不到
                _dataReceivedEvent.Reset();
                serialPort1.DiscardInBuffer();
                serialPort1.Write(data, 0, data.Length);
                if (_dataReceivedEvent.WaitOne(500)) {
                    int len = serialPort1.BytesToRead;
                    byte[] buff = new byte[len];
                    serialPort1.Read(buff, 0, len);
                    return buff;
                }
                return null;
            }
        }

        private void ChangeAutoSendTime(object sender, EventArgs e)
        {
            timAutoSend.Interval = (int)nUDReadInterval.Value;
        }
    }
}
