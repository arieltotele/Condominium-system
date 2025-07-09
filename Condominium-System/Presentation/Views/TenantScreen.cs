using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using System.ComponentModel;

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

                var placeholder = new Housing { Id = 0, Code = "-- Seleccione una vivienda --" };
                var listWithPlaceholder = new List<Housing> { placeholder };
                listWithPlaceholder.AddRange(houses);

                TenantCBHouses.DisplayMember = "Code";
                TenantCBHouses.ValueMember = "Id";
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
                HeaderText = "Numero de teléfono",
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
                HeaderText = "Identificación de la vivienda",
                Name = "HousingIdColumn",
                Width = 155
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(TenantDTGData);
        }

        private async void TenantPNLBTNCreate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewTenant = new Tenant()
                    {
                        FirstName = TenantTBName.Text,
                        LastName = TenantTBLastname.Text,
                        DocumentNumber = TenantMskTDocumentation.Text,
                        PhoneNumber = TenantMskTPhoneNumber.Text,
                        BirthDate = TenantDTPBirthdate.Value,
                        Gender = TenantCBSexs.Text,
                        EntryDate = DateTime.Now,
                        HousingId = (int)TenantCBHouses.SelectedValue,

                        Author = currentUser.Username
                    };

                    await _tenantService.CreateAsync(NewTenant);

                    MessageBox.Show("El inquilino ha sido creado con exito.");
                    CleanForm();
                    await LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando la vivienda: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private void CleanForm()
        {
            TenantTBID.Clear();
            TenantTBName.Clear();
            TenantTBLastname.Clear();
            TenantMskTDocumentation.Clear();
            TenantMskTPhoneNumber.Clear();
            TenantDTPBirthdate.Value = DateTime.Today;

            if (TenantCBSexs.Items.Count > 0)
                TenantCBSexs.SelectedIndex = 0;

            if (TenantCBHouses.Items.Count > 0)
                TenantCBHouses.SelectedIndex = 0;
        }

        public bool FormIsCorrect()
        {
            bool isSexValid = int.TryParse(TenantCBSexs.SelectedValue?.ToString(), out int sexId) && sexId != 0;
            bool isHouseValid = int.TryParse(TenantCBHouses.SelectedValue?.ToString(), out int houseId) && houseId != 0;

            return !(
               string.IsNullOrEmpty(TenantTBName.Text) ||
               string.IsNullOrEmpty(TenantTBLastname.Text) ||
               string.IsNullOrEmpty(TenantDTPBirthdate.Text) ||
               string.IsNullOrEmpty(TenantMskTDocumentation.Text) ||
               string.IsNullOrEmpty(TenantMskTPhoneNumber.Text) ||
               !isSexValid ||
               !isHouseValid ||
               TenantMskTPhoneNumber.Text.Trim().Length != 10 ||
               TenantMskTDocumentation.Text.Trim().Length != 11
           );
        }

        public bool FormIsCorrectToUpdate()
        {
            bool isSexValid = int.TryParse(TenantCBSexs.SelectedValue?.ToString(), out int sexId) && sexId != 0;
            bool isHouseValid = int.TryParse(TenantCBHouses.SelectedValue?.ToString(), out int houseId) && houseId != 0;

            return !(
               string.IsNullOrEmpty(TenantTBID.Text) ||
               string.IsNullOrEmpty(TenantTBName.Text) ||
               string.IsNullOrEmpty(TenantTBLastname.Text) ||
               string.IsNullOrEmpty(TenantDTPBirthdate.Text) ||
               string.IsNullOrEmpty(TenantMskTDocumentation.Text) ||
               string.IsNullOrEmpty(TenantMskTPhoneNumber.Text) ||
               !isSexValid ||
               !isHouseValid ||
               TenantMskTDocumentation.Text.Trim().Length != 10 ||
               TenantMskTPhoneNumber.Text.Trim().Length != 11
           );
        }

        private async void TenantPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TenantTBID.Text))
            {
                try
                {
                    var TenantFound = await _tenantService.GetByIdAsync(Int32.Parse(TenantTBID.Text));
                    if (TenantFound != null)
                    {
                        TenantTBName.Text = TenantFound.FirstName;
                        TenantTBLastname.Text = TenantFound.LastName;
                        TenantMskTDocumentation.Text = TenantFound.DocumentNumber;
                        TenantMskTPhoneNumber.Text = TenantFound.PhoneNumber;
                        TenantDTPBirthdate.Value = TenantFound.BirthDate;
                        TenantCBSexs.Text = TenantFound.Gender;

                        await LoadHousesIntoComboBox();

                        TenantCBHouses.SelectedValue = TenantFound.HousingId;
                    }
                    else
                    {
                        MessageBox.Show("Inquilino no encontrado.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando al inquilino: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe de estar lleno correctamente.");
            }
        }
    }
}
