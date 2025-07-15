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
    public partial class AddFurnitureScreen : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHousingFurnitureService _housingFurnitureService;
        private readonly IFurnitureService _furnitureService;
        private readonly User? _currentUser;
        private readonly Housing? _currentHouse;

        private readonly SemaphoreSlim _furnitureLoadLock = new SemaphoreSlim(1, 1);


        public bool IsEditMode { get; set; } = false;

        public AddFurnitureScreen(IServiceProvider serviceProvider, IFurnitureService furnitureService, IHousingFurnitureService housingFurnitureService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _furnitureService = furnitureService;
            _housingFurnitureService = housingFurnitureService;
            _currentUser = Session.CurrentUser;
            _currentHouse = Session.CurrentHouse;
        }

        private async void AddFurnitureScreen_Load(object sender, EventArgs e)
        {
            int housingId = _currentHouse.Id;

            await LoadFurnitureCheckboxesForHousing("Sala de estar", housingId, AddFurnitrureFlowLayoutLivingRoom);
            await LoadFurnitureCheckboxesForHousing("Comedor", housingId, AddFurnitrureFlowLayoutDinningRoom);
            await LoadFurnitureCheckboxesForHousing("Dormitorio", housingId, AddFurnitrureFlowLayoutBedroom);
            await LoadFurnitureCheckboxesForHousing("Cocina", housingId, AddFurnitrureFlowLayoutKitchen);
            await LoadFurnitureCheckboxesForHousing("Exterior", housingId, AddFurnitrureFlowLayoutOutside);

            ChangeLabelIfInEditMode(IsEditMode);
        }

        private void ChangeLabelIfInEditMode(bool isEditMode) =>
            AddFurnitureScreenLBLTitle.Text = isEditMode ? "Modificar inmuebles de la vivienda" : AddFurnitureScreenLBLTitle.Text;

        private async Task LoadFurnitureCheckboxesForHousing(string furnitureType, int housingId, FlowLayoutPanel targetPanel)
        {
            await _furnitureLoadLock.WaitAsync();
            try
            {
                targetPanel.Controls.Clear();

                var furnitureList = await _furnitureService.GetAllFurnituresAsync();
                var filteredFurnitures = furnitureList
                    .Where(f => f.Type == furnitureType)
                    .ToList();

                var relationList = await _housingFurnitureService.GetAllAsync();
                var assignedFurnitureIds = relationList
                    .Where(hf => hf.HousingId == housingId)
                    .Select(hf => hf.FurnitureId)
                    .ToHashSet();

                foreach (var furniture in filteredFurnitures)
                {
                    var checkBox = new CheckBox
                    {
                        Text = furniture.Name,
                        Tag = furniture.Id,
                        Checked = assignedFurnitureIds.Contains(furniture.Id),
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Margin = new Padding(5, 5, 5, 10)
                    };

                    targetPanel.Controls.Add(checkBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando muebles de tipo {furnitureType}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _furnitureLoadLock.Release();
            }
        }


        private void AddFurniturePNLBTNClean_Click(object sender, EventArgs e)
        {
            UncheckAllFurnitureCheckboxes(AddFurnitrureFlowLayoutLivingRoom, AddFurnitrureFlowLayoutDinningRoom,
                AddFurnitrureFlowLayoutBedroom, AddFurnitrureFlowLayoutKitchen, AddFurnitrureFlowLayoutOutside);
        }

        private void UncheckAllFurnitureCheckboxes(params FlowLayoutPanel[] panels)
        {
            foreach (var panel in panels)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is CheckBox checkBox)
                    {
                        checkBox.Checked = false;
                    }
                }
            }
        }

        private async Task SaveSelectedFurnitureForHousingAsync(int housingId, params FlowLayoutPanel[] panels)
        {
            try
            {
                // 1. Eliminar todas las relaciones actuales del housing
                await _housingFurnitureService.DeleteAllByHousingIdAsync(housingId);

                // 2. Recopilar los muebles seleccionados (checkboxes marcados)
                var selectedFurniture = new List<HousingFurniture>();

                foreach (var panel in panels)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (control is CheckBox checkBox && checkBox.Checked)
                        {
                            if (int.TryParse(checkBox.Tag?.ToString(), out int furnitureId))
                            {
                                selectedFurniture.Add(new HousingFurniture
                                {
                                    HousingId = housingId,
                                    FurnitureId = furnitureId,
                                    CreatedAt = DateTime.Now,
                                    Author = _currentUser.Username,
                                    IsActive = true
                                });
                            }
                        }
                    }
                }

                // 3. Insertar las nuevas relaciones
                if (selectedFurniture.Count > 0)
                {
                    await _housingFurnitureService.CreateRangeAsync(selectedFurniture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el mobiliario seleccionado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void AddFurniturePNLBTNNext_Click(object sender, EventArgs e)
        {
            await SaveSelectedFurnitureForHousingAsync(_currentHouse.Id, AddFurnitrureFlowLayoutLivingRoom, 
                AddFurnitrureFlowLayoutDinningRoom, AddFurnitrureFlowLayoutBedroom, AddFurnitrureFlowLayoutKitchen, 
                AddFurnitrureFlowLayoutOutside);

            this.Hide();
            var form = _serviceProvider.GetRequiredService<AddServiceScreen>();
            form.IsEditMode = this.IsEditMode;
            form.Show();
        }
    }
}
