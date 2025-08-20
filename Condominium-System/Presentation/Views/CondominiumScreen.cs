using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using FastReport;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Timer = System.Windows.Forms.Timer;

namespace Condominium_System.Presentation.Views
{
    public partial class CondominiumScreen : Form
    {
        private readonly ICondominiumService _condominiumService;
        private readonly IServiceProvider _serviceProvider;

        User currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime;

        private bool _isLoaded = false;

        public CondominiumScreen(ICondominiumService condominiumService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _condominiumService = condominiumService;
            _serviceProvider = serviceProvider;
            currentUser = Session.CurrentUser;
        }

        private void CondominuiumScreen_Load(object sender, EventArgs e)
        {
           //IUtils.RoundPanelCorners(CondominiumPNLBTNCreate, 10);

            CondominiumDTGData.CellPainting += CondominiumDTGData_CellPainting;
            CondominiumDTGData.CellClick += CondominiumDTGData_CellClick;

            SetDataGridStyle();
            ConfigureCondominiumColumns();
            LoadDataToDataGrid();

            SetSearchTextBoxStyleAndBehavior();

            _isLoaded = true;
        }

        private void SetSearchTextBoxStyleAndBehavior()
        {
            CondominiumTIId.Text = "Criterio de busqueda";
            CondominiumTIId.ForeColor = SystemColors.GrayText;
            CondominiumTIId.Enter += (s, e) => {
                if (CondominiumTIId.Text == "Criterio de busqueda")
                {
                    CondominiumTIId.Text = "";
                    CondominiumTIId.ForeColor = SystemColors.WindowText;
                }
            };
            CondominiumTIId.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(CondominiumTIId.Text))
                {
                    CondominiumTIId.Text = "Criterio de busqueda";
                    CondominiumTIId.ForeColor = SystemColors.GrayText;
                }
            };
        }

        public async void LoadDataToDataGrid()
        {
            try
            {
                var listCondominium = await _condominiumService.GetAllCondominiumsAsync();
                var bindingList = new BindingList<Condominium>((List<Condominium>)(IEnumerable<Condominium>)listCondominium);
                var source = new BindingSource(bindingList, null);
                CondominiumDTGData.DataSource = source;

                CondominiumDTGData.EnableHeadersVisualStyles = false;
                CondominiumDTGData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 65, 194);
                CondominiumDTGData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                CondominiumDTGData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando condominios: {ex.Message}");
            }
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(CondominiumDTGData);
        }

        private void ConfigureCondominiumColumns()
        {
            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 120
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                Name = "NameColumn",
                Width = 200
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Direccion",
                Name = "AddressColumn",
                Width = 230
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReceptionContactNumber",
                HeaderText = "Numero de recepcion",
                Name = "ReceptionContactNumberColumn",
                Width = 200
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BlockCount",
                HeaderText = "Numero de bloques",
                Name = "BlockCountColumn",
                Width = 180
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void CondominiumDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && CondominiumDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void CondominiumDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CondominiumDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = CondominiumDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = CondominiumDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = CondominiumDTGData.Rows[e.RowIndex];
                var selectedFurniture = selectedRow.DataBoundItem as Condominium;

                if (selectedFurniture == null)
                {
                    MessageBox.Show("No se pudo identificar el condominio.");
                    return;
                }

                if (relativeX < 26)
                {
                    Session.CondominiumToUpsert = selectedFurniture;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52)
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el condominio '{selectedFurniture.Name}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _condominiumService.DeleteCondominiumAsync(selectedFurniture.Id);
                            MessageBox.Show("Condominio eliminado correctamente.");
                            LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar condominio: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (CondominiumDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un condominio para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedCondominium = CondominiumDTGData.CurrentRow.DataBoundItem as Condominium;
                if (selectedCondominium == null)
                {
                    MessageBox.Show("Error al obtener el condominio seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.CondominiumToUpsert = selectedCondominium;
            }
            else
            {
                Session.CondominiumToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertCondominiumScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        private async void CondominiumBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private async void CondominiumBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CondominiumTIId.Text))
            {
                try
                {
                    int id = int.Parse(CondominiumTIId.Text);
                    var condominiumFound = await _condominiumService.GetCondominiumByIdAsync(id);

                    if (condominiumFound != null)
                    {
                        CondominiumDTGData.DataSource = new List<Condominium> { condominiumFound };
                    }
                    else
                    {
                        MessageBox.Show("Condominio no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando condominio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
            }
        }

        private void CleanForm()
        {
            CondominiumTIId.Text = string.Empty;

            LoadDataToDataGrid();
        }

        private async void CondominiumTIId_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;
            if (!this.IsHandleCreated || this.IsDisposed) return;
            if (CondominiumTIId.Text == "Criterio de busqueda") return;

            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = CondominiumTIId.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadDataToDataGrid();
                    return;
                }

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) ||
                                  searchTerm.All(char.IsDigit) ||
                                  searchTerm.Length >= 2;

                if (shouldSearch && !_searchCts.IsCancellationRequested)
                {
                    var results = await _condominiumService.SearchCondominiumsAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        if (this.IsHandleCreated && !this.IsDisposed && !_searchCts.IsCancellationRequested)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (this.IsHandleCreated && !this.IsDisposed && CondominiumDTGData != null && !CondominiumDTGData.IsDisposed)
                                {
                                    try
                                    {
                                        CondominiumDTGData.DataSource = results?.ToList() ?? new List<Condominium>();

                                        if (results != null && !results.Any() && !string.IsNullOrEmpty(searchTerm))
                                        {
                                            ShowStatusMessage("No se encontraron condominios", 3000);
                                        }
                                        else if (statusLabel != null)
                                        {
                                            statusLabel.Visible = false;
                                        }
                                    }
                                    catch (ObjectDisposedException) {}
                                }
                            });
                        }
                    }
                }
            }
            catch (TaskCanceledException) {}
            catch (OperationCanceledException) {}
            catch (Exception ex)
            {
                // Manejo seguro de errores con verificación de estado del formulario
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
                            catch (ObjectDisposedException) {}
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
            catch (ObjectDisposedException) {}
            catch (InvalidOperationException) {}
        }

        private void GenerateCondominiumReportFromFilteredData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Condominium> condominiums = null;

                if (CondominiumDTGData.DataSource is BindingSource bindingSource)
                {
                    condominiums = bindingSource.DataSource as IEnumerable<Condominium>;
                }
                else if (CondominiumDTGData.DataSource is IEnumerable<Condominium> list)
                {
                    condominiums = list;
                }

                if (condominiums == null || !condominiums.Any())
                {
                    MessageBox.Show("No se encontraron condominios para el informe.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/CondominiumReportFiltered.frx");

                report.RegisterData(condominiums.ToList(), "Condominiums");
                report.GetDataSource("Condominiums").Enabled = true;

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
