using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using FastReport;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace Condominium_System.Presentation.Views
{
    public partial class InvoiceScreen : Form
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;

        private User currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime;

        public InvoiceScreen(IInvoiceService invoiceService, ITenantService tenantService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _invoiceService = invoiceService;
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void InvoiceScreen_Load(object sender, EventArgs e)
        {
            InvoiceDTGData.CellPainting += InvoiceDTGData_CellPainting;
            InvoiceDTGData.CellClick += InvoiceDTGData_CellClick;

            SetDataGridStyle();
            ConfigureInvoiceColumns();
            await LoadDataToDataGrid();
        }

        private void InvoiceDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && InvoiceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void InvoiceDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && InvoiceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = InvoiceDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = InvoiceDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = InvoiceDTGData.Rows[e.RowIndex];
                var selectedInvoice = selectedRow.DataBoundItem as Invoice;

                if (selectedInvoice == null)
                {
                    MessageBox.Show("No se pudo identificar la factura.");
                    return;
                }

                if (relativeX < 26)
                {
                    Session.InvoiceToUpsert = selectedInvoice;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52)
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar la factura '{selectedInvoice.Id}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _invoiceService.DeleteAsync(selectedInvoice.Id);
                            MessageBox.Show("Factura eliminada correctamente.");
                            await LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar la factura: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (InvoiceDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona una factura para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedInvoice = InvoiceDTGData.CurrentRow.DataBoundItem as Invoice;
                if (selectedInvoice == null)
                {
                    MessageBox.Show("Error al obtener la factura seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.InvoiceToUpsert = selectedInvoice;
            }
            else
            {
                Session.InvoiceToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertInvoiceScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        public async Task LoadDataToDataGrid()
        {
            try
            {
                var invoices = await _invoiceService.GetAllAsync();
                var bindingList = new BindingList<Invoice>((List<Invoice>)invoices);
                var source = new BindingSource(bindingList, null);
                InvoiceDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando facturas: {ex.Message}");
            }
        }

        private void ConfigureInvoiceColumns()
        {
            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "IdColumn",
                Width = 60
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IssueDate",
                HeaderText = "Fecha",
                Name = "DateColumn",
                Width = 150
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detail",
                HeaderText = "Detalle",
                Name = "DetailColumn",
                Width = 229
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Monto Total",
                Name = "AmountColumn",
                Width = 150
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenantId",
                HeaderText = "Inquilino",
                Name = "TenantColumn",
                Width = 150
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Author",
                HeaderText = "Facturante",
                Name = "AuthorColumn",
                Width = 150
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(InvoiceDTGData);
        }

        private void CleanForm()
        {
            InvoiceTBID.Clear();
        }

        private async void InvoicePNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private async void InvoicePNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InvoiceTBID.Text))
            {
                try
                {
                    int id = int.Parse(InvoiceTBID.Text);
                    var invoiceFound = await _invoiceService.GetByIdAsync(id);

                    if (invoiceFound != null)
                    {
                        InvoiceDTGData.DataSource = new List<Invoice> { invoiceFound };
                    }
                    else
                    {
                        MessageBox.Show("Factura no encontrada.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                        await LoadDataToDataGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                    await LoadDataToDataGrid();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
                await LoadDataToDataGrid();
            }
        }

        private async void InvoiceTBID_TextChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;

            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = InvoiceTBID.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadDataToDataGrid();
                    return;
                }

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) || searchTerm.Length >= 2;

                if (shouldSearch && !_searchCts.IsCancellationRequested)
                {
                    var filteredInvoices = await _invoiceService.SearchInvoicesAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        _lastSearchTime = DateTime.Now;

                        if (this.IsHandleCreated && !this.IsDisposed && !_searchCts.IsCancellationRequested)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (this.IsHandleCreated && !this.IsDisposed && InvoiceDTGData != null && !InvoiceDTGData.IsDisposed)
                                {
                                    try
                                    {
                                        InvoiceDTGData.DataSource = filteredInvoices?.ToList() ?? new List<Invoice>();

                                        if (filteredInvoices != null && !filteredInvoices.Any() && !string.IsNullOrEmpty(searchTerm))
                                        {
                                            ShowStatusMessage("No se encontraron facturas", 3000);
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

        private void GenerateInvoiceReportFromFilteredData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Invoice> invoices = null;

                if (InvoiceDTGData.DataSource is BindingSource bindingSource)
                {
                    invoices = bindingSource.DataSource as IEnumerable<Invoice>;
                }
                else if (InvoiceDTGData.DataSource is IEnumerable<Invoice> list)
                {
                    invoices = list;
                }

                if (invoices == null || !invoices.Any())
                {
                    MessageBox.Show("No se encontraron facturas para el informe.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/InvoiceReportFiltered.frx");

                report.RegisterData(invoices.ToList(), "Invoices");
                report.GetDataSource("Invoices").Enabled = true;

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