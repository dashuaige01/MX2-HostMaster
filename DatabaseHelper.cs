using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using ClosedXML.Excel;

namespace 多设备管理系统
{
    internal class DatabaseHelper
    {
        private string dbPath; // 每个实例不同：sensor_data_1.db、sensor_data_2.db...
        private string filePath; // 每个实例不同：SensorData_1.xlsx...
        public string connectionString;

        public DatabaseHelper(int deviceAddr)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory; // @"C:\Users\Administrator\Desktop\手机Linux"; 
            dbPath = Path.Combine(baseDir, $"sensor_data_{deviceAddr}.db");
            filePath = Path.Combine(baseDir, $"SensorData_{deviceAddr}.xlsx");
            connectionString = $"Data Source={dbPath};Version=3;";
            Initialize();
        }

        private void Initialize() // 初始化方法：创建数据库文件和表（程序启动时调用一次）
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"CREATE TABLE IF NOT EXISTS
                        sensor_data (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        record_time TEXT NOT NULL,
                        device_addr INTEGER,
                        temperature REAL,
                        humidity REAL,
                        sensor_t_status TEXT,
                        heater1_status TEXT,
                        heater2_status TEXT )";
                    using (var cmd = new SQLiteCommand(sql, conn)) {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void InsertData(DateTime time, int addr, float temp, float humi,
            string sensorT, string heater1, string heater2) // 插入一条数据，最大10000条
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO
                    sensor_data (record_time, device_addr, temperature, humidity, sensor_t_status, heater1_status, heater2_status)
                    VALUES (@time, @addr, @temp, @humi, @sensorT, @heater1, @heater2)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@time", time.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@addr", addr);
                    cmd.Parameters.AddWithValue("@temp", Convert.ToDouble(temp).ToString("F1"));
                    cmd.Parameters.AddWithValue("@humi", Convert.ToDouble(humi).ToString("F1"));
                    cmd.Parameters.AddWithValue("@sensorT", sensorT);
                    cmd.Parameters.AddWithValue("@heater1", heater1);
                    cmd.Parameters.AddWithValue("@heater2", heater2);
                    cmd.ExecuteNonQuery();
                }
                string deleteSql = @"DELETE FROM
                    sensor_data WHERE id <= 
                    ( SELECT id FROM sensor_data ORDER BY id DESC LIMIT 1 OFFSET 10000 )";
                using (var deleteCmd = new SQLiteCommand(deleteSql, conn))
                    deleteCmd.ExecuteNonQuery();
            }
        }

        public void ReadSQLData(string savePath)
        {
            Int32 lastExportedId = 0;
            string sql;
            if (!string.IsNullOrEmpty(savePath)) // 确保路径不为空
                filePath = savePath; // 用你选的路径覆盖默认路径
            bool fileExists = File.Exists(filePath); // 检查文件是否存在

            if (!fileExists) {
                // 文件不存在：查全部数据，建新文件+写表头
                sql = "SELECT * FROM sensor_data ORDER BY id";
            } else {
                // 文件已存在：只查 lastExportedId 之后的数据，追加到文件末尾
                using (var workbook = new XLWorkbook(filePath)) // excel文件操作对象
                {
                    var ws = workbook.Worksheet(1); // 表操作对象
                    var lastRow = ws.LastRowUsed(); // 获取表最后一行数据
                    if (lastRow != null)
                    {
                        int.TryParse(lastRow.Cell(1).GetString(), out lastExportedId); // lastRow第一个数据赋值给lastExportedId
                    }
                }
                sql = $"SELECT * FROM sensor_data WHERE id > {lastExportedId} ORDER BY id";
            }

            using (var conn = new SQLiteConnection(connectionString)) // 连接数据库
            {
                conn.Open(); // 打开数据库
                using (var cmd = new SQLiteCommand(sql, conn)) // 查询命令对象
                using (var reader = cmd.ExecuteReader()) // 执行查询
                {
                    if (!reader.HasRows) { // 没有可以查询的数据
                        MessageBox.Show("无最新数据！");
                        return; // 没有新数据，直接退出
                    }

                    XLWorkbook workbook;
                    IXLWorksheet ws;
                    int startRow;

                    if (!fileExists) { // 文件不存在
                        workbook = new XLWorkbook(); // 新建文件
                        ws = workbook.Worksheets.Add("传感器数据"); // 添加表并返回表操作对象
                        string[] headers = { "ID", "记录时间", "设备地址", "温度", "湿度", 
                                            "温度传感器状态", "加热器1状态", "加热器2状态" }; // 写表头
                        for (int i = 0; i < headers.Length; i++) // 写入表头数据
                            ws.Cell(1, i + 1).Value = headers[i];
                        ws.Range(1, 1, 1, headers.Length).Style.Font.Bold = true; // 表头数据字体加粗
                        startRow = 2; // 设置数据写入起始行变量为2
                    } else { // 文件存在
                        workbook = new XLWorkbook(filePath); // 加载已有文件
                        ws = workbook.Worksheet(1); // 返回第一个表的操作对象
                        startRow = ws.LastRowUsed().RowNumber() + 1; // 找到最后一行，从下一行开始追加
                    }

                    // 追加新数据
                    while (reader.Read()) {
                        ws.Cell(startRow, 1).Value = reader["id"].ToString();
                        ws.Cell(startRow, 2).Value = reader["record_time"].ToString();
                        ws.Cell(startRow, 3).Value = reader["device_addr"].ToString();
                        ws.Cell(startRow, 4).Value = Convert.ToDouble(reader["temperature"]).ToString("F1");
                        ws.Cell(startRow, 5).Value = Convert.ToDouble(reader["humidity"]).ToString("F1");
                        ws.Cell(startRow, 6).Value = reader["sensor_t_status"].ToString();
                        ws.Cell(startRow, 7).Value = reader["heater1_status"].ToString();
                        ws.Cell(startRow, 8).Value = reader["heater2_status"].ToString();
                        startRow++;
                    }

                    ws.Columns().AdjustToContents(); // 自动列宽

                    try {
                        workbook.SaveAs(filePath);
                        MessageBox.Show("导出成功！");
                    } catch (Exception ex) {
                        MessageBox.Show("导出失败：" + ex.Message);
                    }
                }
            }
        }

        public void CleanOldData() // 清除数据库数据
        {
            using (var conn = new SQLiteConnection(connectionString)) {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn)) {
                    cmd.CommandText = "DELETE FROM sensor_data";
                    int rowsAffected = cmd.ExecuteNonQuery();

                    cmd.CommandText = "DELETE FROM sqlite_sequence WHERE name='sensor_data'";
                    cmd.ExecuteNonQuery();

                    System.Diagnostics.Debug.WriteLine($"数据清理完毕，本次删除了 {rowsAffected} 条旧数据");
                }
            }
        }
    }
}
