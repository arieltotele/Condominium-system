using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Extensions.DependencyInjection;
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

        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICondominiumService _condominiumService;
        User currentUser;

        public UsersScreen(IUserService userService, IServiceProvider serviceProvider, ICondominiumService condominiumService)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;
            _condominiumService = condominiumService;
            currentUser = Session.CurrentUser;            
        }

        private void UsersScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureUserColumns();
            LoadDataToDataGrid();            
            SetComboBoxForTypeOfUsers();
        }

        private void ConfigureUserColumns()
        {

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 110
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "Nombre",
                Name = "FirstNameColumn",
                Width = 150
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Apellido",
                Name = "LastNameColumn",
                Width = 150
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DocumentNumber",
                HeaderText = "Cedula",
                Name = "DocumentNumberColumn",
                Width = 130
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = "Nombre de Usuario",
                Name = "UsernameColumn",
                Width = 180
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Password",
                HeaderText = "Contraseña",
                Name = "PasswordColumn",
                Width = 130
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                Name = "TypeColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(UserDTGData);
        }

        private void SetComboBoxForTypeOfUsers()
        {
            var userTypes = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "-- Seleccione un tipo de usuario --"),
                new KeyValuePair<int, string>(1, "Administrador"),
                new KeyValuePair<int, string>(2, "Operario")
            };

            UserCbType.DataSource = userTypes;
            UserCbType.DisplayMember = "Value";
            UserCbType.ValueMember = "Key";
            UserCbType.DropDownStyle = ComboBoxStyle.DropDownList;
            UserCbType.SelectedIndex = 0;
        }

        private async Task LoadCondominiumsIntoComboBox()
        {
            var condominiums = await _condominiumService.GetAllCondominiumsAsync();

            UserTBCondominium.DisplayMember = "Name";
            UserTBCondominium.ValueMember = "Id";
            UserTBCondominium.DataSource = condominiums;

            var placeholder = new Condominium { Id = 0, Name = "-- Seleccione un condominio --" };
            var listWithPlaceholder = new List<Condominium> { placeholder };
            listWithPlaceholder.AddRange(condominiums);
            UserTBCondominium.DataSource = listWithPlaceholder;
        }

        private void UserBTNCreate_Click(object sender, EventArgs e)
        {
            var signUpScreen = _serviceProvider.GetRequiredService<SignUpScreen>();
            signUpScreen.UserCreated += (s, ev) => LoadDataToDataGrid();

            signUpScreen.Show();
        }

        private async void LoadDataToDataGrid()
        {
            try
            {
                var listUser = await _userService.GetAllAsync();
                var bindingList = new BindingList<User>((List<User>)(IEnumerable<User>)listUser);
                var source = new BindingSource(bindingList, null);
                UserDTGData.DataSource = source;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los usuarios: {ex.Message}");
            }
        }

        private async void UserBTNSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UserTxtBxPId.Text))
            {
                try
                {
                    var UserFound = await _userService.GetByIdAsync(Int32.Parse(UserTxtBxPId.Text));
                    if (UserFound != null)
                    {
                        UserTxtBxPId.Text = UserFound.Id.ToString();
                        UserTxtBxPName.Text = UserFound.FirstName;
                        UserTxtBxPLastname.Text = UserFound.LastName;
                        UserMskTbDocumentation.Text = UserFound.DocumentNumber;
                        UserTbPassword.Text = UserFound.Password;
                        UserTxtBxPUsername.Text = UserFound.Username;
                        UserMskTbContactNumber.Text = UserFound.PhoneNumber;

                        await LoadCondominiumsIntoComboBox();

                        UserTBCondominium.SelectedValue = UserFound.CondominiumId;

                        if (UserFound.Type == "Administrador")
                            UserCbType.SelectedValue = 1;
                        else if (UserFound.Type == "Operario")
                            UserCbType.SelectedValue = 2;
                        else
                            UserCbType.SelectedValue = 0;

                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando usuario: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe de estar lleno correctamente.");
            }
        }

        private async void UserBTNUpdate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrectToUpdate())
            {
                try
                {
                    var UserToUpdate = await _userService.GetByIdAsync(Int32.Parse(UserTxtBxPId.Text));

                    if (UserToUpdate != null)
                    {
                        UserToUpdate.Id = int.Parse(UserTxtBxPId.Text);
                        UserToUpdate.FirstName = UserTxtBxPName.Text;
                        UserToUpdate.LastName = UserTxtBxPLastname.Text;
                        UserToUpdate.DocumentNumber = UserMskTbDocumentation.Text;
                        UserToUpdate.Password = UserTbPassword.Text;
                        UserToUpdate.Username = UserTxtBxPUsername.Text;
                        UserToUpdate.PhoneNumber = UserMskTbContactNumber.Text;
                        UserToUpdate.CondominiumId = (int)UserTBCondominium.SelectedValue;
                        UserToUpdate.Type = UserCbType.Text;

                        _userService.UpdateAsync(UserToUpdate);

                        MessageBox.Show("El usuario ha sido actualizado con exito");
                        LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("usuario no encontrado.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving user: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private void CleanForm()
        {
            UserTxtBxPId.Clear();
            UserTxtBxPName.Clear();
            UserTxtBxPLastname.Clear();
            UserTxtBxPUsername.Clear();
            UserMskTbDocumentation.Clear();
            UserTbPassword.Clear();
            UserMskTbContactNumber.Clear();

            if (UserCbType.Items.Count > 0)
                UserCbType.SelectedIndex = 0;

            if (UserTBCondominium.Items.Count > 0)
                UserTBCondominium.SelectedIndex = 0;
        }

        public bool FormIsCorrectToUpdate()
        {
            bool isTypeValid = int.TryParse(UserCbType.SelectedValue?.ToString(), out int typeId) && typeId != 0;
            bool isCondoValid = int.TryParse(UserTBCondominium.SelectedValue?.ToString(), out int condoId) && condoId != 0;

            return !(
               string.IsNullOrEmpty(UserTxtBxPId.Text) ||
               string.IsNullOrEmpty(UserTxtBxPName.Text) ||
               string.IsNullOrEmpty(UserTxtBxPLastname.Text) ||
               string.IsNullOrEmpty(UserTxtBxPUsername.Text) ||
               string.IsNullOrEmpty(UserMskTbDocumentation.Text) ||
               string.IsNullOrEmpty(UserTbPassword.Text) ||
               string.IsNullOrEmpty(UserMskTbContactNumber.Text) ||
               !isTypeValid ||
               !isCondoValid ||
               UserMskTbContactNumber.Text.Trim().Length != 10 ||
               UserMskTbDocumentation.Text.Trim().Length != 11
           );
        }

        private async void UserBTNDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UserTxtBxPId.Text))
            {

                if (currentUser.Id == Int32.Parse(UserTxtBxPId.Text))
                {
                    MessageBox.Show("No puede elimiarse a sí mismo del sistema.");
                    CleanForm();
                    return;
                }

                var UserToDelete = await _userService.GetByIdAsync(Int32.Parse(UserTxtBxPId.Text));

                if (UserToDelete != null)
                {
                    await _userService.DeleteAsync(Int32.Parse(UserTxtBxPId.Text));
                    MessageBox.Show("El usuario ha sido borrado con exitosamente.");
                    LoadDataToDataGrid();
                    CleanForm();

                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("El campo de Id debe de estar lleno.");
            }
        }
    }
}
