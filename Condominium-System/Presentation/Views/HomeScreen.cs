using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using User = Condominium_System.Data.Entities.User;

namespace Condominium_System.Presentation.Views
{
    public partial class HomeScreen : Form
    {

        private Panel activePanel = null;
        private readonly IServiceProvider _serviceProvider;

        public HomeScreen(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            User user = Session.CurrentUser;

            if (user != null)
            {
                HomeScreenLBLTitleName.Text = "Hola, " + user.FirstName + " " + user.LastName;
            }

            if (user.Type.Equals("Operario")) {
                HomeScreenPNLUsers.Visible = false;
            }

            foreach (Panel panel in HomeScreenPNLMenu.Controls.OfType<Panel>())
            {
                panel.Click += SelectPanel;

                foreach (Control child in panel.Controls)
                {
                    child.Click += SelectPanel;
                }
            }

        }
        private void SelectPanel(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Panel clickedPanel = control as Panel ?? control.Parent as Panel;

            if (clickedPanel == null || clickedPanel == activePanel)
                return;

            if (activePanel != null)
            {
                Label previousLabel = activePanel.Controls.OfType<Label>().FirstOrDefault();
                if (previousLabel != null)
                    previousLabel.Font = new Font(previousLabel.Font, FontStyle.Regular);
            }

            Label newLabel = clickedPanel.Controls.OfType<Label>().FirstOrDefault();
            if (newLabel != null)
                newLabel.Font = new Font(newLabel.Font, FontStyle.Bold);

            activePanel = clickedPanel;

            switch (clickedPanel.Name)
            {
                case "HomeScreenPNLCondominium":
                    HomeScreenLBLTitle.Text = "Condominio";
                    var condominiumScreen = _serviceProvider.GetRequiredService<CondominiumScreen>();
                    LoadFormInPanel(condominiumScreen);
                    break;

                case "HomeScreenPNLHouseBlocks":
                    HomeScreenLBLTitle.Text = "Bloque";
                    var housingBlocksScreen = _serviceProvider.GetRequiredService<HousingBlocksScreen>();
                    LoadFormInPanel(housingBlocksScreen);
                    break;

                case "HomeScreenPNLHousing":
                    HomeScreenLBLTitle.Text = "Vivienda";
                    var housingScreen = _serviceProvider.GetRequiredService<HousingScreen>();
                    LoadFormInPanel(housingScreen);
                    break;

                case "HomeScreenPNLTenant":
                    HomeScreenLBLTitle.Text = "Inquilino";
                    var tenantScreen = _serviceProvider.GetRequiredService<TenantScreen>();
                    LoadFormInPanel(tenantScreen);
                    break;

                case "HomeScreenPNLIncidence":
                    HomeScreenLBLTitle.Text = "Incidencia";
                    var incidenceScreen = _serviceProvider.GetRequiredService<IncidenceScreen>();
                    LoadFormInPanel(incidenceScreen);
                    break;

                case "HomeScreenPNLInvoice":
                    HomeScreenLBLTitle.Text = "Factura";
                    var invoiceScreen = _serviceProvider.GetRequiredService<InvoiceScreen>();
                    LoadFormInPanel(invoiceScreen);
                    break;

                case "HomeScreenPNLFurniture":
                    HomeScreenLBLTitle.Text = "Mobiliario";
                    var furnitureScreen = _serviceProvider.GetRequiredService<FurnitureScreen>();
                    LoadFormInPanel(furnitureScreen);
                    break;

                case "HomeScreenPNLMaintenance":
                    HomeScreenLBLTitle.Text = "Servicios";
                    OpenServiceScreen();
                    break;

                case "HomeScreenPNLReport":
                    HomeScreenLBLTitle.Text = "Reporte";
                    var reportScreen = _serviceProvider.GetRequiredService<ReportScreen>();
                    LoadFormInPanel(reportScreen);
                    break;

                case "HomeScreenPNLUsers":
                    HomeScreenLBLTitle.Text = "Usuario";
                    var userScreen = _serviceProvider.GetRequiredService<UsersScreen>();
                    LoadFormInPanel(userScreen);
                    break;

                default:
                    break;
            }
        }

        private void OpenServiceScreen()
        {
            var screen = _serviceProvider.GetRequiredService<ServiceScreen>();
            LoadFormInPanel(screen);
        }

        private void LoadFormInPanel(Form childForm)
        {
            if (HomeScreenPNLMain.Controls.Count > 0)
            {
                var oldForm = HomeScreenPNLMain.Controls[0] as Form;
                if (oldForm != null)
                {
                    oldForm.Hide();
                    oldForm.Dispose();
                }
                HomeScreenPNLMain.Controls.Clear();
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            HomeScreenPNLMain.Controls.Add(childForm);
            HomeScreenPNLMain.Tag = childForm;

            // Forzar la creación del handle antes de mostrar
            if (!childForm.IsHandleCreated)
            {
                var handle = childForm.Handle; // Esto fuerza la creación del handle
            }

            childForm.Show();
        }

        private void HomeScreenBTNLogOut_Click(object sender, EventArgs e)
        {
            Session.CurrentUser = null;
            this.Hide();
            var form = _serviceProvider.GetRequiredService<Login>();
            form.Closed += (s, args) => this.Close();
            form.CleanForm();
            form.Show();
        }
    }
}
