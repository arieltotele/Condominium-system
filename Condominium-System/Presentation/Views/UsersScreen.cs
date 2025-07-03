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
            currentUser = Session.CurrentUser;
            _condominiumService = condominiumService;
        }

        private void UsersScreen_Load(object sender, EventArgs e)
        {
            LoadDataToDataGrid();
            DisableDataGrid();
            SetComboBoxForTypeOfUsers();
            LoadUserTypeIntoComboBox();
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
            UserCbType.SelectedIndex = 0;
        }

        private void LoadUserTypeIntoComboBox()
        {
            UserCbType.DropDownStyle = ComboBoxStyle.DropDownList;

            List<ComboBoxItem> userTypes = new List<ComboBoxItem>
            {
                new ComboBoxItem { Text = "-- Seleccione un tipo de usuario --", Value = "0" },
                new ComboBoxItem { Text = "Administrador", Value = "Administrador" },
                new ComboBoxItem { Text = "Operario", Value = "Operario" }
            };

            UserCbType.DataSource = userTypes;
            UserCbType.DisplayMember = "Text";
            UserCbType.ValueMember = "Value";
            UserCbType.SelectedIndex = 0;
        }

        private async Task LoadCondominiumsIntoComboBox()
        {
            var condominiums = await _condominiumService.GetAllCondominiumsAsync();

            UserTBCondominium.DisplayMember = "Name";     // lo que se muestra
            UserTBCondominium.ValueMember = "Id";         // lo que se guarda/usa
            UserTBCondominium.DataSource = condominiums;

            // Opcional: insertar opción inicial
            var placeholder = new Condominium { Id = 0, Name = "-- Seleccione un condominio --" };
            var listWithPlaceholder = new List<Condominium> { placeholder };
            listWithPlaceholder.AddRange(condominiums);
            UserTBCondominium.DataSource = listWithPlaceholder;
        }

        private void UserBTNCreate_Click(object sender, EventArgs e)
        {
            var signUpScreen = _serviceProvider.GetRequiredService<SignUpScreen>();
            signUpScreen.UserCreated += (s, ev) => LoadDataToDataGrid(); // ✅ RECARGA DATOS

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

        private void DisableDataGrid()
        {
            UserDTGData.ReadOnly = true;
            UserDTGData.AllowUserToAddRows = false;
            UserDTGData.AllowUserToDeleteRows = false;
            UserDTGData.AllowUserToResizeColumns = false;
            UserDTGData.AllowUserToResizeRows = false;
            UserDTGData.AllowUserToOrderColumns = false;
            UserDTGData.MultiSelect = false;
            UserDTGData.ScrollBars = ScrollBars.Both;
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

                        // Cargar condominios si no están cargados ya
                        await LoadCondominiumsIntoComboBox();

                        // Establecer el seleccionado según el ID
                        UserTBCondominium.SelectedValue = UserFound.CondominiumId;

                        UserCbType.SelectedValue = UserFound.Type;

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
    }
}
