using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
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
        private User currentUser;

        public FurnitureScreen(IFurnitureService furnitureService)
        {
            InitializeComponent();
            _furnitureService = furnitureService;
            currentUser = Session.CurrentUser;
        }

        private async void FurnitureScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureFurnitureColumns();
            SetComboBoxForTypes();
            await LoadDataToDataGrid();
        }

        private void SetComboBoxForTypes()
        {
            var types = new List<string>
            {
                "-- Seleccione un tipo --",
                "Sala de estar",
                "Comedor",
                "Dormitorio",
                "Cocina",
                "Exterior"
            };

            FurnitureCBTypes.DataSource = types;
            FurnitureCBTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            FurnitureCBTypes.SelectedIndex = 0;
        }

        private async Task LoadDataToDataGrid()
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
                Width = 200
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(FurnitureDTGData);
        }

        private void CleanForm()
        {
            FurnitureTBID.Clear();
            FurnitureTBName.Clear();
            FurnitureTBDetail.Clear();

            if (FurnitureCBTypes.Items.Count > 0)
                FurnitureCBTypes.SelectedIndex = 0;
        }

        public bool FormIsCorrect()
        {
            bool isTypeValid = FurnitureCBTypes.SelectedIndex != 0;

            return !(
                string.IsNullOrEmpty(FurnitureTBName.Text) ||
                string.IsNullOrEmpty(FurnitureTBDetail.Text) ||
                !isTypeValid
            );
        }

        public bool FormIsCorrectToUpdate()
        {
            bool isTypeValid = FurnitureCBTypes.SelectedIndex != 0;

            return !(
                string.IsNullOrEmpty(FurnitureTBID.Text) ||
                string.IsNullOrEmpty(FurnitureTBName.Text) ||
                string.IsNullOrEmpty(FurnitureTBDetail.Text) ||
                !isTypeValid
            );
        }

        private async void FurniturePNLBTNCreate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var newFurniture = new Furniture
                    {
                        Name = FurnitureTBName.Text,
                        Detail = FurnitureTBDetail.Text,
                        Type = FurnitureCBTypes.SelectedItem.ToString(),
                        Author = currentUser.Username
                    };

                    await _furnitureService.CreateFurnitureAsync(newFurniture);

                    MessageBox.Show("El mobiliario ha sido creado con éxito.");
                    CleanForm();
                    await LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creando el mobiliario: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos correctamente.");
            }
        }

        private async void FurniturePNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FurnitureTBID.Text))
            {
                try
                {
                    var furniture = await _furnitureService.GetFurnitureByIdAsync(int.Parse(FurnitureTBID.Text));

                    if (furniture != null)
                    {
                        FurnitureTBName.Text = furniture.Name;
                        FurnitureTBDetail.Text = furniture.Detail;
                        FurnitureCBTypes.SelectedItem = furniture.Type;
                    }
                    else
                    {
                        MessageBox.Show("Mobiliario no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar el mobiliario: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno.");
            }
        }

        private async void FurniturePNLBTNUpdate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrectToUpdate())
            {
                try
                {
                    var furniture = await _furnitureService.GetFurnitureByIdAsync(int.Parse(FurnitureTBID.Text));

                    if (furniture != null)
                    {
                        furniture.Name = FurnitureTBName.Text;
                        furniture.Detail = FurnitureTBDetail.Text;
                        furniture.Type = FurnitureCBTypes.SelectedItem.ToString();
                        furniture.UpdatedAt = DateTime.Now;

                        await _furnitureService.UpdateFurnitureAsync(furniture);

                        MessageBox.Show("El mobiliario ha sido actualizado con éxito.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Mobiliario no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando el mobiliario: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos correctamente.");
            }
        }

        private async void FurniturePNLBTNDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FurnitureTBID.Text))
            {
                try
                {
                    var furniture = await _furnitureService.GetFurnitureByIdAsync(int.Parse(FurnitureTBID.Text));

                    if (furniture != null)
                    {
                        furniture.DeletedAt = DateTime.Now;
                        await _furnitureService.DeleteFurnitureAsync(furniture.Id);

                        MessageBox.Show("El mobiliario ha sido eliminado correctamente.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Mobiliario no encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el mobiliario: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno.");
            }
        }
    }
}
