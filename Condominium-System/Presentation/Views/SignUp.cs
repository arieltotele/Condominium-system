using Condominium_System.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System.Presentation.Views
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            SetComboBoxForTypeOfUsers();
            UIUtils.RoundPanelCorners(SignUpPNLBTNBack, 16);
            UIUtils.RoundPanelCorners(SignUpPNLBTNClean, 16);
            UIUtils.RoundPanelCorners(SignUpPNLBTNSave, 16);
        }

        private void SetComboBoxForTypeOfUsers()
        {
            //TODO: filter the options depending on the type of user who is already logged in.
            string[] opciones = {"Seleccione", "Administrador", "Operario"};
            SignUpComboBxType.Items.AddRange(opciones);
        }

        private void SetComboBoxForCondominiums()
        {
            //TODO: filter the options depending on the type of user who is already logged in.            
        }
        
    }
}
