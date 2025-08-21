using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Timer = System.Windows.Forms.Timer;
using FastReport;

namespace Condominium_System.Presentation.Views
{
    public partial class TenantScreen : Form
    {

        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;

        User currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime;

        private bool _isLoaded = false;

        public TenantScreen(ITenantService tenantService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
            _searchCts = new CancellationTokenSource();
        }

        private async void TenantScreen_Load(object sender, EventArgs e)
        {

            TenantDTGData.CellPainting += TenantDTGData_CellPainting;
            TenantDTGData.CellClick += TenantDTGData_CellClick;

            SetDataGridStyle();
            ConfigureHousingColumns();
            await LoadDataToDataGrid();

            SetSearchTextBoxStyleAndBehavior();

            _isLoaded = true;
        }

        private void SetSearchTextBoxStyleAndBehavior()
        {
            TenantTBID.Text = "Criterio de busqueda";
            TenantTBID.ForeColor = SystemColors.GrayText;
            TenantTBID.Enter += (s, e) => {
                if (TenantTBID.Text == "Criterio de busqueda")
                {
                    TenantTBID.Text = "";
                    TenantTBID.ForeColor = SystemColors.WindowText;
                }
            };
            TenantTBID.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(TenantTBID.Text))
                {
                    TenantTBID.Text = "Criterio de busqueda";
                    TenantTBID.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void TenantDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && TenantDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void TenantDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && TenantDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = TenantDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = TenantDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = TenantDTGData.Rows[e.RowIndex];
                var selectedTenant = selectedRow.DataBoundItem as Tenant;

                if (selectedTenant == null)
                {
                    MessageBox.Show("No se pudo identificar el propietario.");
                    return;
                }

                if (relativeX < 26)
                {
                    Session.TenantToUpsert = selectedTenant;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52)
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el propietario '{selectedTenant.FirstName}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _tenantService.DeleteAsync(selectedTenant.Id);
                            MessageBox.Show("Propietario eliminado correctamente.");
                            await LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar propietario: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (TenantDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un propietario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedTenant = TenantDTGData.CurrentRow.DataBoundItem as Tenant;
                if (selectedTenant == null)
                {
                    MessageBox.Show("Error al obtener el propietario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.TenantToUpsert = selectedTenant;
            }
            else
            {
                Session.TenantToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertTenantScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        public async Task LoadDataToDataGrid()
        {
            try
            {
                var listTenant = await _tenantService.GetAllAsync();
                var bindingList = new BindingList<Tenant>((List<Tenant>)(IEnumerable<Tenant>)listTenant);
                var source = new BindingSource(bindingList, null);
                TenantDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando propietarios: {ex.Message}");
            }
        }

        private void ConfigureHousingColumns()
        {

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 105
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "Nombre",
                Name = "FirstNameColumn",
                Width = 140
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Apellido",
                Name = "LastNameColumn",
                Width = 150
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DocumentNumber",
                HeaderText = "Cedula",
                Name = "DocumentNumberColumn",
                Width = 150
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Numero de teléfono",
                Name = "PhoneNumberColumn",
                Width = 155
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender",
                HeaderText = "Sexo",
                Name = "GenderColumn",
                Width = 100
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HousingId",
                HeaderText = "Identificación de la vivienda",
                Name = "HousingIdColumn",
                Width = 130
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(TenantDTGData);
        }

        private async void CleanForm()
        {
            TenantTBID.Clear();
            await LoadDataToDataGrid();
        }

        private async void TenantPNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private async void TenantPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TenantTBID.Text))
            {
                try
                {
                    int id = int.Parse(TenantTBID.Text);
                    var TenantFound = await _tenantService.GetByIdAsync(id);

                    if (TenantFound != null)
                    {
                        TenantDTGData.DataSource = new List<Tenant> { TenantFound };
                    }
                    else
                    {
                        MessageBox.Show("Propietario no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando propietario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
            }
        }

        private async void TenantPNLBTNDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TenantTBID.Text))
            {
                var TenantToDelete = await _tenantService.GetByIdAsync(Int32.Parse(TenantTBID.Text));

                if (TenantToDelete != null)
                {
                    TenantToDelete.DeletedAt = DateTime.Now;

                    await _tenantService.DeleteAsync(Int32.Parse(TenantTBID.Text));
                    MessageBox.Show("El propietario ha sido borrado con exitosamente.");

                    await LoadDataToDataGrid();
                    CleanForm();
                }
                else
                {
                    MessageBox.Show("Propietario no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("El campo de Id debe de estar lleno.");
            }
        }

        private async void TenantTBID_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;
            if (!this.IsHandleCreated || this.IsDisposed) return;
            if (TenantTBID.Text == "Criterio de busqueda") return;

            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = TenantTBID.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadDataToDataGrid();
                    return;
                }

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) || searchTerm.Length >= 2;

                if (shouldSearch && !_searchCts.IsCancellationRequested)
                {
                    var filteredTenants = await _tenantService.SearchTenantsAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        if (this.IsHandleCreated && !this.IsDisposed && !_searchCts.IsCancellationRequested)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (this.IsHandleCreated && !this.IsDisposed && TenantDTGData != null && !TenantDTGData.IsDisposed)
                                {
                                    try
                                    {
                                        TenantDTGData.DataSource = filteredTenants?.ToList() ?? new List<Tenant>();

                                        if (filteredTenants != null && !filteredTenants.Any() && !string.IsNullOrEmpty(searchTerm))
                                        {
                                            ShowStatusMessage("No se encontraron servicios", 3000);
                                        }
                                        else if (statusLabel != null)
                                        {
                                            statusLabel.Visible = false;
                                        }
                                    }
                                    catch (ObjectDisposedException) { }
                                }
                            });
                        }
                    }
                }
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (this.IsHandleCreated && !this.IsDisposed && !_searchCts.IsCancellationRequested)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        if (this.IsHandleCreated && !this.IsDisposed && statusLabel != null)
                        {
                            try
                            {
                                ShowStatusMessage($"Error: {ex.Message}", 3000);
                            }
                            catch (ObjectDisposedException) { }
                        }
                    });
                }
            }
        }

        private void ShowStatusMessage(string message, int durationMs)
        {
            if (statusLabel == null || this.IsDisposed || !this.IsHandleCreated)
                return;

            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (this.IsHandleCreated && !this.IsDisposed && statusLabel != null)
                    {
                        statusLabel.Text = message;
                        statusLabel.Visible = true;

                        var timer = new Timer { Interval = durationMs };
                        timer.Tick += (s, e) =>
                        {
                            if (statusLabel != null && this.IsHandleCreated && !this.IsDisposed)
                            {
                                statusLabel.Visible = false;
                            }
                            timer.Stop();
                            timer.Dispose();
                        };
                        timer.Start();
                    }
                });
            }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }
        }

        private void GenerateTenantReportFromFilteredData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Tenant> tenants = null;

                if (TenantDTGData.DataSource is BindingSource bindingSource)
                {
                    tenants = bindingSource.DataSource as IEnumerable<Tenant>;
                }
                else if (TenantDTGData.DataSource is IEnumerable<Tenant> list)
                {
                    tenants = list;
                }

                if (tenants == null || !tenants.Any())
                {
                    MessageBox.Show("No se encontraron propietarios para el informe.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/TenantReportFiltered.frx");

                report.RegisterData(tenants.ToList(), "Tenants");
                report.GetDataSource("Tenants").Enabled = true;

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
