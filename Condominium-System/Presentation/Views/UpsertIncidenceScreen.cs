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
    public partial class UpsertIncidenceScreen : Form
    {

        public bool IsEditMode { get; set; } = false;
        public UpsertIncidenceScreen()
        {
            InitializeComponent();
        }

        private void UpsertIncidenceScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
