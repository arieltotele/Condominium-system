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
        public ReportScreen(ICondominiumService condominiumService)
        {
            InitializeComponent();
            _condominiumService = condominiumService;
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
                    var a = ReportComboBxEntities.SelectedIndex;
                    switch (ReportComboBxEntities.SelectedIndex)
                    {
                        case 1:
                            var condominiums = await _condominiumService.GetAllCondominiumsAsync();
                                                        
                            report.Load("Presentation/Reports/CondominiumReport.frx");
                            report.RegisterData(condominiums, "Condominium");

                            var viewer = new ReportViewerForm(report);
                            viewer.Show();
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
