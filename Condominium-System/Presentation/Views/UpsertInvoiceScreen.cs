using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
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
    public partial class UpsertInvoiceScreen : Form
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepositoryNoId<HousingService> _housingServiceRepository;

        private readonly User currentUser;

        public bool IsEditMode { get; set; } = false;

        public UpsertInvoiceScreen(IInvoiceService invoiceService, ITenantService tenantService,
            IServiceProvider serviceProvider, IRepositoryNoId<HousingService> housingServiceRepository)
        {
            InitializeComponent();
            _invoiceService = invoiceService;
            _tenantService = tenantService;
            _serviceProvider = serviceProvider;
            currentUser = Session.CurrentUser;
            _housingServiceRepository = housingServiceRepository;
        }

        private async void UpsertInvoiceScreen_Load(object sender, EventArgs e)
        {
            await SetComboBoxForTenants();

            if (IsEditMode)
            {
                LoadDataIfIsToUpdate();
            }
        }

        private async Task SetComboBoxForTenants()
        {
            var tenants = (await _tenantService.GetAllAsync()).ToList();

            tenants.Insert(0, new Tenant
            {
                Id = 0,
                FirstName = "-- Seleccione un condominio --"
            });

            UpsertInvoiceComboBxTenants.DataSource = tenants;
            UpsertInvoiceComboBxTenants.DisplayMember = "FirstName";
            UpsertInvoiceComboBxTenants.ValueMember = "Id";
            UpsertInvoiceComboBxTenants.SelectedIndex = 0;
        }

        private async void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.InvoiceToUpsert != null)
            {
                var InvoiceToUpdate = Session.InvoiceToUpsert;

                UpsertInvoiceTBDescription.Text = InvoiceToUpdate.Detail;
                UpsertInvoiceTBTotalAmount.Text = InvoiceToUpdate.TotalAmount.ToString();

                await SetComboBoxForTenants();
                UpsertInvoiceComboBxTenants.SelectedValue = InvoiceToUpdate.TenantId;

            }
        }

        private void UpsertLBLBTN_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditIncidence(); }
            else { SaveIncidence(); }
        }

        private async void EditIncidence()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var InvoiceToUpdate = Session.InvoiceToUpsert;

                    if (InvoiceToUpdate != null)
                    {
                        InvoiceToUpdate.Detail = UpsertInvoiceTBDescription.Text;
                        InvoiceToUpdate.TotalAmount = UpsertInvoiceTBTotalAmount.Text;
                        InvoiceToUpdate.TenantId = (int)UpsertInvoiceComboBxTenants.SelectedValue;
                        InvoiceToUpdate.UpdatedAt = DateTime.Now;

                        await _invoiceService.UpdateAsync(InvoiceToUpdate);

                        MessageBox.Show("La factura ha sido actualizado con exito");
                        CleanForm();
                        ((InvoiceScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Factura no encontrada.");
                        CleanForm();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveIncidence()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var newInvoice = new Invoice()
                    {
                        Detail = UpsertInvoiceTBDescription.Text,
                        TotalAmount = UpsertInvoiceTBTotalAmount.Text,
                        TenantId = (int)UpsertInvoiceComboBxTenants.SelectedValue,
                        Author = currentUser.Username
                    };

                    await _invoiceService.CreateAsync(newInvoice);

                    MessageBox.Show("La factura ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    ((InvoiceScreen)this.Owner).LoadDataToDataGrid();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        public bool FormIsCorrect()
        {
            bool isInvoiceValid = int.TryParse(UpsertInvoiceComboBxTenants.SelectedValue?.ToString(), out int invoiceId) && invoiceId != 0;

            return !(
               string.IsNullOrEmpty(UpsertInvoiceTBDescription.Text) ||
               string.IsNullOrEmpty(UpsertInvoiceTBTotalAmount.Text) ||
               !isInvoiceValid
           );
        }

        private async void CleanForm()
        {
            UpsertInvoiceTBDescription.Clear();
            UpsertInvoiceTBTotalAmount.Clear();

            if (UpsertInvoiceComboBxTenants.Items.Count > 0)
                UpsertInvoiceComboBxTenants.SelectedIndex = 0;
        }

        private async void UpsertInvoiceComboBxTenants_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpsertInvoiceComboBxTenants.SelectedValue is int tenantId && tenantId > 0)
            {
                try
                {
                    decimal totalServices = await _tenantService.CalculateTotalServicesByTenantAsync(tenantId);
                    UpsertInvoiceTBTotalAmount.Text = totalServices.ToString("N2");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error calculando servicios: {ex.Message}");
                    UpsertInvoiceTBTotalAmount.Text = "0.00";
                }
            }
            else
            {
                UpsertInvoiceTBTotalAmount.Text = "0.00";
            }
        }
    }
}
