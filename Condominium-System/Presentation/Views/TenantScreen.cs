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
    public partial class TenantScreen : Form
    {

        private readonly ITenantService _tenantService;
        private readonly IHousingEntityService _housingEntityService;        

        User currentUser;
        public TenantScreen(ITenantService tenantService, IHousingEntityService housingEntityService)
        {
            InitializeComponent();
            _tenantService = tenantService;
            _housingEntityService = housingEntityService;
            currentUser = Session.CurrentUser;
        
        }

        private async void TenantScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureHousingColumns();
            await LoadDataToDataGrid();
            await LoadHousesIntoComboBox();
            SetComboBoxForSexs();
        }
        private void SetComboBoxForSexs()
        {
            var userTypes = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "-- Seleccione un sexo --"),
                new KeyValuePair<int, string>(1, "Masculino"),
                new KeyValuePair<int, string>(2, "Femenino")
            };

            TenantCBSexs.DataSource = userTypes;
            TenantCBSexs.DisplayMember = "Value";
            TenantCBSexs.ValueMember = "Key";
            TenantCBSexs.DropDownStyle = ComboBoxStyle.DropDownList;
            TenantCBSexs.SelectedIndex = 0;
        }

        private async Task LoadHousesIntoComboBox()
        {
            try
            {
                var houses = await _housingEntityService.GetAllHousingsAsync();

                TenantCBHouses.DisplayMember = "Code";
                TenantCBHouses.ValueMember = "Id";
                TenantCBHouses.DataSource = houses;

                var placeholder = new Housing { Id = 0, Code = "-- Seleccione una vivienda --" };
                var listWithPlaceholder = new List<Housing> { placeholder };
                listWithPlaceholder.AddRange(houses);
                TenantCBHouses.DataSource = listWithPlaceholder;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando las viviendas: {ex.Message}");
            }

        }

        private async Task LoadDataToDataGrid()
        {
            try
            {
                var listTenant = await _tenantService.GetAllAsync();
                var bindingList = new BindingList<Tenant>((List<Tenant>)(IEnumerable<Tenant>)listTenant);
                var source = new BindingSource(bindingList, null);
                TenantDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando inquilinos: {ex.Message}");
            }
        }

        private void ConfigureHousingColumns()
        {

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 105
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "Nombre",
                Name = "FirstNameColumn",
                Width = 150
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Apellido",
                Name = "LastNameColumn",
                Width = 180
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DocumentNumber",
                HeaderText = "Cantidad de habitaciones",
                Name = "DocumentNumberColumn",
                Width = 200
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Numero de telefono",
                Name = "PhoneNumberColumn",
                Width = 160
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender",
                HeaderText = "Sexo",
                Name = "GenderColumn",
                Width = 155
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HousingId",
                HeaderText = "Identificacion de la vivienda",
                Name = "HousingIdColumn",
                Width = 155
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(TenantDTGData);
        }
    }
}
