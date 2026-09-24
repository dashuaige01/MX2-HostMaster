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
        public Int32 lastExportedId = 0;

        public DatabaseHelper(int deviceAddr)
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            dbPath = Path.Combine(baseDir, $"sensor_data_{deviceAddr}.db");
            filePath = Path.Combine(baseDir, $"SensorData_{deviceAddr}.xlsx");
            connectionString = $"Data Source={dbPath};Version=3;";
            Initialize();
        }

        // 2. 初始化方法：创建数据库文件和表（程序启动时调用一次）
        private void Initialize()
        {
            //if (!Directory.Exists(saveDir))
            //    Directory.CreateDirectory(saveDir);
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
                        heater2_status TEXT
                )";
                    using (var cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            //// 获取数据库中最新数据索引
            //Int32 dbMaxId = 0;
            //using (var conn = new SQLiteConnection(connectionString))
            //{
            //    conn.Open();
            //    using (var cmd = new SQLiteCommand("SELECT COALESCE(MAX(id), 0) FROM sensor_data", conn))
            //    {
            //        dbMaxId = Convert.ToInt32(cmd.ExecuteScalar());
            //    }
            //}
            // 如果xlsx文件已存在，读取文件中最后一行的id
            int fileMaxId = 0;
            if (File.Exists(filePath))
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var ws = workbook.Worksheet(1);
                    var lastRow = ws.LastRowUsed();
                    if (lastRow != null)
                    {
                        int.TryParse(lastRow.Cell(1).GetString(), out fileMaxId);
                    }
                }
            }
            lastExportedId = fileMaxId; // Math.Max(dbMaxId, fileMaxId);
        }

        // 插入一条数据，最大10000条
        public void InsertData(DateTime time, int addr, float temp, float humi,
            string sensorT, string heater1, string heater2)
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

        public void ReadSQLData()
        {
            string sql;
            bool fileExists = File.Exists(filePath);

            if (!fileExists)
            {
                // 文件不存在：查全部数据，建新文件+写表头
                sql = "SELECT * FROM sensor_data ORDER BY id";
            }
            else
            {
                // 文件已存在：只查 lastExportedId 之后的数据，追加到文件末尾
                sql = $"SELECT * FROM sensor_data WHERE id > {lastExportedId} ORDER BY id";
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("无最新数据！");
                        return; // 没有新数据，直接退出
                    }

                    XLWorkbook workbook;
                    IXLWorksheet ws;
                    int startRow;

                    if (!fileExists)
                    {
                        // 新建文件
                        workbook = new XLWorkbook();
                        ws = workbook.Worksheets.Add("传感器数据");
                        // 写表头
                        string[] headers = { "ID", "记录时间", "设备地址", "温度", "湿度", "温度传感器状态", "加热器1状态", "加热器2状态" };
                        for (int i = 0; i < headers.Length; i++)
                            ws.Cell(1, i + 1).Value = headers[i];
                        ws.Range(1, 1, 1, headers.Length).Style.Font.Bold = true;
                        startRow = 2;
                    }
                    else
                    {
                        // 加载已有文件
                        workbook = new XLWorkbook(filePath);
                        ws = workbook.Worksheet(1);
                        // 找到最后一行，从下一行开始追加
                        startRow = ws.LastRowUsed().RowNumber() + 1;
                    }

                    // 追加新数据
                    int row = startRow;
                    while (reader.Read())
                    {
                        ws.Cell(row, 1).Value = reader["id"].ToString();
                        ws.Cell(row, 2).Value = reader["record_time"].ToString();
                        ws.Cell(row, 3).Value = reader["device_addr"].ToString();
                        ws.Cell(row, 4).Value = Convert.ToDouble(reader["temperature"]).ToString("F1");
                        ws.Cell(row, 5).Value = Convert.ToDouble(reader["humidity"]).ToString("F1");
                        ws.Cell(row, 6).Value = reader["sensor_t_status"].ToString();
                        ws.Cell(row, 7).Value = reader["heater1_status"].ToString();
                        ws.Cell(row, 8).Value = reader["heater2_status"].ToString();
                        row++;
                    }

                    // 更新 lastExportedId 为当前导出的最大id
                    lastExportedId = (Int32)row - 1;
                    ws.Columns().AdjustToContents(); // 自动列宽

                    try
                    {
                        workbook.SaveAs(filePath);
                        MessageBox.Show("导出成功！");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出失败：" + ex.Message);
                    }
                }
            }
        }

        // 清除数据库数据
        public void CleanOldData()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(conn))
                {
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
