using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    class ToolStripButtonEx:ToolStripButton
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Checked)
                e.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), e.ClipRectangle);
            else
                e.Graphics.FillRectangle(new SolidBrush(SystemColors.Control), e.ClipRectangle);
            base.OnPaint(e);
            
        }
    }
}
