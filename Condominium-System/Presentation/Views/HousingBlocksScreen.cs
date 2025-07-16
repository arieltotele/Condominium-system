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

namespace Condominium_System.Presentation.Views
{
    public partial class HousingBlocksScreen : Form
    {
        private readonly IBlockService _blockService;
        private readonly ICondominiumService _condominiumService;
        private readonly IServiceProvider _serviceProvider;
        User currentUser;

        public HousingBlocksScreen(IBlockService blockService, ICondominiumService condominiumService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _blockService = blockService;
            _condominiumService = condominiumService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
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

            //if (FormIsCorrect())
            //{
            //    try
            //    {
            //        var NewBlock = new Block()
            //        {
            //            Name = BlockTBName.Text,
            //            Address = BlockTBAddress.Text,
            //            HousingType = BlockCBTypeHousing.Text,
            //            HousingCount = Int32.Parse(BlockTBHouseQuantity.Text),
            //            Feature = BlockTBFeature.Text,
            //            CondominiumId = (int)BlockCBCondominium.SelectedValue,
            //            Author = currentUser.Username
            //        };

            //        await _blockService.CreateBlockAsync(NewBlock);

            //        MessageBox.Show("El bloque de casas ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        CleanForm();
            //        LoadDataToDataGrid();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error guardando el bloque de casas: {ex.Message}");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Todos los campos deben ser completados correctamente.");
            //}
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

                var selectedHousingBlock = BlockDTGData.CurrentRow.DataBoundItem as Condominium;
                if (selectedHousingBlock == null)
                {
                    MessageBox.Show("Error al obtener el bloque seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.CondominiumToUpsert = selectedHousingBlock;
            }
            else
            {
                Session.CondominiumToUpsert = null;
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
            //if (!String.IsNullOrEmpty(BlockPNLID.Text))
            //{
            //    try
            //    {
            //        var BlockFound = await _blockService.GetBlockByIdAsync(Int32.Parse(BlockPNLID.Text));
            //        if (BlockFound != null)
            //        {
            //            BlockPNLID.Text = BlockFound.Id.ToString();
            //            BlockTBName.Text = BlockFound.Name;
            //            BlockTBAddress.Text = BlockFound.Address;
            //            BlockTBHouseQuantity.Text = BlockFound.HousingCount.ToString();
            //            BlockTBFeature.Text = BlockFound.Feature;

            //            await LoadCondominiumsIntoComboBox();

            //            BlockCBCondominium.SelectedValue = BlockFound.CondominiumId;

            //            if (BlockFound.HousingType == "Casa")
            //                BlockCBTypeHousing.SelectedValue = 1;
            //            else if (BlockFound.HousingType == "Apartamento")
            //                BlockCBTypeHousing.SelectedValue = 2;
            //            else
            //                BlockCBTypeHousing.SelectedValue = 0;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Bloque de casa no encontrado.");
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error buscando el bloque de casa: {ex.Message}");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("El campo Id debe de estar lleno correctamente.");
            //}
        }

        private async void BlockPNLBTNUpdate_Click(object sender, EventArgs e)
        {
            //if (FormIsCorrectToUpdate())
            //{
            //    try
            //    {
            //        var BlockToUpdate = await _blockService.GetBlockByIdAsync(Int32.Parse(BlockTBID.Text));

            //        if (BlockToUpdate != null)
            //        {
            //            BlockToUpdate.Id = int.Parse(BlockTBID.Text);
            //            BlockToUpdate.Name = BlockTBName.Text;
            //            BlockToUpdate.Feature = BlockTBFeature.Text;
            //            BlockToUpdate.HousingCount = Int32.Parse(BlockTBHouseQuantity.Text);
            //            BlockToUpdate.Address = BlockTBAddress.Text;
            //            BlockToUpdate.CondominiumId = (int)BlockCBCondominium.SelectedValue;
            //            BlockToUpdate.HousingType = BlockCBTypeHousing.Text;

            //            BlockToUpdate.UpdatedAt = DateTime.Now;

            //            await _blockService.UpdateBlockAsync(BlockToUpdate);

            //            MessageBox.Show("El bloque de vivienda ha sido actualizado con exito");
            //            LoadDataToDataGrid();
            //            CleanForm();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Bloque de vivienda no encontrado.");
            //            return;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error actualizando el bloque de vivienda: {ex.Message}");
            //    }
            //}
        }

        private async void BlockPNLBTNDelete_Click(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(BlockTBID.Text))
            //{
            //    var BlockToDelete = await _blockService.GetBlockByIdAsync(Int32.Parse(BlockTBID.Text));

            //    if (BlockToDelete != null)
            //    {
            //        BlockToDelete.DeletedAt = DateTime.Now;
            //        await _blockService.DeleteBlockAsync(Int32.Parse(BlockTBID.Text));
            //        MessageBox.Show("El bloque de viviendas ha sido borrado con exitosamente.");
            //        LoadDataToDataGrid();
            //        CleanForm();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Bloque de viviendas no encontrado.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("El campo de Id debe de estar lleno.");
            //}
        }

        private void CleanForm()
        {
            BlockTBID.Clear();
            LoadDataToDataGrid();
        }        
    }
}
