using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace 多设备管理系统
{
    // 能自己画出"窗体背景图对应部分"的滚动面板：
    // 滚动露出的区域由它自己独立重画（杜绝残影），
    // 画的内容与窗体那张图1:1对位（无缝衔接）
    internal class PhotoFlowPanel : FlowLayoutPanel
    {
        protected override void OnScroll(ScrollEventArgs se) // 滑块滑动触发的事件
        {
            base.OnScroll(se); // 执行默认的滑块滑动逻辑
            Invalidate(); // 每次滚动整板重绘，双保险
        }

        protected override void OnMouseWheel(MouseEventArgs e) // 鼠标滚轮滚动触发的事件
        {
            base.OnMouseWheel(e); // 执行默认的滚轮滚动逻辑
            Invalidate(); // 补重绘（滚轮不会触发 Scroll 事件，必须自己补这一刀）
        }

        protected override void OnPaintBackground(PaintEventArgs e) // 控件背景需要重新绘制时发生
        {
            Form f = FindForm(); // 控件所在窗体对象
            Image img = f?.BackgroundImage; // 控件所在窗体对象背景图片
            if (img == null) // 控件所在窗体对象背景图片不存在
            {
                base.OnPaintBackground(e);   // 没图就退回默认画法
                return;
            }

            // 算出本控件在窗体客户区中的绝对位置
            Point offset = new Point(0, 0);
            Control c = this;
            while (c != null && c != f)
            {
                offset.X += c.Left;
                offset.Y += c.Top;
                c = c.Parent;
            }

            // 把窗体那张图按窗体尺寸1:1画到对应位置（不随滚动移动）
            e.Graphics.DrawImage(img,
                    new Rectangle(-offset.X, -offset.Y, // 取负：左上对位，与窗体图无缝衔接
                    f.ClientSize.Width, f.ClientSize.Height)); // 把背景图片放到当前控件显示，按控件在窗体的位置来显示上
        }

        protected override void OnPaint(PaintEventArgs e) // 控件需要重新绘制时发生
        {
            base.OnPaint(e);

            // 圆角描边：画在自己的背景图之上；
            // 形状由 pnlDeviceFrame 的圆角 Region 裁剪而成
            UiStyle.DrawRoundBorder(e, this, 10, Color.FromArgb(80, 80, 80), 2f);
        }
    }
}
