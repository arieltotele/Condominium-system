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
    public partial class AddFurnitureScreen : Form
    {
        private readonly IHousingFurnitureService _housingFurnitureService;
        private readonly IFurnitureService _furnitureService;
        private User? _currentUser;
        private Housing? _currentHouse;

        public AddFurnitureScreen(IFurnitureService furnitureService, IHousingFurnitureService housingFurnitureService)
        {
            InitializeComponent();
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
        }

        private async Task LoadFurnitureCheckboxesForHousing(string furnitureType, int housingId, FlowLayoutPanel targetPanel)
        {
            try
            {

                targetPanel.Controls.Clear();

                var furnitures = await _furnitureService.GetAllFurnituresAsync();
                var filteredFurnitures = furnitures.Where(f => f.Type == furnitureType).ToList();

                var allRelations = await _housingFurnitureService.GetAllAsync();
                var assignedFurnitureIds = allRelations
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
                MessageBox.Show($"Error cargando muebles de tipo {furnitureType}: {ex.Message}");
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
    }
}
