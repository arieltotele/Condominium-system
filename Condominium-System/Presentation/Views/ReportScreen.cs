using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using FastReport;
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
    public partial class ReportScreen : Form
    {
        private readonly ICondominiumService _condominiumService;
        private readonly IBlockService _blockService;
        private readonly IHousingEntityService _housingEntityService;
        private readonly ITenantService _tenantService;
        private readonly IIncidentService _incidenceService;
        public ReportScreen(ICondominiumService condominiumService, IBlockService blockService, IHousingEntityService housingEntityService,
            ITenantService tenantService, IIncidentService incidenceService)
        {
            InitializeComponent();
            _condominiumService = condominiumService;
            _blockService = blockService;
            _housingEntityService = housingEntityService;
            _tenantService = tenantService;
            _incidenceService = incidenceService;
        }

        private void ReportScreen_Load(object sender, EventArgs e)
        {
            SetComboBoxForTypes();
        }

        private void SetComboBoxForTypes()
        {
            var serviceTypes = new List<string> { "-- Seleccione una entidad --",
                "Condominio", "Bloque", "Vivienda", "Inquilino", "Incidencia",
                "Factura", "Mobiliario", "Servicios", "Reporte", "Usuarios"};
            ReportComboBxEntities.DataSource = serviceTypes;
            ReportComboBxEntities.DropDownStyle = ComboBoxStyle.DropDownList;
            ReportComboBxEntities.SelectedIndex = 0;
        }

        private async void GenerateReportBTN_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var report = new Report();
                    switch (ReportComboBxEntities.SelectedIndex)
                    {
                        case 1:
                            var condominiums = await _condominiumService.GetAllCondominiumsAsync();
                                                        
                            report.Load("Presentation/Reports/CondominiumReport.frx");
                            report.RegisterData(condominiums, "Condominium");

                            var viewer = new ReportViewerForm(report);
                            viewer.Show();
                            break;

                        case 2:
                            var blocks = await _blockService.GetAllBlocksAsync();

                            report.Load("Presentation/Reports/BlockReport.frx");
                            report.RegisterData(blocks, "Block");

                            var viewerBlock = new ReportViewerForm(report);
                            viewerBlock.Show();
                            break;

                        case 3:
                            var houses = await _housingEntityService.GetAllHousingsAsync();

                            report.Load("Presentation/Reports/HousingReport.frx");
                            report.RegisterData(houses, "Housing");

                            var viewerHouses = new ReportViewerForm(report);
                            viewerHouses.Show();
                            break;

                        case 4:
                            var tenants = await _tenantService.GetAllAsync();

                            report.Load("Presentation/Reports/TenantReport.frx");
                            report.RegisterData(tenants, "Housing");

                            var viewerTenants = new ReportViewerForm(report);
                            viewerTenants.Show();
                            break;

                        case 5:
                            var incidence = await _incidenceService.GetAllAsync();

                            report.Load("Presentation/Reports/IncidenceReport.frx");
                            report.RegisterData(incidence, "Incidence");

                            var viewerIncidence = new ReportViewerForm(report);
                            viewerIncidence.Show();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando servicio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar una opcion valida.");
            }
        }

        private async void CleanForm()
        {
            if (ReportComboBxEntities.Items.Count > 0)
                ReportComboBxEntities.SelectedIndex = 0;
        }

        public bool FormIsCorrect()
        {
            bool isTypeValid = ReportComboBxEntities.SelectedIndex != 0;
            return isTypeValid;

        }
    }
}
