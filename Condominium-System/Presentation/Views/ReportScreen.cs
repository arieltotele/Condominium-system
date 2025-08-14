using Condominium_System.Business.Models;
using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
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
        private readonly IInvoiceService _invoiceService;
        private readonly IFurnitureService _furnitureService;
        private readonly IServiceService _serviceService;
        private readonly IUserService _userService;

        public ReportScreen(ICondominiumService condominiumService, IBlockService blockService, IHousingEntityService housingEntityService,
            ITenantService tenantService, IIncidentService incidenceService, IInvoiceService invoiceService, IFurnitureService furnitureService,
            IServiceService serviceService, IUserService userService)
        {
            InitializeComponent();
            _condominiumService = condominiumService;
            _blockService = blockService;
            _housingEntityService = housingEntityService;
            _tenantService = tenantService;
            _incidenceService = incidenceService;
            _invoiceService = invoiceService;
            _furnitureService = furnitureService;
            _serviceService = serviceService;
            _userService = userService;
        }

        private void ReportScreen_Load(object sender, EventArgs e)
        {
            SetComboBoxForTypes();
        }

        private void SetComboBoxForTypes()
        {
            var serviceTypes = new List<string> { "-- Seleccione una entidad --",
                "Condominio", "Bloque", "Vivienda", "Inquilino", "Incidencia",
                "Factura", "Mobiliario", "Servicios", "Usuarios"};
            ReportComboBxEntities.DataSource = serviceTypes;
            ReportComboBxEntities.DropDownStyle = ComboBoxStyle.DropDownList;
            ReportComboBxEntities.SelectedIndex = 0;
        }

        private async void GenerateReportBTN_Click(object sender, EventArgs e)
        {
            if (!FormIsCorrect())
            {
                MessageBox.Show("Debe de seleccionar una opcion valida.");
                return;
            }

            try
            {
                switch (ReportComboBxEntities.SelectedIndex)
                {
                    case 1:
                        await ShowReportAsync("Presentation/Reports/CondominiumReport.frx",
                            await _condominiumService.GetAllCondominiumsAsync(),
                            "Condominium");
                        break;

                    case 2:
                        await ShowReportAsync("Presentation/Reports/BlockReport.frx",
                            await _blockService.GetAllBlocksAsync(),
                            "Block");
                        break;

                    case 3:
                        await ShowReportAsync("Presentation/Reports/HousingReport.frx",
                            await _housingEntityService.GetAllHousingsAsync(),
                            "Housing");
                        break;

                    case 4:
                        await ShowReportAsync("Presentation/Reports/TenantReport.frx",
                            await _tenantService.GetAllAsync(),
                            "Housing");
                        break;

                    case 5:
                        await ShowReportAsync("Presentation/Reports/IncidenceReport.frx",
                            await _incidenceService.GetAllAsync(),
                            "Incidence");
                        break;

                    case 6:
                        await ShowReportAsync("Presentation/Reports/InvoiceReport.frx",
                            await _invoiceService.GetAllAsync(),
                            "Invoice");
                        break;

                    case 7:
                        await ShowReportAsync("Presentation/Reports/FurnitureReport.frx",
                            await _furnitureService.GetAllFurnituresAsync(),
                            "Furniture");
                        break;

                    case 8:
                        await ShowReportAsync("Presentation/Reports/ServiceReport.frx",
                            await _serviceService.GetAllAsync(),
                            "Service");
                        break;

                    case 9:
                        await ShowReportAsync("Presentation/Reports/UserReport.frx",
                            await _userService.GetAllAsync(),
                            "User");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generando reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CleanForm();
            }
        }

        private Task ShowReportAsync<T>(string reportPath, IEnumerable<T> data, string dataName)
        {
            var report = new Report();
            report.Load(reportPath);
            report.RegisterData(data, dataName);

            var viewer = new ReportViewerForm(report);
            viewer.Show();

            return Task.CompletedTask;
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
