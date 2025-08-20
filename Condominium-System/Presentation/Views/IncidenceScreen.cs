using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using FastReport;
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
using Timer = System.Windows.Forms.Timer;

namespace Condominium_System.Presentation.Views
{
    public partial class IncidenceScreen : Form
    {
        private readonly IIncidentService _incidentService;
        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;

        User currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime = DateTime.MinValue;

        public IncidenceScreen(IIncidentService incidentService, ITenantService tenantService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _incidentService = incidentService;
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void IncidenceScreen_Load(object sender, EventArgs e)
        {
            IncidenceDTGData.CellPainting += IncidenceDTGData_CellPainting;
            IncidenceDTGData.CellClick += IncidenceDTGData_CellClick;

            SetDataGridStyle();
            ConfigureIncidenceColumns();
            await LoadDataToDataGrid();

            SetSearchTextBoxStyleAndBehavior();
        }

        private void SetSearchTextBoxStyleAndBehavior()
        {
            IncidenceTBID.Text = "Criterio de busqueda";
            IncidenceTBID.ForeColor = SystemColors.GrayText;
            IncidenceTBID.Enter += (s, e) => {
                if (IncidenceTBID.Text == "Criterio de busqueda")
                {
                    IncidenceTBID.Text = "";
                    IncidenceTBID.ForeColor = SystemColors.WindowText;
                }
            };
            IncidenceTBID.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(IncidenceTBID.Text))
                {
                    IncidenceTBID.Text = "Criterio de busqueda";
                    IncidenceTBID.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void IncidenceDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && IncidenceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void IncidenceDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && IncidenceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = IncidenceDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = IncidenceDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = IncidenceDTGData.Rows[e.RowIndex];
                var selectedIncidence = selectedRow.DataBoundItem as Incident;

                if (selectedIncidence == null)
                {
                    MessageBox.Show("No se pudo identificar el incidente.");
                    return;
                }

                if (relativeX < 26) // 🟢 Editar
                {
                    Session.IncidenceToUpsert = selectedIncidence;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52) // 🔴 Eliminar
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar la incidencia '{selectedIncidence.Id}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _incidentService.DeleteAsync(selectedIncidence.Id);
                            MessageBox.Show("Incidencia eliminada correctamente.");
                            await LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar la incidencia: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (IncidenceDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona una incidencia para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedIncidence = IncidenceDTGData.CurrentRow.DataBoundItem as Incident;
                if (selectedIncidence == null)
                {
                    MessageBox.Show("Error al obtener la incidencia seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.IncidenceToUpsert = selectedIncidence;
            }
            else
            {
                Session.IncidenceToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertIncidenceScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        public async Task LoadDataToDataGrid()
        {
            try
            {
                var listIncidence = await _incidentService.GetAllAsync();
                var bindingList = new BindingList<Incident>((List<Incident>)(IEnumerable<Incident>)listIncidence);
                var source = new BindingSource(bindingList, null);
                IncidenceDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando las incidencias: {ex.Message}");
            }
        }
        private void ConfigureIncidenceColumns()
        {

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 110
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Fecha",
                Name = "DateColumn",
                Width = 220
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Descripción",
                Name = "DescriptionColumn",
                Width = 310
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenantId",
                HeaderText = "Documentacion del inquilino",
                Name = "TenantIdColumn",
                Width = 250
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(IncidenceDTGData);
        }

        private async void IncidentPNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private async void IncidentPNLBTNSearch_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(IncidenceTBID.Text))
            {
                try
                {
                    int id = int.Parse(IncidenceTBID.Text);
                    var incidenceFound = await _incidentService.GetByIdAsync(id);

                    if (incidenceFound != null)
                    {
                        IncidenceDTGData.DataSource = new List<Incident> { incidenceFound };
                    }
                    else
                    {
                        MessageBox.Show("Incidencia no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando la incidencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
            }
        }

        private async void CleanForm()
        {
            IncidenceTBID.Clear();
            await LoadDataToDataGrid();
        }

        private async void IncidenceTBID_TextChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;
            if (IncidenceTBID.Text == "Criterio de busqueda") return;

            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = IncidenceTBID.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    await LoadDataToDataGrid();
                    return;
                }

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) ||
                                  (searchTerm.All(char.IsDigit)) ||
                                  (searchTerm.Length > 1);

                if (shouldSearch && !_searchCts.IsCancellationRequested)
                {
                    var filteredIncidents = await _incidentService.SearchIncidentsAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        _lastSearchTime = DateTime.Now;

                        if (this.IsHandleCreated && !this.IsDisposed && !_searchCts.IsCancellationRequested)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (this.IsHandleCreated && !this.IsDisposed && IncidenceDTGData != null && !IncidenceDTGData.IsDisposed)
                                {
                                    try
                                    {
                                        IncidenceDTGData.DataSource = filteredIncidents?.ToList() ?? new List<Incident>();

                                        if (filteredIncidents != null && !filteredIncidents.Any() && !string.IsNullOrEmpty(searchTerm))
                                        {
                                            ShowStatusMessage("No se encontraron incidentes", 3000);
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

        private void GenerateIncidenceReportFromFilteredData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Incident> incidents = null;

                if (IncidenceDTGData.DataSource is BindingSource bindingSource)
                {
                    incidents = bindingSource.DataSource as IEnumerable<Incident>;
                }
                else if (IncidenceDTGData.DataSource is IEnumerable<Incident> list)
                {
                    incidents = list;
                }

                if (incidents == null || !incidents.Any())
                {
                    MessageBox.Show("No se encontraron incidencias para el informe.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/IncidenceReportFiltered.frx");

                report.RegisterData(incidents.ToList(), "Incidents");
                report.GetDataSource("Incidents").Enabled = true;

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
