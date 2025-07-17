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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System.Presentation.Views
{
    public partial class FurnitureScreen : Form
    {
        private readonly IFurnitureService _furnitureService;
        private readonly IServiceProvider _serviceProvider;
        private User currentUser;

        public FurnitureScreen(IFurnitureService furnitureService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _furnitureService = furnitureService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void FurnitureScreen_Load(object sender, EventArgs e)
        {
            FurnitureDTGData.CellPainting += FurnitureDTGData_CellPainting;
            FurnitureDTGData.CellClick += FurnitureDTGData_CellClick;

            SetDataGridStyle();
            ConfigureFurnitureColumns();
            
            await LoadDataToDataGrid();
        }

        private void FurnitureDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && FurnitureDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void FurnitureDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && FurnitureDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = FurnitureDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = FurnitureDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = FurnitureDTGData.Rows[e.RowIndex];
                var selectedFurniture = selectedRow.DataBoundItem as Furniture;

                if (selectedFurniture == null)
                {
                    MessageBox.Show("No se pudo identificar el mobiliario.");
                    return;
                }

                if (relativeX < 26) // 🟢 Editar
                {
                    Session.FurnitureToUpsert = selectedFurniture;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52) // 🔴 Eliminar
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el mobiliario '{selectedFurniture.Name}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _furnitureService.DeleteFurnitureAsync(selectedFurniture.Id);
                            MessageBox.Show("Mobiliario eliminado correctamente.");
                            await LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar el mobiliario: {ex.Message}");
                        }
                    }
                }
            }
        }

        public async Task LoadDataToDataGrid()
        {
            try
            {
                var furnitureList = await _furnitureService.GetAllFurnituresAsync();
                var bindingList = new BindingList<Furniture>((List<Furniture>)furnitureList);
                var source = new BindingSource(bindingList, null);
                FurnitureDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los mobiliarios: {ex.Message}");
            }
        }

        private void ConfigureFurnitureColumns()
        {
            FurnitureDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificación",
                Name = "IdColumn",
                Width = 120
            });

            FurnitureDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                Name = "NameColumn",
                Width = 250
            });

            FurnitureDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detail",
                HeaderText = "Detalle",
                Name = "DetailColumn",
                Width = 335
            });

            FurnitureDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                Name = "TypeColumn",
                Width = 170
            });

            FurnitureDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(FurnitureDTGData);
        }

        private async void CleanForm()
        {
            FurnitureTBID.Clear();
            await LoadDataToDataGrid();
        }

        private async void FurniturePNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);            
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (FurnitureDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un mobiliario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedFurniture = FurnitureDTGData.CurrentRow.DataBoundItem as Furniture;
                if (selectedFurniture == null)
                {
                    MessageBox.Show("Error al obtener el mobiliario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.FurnitureToUpsert = selectedFurniture;
            }
            else
            {
                Session.FurnitureToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertFurnitureScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        private async void FurniturePNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FurnitureTBID.Text))
            {
                try
                {
                    int id = int.Parse(FurnitureTBID.Text);
                    var furnitureFound = await _furnitureService.GetFurnitureByIdAsync(id);

                    if (furnitureFound != null)
                    {
                        FurnitureDTGData.DataSource = new List<Furniture> { furnitureFound };
                    }
                    else
                    {
                        MessageBox.Show("Mobiliario no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando mobiliario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
            }
        }
    }
}
