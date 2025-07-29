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
    public partial class UpsertUserScreen : Form
    {

        public bool IsEditMode { get; set; } = false;
        public UpsertUserScreen()
        {
            InitializeComponent();
        }

        private void UpsertUserScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
