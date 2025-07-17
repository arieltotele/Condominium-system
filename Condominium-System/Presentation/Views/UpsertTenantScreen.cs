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
    public partial class UpsertTenantScreen : Form
    {

        private readonly ITenantService _tenantService;
        private readonly IHousingEntityService _housingEntityService;
        private readonly IServiceProvider _serviceProvider;
        User currentUser;

        public bool IsEditMode { get; set; } = false;

        public UpsertTenantScreen(ITenantService tenantService, IHousingEntityService housingEntityService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _tenantService = tenantService;
            _housingEntityService = housingEntityService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void UpsertTenantScreen_Load(object sender, EventArgs e)
        {
            await LoadHousesIntoComboBox();
            SetComboBoxForSexs();

            if (IsEditMode)
            {
                LoadDataIfIsToUpdate();
            }            
        }

        private async void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.TenantToUpsert != null)
            {
                var TenantToUpdate = Session.TenantToUpsert;

                TenantTBName.Text = TenantToUpdate.FirstName;
                TenantTBLastname.Text = TenantToUpdate.LastName;
                TenantMskTDocumentation.Text = TenantToUpdate.DocumentNumber;
                TenantMskTPhoneNumber.Text = TenantToUpdate.PhoneNumber;
                TenantDTPBirthdate.Value = TenantToUpdate.BirthDate;
                TenantCBSexs.Text = TenantToUpdate.Gender;

                await LoadHousesIntoComboBox();

                TenantCBHouses.SelectedValue = TenantToUpdate.HousingId;
            }
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

        private void UpsertPNLBTN_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditTenant(); }
            else { SaveTenant(); }
        }

        private async void EditTenant()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var TenantToUpdate = Session.TenantToUpsert;

                    if (TenantToUpdate != null)
                    {

                        TenantToUpdate.FirstName = TenantTBName.Text.Trim().ToUpper();
                        TenantToUpdate.LastName = TenantTBLastname.Text.Trim().ToUpper();
                        TenantToUpdate.DocumentNumber = TenantMskTDocumentation.Text;
                        TenantToUpdate.PhoneNumber = TenantMskTPhoneNumber.Text;
                        TenantToUpdate.BirthDate = TenantDTPBirthdate.Value;
                        TenantToUpdate.Gender = TenantCBSexs.Text;
                        TenantToUpdate.HousingId = (int)TenantCBHouses.SelectedValue;

                        TenantToUpdate.UpdatedAt = DateTime.Now;

                        await _tenantService.UpdateAsync(TenantToUpdate);

                        MessageBox.Show("El inquilino ha sido actualizado con exito");
                        CleanForm();
                        ((TenantScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Inquilino no encontrado.");
                        CleanForm();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando inquilino: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveTenant()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewTenant = new Tenant()
                    {
                        FirstName = TenantTBName.Text.Trim().ToUpper(),
                        LastName = TenantTBLastname.Text.Trim().ToUpper(),
                        DocumentNumber = TenantMskTDocumentation.Text,
                        PhoneNumber = TenantMskTPhoneNumber.Text,
                        BirthDate = TenantDTPBirthdate.Value,
                        Gender = TenantCBSexs.Text,
                        EntryDate = DateTime.Now,
                        HousingId = (int)TenantCBHouses.SelectedValue,

                        Author = currentUser.Username
                    };

                    await _tenantService.CreateAsync(NewTenant);

                    MessageBox.Show("El inquilino ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    ((TenantScreen)this.Owner).LoadDataToDataGrid();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando inquilino: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void CleanForm()
        {
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
    }
}
