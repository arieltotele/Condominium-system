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
    public partial class UsersScreen : Form
    {
        public UsersScreen()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            var SignUpScreen = new SignUpScreen();
            SignUpScreen.Closed += (s, args) => this.Close();
            SignUpScreen.Show();
        }
    }
}
