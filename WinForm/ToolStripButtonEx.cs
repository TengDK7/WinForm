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
        private Brush highlight = new SolidBrush(Color.GreenYellow);
        private Brush normal = new SolidBrush(SystemColors.Control);
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.Checked)
                e.Graphics.FillRectangle(highlight, e.ClipRectangle);
            else
                e.Graphics.FillRectangle(normal, e.ClipRectangle);
            base.OnPaint(e);
            
        }
    }
}
