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
    public partial class IncidenceScreen : Form
    {
        private readonly IIncidentService _incidentService;
        private readonly ITenantService _tenantService;

        User currentUser;

        public IncidenceScreen(IIncidentService incidentService, ITenantService tenantService)
        {
            InitializeComponent();
            _incidentService = incidentService;
            _tenantService = tenantService;            
            currentUser = Session.CurrentUser;
        }

        private async void IncidenceScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureIncidenceColumns();
            await LoadDataToDataGrid();
        }

        private async Task LoadDataToDataGrid()
        {
            try
            {
                var listIncidence = await _incidentService.GetAllAsync();
                var bindingList = new BindingList<Incident>((List<Incident>)(IEnumerable<Incident>)listIncidence);
                var source = new BindingSource(bindingList, null);
                IncidenceDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando las incidencias: {ex.Message}");
            }
        }
        private void ConfigureIncidenceColumns()
        {

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 110
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Fecha",
                Name = "DateColumn",
                Width = 220
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Descripción",
                Name = "DescriptionColumn",
                Width = 280
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenantId",
                HeaderText = "Documentacion del inquilino",
                Name = "TenantIdColumn",
                Width = 300
            });            
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(IncidenceDTGData);
        }
    }
}
