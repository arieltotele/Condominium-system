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
    public partial class AddServiceScreen : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHousingServiceRelationService _housingServiceService;
        private readonly IServiceService _serviceService;
        private readonly User? _currentUser;
        private readonly Housing? _currentHouse;

        public bool IsEditMode { get; set; } = false;

        public AddServiceScreen(IServiceProvider serviceProvider, IHousingServiceRelationService housingServiceService, IServiceService serviceService)
        {
            InitializeComponent();

            _serviceProvider = serviceProvider;
            _housingServiceService = housingServiceService;
            _serviceService = serviceService;
            _currentUser = Session.CurrentUser;
            _currentHouse = Session.CurrentHouse;
        }

        private async void AddServiceScreen_Load(object sender, EventArgs e)
        {
            int housingId = _currentHouse.Id;

            await LoadServiceCheckboxesForHousing("Esenciales", housingId, AddServiceFlowLayoutEssentials);
            await LoadServiceCheckboxesForHousing("Comunitarios", housingId, AddServiceFlowLayoutCommunity);
            await LoadServiceCheckboxesForHousing("Convivencia", housingId, AddServiceFlowLayoutConvivence);

            ChangeLabelIfInEditMode(IsEditMode);
        }

        private void ChangeLabelIfInEditMode(bool isEditMode) =>
            AddServiceLBLTitle.Text = isEditMode ? "Modificar servicios de la vivienda" : AddServiceLBLTitle.Text;

        private async Task LoadServiceCheckboxesForHousing(string serviceType, int housingId, FlowLayoutPanel targetPanel)
        {
            try
            {
                targetPanel.Controls.Clear();

                var services = await _serviceService.GetAllAsync();
                var filteredServices = services.Where(s => s.Type == serviceType).ToList();

                var allRelations = await _housingServiceService.GetAllAsync();
                var assignedServiceIds = allRelations
                    .Where(hs => hs.HousingId == housingId)
                    .Select(hs => hs.ServiceId)
                    .ToHashSet();

                foreach (var service in filteredServices)
                {
                    var checkBox = new CheckBox
                    {
                        Text = service.Name,
                        Tag = service.Id,
                        Checked = assignedServiceIds.Contains(service.Id),
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        Margin = new Padding(5, 5, 5, 5)
                    };

                    targetPanel.Controls.Add(checkBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando servicios de tipo {serviceType}: {ex.Message}");
            }
        }

        private void UncheckAllServiceCheckboxes(params FlowLayoutPanel[] panels)
        {
            foreach (var panel in panels)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is CheckBox checkBox)
                        checkBox.Checked = false;
                }
            }
        }

        private async Task SaveSelectedServicesForHousingAsync(int housingId, params FlowLayoutPanel[] panels)
        {
            try
            {
                var allRelations = await _housingServiceService.GetAllAsync();
                var existingServiceIds = allRelations
                    .Where(hs => hs.HousingId == housingId)
                    .Select(hs => hs.ServiceId)
                    .ToHashSet();

                var selectedServiceIds = new HashSet<int>();

                foreach (var panel in panels)
                {
                    foreach (Control control in panel.Controls)
                    {
                        if (control is CheckBox checkBox && int.TryParse(checkBox.Tag?.ToString(), out int serviceId))
                        {
                            if (checkBox.Checked)
                            {
                                selectedServiceIds.Add(serviceId);

                                if (!existingServiceIds.Contains(serviceId))
                                {
                                    var newRelation = new HousingService
                                    {
                                        HousingId = housingId,
                                        ServiceId = serviceId,
                                        CreatedAt = DateTime.Now,
                                        Author = _currentUser.Username
                                    };

                                    await _housingServiceService.CreateAsync(newRelation);
                                }
                            }
                        }
                    }
                }

                if (IsEditMode)
                {
                    var toDelete = existingServiceIds.Except(selectedServiceIds);
                    foreach (var serviceId in toDelete)
                    {
                        await _housingServiceService.DeleteAsync(housingId, serviceId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los servicios seleccionados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AddServicePNLBTNNext_Click(object sender, EventArgs e)
        {
            await SaveSelectedServicesForHousingAsync(
                _currentHouse.Id,
                AddServiceFlowLayoutEssentials,
                AddServiceFlowLayoutCommunity,
                AddServiceFlowLayoutConvivence
            );

            this.Hide();;
        }

        private void AddServicePNLBTNClean_Click(object sender, EventArgs e)
        {
            UncheckAllServiceCheckboxes(
                AddServiceFlowLayoutEssentials,
                AddServiceFlowLayoutCommunity,
                AddServiceFlowLayoutConvivence
            );
        }
    }
}
