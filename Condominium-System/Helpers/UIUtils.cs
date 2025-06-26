using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Helpers
{
    public class UIUtils
    {
        public static void RoundPanelCorners(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90); // Top-right
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90); // Bottom-right
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90); // Bottom-left
            path.CloseAllFigures();

            panel.Region = new Region(path);
        }
    }
}
