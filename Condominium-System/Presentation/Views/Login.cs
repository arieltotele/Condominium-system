using Condominium_System.Business.Services;
using Condominium_System.Data.Context;
using Condominium_System.Helpers;
using Microsoft.Extensions.DependencyInjection;
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
using static System.Collections.Specialized.BitVector32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Condominium_System.Presentation.Views
{
    public partial class Login : Form
    {

        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;

        public Login(IUserService userService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UIUtils.RoundPanelCorners(LoginPNLUsername, 10);
            UIUtils.RoundPanelCorners(LoginPNLPassword, 10);
            CleanForm();
        }

        private async void LoginBTNLogIn_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var users = await _userService.GetAllAsync();
                    var user = users.FirstOrDefault(u => u.Username == LoginTxtBxPUsername.Text && u.Password == LoginTxtBxPassword.Text);

                    if (user != null)
                    {
                        Session.CurrentUser = user;
                        this.Hide();
                        var form = _serviceProvider.GetRequiredService<HomeScreen>();
                        form.Closed += (s, args) => this.Close();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Nombre de ususario o contrasena incorrectos.");
                        CleanForm();
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"Error guardando usuario: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");                
            }
        }

        public bool FormIsCorrect() =>
            (String.IsNullOrEmpty(LoginTxtBxPUsername.Text) || String.IsNullOrEmpty(LoginTxtBxPassword.Text)) ? false : true; 

        public void CleanForm()
        {
            LoginTxtBxPUsername.Text = "";            
            LoginTxtBxPassword.Text = "";
        }
    }
}
