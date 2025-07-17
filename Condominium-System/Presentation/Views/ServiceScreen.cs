using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace Condominium_System.Presentation.Views
{
    public partial class ServiceScreen : Form
    {
        private readonly IServiceService _serviceService;
        private readonly IServiceProvider _serviceProvider;
        private User currentUser;

        public ServiceScreen(IServiceService serviceService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceService = serviceService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void ServiceScreen_Load(object sender, EventArgs e)
        {
            ServiceDTGData.CellPainting += ServiceDTGData_CellPainting;
            ServiceDTGData.CellClick += ServiceDTGData_CellClick;

            SetDataGridStyle();
            ConfigureServiceColumns();
            await LoadDataToDataGrid();
        }

        private void ServiceDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && ServiceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                int iconWidth = 16;
                int iconHeight = 16;
                int padding = 5;

                int x = e.CellBounds.Left + padding;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(Properties.Resources.pencil_blue, new Rectangle(x, y, iconWidth, iconHeight));

                x += iconWidth + padding;
                e.Graphics.DrawImage(Properties.Resources.trash_red, new Rectangle(x, y, iconWidth, iconHeight));

                e.Handled = true;
            }
        }

        private async void ServiceDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ServiceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = ServiceDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = ServiceDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = ServiceDTGData.Rows[e.RowIndex];
                var selectedService = selectedRow.DataBoundItem as Service;

                if (selectedService == null)
                {
                    MessageBox.Show("No se pudo identificar el servicio.");
                    return;
                }

                if (relativeX < 26) // 🟢 Editar
                {
                    Session.ServiceToUpsert = selectedService;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52) // 🔴 Eliminar
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el servicio '{selectedService.Name}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _serviceService.DeleteAsync(selectedService.Id);
                            MessageBox.Show("Servicio eliminado correctamente.");
                            LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar servicio: {ex.Message}");
                        }
                    }
                }
            }
        }

        public async Task LoadDataToDataGrid()
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
                Width = 140
            });

            ServiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(ServiceDTGData);
        }

        private async void CleanForm()
        {
            ServiceTBID.Clear();
            await LoadDataToDataGrid();
            //ServiceTBName.Clear();
            //ServiceTBDetail.Clear();
            //ServiceTBCost.Clear();

            //if (ServiceCBTypes.Items.Count > 0)
            //    ServiceCBTypes.SelectedIndex = 0;
        }

        //public bool FormIsCorrect()
        //{
        //    bool isTypeValid = ServiceCBTypes.SelectedIndex != 0;
        //    bool isCostValid = int.TryParse(ServiceTBCost.Text, out int _);

        //    return !(
        //        string.IsNullOrEmpty(ServiceTBName.Text) ||
        //        string.IsNullOrEmpty(ServiceTBDetail.Text) ||
        //        string.IsNullOrEmpty(ServiceTBCost.Text) ||
        //        !isCostValid ||
        //        !isTypeValid
        //    );
        //}

        //public bool FormIsCorrectToUpdate()
        //{
        //    bool isTypeValid = ServiceCBTypes.SelectedIndex != 0;
        //    bool isCostValid = int.TryParse(ServiceTBCost.Text, out int _);

        //    return !(
        //        string.IsNullOrEmpty(ServiceTBID.Text) ||
        //        string.IsNullOrEmpty(ServiceTBName.Text) ||
        //        string.IsNullOrEmpty(ServiceTBDetail.Text) ||
        //        string.IsNullOrEmpty(ServiceTBCost.Text) ||
        //        !isCostValid ||
        //        !isTypeValid
        //    );        
        //}

        private async void ServicePNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
            //if (FormIsCorrect())
            //{
            //    try
            //    {
            //        var newService = new Service
            //        {
            //            Name = ServiceTBName.Text,
            //            Detail = ServiceTBDetail.Text,
            //            Cost = int.Parse(ServiceTBCost.Text),
            //            Type = ServiceCBTypes.SelectedItem.ToString(),
            //            Author = currentUser.Username
            //        };

            //        await _serviceService.CreateAsync(newService);

            //        MessageBox.Show("El servicio ha sido creado con éxito.");
            //        CleanForm();
            //        await LoadDataToDataGrid();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error creando el servicio: {ex.Message}");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Todos los campos deben estar completos correctamente.");
            //}
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (ServiceDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un servicio para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedService = ServiceDTGData.CurrentRow.DataBoundItem as Service;
                if (selectedService == null)
                {
                    MessageBox.Show("Error al obtener el servicio seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.ServiceToUpsert = selectedService;
            }
            else
            {
                Session.ServiceToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertServiceScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        private async void ServicePNLBTNSearch_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(ServiceTBID.Text))
            {
                try
                {
                    int id = int.Parse(ServiceTBID.Text);
                    var serviceFound = await _serviceService.GetByIdAsync(id);

                    if (serviceFound != null)
                    {
                        ServiceDTGData.DataSource = new List<Service> { serviceFound };
                    }
                    else
                    {
                        MessageBox.Show("Servicio no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
            }

            //if (!string.IsNullOrWhiteSpace(ServiceTBID.Text))
            //{
            //    try
            //    {
            //        var service = await _serviceService.GetByIdAsync(int.Parse(ServiceTBID.Text));

            //        if (service != null)
            //        {
            //            ServiceTBName.Text = service.Name;
            //            ServiceTBDetail.Text = service.Detail;
            //            ServiceTBCost.Text = service.Cost.ToString();
            //            ServiceCBTypes.SelectedItem = service.Type;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Servicio no encontrado.");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error al buscar el servicio: {ex.Message}");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("El campo ID debe estar lleno.");
            //}
        }

        private async void ServicePNLBTNUpdate_Click(object sender, EventArgs e)
        {
            //if (FormIsCorrectToUpdate())
            //{
            //    try
            //    {
            //        var service = await _serviceService.GetByIdAsync(int.Parse(ServiceTBID.Text));

            //        if (service != null)
            //        {
            //            service.Name = ServiceTBName.Text;
            //            service.Detail = ServiceTBDetail.Text;
            //            service.Cost = int.Parse(ServiceTBCost.Text);
            //            service.Type = ServiceCBTypes.SelectedItem.ToString();
            //            service.UpdatedAt = DateTime.Now;

            //            await _serviceService.UpdateAsync(service);

            //            MessageBox.Show("El servicio ha sido actualizado con éxito.");
            //            await LoadDataToDataGrid();
            //            CleanForm();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Servicio no encontrado.");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error actualizando el servicio: {ex.Message}");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Todos los campos deben estar completos correctamente.");
            //}
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
