using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Condominium_System.Presentation.Views
{
    public partial class HousingBlocksScreen : Form
    {
        private readonly IBlockService _blockService;
        private readonly ICondominiumService _condominiumService;
        private readonly IServiceProvider _serviceProvider;

        User currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime;


        public HousingBlocksScreen(IBlockService blockService, ICondominiumService condominiumService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _blockService = blockService;
            _condominiumService = condominiumService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
            _searchCts = new CancellationTokenSource();
        }

        private async void HousingBlocksScreen_Load(object sender, EventArgs e)
        {
            BlockDTGData.CellPainting += BlockDTGData_CellPainting;
            BlockDTGData.CellClick += BlockDTGData_CellClick;

            SetDataGridStyle();
            ConfigureBlockColumns();
            LoadDataToDataGrid();
        }

        private void BlockDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && BlockDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void BlockDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && BlockDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = BlockDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = BlockDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = BlockDTGData.Rows[e.RowIndex];
                var selectedBlock = selectedRow.DataBoundItem as Block;

                if (selectedBlock == null)
                {
                    MessageBox.Show("No se pudo identificar el bloque.");
                    return;
                }

                if (relativeX < 26) // 🟢 Editar
                {
                    Session.BlockToUpsert = selectedBlock;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52) // 🔴 Eliminar
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el bloque '{selectedBlock.Name}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _blockService.DeleteBlockAsync(selectedBlock.Id);
                            MessageBox.Show("Bloque eliminado correctamente.");
                            LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar bloque: {ex.Message}");
                        }
                    }
                }
            }
        }

        public async void LoadDataToDataGrid()
        {
            try
            {
                var listBlock = await _blockService.GetAllBlocksAsync();
                var bindingList = new BindingList<Block>((List<Block>)(IEnumerable<Block>)listBlock);
                var source = new BindingSource(bindingList, null);
                BlockDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando bloques: {ex.Message}");
            }
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(BlockDTGData);
        }

        private void ConfigureBlockColumns()
        {

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 105
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                Name = "NameColumn",
                Width = 130
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Feature",
                HeaderText = "Caracteristica",
                Name = "FeatureColumn",
                Width = 250
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HousingType",
                HeaderText = "Tipos de vivienda",
                Name = "HousingTypeColumn",
                Width = 170
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HousingCount",
                HeaderText = "Numero de casas",
                Name = "HousingCountColumn",
                Width = 120
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Direccion",
                Name = "AddressColumn",
                Width = 120
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private async void BlockPNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (BlockDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un bloque para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedHousingBlock = BlockDTGData.CurrentRow.DataBoundItem as Block;
                if (selectedHousingBlock == null)
                {
                    MessageBox.Show("Error al obtener el bloque seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.BlockToUpsert = selectedHousingBlock;
            }
            else
            {
                Session.BlockToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertHousingBlocks>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        private async void BlockPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(BlockTBID.Text))
            {
                try
                {
                    int id = int.Parse(BlockTBID.Text);
                    var housingBlockFound = await _blockService.GetBlockByIdAsync(id);

                    if (housingBlockFound != null)
                    {
                        BlockDTGData.DataSource = new List<Block> { housingBlockFound };
                    }
                    else
                    {
                        MessageBox.Show("Bloque no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando Bloque: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            BlockTBID.Clear();
            LoadDataToDataGrid();
        }

        private async void BlockTBID_TextChanged(object sender, EventArgs e)
        {
            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = BlockTBID.Text.Trim();

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) ||
                                  searchTerm.All(char.IsDigit) ||
                                  searchTerm.Length >= 2;

                if (shouldSearch)
                {
                    var filteredBlocks = await _blockService.SearchBlocksAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        _lastSearchTime = DateTime.Now;

                        this.Invoke((MethodInvoker)delegate {
                            BlockDTGData.DataSource = filteredBlocks.ToList();

                            if (!filteredBlocks.Any() && !string.IsNullOrEmpty(searchTerm))
                            {
                                ShowStatusMessage("No se encontraron bloques", 3000);
                            }
                            else
                            {
                                statusLabel.Visible = false;
                            }
                        });
                    }
                }
            }
            catch (TaskCanceledException) { }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate {
                    if (!_searchCts.IsCancellationRequested)
                    {
                        ShowStatusMessage($"Error: {ex.Message}", 3000);
                    }
                });
            }
        }

        private void ShowStatusMessage(string message, int durationMs)
        {
            statusLabel.Text = message;
            statusLabel.Visible = true;

            var timer = new Timer { Interval = durationMs };
            timer.Tick += (s, e) => {
                statusLabel.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }
    }
}
