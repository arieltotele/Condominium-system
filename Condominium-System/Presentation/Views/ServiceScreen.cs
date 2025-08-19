using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Timer = System.Windows.Forms.Timer;
using FastReport;

namespace Condominium_System.Presentation.Views
{
    public partial class ServiceScreen : Form
    {
        private readonly IServiceService _serviceService;
        private readonly IServiceProvider _serviceProvider;

        private User currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime;

        public ServiceScreen(IServiceService serviceService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceService = serviceService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
            _searchCts = new CancellationTokenSource();
        }

        private async void ServiceScreen_Load(object sender, EventArgs e)
        {
            ServiceDTGData.CellPainting += ServiceDTGData_CellPainting;
            ServiceDTGData.CellClick += ServiceDTGData_CellClick;

            SetDataGridStyle();
            ConfigureServiceColumns();
            await LoadDataToDataGrid();

            SetSearchTextBoxStyleAndBehavior();
        }

        private void SetSearchTextBoxStyleAndBehavior()
        {
            ServiceTBID.Text = "Criterio de busqueda";
            ServiceTBID.ForeColor = SystemColors.GrayText;
            ServiceTBID.Enter += (s, e) =>
            {
                if (ServiceTBID.Text == "Criterio de busqueda")
                {
                    ServiceTBID.Text = "";
                    ServiceTBID.ForeColor = SystemColors.WindowText;
                }
            };
            ServiceTBID.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(ServiceTBID.Text))
                {
                    ServiceTBID.Text = "Criterio de busqueda";
                    ServiceTBID.ForeColor = SystemColors.GrayText;
                }
            };
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

                if (relativeX < 26)
                {
                    Session.ServiceToUpsert = selectedService;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52)
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el servicio '{selectedService.Name}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _serviceService.DeleteAsync(selectedService.Id);
                            MessageBox.Show("Servicio eliminado correctamente.");
                            await LoadDataToDataGrid();
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
        }

        private async void ServicePNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
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
        }

        private async void ServiceTBID_TextChanged(object sender, EventArgs e)
        {
            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = ServiceTBID.Text.Trim();

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) || searchTerm.Length >= 2;

                if (shouldSearch)
                {
                    var filteredServices = await _serviceService.SearchServicesAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        _lastSearchTime = DateTime.Now;

                        if (ServiceDTGData.IsHandleCreated)
                        {
                            ServiceDTGData.Invoke((MethodInvoker)delegate
                            {
                                ServiceDTGData.DataSource = filteredServices.ToList();

                                if (!filteredServices.Any() && !string.IsNullOrEmpty(searchTerm))
                                {
                                    ShowStatusMessage("No se encontraron servicios", 3000);
                                }
                                else
                                {
                                    statusLabel.Visible = false;
                                }
                            });
                        }
                    }
                }
            }
            catch (TaskCanceledException) { }
            catch (Exception ex)
            {
                if (ServiceDTGData.IsHandleCreated)
                {
                    ServiceDTGData.Invoke((MethodInvoker)delegate
                    {
                        if (!_searchCts.IsCancellationRequested)
                        {
                            ShowStatusMessage($"Error: {ex.Message}", 3000);
                        }
                    });
                }
            }
        }

        private void ShowStatusMessage(string message, int durationMs)
        {
            statusLabel.Text = message;
            statusLabel.Visible = true;

            var timer = new Timer { Interval = durationMs };
            timer.Tick += (s, e) =>
            {
                statusLabel.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }

        private void GenerateServiceReportFromFilteredData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Service> services = null;

                if (ServiceDTGData.DataSource is BindingSource bindingSource)
                {
                    services = bindingSource.DataSource as IEnumerable<Service>;
                }
                else if (ServiceDTGData.DataSource is IEnumerable<Service> list)
                {
                    services = list;
                }

                if (services == null || !services.Any())
                {
                    MessageBox.Show("No se encontraron servicios para el informe.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/ServiceReportFiltered.frx");

                report.RegisterData(services.ToList(), "Services");
                report.GetDataSource("Services").Enabled = true;

                var viewer = new ReportViewerForm(report);
                viewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generando reporte: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
