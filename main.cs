using DocumentFormat.OpenXml.Drawing.Charts;
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
        private int ScanIndex = 1; // 最后一个子设备地址索引
        private readonly object _serialLock = new object(); // 防止获取设备数据和找设备的定时器冲突的锁
        public main()
        {
            InitializeComponent(); // 初始化组件窗口
        }

        private void main_Load(object sender, EventArgs e)
        {
            get_Serial_port(); // 获取串口信息
            if (cmbSerialPort.Items.Count > 1) // 串口数组数量大于1
                cmbSerialPort.Text = cmbSerialPort.Items[1].ToString(); // 显示第2个串口信息
            else if (cmbSerialPort.Items.Count > 0) // 串口数组数量大于0
                cmbSerialPort.Text = cmbSerialPort.Items[0].ToString(); // 显示第1个串口信息

            flpDevice.Controls.Clear(); // 清除设计器里残留的旧面板
            UiStyle.EnableRoundCorners(flpDevice, 10, Color.FromArgb(80, 80, 80)); // 圆角描边
            UiStyle.EnableRoundCorners(pnlDeviceControl, 10, Color.FromArgb(80, 80, 80)); // 圆角描边
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

        private void btnConnect_Click(object sender, EventArgs e) // 连接按钮回调函数
        {
            try {
                if (btnStart.Text == "连接") 
                { // 当前为打开操作
                    serialPort1.PortName = cmbSerialPort.Text; // 获取要打开的串口号
                    serialPort1.BaudRate = int.Parse(cmbBaudRate.Text); // 获取用户选择的波特率值
                    serialPort1.DataBits = int.Parse(cmbDataBits.Text); // 数据位

                    if (cmbStopBits.Text == "1") { // 停止位长度
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
                    btnStart.Text = "断开"; // 切换按钮文字
                    btnStart.BackColor = Color.DodgerBlue; // 按钮变红色表示串口已打开
                    cmbSerialPort.Enabled = false; // 禁用串口号下拉框
                    cmbBaudRate.Enabled = false; // 禁用波特率下拉框
                    cmbDataBits.Enabled = false; // 禁用数据位下拉框
                    cmbStopBits.Enabled = false; // 禁用停止位下拉框
                    cmbParity.Enabled = false; // 禁用校验位下拉框
                } 
                else if (btnStart.Text == "断开") 
                { // 当前为关闭操作
                    btnStart.Text = "连接"; // 切换按钮文字
                    btnStart.BackColor = Color.Empty; // 恢复按钮默认颜色
                    cmbSerialPort.Enabled = true; // 启用串口号下拉框
                    cmbBaudRate.Enabled = true; // 启用波特率下拉框
                    cmbDataBits.Enabled = true; // 启用数据位下拉框
                    cmbStopBits.Enabled = true; // 启用停止位下拉框
                    cmbParity.Enabled = true; // 启用校验位下拉框
                    timScan.Stop(); // 关闭需要从机设备的定时器
                    lock (_serialLock)
                    { // 等正在收发的操作做完
                        serialPort1.Close();
                    }
                }
            } catch (Exception err) { // 捕获打开/关闭串口时的异常
                MessageBox.Show("打开失败" + err.ToString(), "提示！"); // 弹出错误提示
            }

            Device_Scan();
            timScan.Start(); // 开启需要从机设备的定时器
        }

        private async void timSerialPort_Tick(object sender, EventArgs e)
        {
            get_Serial_port(); // 获取电脑当前可用串口列表
        }

        private async void timAutoSend_Tick(object sender, EventArgs e) // 异步后台执行wait代码
        {
            if (!serialPort1.IsOpen || devices.Count == 0) // 串口关闭且有设备存在
                return;

            ((System.Windows.Forms.Timer)sender).Stop(); // 暂停该定时器计数，防止重复进入

            byte[] dataSend = { 0x01, 0x03, 0x00, 0x01, 0x00, 0x04, 0x04, 0x08 }; // 上位机获取数据帧

            var snapshot = devices.ToList(); // 把字典数据改成链表
            foreach (var kvp in snapshot) { // 遍历链表
                int addr = kvp.Key; // 获取键值
                DevicePanel panel = kvp.Value; // 获取数据结构体

                dataSend[0] = (byte)addr; // 改从机地址

                byte[] crc = CRC16_MODBUS(dataSend, dataSend.Length - 2); // 获取CRC
                dataSend[dataSend.Length - 2] = crc[0]; // 改CRC校验位
                dataSend[dataSend.Length - 1] = crc[1];

                byte[] buff = await Task.Run(() => SendAndReceive(dataSend)); // 后台收发

                if (buff != null && buff[0] == (byte)addr) {
                    byte[] checkCrc = CRC16_MODBUS(buff, buff.Length - 2);
                    if (checkCrc[0] == buff[buff.Length - 2] && checkCrc[1] == buff[buff.Length - 1]) { // 检验位正确
                        panel.UpdateData(buff); // 回到UI线程，直接改界面
                        panel.DeviceOnline(true); // 子设备存在
                    }
                } else {
                    panel.DeviceOnline(false); // 子设备不存在
                }

                await Task.Delay(50); // 非阻塞等待，替代 Thread.Sleep
            }

            ((System.Windows.Forms.Timer)sender).Start(); // 开启该计时器计数
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
            if (!serialPort1.IsOpen) // 确保串口是打开的
                return;

            ((System.Windows.Forms.Timer)sender).Stop(); // 暂停定时器计时，防止重复进入

            try 
            {
                byte[] dataSend = { 0x01, 0x03, 0x00, 0x01, 0x00, 0x01, 0x04, 0x08 }; // 数据帧
                byte[] crc = CRC16_MODBUS(dataSend, dataSend.Length - 2); // CRC校验计算
                dataSend[dataSend.Length - 2] = crc[0]; // 改数据帧校验位
                dataSend[dataSend.Length - 1] = crc[1];

                byte[] buff = await Task.Run(() => SendAndReceive(dataSend)); // 后台收发
                if (buff == null || buff.Length < 4)
                    return;
                crc = CRC16_MODBUS(buff, buff.Length - 2);
                if (buff[0] != 0x01 || crc[0] != buff[buff.Length - 2] || crc[1] != buff[buff.Length - 1]) // 没发现新设备的正常情况
                    return;

                _lastScanIndex++; // 分配新从机地址
                while (devices.ContainsKey(_lastScanIndex))
                { // 找最小的没有分配的地址
                    _lastScanIndex++;
                }
                byte[] dataChange = { 0x01, 0x06, 0x00, 0x08, 0x02, 0x84, 0x0A }; // 修改串口地址数据帧
                dataChange[4] = (byte)_lastScanIndex; // 改从机设备地址
                crc = CRC16_MODBUS(dataChange, dataChange.Length - 2); // CRC校验计算
                dataChange[dataChange.Length - 2] = crc[0]; // 改数据帧校验位
                dataChange[dataChange.Length - 1] = crc[1];
                byte[] buffChange = await Task.Run(() => SendAndReceive(dataChange)); // 后台收发
                if (buffChange == null || buffChange.Length < 4)
                    return;
                crc = CRC16_MODBUS(buffChange, buffChange.Length - 2);
                if (buff[0] != 0x01 || crc[0] != buffChange[buffChange.Length - 2] || crc[1] != buffChange[buffChange.Length - 1]) // 没发现新设备的正常情况
                    return;
                AddDevicePanel(_lastScanIndex); // 增加新的子设备窗口
            } 
            finally 
            {
                ((System.Windows.Forms.Timer)sender).Start(); // 无论成功失败都重启扫描
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen) 
            { // 1. 检查串口是否打开
                MessageBox.Show("请先打开串口！");
                return;
            }

            byte Index = (byte)nUDAddDevice.Value; // 转换数据
            if (!devices.ContainsKey(Index)) 
            { // 没有这个字典键值
                bool received = false;
                lock (_serialLock) 
                { // 串口锁，防止多任务访问同一串口发生冲突
                    byte[] dataSend = { Index, 0x03, 0x00, 0x01, 0x00, 0x01, 0x84, 0x0A }; // 修改串口地址数据帧
                    byte[] crc = CRC16_MODBUS(dataSend, dataSend.Length - 2); // CRC校验计算
                    dataSend[dataSend.Length - 2] = crc[0]; // 改数据帧校验位
                    dataSend[dataSend.Length - 1] = crc[1];
                    _dataReceivedEvent.Reset(); // 发送前重置信号
                    serialPort1.DiscardInBuffer(); // 清除串口缓冲区数据
                    serialPort1.Write(dataSend, 0, dataSend.Length); // 发送数据
                    received = _dataReceivedEvent.WaitOne(200);
                }
                if (received) 
                { // 子设备存在且更改成功
                    AddDevicePanel(Index); // 按序增加子设备窗口
                }
            }
        }

        public byte[] SendAndReceive(byte[] data) // 发送数据帧并返回接受数据帧
        {
            if (!serialPort1.IsOpen) 
            { // 1. 检查串口是否打开 
                return null;
            }

            lock (_serialLock) { // 锁只在 main.cs 内部，外部碰不到 
                _dataReceivedEvent.Reset(); // 复位串口信号量 
                serialPort1.DiscardInBuffer(); // 清空串口数据缓存 
                serialPort1.Write(data, 0, data.Length); // 发送串口数据帧 
                if (_dataReceivedEvent.WaitOne(200)) 
                { // 等待接收到数据的信号量
                    int len = serialPort1.BytesToRead; // 获取接收到的数据帧长度 
                    byte[] buff = new byte[len]; // 分配数据数组地址 
                    serialPort1.Read(buff, 0, len); // 获取数据帧 
                    return buff; // 返回数据帧 
                }
                return null;
            }
        }

        private void ChangeAutoSendTime(object sender, EventArgs e) // 改变自动发送定时器时间长度
        {
            timAutoSend.Interval = (int)nUDReadInterval.Value;
        }

        public void RemoveDevice(int addr)
        {
            if (devices.TryGetValue(addr, out DevicePanel panel)) 
            {
                devices.Remove(addr); // 删除字典中设备数据
                flpDevice.Controls.Remove(panel); // 删除控件中窗口
                panel.Dispose(); // 释放控件资源
                _lastScanIndex--;
            }
        }

        private void AddDevicePanel(int addr) // 按序增加子设备窗口
        {
            DevicePanel panel = new DevicePanel(addr, SendAndReceive, RemoveDevice); // 创建新的子设备窗口
            devices[addr] = panel; // 把新的子设备窗口加入字典
            flpDevice.Controls.Add(panel); // 把新的子设备窗口显示在flpDevice

            // 计算插入位置：地址比它小的面板数量
            int insertIndex = 0;
            foreach (Control c in flpDevice.Controls) 
            { // 遍历flpDevice的子设备窗口
                if (c == panel) continue; // 如果只有这一个子设备窗口就直接跳过
                if (((DevicePanel)c).DeviceAddress > addr) // 如果子设备窗口地址索引大于该地址
                    break;
                insertIndex++; // 插入位置++
            }
            flpDevice.Controls.SetChildIndex(panel, insertIndex); // 挪到该位置
        }

        private async void Device_Scan()
        {
            byte[] dataSend = { 0x01, 0x03, 0x00, 0x01, 0x00, 0x01, 0x04, 0x08 }; // 数据帧
            for (ScanIndex = 2; ScanIndex < 255; ScanIndex++)
            {
                if (devices.ContainsKey(ScanIndex))
                { // 找最小的没有分配的地址
                    continue;
                }
                dataSend[0] = (byte)ScanIndex;
                byte[] crc = CRC16_MODBUS(dataSend, dataSend.Length - 2); // CRC校验计算
                dataSend[dataSend.Length - 2] = crc[0]; // 改数据帧校验位
                dataSend[dataSend.Length - 1] = crc[1];

                if (!serialPort1.IsOpen)
                { // 1. 检查串口是否打开
                    return;
                }
                byte[] buff = await Task.Run(() =>SendAndReceive(dataSend)); // 后台收发
                if (buff == null || buff.Length < 4)
                    continue;
                crc = CRC16_MODBUS(buff, buff.Length - 2);
                if (buff[0] != ScanIndex || crc[0] != buff[buff.Length - 2] || crc[1] != buff[buff.Length - 1]) // 没发现新设备的正常情况
                    continue;
                AddDevicePanel(ScanIndex); // 增加新的子设备窗口
                await Task.Delay(50); // 非阻塞等待，替代 Thread.Sleep
            }
        }
    }
}
