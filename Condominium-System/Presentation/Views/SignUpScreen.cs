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
        private readonly ICondominiumService _condominiumService;
        User currentUser;
        public event EventHandler UserCreated;

        public SignUpScreen(IUserService userService, ICondominiumService condominiumService)
        {
            InitializeComponent();
            _userService = userService;
            currentUser = Session.CurrentUser;
            _condominiumService = condominiumService;            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {            
            UIUtils.RoundPanelCorners(SignUpPNLBTNBack, 16);
            UIUtils.RoundPanelCorners(SignUpPNLBTNClean, 16);
            UIUtils.RoundPanelCorners(SignUpPNLBTNSave, 16);

            SetComboBoxForTypeOfUsers();
            SetComboBoxForCondominiums();
        }

        private void SetComboBoxForTypeOfUsers()
        {
            var userTypes = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "-- Seleccione un tipo de usuario --"),
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(2, "Operario")
            };

            SignUpComboBxType.DataSource = userTypes;
            SignUpComboBxType.DisplayMember = "Value";
            SignUpComboBxType.ValueMember = "Key";
            SignUpComboBxType.SelectedIndex = 0;
        }

        private async void SetComboBoxForCondominiums()
        {
            var condominiums = (await _condominiumService.GetAllCondominiumsAsync()).ToList();

            // Insertar opción por defecto
            condominiums.Insert(0, new Condominium
            {
                Id = 0,
                Name = "-- Seleccione un condominio --"
            });

            SignUpComboBxCondominium.DataSource = condominiums;
            SignUpComboBxCondominium.DisplayMember = "Name";
            SignUpComboBxCondominium.ValueMember = "Id";
            SignUpComboBxCondominium.SelectedIndex = 0;
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
            this.Close();
        }

        private void SignUpPNLBTNClear_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        public bool FormIsCorrect() =>            
            !(
        string.IsNullOrEmpty(SignUpTxtBxName.Text) ||
        string.IsNullOrEmpty(SignUpTxtBxLastname.Text) ||
        string.IsNullOrEmpty(SignUpTxtBxUsername.Text) ||
        string.IsNullOrEmpty(SignUpMskTBDocumentNumber.Text) ||
        string.IsNullOrEmpty(SignUpTxtBxPassword.Text) ||
        string.IsNullOrEmpty(SignUpTxtBxConfirmPassword.Text) ||
        string.IsNullOrEmpty(SignUpMskTBTelephoneNumber.Text) ||
        SignUpComboBxType.SelectedValue == null ||
        SignUpComboBxCondominium.SelectedValue == null ||
        (int)SignUpComboBxType.SelectedValue == 0 ||
        (int)SignUpComboBxCondominium.SelectedValue == 0 ||
        SignUpMskTBTelephoneNumber.Text.Trim().Length != 10 ||
        SignUpMskTBDocumentNumber.Text.Trim().Length != 11 ||
        !SignUpTxtBxPassword.Text.Equals(SignUpTxtBxConfirmPassword.Text)
    );

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
                        Author = currentUser.Username,
                        CondominiumId = (int) SignUpComboBxCondominium.SelectedValue,
                    };

                    await _userService.CreateAsync(NewUser);

                    MessageBox.Show("El usuario ha sido creado con exito.");
                    CleanForm();

                    UserCreated?.Invoke(this, EventArgs.Empty);

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
