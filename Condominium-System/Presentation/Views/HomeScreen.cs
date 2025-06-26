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

namespace Condominium_System.Presentation.Views
{
    public partial class HomeScreen : Form
    {

        private Panel activePanel = null;
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            foreach (Panel panel in HomeScreenPNLMenu.Controls.OfType<Panel>())
            {
                panel.Click += SelectPanel;

                // Also attach the event to child controls (Label, PictureBox, etc.)
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
                    LoadFormInPanel(new CondominuiumScreen());
                    break;

                case "HomeScreenPNLHouseBlocks":
                    HomeScreenLBLTitle.Text = "Bloque";
                    LoadFormInPanel(new HousingBlocksScreen());
                    break;

                case "HomeScreenPNLHousing":
                    HomeScreenLBLTitle.Text = "Vivienda";
                    LoadFormInPanel(new HousingScreen());
                    break;

                case "HomeScreenPNLTenant":
                    HomeScreenLBLTitle.Text = "Inquilino";
                    LoadFormInPanel(new TenantScreen());
                    break;

                case "HomeScreenPNLIncidence":
                    HomeScreenLBLTitle.Text = "Incidencia";
                    break;

                case "HomeScreenPNLInvoice":
                    HomeScreenLBLTitle.Text = "Factura";
                    break;

                case "HomeScreenPNLFurniture":
                    HomeScreenLBLTitle.Text = "Mobiliario";
                    break;

                case "HomeScreenPNLMaintenance":
                    HomeScreenLBLTitle.Text = "Servicios";
                    break;

                case "HomeScreenPNLUsers":
                    HomeScreenLBLTitle.Text = "Usuarios";
                    break;

                default:
                    break;
            }
        }

        private void LoadFormInPanel(Form childForm)
        {
            // Limpia cualquier formulario anterior
            if (HomeScreenPNLMain.Controls.Count > 0)
            {
                HomeScreenPNLMain.Controls[0].Dispose();
                HomeScreenPNLMain.Controls.Clear();
            }

            // Preparar el nuevo formulario para estar "embebido"
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Agregarlo al panel y mostrarlo
            HomeScreenPNLMain.Controls.Add(childForm);
            HomeScreenPNLMain.Tag = childForm;
            childForm.Show();
        }

    }
}
