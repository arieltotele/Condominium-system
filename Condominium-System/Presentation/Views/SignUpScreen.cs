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
        private readonly IServiceProvider _serviceProvider;

        public bool IsEditMode { get; set; } = false;

        public SignUpScreen(IUserService userService, ICondominiumService condominiumService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            currentUser = Session.CurrentUser;
            _condominiumService = condominiumService;
            _serviceProvider = serviceProvider;
        }

        private async void SignUp_Load(object sender, EventArgs e)
        {            
            UIUtils.RoundPanelCorners(SignUpPNLBTNBack, 16);
            UIUtils.RoundPanelCorners(SignUpPNLBTNClean, 16);
            UIUtils.RoundPanelCorners(SignUpPNLBTNSave, 16);

            SetComboBoxForTypeOfUsers();
            await SetComboBoxForCondominiums();

            if (IsEditMode)
            {
                SignUpTitleLBL.Text = "Modificar Usuario";
                await LoadDataIfIsToUpdate();
            }
        }

        private async Task LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.UserToUpsert != null)
            {
                var UserToUpsert = Session.UserToUpsert;
                SignUpTxtBxName.Text = UserToUpsert.FirstName;
                SignUpTxtBxLastname.Text = UserToUpsert.LastName;
                SignUpMskTBDocumentNumber.Text = UserToUpsert.DocumentNumber;
                SignUpTxtBxPassword.Text = UserToUpsert.Password;
                SignUpTxtBxConfirmPassword.Text = UserToUpsert.Password;
                SignUpTxtBxUsername.Text = UserToUpsert.Username;
                SignUpMskTBTelephoneNumber.Text = UserToUpsert.PhoneNumber;

                await SetComboBoxForCondominiums();

                SignUpComboBxCondominium.SelectedValue = UserToUpsert.CondominiumId;

                if (UserToUpsert.Type == "Administrador")
                    SignUpComboBxType.SelectedValue = 1;
                else if (UserToUpsert.Type == "Operario")
                    SignUpComboBxType.SelectedValue = 2;
                else
                    SignUpComboBxType.SelectedValue = 0;
            }
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

        private async Task SetComboBoxForCondominiums()
        {
            try
            {
                var condominiums = (await _condominiumService.GetAllCondominiumsAsync()).ToList();

                if (!condominiums.Any())
                {
                    SignUpComboBxCondominium.DataSource = null;
                    SignUpComboBxCondominium.Items.Clear();
                    SignUpComboBxCondominium.Text = "No hay condominios registrados";
                    SignUpComboBxCondominium.Enabled = false;

                    MessageBox.Show("No se encontraron condominios registrados. Por favor, registre al menos un condominio.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    if (this.Owner is UsersScreen owner)
                    {
                        owner.LoadDataToDataGrid();
                    }
                    this.Hide();
                    return;
                }

                var placeholder = new Condominium
                {
                    Id = 0,
                    Name = "-- Seleccione un condominio --",
                    Address = string.Empty,
                    ReceptionContactNumber = string.Empty
                };

                var condominiumList = new List<Condominium> { placeholder };
                condominiumList.AddRange(condominiums);

                SignUpComboBxCondominium.DataSource = condominiumList;
                SignUpComboBxCondominium.DisplayMember = "Name";
                SignUpComboBxCondominium.ValueMember = "Id";
                SignUpComboBxCondominium.SelectedIndex = 0;
                SignUpComboBxCondominium.Enabled = true;
            }
            catch (Exception ex)
            {
                SignUpComboBxCondominium.DataSource = null;
                SignUpComboBxCondominium.Items.Clear();
                SignUpComboBxCondominium.Text = "Error al cargar condominios";
                SignUpComboBxCondominium.Enabled = false;

                MessageBox.Show($"Error cargando condominios: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);

                if (this.Owner is UsersScreen owner)
                {
                    owner.LoadDataToDataGrid();
                }
                this.Hide();
            }
            finally
            {
                SignUpComboBxCondominium.Refresh();
            }
        }

        private void SignUpTxtBxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' &&
                e.KeyChar != 'á' && e.KeyChar != 'é' && e.KeyChar != 'í' && e.KeyChar != 'ó' && e.KeyChar != 'ú' &&
                e.KeyChar != 'ñ' && e.KeyChar != 'Á' && e.KeyChar != 'É' && e.KeyChar != 'Í' && e.KeyChar != 'Ó' &&
                e.KeyChar != 'Ú' && e.KeyChar != 'Ñ')
            {
                e.Handled = true;
            }
        }

        private void SignUpTxtBxLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ' &&
                e.KeyChar != 'á' && e.KeyChar != 'é' && e.KeyChar != 'í' && e.KeyChar != 'ó' && e.KeyChar != 'ú' &&
                e.KeyChar != 'ñ' && e.KeyChar != 'Á' && e.KeyChar != 'É' && e.KeyChar != 'Í' && e.KeyChar != 'Ó' &&
                e.KeyChar != 'Ú' && e.KeyChar != 'Ñ')
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
            if (IsEditMode) { EditUser(); }
            else { SaveUser(); }

        }

        private async void SaveUser()
        {
            if (FormIsCorrect())
            {
                try
                {
                    if (await _userService.UsernameExistsAsync(SignUpTxtBxUsername.Text))
                    {
                        MessageBox.Show($"El nombre de usuario '{SignUpTxtBxUsername.Text}' ya está en uso.",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                        SignUpTxtBxUsername.Focus();
                        return;
                    }

                    var NewUser = new User()
                    {
                        FirstName = SignUpTxtBxName.Text.Trim().ToUpper(),
                        LastName = SignUpTxtBxLastname.Text.Trim().ToUpper(),
                        DocumentNumber = SignUpMskTBDocumentNumber.Text,
                        PhoneNumber = SignUpMskTBTelephoneNumber.Text,
                        Username = SignUpTxtBxUsername.Text,
                        Password = SignUpTxtBxPassword.Text,
                        Type = SignUpComboBxType.Text,
                        Author = currentUser.Username,
                        CondominiumId = (int)SignUpComboBxCondominium.SelectedValue,
                        CreatedAt = DateTime.Now,
                        IsActive = true
                    };

                    await _userService.CreateAsync(NewUser);

                    MessageBox.Show("El usuario ha sido creado con éxito",
                                  "Operación exitosa",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    CleanForm();
                    ((UsersScreen)this.Owner).LoadDataToDataGrid();
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
                    when (dbEx.InnerException?.Message.Contains("IX_Users_Username") == true)
                {
                    MessageBox.Show($"El nombre de usuario '{SignUpTxtBxUsername.Text}' ya está registrado. Por favor elija otro.",
                                  "Nombre de usuario no disponible",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    SignUpTxtBxUsername.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creando usuario: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.",
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }

        private async void EditUser()
        {
            if (FormIsCorrect() && Session.CurrentUser != null)
            {
                try
                {
                    var UserToUpdate = Session.UserToUpsert;

                    if (UserToUpdate != null)
                    {
                        // Verificar si el username fue modificado
                        if (SignUpTxtBxUsername.Text != UserToUpdate.Username &&
                            await _userService.UsernameExistsAsync(SignUpTxtBxUsername.Text, UserToUpdate.Id))
                        {
                            MessageBox.Show($"El nombre de usuario '{SignUpTxtBxUsername.Text}' ya está en uso.",
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Warning);
                            return;
                        }

                        UserToUpdate.FirstName = SignUpTxtBxName.Text.Trim().ToUpper();
                        UserToUpdate.LastName = SignUpTxtBxLastname.Text.Trim().ToUpper();
                        UserToUpdate.DocumentNumber = SignUpMskTBDocumentNumber.Text;
                        UserToUpdate.Password = SignUpTxtBxPassword.Text;
                        UserToUpdate.Username = SignUpTxtBxUsername.Text;
                        UserToUpdate.PhoneNumber = SignUpMskTBTelephoneNumber.Text;
                        UserToUpdate.CondominiumId = (int)SignUpComboBxCondominium.SelectedValue;
                        UserToUpdate.Type = SignUpComboBxType.Text;
                        UserToUpdate.UpdatedAt = DateTime.Now;

                        
                        await _userService.UpdateAsync(UserToUpdate);

                        MessageBox.Show("El usuario ha sido actualizado con éxito",
                                      "Actualización exitosa",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        ((UsersScreen)this.Owner).LoadDataToDataGrid();
                        this.DialogResult = DialogResult.OK;                        
                        this.Hide();
                    }
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException dbEx)
                    when (dbEx.InnerException?.Message.Contains("IX_Users_Username") == true)
                {
                    MessageBox.Show($"El nombre de usuario '{SignUpTxtBxUsername.Text}' ya está registrado. Por favor elija otro.",
                                  "Nombre de usuario no disponible",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    SignUpTxtBxUsername.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando usuario: {ex.Message}",
                                  "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.",
                              "Validación",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
            }
        }
    }
}
