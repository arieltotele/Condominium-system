using Condominium_System.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System.Presentation.Views
{
    public partial class CondominuiumScreen : Form
    {
        public CondominuiumScreen()
        {
            InitializeComponent();
        }

        private void CondominuiumScreen_Load(object sender, EventArgs e)
        {
            UIUtils.RoundPanelCorners(CondominiumPNLBTNCreate, 10);
            UIUtils.RoundPanelCorners(CondominiumPNLBTNSearch, 10);
            UIUtils.RoundPanelCorners(CondominiumPNLBTNUpdate, 10);
            UIUtils.RoundPanelCorners(CondominiumPNLBTNDelete, 10);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
