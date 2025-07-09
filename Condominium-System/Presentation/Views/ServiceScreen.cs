using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
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
    public partial class ServiceScreen : Form
    {
        private readonly IServiceService _serviceService;
        private User currentUser;

        public ServiceScreen(IServiceService serviceService)
        {
            InitializeComponent();
            _serviceService = serviceService;
            currentUser = Session.CurrentUser;
        }

        private async void ServiceScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureServiceColumns();
            SetComboBoxForTypes();
            await LoadDataToDataGrid();
        }

        private void SetComboBoxForTypes()
        {
            var serviceTypes = new List<string> { "-- Seleccione un tipo --", "Esenciales", "Comunitarios", "Convivencia" };
            ServiceCBTypes.DataSource = serviceTypes;
            ServiceCBTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            ServiceCBTypes.SelectedIndex = 0;
        }

        private async Task LoadDataToDataGrid()
        {
            try
            {
                var services = await _serviceService.GetAllAsync();
                var bindingList = new BindingList<Service>((List<Service>)services);
                var source = new BindingSource(bindingList, null);
                ServiceDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los servicios: {ex.Message}");
            }
        }

        private void ConfigureServiceColumns()
        {
            ServiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 120
            });

            ServiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                Name = "NameColumn",
                Width = 170
            });

            ServiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detail",
                HeaderText = "Detalle",
                Name = "DetailColumn",
                Width = 365
            });

            ServiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cost",
                HeaderText = "Costo",
                Name = "CostColumn",
                Width = 100
            });

            ServiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                Name = "TypeColumn",
                Width = 150
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(ServiceDTGData);
        }

        private void CleanForm()
        {
            ServiceTBID.Clear();
            ServiceTBName.Clear();
            ServiceTBDetail.Clear();
            ServiceTBCost.Clear();

            if (ServiceCBTypes.Items.Count > 0)
                ServiceCBTypes.SelectedIndex = 0;
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

        public bool FormIsCorrectToUpdate()
        {
            return !string.IsNullOrEmpty(ServiceTBID.Text) && FormIsCorrect();
        }

        private async void ServicePNLBTNCreate_Click(object sender, EventArgs e)
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

                    MessageBox.Show("El servicio ha sido creado con éxito.");
                    CleanForm();
                    await LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creando el servicio: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos correctamente.");
            }
        }

        private async void ServicePNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ServiceTBID.Text))
            {
                try
                {
                    var service = await _serviceService.GetByIdAsync(int.Parse(ServiceTBID.Text));

                    if (service != null)
                    {
                        ServiceTBName.Text = service.Name;
                        ServiceTBDetail.Text = service.Detail;
                        ServiceTBCost.Text = service.Cost.ToString();
                        ServiceCBTypes.SelectedItem = service.Type;
                    }
                    else
                    {
                        MessageBox.Show("Servicio no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar el servicio: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno.");
            }
        }

        private async void ServicePNLBTNUpdate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrectToUpdate())
            {
                try
                {
                    var service = await _serviceService.GetByIdAsync(int.Parse(ServiceTBID.Text));

                    if (service != null)
                    {
                        service.Name = ServiceTBName.Text;
                        service.Detail = ServiceTBDetail.Text;
                        service.Cost = int.Parse(ServiceTBCost.Text);
                        service.Type = ServiceCBTypes.SelectedItem.ToString();
                        service.UpdatedAt = DateTime.Now;

                        await _serviceService.UpdateAsync(service);

                        MessageBox.Show("El servicio ha sido actualizado con éxito.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Servicio no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando el servicio: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos correctamente.");
            }
        }

        private async void ServicePNLBTNDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ServiceTBID.Text))
            {
                try
                {
                    var service = await _serviceService.GetByIdAsync(int.Parse(ServiceTBID.Text));

                    if (service != null)
                    {
                        service.DeletedAt = DateTime.Now;
                        await _serviceService.DeleteAsync(service.Id);

                        MessageBox.Show("El servicio ha sido eliminado correctamente.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Servicio no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el servicio: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno.");
            }
        }
    }
}
