using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
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
    public partial class SignUpScreen : Form
    {
        private readonly IUserService _userService;
        User currentUser;

        public SignUpScreen(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            currentUser = Session.CurrentUser;
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
            SignUpComboBxType.Items.Add("-- Seleccione un tipo de usuario --");
            SignUpComboBxType.Items.Add("Administrador");
            SignUpComboBxType.Items.Add("Operario");

            SignUpComboBxType.SelectedIndex = 0;
        }

        private void SetComboBoxForCondominiums()
        {
            //TODO: filter the options depending on the type of user who is already logged in.            
        }

        private void SignUpTxtBxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 'á' && e.KeyChar != 'é' && e.KeyChar != 'í'
                && e.KeyChar != 'ó' && e.KeyChar != 'ú' && e.KeyChar != 'ñ' && e.KeyChar != 'Á' && e.KeyChar != 'É'
                && e.KeyChar != 'Í' && e.KeyChar != 'Ó' && e.KeyChar != 'Ú' && e.KeyChar != 'Ñ')
            {
                e.Handled = true;
            }
        }

        private void SignUpTxtBxLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 'á' && e.KeyChar != 'é'
                && e.KeyChar != 'í' && e.KeyChar != 'ó' && e.KeyChar != 'ú' && e.KeyChar != 'ñ' && e.KeyChar != 'Á' && e.KeyChar != 'É'
                && e.KeyChar != 'Í' && e.KeyChar != 'Ó' && e.KeyChar != 'Ú' && e.KeyChar != 'Ñ')
            {
                e.Handled = true;
            }
        }

        private void SignUpPNLBTNBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SignUpPNLBTNClear_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        public bool FormIsCorrect() =>
            (String.IsNullOrEmpty(SignUpTxtBxName.Text) || String.IsNullOrEmpty(SignUpTxtBxLastname.Text)
            || String.IsNullOrEmpty(SignUpTxtBxUsername.Text) || String.IsNullOrEmpty(SignUpMskTBDocumentNumber.Text)
            || String.IsNullOrEmpty(SignUpTxtBxPassword.Text) || String.IsNullOrEmpty(SignUpTxtBxConfirmPassword.Text)
            || String.IsNullOrEmpty(SignUpMskTBTelephoneNumber.Text)
            || SignUpComboBxType.SelectedIndex == 0 || SignUpComboBxType.SelectedIndex == 0
            || SignUpTxtBxPassword.Text.Equals(SignUpTxtBxConfirmPassword.Text)) ? false : true;

        private void CleanForm()
        {
            SignUpTxtBxName.Clear();
            SignUpTxtBxLastname.Clear();
            SignUpTxtBxUsername.Clear();
            SignUpMskTBDocumentNumber.Clear();
            SignUpTxtBxPassword.Clear();
            SignUpTxtBxConfirmPassword.Clear();
            SignUpMskTBTelephoneNumber.Clear();
            SignUpComboBxType.SelectedIndex = 0;
            SignUpComboBxCondominium.SelectedIndex = 0;
        }

        private async void SignUpPNLBTNSave_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewUser = new User()
                    {
                        FirstName = SignUpTxtBxName.Text,
                        LastName = SignUpTxtBxLastname.Text,
                        DocumentNumber = SignUpMskTBDocumentNumber.Text,
                        PhoneNumber = SignUpMskTBTelephoneNumber.Text,
                        Username = SignUpTxtBxUsername.Text,
                        Password = SignUpTxtBxPassword.Text,
                        Type = SignUpComboBxType.Text,
                        Author = currentUser.Username
                    };

                    await _userService.CreateAsync(NewUser);

                    MessageBox.Show("El usuario ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando usuario: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }
    }
}
