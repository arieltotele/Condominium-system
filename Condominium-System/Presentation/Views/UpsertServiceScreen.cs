using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public partial class UpsertServiceScreen : Form
    {
        private readonly IServiceService _serviceService;
        private readonly IServiceProvider _serviceProvider;
        private User currentUser;

        public bool IsEditMode { get; set; } = false;

        public UpsertServiceScreen(IServiceService serviceService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceService = serviceService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private void UpsertServiceScreen_Load(object sender, EventArgs e)
        {
            SetComboBoxForTypes();

            if (IsEditMode)
            {
                LoadDataIfIsToUpdate();
            }
        }

        private void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.ServiceToUpsert != null)
            {
                var service = Session.ServiceToUpsert;
                ServiceTBName.Text = service.Name;
                ServiceTBDetail.Text = service.Detail;
                ServiceTBCost.Text = service.Cost.ToString();
                ServiceCBTypes.SelectedItem = service.Type;
            }
        }

        private void SetComboBoxForTypes()
        {
            var serviceTypes = new List<string> { "-- Seleccione un tipo --", "Esenciales", "Comunitarios", "Convivencia" };
            ServiceCBTypes.DataSource = serviceTypes;
            ServiceCBTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            ServiceCBTypes.SelectedIndex = 0;
        }

        private void UpsertPNLBTN_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditService(); }
            else { SaveService(); }
        }

        private async void EditService()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var ServiceToUpdate = Session.ServiceToUpsert;

                    if (ServiceToUpdate != null)
                    {
                        ServiceToUpdate.Name = ServiceTBName.Text;
                        ServiceToUpdate.Detail = ServiceTBDetail.Text;
                        ServiceToUpdate.Cost = int.Parse(ServiceTBCost.Text);
                        ServiceToUpdate.Type = ServiceCBTypes.SelectedItem.ToString();
                        ServiceToUpdate.UpdatedAt = DateTime.Now;

                        await _serviceService.UpdateAsync(ServiceToUpdate);

                        MessageBox.Show("El servicio ha sido actualizado con exito");
                        CleanForm();
                        await ((ServiceScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Servicio no encontrado.");
                        CleanForm();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveService()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var newService = new Service
                    {
                        Name = ServiceTBName.Text,
                        Detail = ServiceTBDetail.Text,
                        Cost = int.Parse(ServiceTBCost.Text),
                        Type = ServiceCBTypes.SelectedItem.ToString(),
                        Author = currentUser.Username
                    };

                    await _serviceService.CreateAsync(newService);

                    MessageBox.Show("El servicio ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    await ((ServiceScreen)this.Owner).LoadDataToDataGrid();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        public bool FormIsCorrect()
        {
            bool isTypeValid = ServiceCBTypes.SelectedIndex != 0;
            bool isCostValid = int.TryParse(ServiceTBCost.Text, out int _);

            return !(
                string.IsNullOrEmpty(ServiceTBName.Text) ||
                string.IsNullOrEmpty(ServiceTBDetail.Text) ||
                string.IsNullOrEmpty(ServiceTBCost.Text) ||
                !isCostValid ||
                !isTypeValid
            );
        }

        private async void CleanForm()
        {
            ServiceTBName.Clear();
            ServiceTBDetail.Clear();
            ServiceTBCost.Clear();

            if (ServiceCBTypes.Items.Count > 0)
                ServiceCBTypes.SelectedIndex = 0;
        }
    }
}
