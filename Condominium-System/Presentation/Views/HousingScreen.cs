using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using FastReport;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace Condominium_System.Presentation.Views
{
    public partial class HousingScreen : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHousingEntityService _housingEntityService;
        private readonly IBlockService _blockService;

        User? currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime;

        private bool _isLoaded = false;

        public HousingScreen(IServiceProvider serviceProvider, IHousingEntityService housingEntityService, IBlockService blockService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _housingEntityService = housingEntityService;
            _blockService = blockService;
            currentUser = Session.CurrentUser;
            _searchCts = new CancellationTokenSource();
        }

        private async void HousingScreen_Load(object sender, EventArgs e)
        {
            HousingDTGData.CellPainting += HousingDTGData_CellPainting;
            HousingDTGData.CellClick += HousingDTGData_CellClick;

            SetDataGridStyle();
            ConfigureHousingColumns();
            await LoadDataToDataGrid();

            SetSearchTextBoxStyleAndBehavior();

            _isLoaded = true;
        }

        private void SetSearchTextBoxStyleAndBehavior()
        {
            HousingTBID.Text = "Criterio de busqueda";
            HousingTBID.ForeColor = SystemColors.GrayText;
            HousingTBID.Enter += (s, e) => {
                if (HousingTBID.Text == "Criterio de busqueda")
                {
                    HousingTBID.Text = "";
                    HousingTBID.ForeColor = SystemColors.WindowText;
                }
            };
            HousingTBID.Leave += (s, e) => {
                if (string.IsNullOrWhiteSpace(HousingTBID.Text))
                {
                    HousingTBID.Text = "Criterio de busqueda";
                    HousingTBID.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void HousingDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && HousingDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void HousingDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && HousingDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = HousingDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = HousingDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = HousingDTGData.Rows[e.RowIndex];
                var selectedHousing = selectedRow.DataBoundItem as Housing;

                if (selectedHousing == null)
                {
                    MessageBox.Show("No se pudo identificar el servicio.");
                    return;
                }

                if (relativeX < 26)
                {
                    Session.CurrentHouse = selectedHousing;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52)
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar la vivienda '{selectedHousing.Code}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _housingEntityService.DeleteHousingAsync(selectedHousing.Id);
                            MessageBox.Show("Vivienda eliminada correctamente.");
                            await LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar la vivienda: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (HousingDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona una vivienda para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedHouse = HousingDTGData.CurrentRow.DataBoundItem as Housing;
                if (selectedHouse == null)
                {
                    MessageBox.Show("Error al obtener la vivienda seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.CurrentHouse = selectedHouse;
            }
            else
            {
                Session.CurrentHouse = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertHousingScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        public async Task LoadDataToDataGrid()
        {
            try
            {
                var listHousing = await _housingEntityService.GetAllHousingsAsync();
                var bindingList = new BindingList<Housing>((List<Housing>)(IEnumerable<Housing>)listHousing);
                var source = new BindingSource(bindingList, null);
                HousingDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando viviendas: {ex.Message}");
            }
        }

        private void ConfigureHousingColumns()
        {

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 115
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Code",
                HeaderText = "Codigo",
                Name = "CodeColumn",
                Width = 130
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PeopleCount",
                HeaderText = "Cantidad de personas",
                Name = "PeopleCountColumn",
                Width = 160
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomCount",
                HeaderText = "Cantidad de habitaciones",
                Name = "RoomCountColumn",
                Width = 180
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BathroomCount",
                HeaderText = "Numero de baños",
                Name = "BathroomCountColumn",
                Width = 140
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BlockID",
                HeaderText = "Identificacion del bloque",
                Name = "BlockIDColumn",
                Width = 165
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(HousingDTGData);
        }

        private async void HousingPNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private async void HousingPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(HousingTBID.Text))
            {
                try
                {
                    int id = int.Parse(HousingTBID.Text);
                    var HousingFound = await _housingEntityService.GetHousingByIdAsync(id);

                    if (HousingFound != null)
                    {
                        HousingDTGData.DataSource = new List<Housing> { HousingFound };
                    }
                    else
                    {
                        MessageBox.Show("Vivienda no encontrada.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanFormHousing();
                        await LoadDataToDataGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando vivienda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanFormHousing();
                    await LoadDataToDataGrid();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanFormHousing();
                await LoadDataToDataGrid();
            }
        }

        private void CleanFormHousing()
        {
            HousingTBID.Clear();
        }

        private async void HousingTBID_TextChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return;
            if (!this.IsHandleCreated) return;

            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = HousingTBID.Text.Trim();

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) ||
                                  searchTerm.All(char.IsDigit) ||
                                  searchTerm.Length >= 2; // Búsqueda con mínimo 2 caracteres

                if (shouldSearch)
                {
                    var filteredHousings = await _housingEntityService.SearchHousingsAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        _lastSearchTime = DateTime.Now;

                        // Verificar si el control todavía está disponible
                        if (this.IsHandleCreated && !this.IsDisposed)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                // Verificar nuevamente por si acaso
                                if (this.IsHandleCreated && !this.IsDisposed)
                                {
                                    HousingDTGData.DataSource = filteredHousings.ToList();

                                    if (!filteredHousings.Any() && !string.IsNullOrEmpty(searchTerm))
                                    {
                                        ShowStatusMessage("No se encontró vivienda", 3000);
                                    }
                                    else
                                    {
                                        statusLabel.Visible = false;
                                    }
                                }
                            });
                        }
                    }
                }
            }
            catch (TaskCanceledException) { }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (!_searchCts.IsCancellationRequested)
                    {
                        ShowStatusMessage($"Error: {ex.Message}", 3000);
                    }
                });
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

        private void GenerateHousingReportFromFilteredData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<Housing> housings = null;

                if (HousingDTGData.DataSource is BindingSource bindingSource)
                {
                    housings = bindingSource.DataSource as IEnumerable<Housing>;
                }
                else if (HousingDTGData.DataSource is IEnumerable<Housing> list)
                {
                    housings = list;
                }

                if (housings == null || !housings.Any())
                {
                    MessageBox.Show("No se encontraron viviendas para el informe.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/HousingReportFiltered.frx");

                report.RegisterData(housings.ToList(), "Housings");
                report.GetDataSource("Housings").Enabled = true;

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
