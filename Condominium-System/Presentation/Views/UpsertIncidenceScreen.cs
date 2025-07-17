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
    public partial class UpsertIncidenceScreen : Form
    {
        private readonly IIncidentService _incidentService;
        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;

        User currentUser;

        public bool IsEditMode { get; set; } = false;
        public UpsertIncidenceScreen(IIncidentService incidentService, ITenantService tenantService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _incidentService = incidentService;
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void UpsertIncidenceScreen_Load(object sender, EventArgs e)
        {
            await LoadTenantsIntoComboBox();
        }

        private string FormatDocument(string doc)
        {
            if (!string.IsNullOrEmpty(doc) && doc.Length == 11)
                return $"{doc.Substring(0, 3)}-{doc.Substring(3, 7)}-{doc.Substring(10, 1)}";

            return doc;
        }

        private async Task LoadTenantsIntoComboBox()
        {
            try
            {
                var tenants = await _tenantService.GetAllAsync();

                var placeholder = new { Id = 0, Display = "-- Seleccione un inquilino --" };

                var tenantDisplayList = tenants.Select(t => new
                {
                    Id = t.Id,
                    Display = $"{FormatDocument(t.DocumentNumber)} - {t.FirstName} {t.LastName}"
                }).ToList();

                tenantDisplayList.Insert(0, placeholder);

                IncidenceCBTenants.DisplayMember = "Display";
                IncidenceCBTenants.ValueMember = "Id";
                IncidenceCBTenants.DataSource = tenantDisplayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los inquilinos: {ex.Message}");
            }
        }
    }
}
