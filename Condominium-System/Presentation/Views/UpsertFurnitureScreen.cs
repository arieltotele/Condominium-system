using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
    public partial class UpsertFurnitureScreen : Form
    {
        private readonly IFurnitureService _furnitureService;
        private readonly IServiceProvider _serviceProvider;
        private User currentUser;

        public bool IsEditMode { get; set; } = false;

        public UpsertFurnitureScreen(IFurnitureService furnitureService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _furnitureService = furnitureService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private void UpsertFurnitureScreen_Load(object sender, EventArgs e)
        {
            SetComboBoxForTypes();

            if (IsEditMode)
            {
                LoadDataIfIsToUpdate();
            }
        }

        private void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.FurnitureToUpsert != null)
            {
                var furniture = Session.FurnitureToUpsert;
                FurnitureTBName.Text = furniture.Name;
                FurnitureTBDetail.Text = furniture.Detail;
                FurnitureCBTypes.SelectedItem = furniture.Type;
            }
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

        private void UpsertLBLBTN_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditFurniture(); }
            else { SaveFurniture(); }
        }

        private async void EditFurniture()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var FurnitureToUpdate = Session.FurnitureToUpsert;

                    if (FurnitureToUpdate != null)
                    {
                        FurnitureToUpdate.Name = FurnitureTBName.Text;
                        FurnitureToUpdate.Detail = FurnitureTBDetail.Text;
                        FurnitureToUpdate.Type = FurnitureCBTypes.SelectedItem.ToString();
                        FurnitureToUpdate.UpdatedAt = DateTime.Now;

                        await _furnitureService.UpdateFurnitureAsync(FurnitureToUpdate);

                        MessageBox.Show("El mobiliario ha sido actualizado con exito");
                        CleanForm();
                        await ((FurnitureScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Mobiliario no encontrado.");
                        CleanForm();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando mobiliario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveFurniture()
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

                    MessageBox.Show("El mobiliario ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    await ((FurnitureScreen)this.Owner).LoadDataToDataGrid();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando mobiliario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private void CleanForm()
        {
            FurnitureTBName.Clear();
            FurnitureTBDetail.Clear();

            if (FurnitureCBTypes.Items.Count > 0)
                FurnitureCBTypes.SelectedIndex = 0;

            SetComboBoxForTypes();
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
    }
}
