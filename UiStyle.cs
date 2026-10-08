using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多设备管理系统
{
    internal static class UiStyle
    { // 静态类：不用 new，直接 UiStyle.方法() 调用
        public static GraphicsPath CreateRoundRect(Rectangle r, int radius)
        // 私有静态      返回类型      函数名称   圆角矩形总边界   圆角半径
        { // 1. 生成圆角矩形路径（所有圆角逻辑的根源）
            int d = Math.Min(radius * 2, Math.Min(r.Width, r.Height)); // 圆角直径
            var path = new GraphicsPath(); // 创建图形路径对象
            // 左上角X坐标, 左上角Y坐标, 宽度, 高度, 起始角度, 扫过的角度
            path.AddArc(r.X, r.Y, d, d, 180, 90); // 左上
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90); // 右上
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90); // 右下
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90); // 左下
            path.CloseFigure(); // 闭合图形
            return path; // 返回绘制好的路径
        }

        public static void ApplyRoundRegion(Control ctrl, int radius)
        { // 2. 给任意控件加圆角裁剪
            var old = ctrl.Region;
            using (var path = CreateRoundRect(ctrl.ClientRectangle, radius))
                ctrl.Region = new Region(path);
            if (old != null) old.Dispose();
        }

        public static void PaintGlassHighlight(PaintEventArgs e, Control ctrl, int radius)
        { // 顶部高光（模拟磨砂）
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = CreateRoundRect(ctrl.ClientRectangle, radius))
            {
                g.SetClip(path);
                using (var brush = new SolidBrush(Color.FromArgb(50, 255, 255, 255))) // 白色薄雾
                    g.FillPath(brush, path);
                g.ResetClip();
            }
        }

        public static void DrawRoundBorder(PaintEventArgs e, Control ctrl,
                                           int radius, Color color, float width = 1f)
        { // 3. 画圆角描边（在 Paint 事件里调用）
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = CreateRoundRect(ctrl.ClientRectangle, radius))
            using (var pen = new Pen(color, width))
                e.Graphics.DrawPath(pen, path);
        }

        public static void EnableRoundCorners(Control ctrl, int radius,
                                              Color? borderColor = null)
        { // 4. 一键圆角：裁剪 + 描边 + 自动跟随尺寸变化
          // BorderStyle 是具体控件才有的属性，基类 Control 没有，需要先判断类型
            if (ctrl is Panel panel)
                panel.BorderStyle = BorderStyle.None;
            else if (ctrl is UserControl uc)
                uc.BorderStyle = BorderStyle.None;

            ctrl.SizeChanged // 控件尺寸改变事件
                += // 事件订阅操作符,事件发生时,执行后面的逻辑
                (s, ev) => // Lambda 表达式
                {
                    ApplyRoundRegion(ctrl, radius); // 圆角裁剪
                    ctrl.Invalidate();   // ← 新增：强制全量重绘，清掉旧边框残影
                };
                
            
            ctrl.Paint // 窗口内容或大小改变的事件
                += // 事件订阅操作符,事件发生时,执行后面的逻辑
                (s, ev) => // Lambda 表达式
            {
                var c = borderColor ?? Color.FromArgb(150, 128, 128, 128);
                DrawRoundBorder(ev, ctrl, radius, c, 2f);
            };
        }
    }
}
