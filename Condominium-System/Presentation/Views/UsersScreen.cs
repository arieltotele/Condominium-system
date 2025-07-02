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
        User currentUser;

        public UsersScreen(IUserService userService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            LoadDataToDataGrid();
            DisableDataGrid();
            _serviceProvider = serviceProvider;
            currentUser = Session.CurrentUser;
        }

        private void UserBTNCreate_Click(object sender, EventArgs e)
        {
            var SignUpScreen = _serviceProvider.GetRequiredService<SignUpScreen>();
            SignUpScreen.Show();
        }

        private void UsersScreen_Load(object sender, EventArgs e)
        {

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
    }
}
