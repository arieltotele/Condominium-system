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
    public partial class PaymentScreen : Form
    {
        ITenantService _tenantService;
        IHousingEntityService _housingService;
        IReceiptService _receiptService;
        IPaymentService _paymentService;
        User? _currentUser;

        public PaymentScreen(ITenantService tenantService, IHousingEntityService housingService,
            IReceiptService receiptService, IPaymentService paymentService)
        {
            InitializeComponent();
            _tenantService = tenantService;
            _housingService = housingService;
            _receiptService = receiptService;
            _paymentService = paymentService;
            _currentUser = Session.CurrentUser;
        }

        private void PaymentScreen_Load(object sender, EventArgs e)
        {
            SetSearchTextBoxStyleAndBehavior();
            ManageInitialBehaviorInCondominiumCB();
        }

        private void SetSearchTextBoxStyleAndBehavior()
        {
            PaymentTBPropietaryDocument.Text = "Ingrese el documento del propietario";
            PaymentTBPropietaryDocument.ForeColor = SystemColors.GrayText;
            PaymentTBPropietaryDocument.Enter += (s, e) =>
            {
                if (PaymentTBPropietaryDocument.Text == "Ingrese el documento del propietario")
                {
                    PaymentTBPropietaryDocument.Text = "";
                    PaymentTBPropietaryDocument.ForeColor = SystemColors.WindowText;
                }
            };
            PaymentTBPropietaryDocument.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(PaymentTBPropietaryDocument.Text))
                {
                    PaymentTBPropietaryDocument.Text = "Ingrese el documento del propietario";
                    PaymentTBPropietaryDocument.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void ManageInitialBehaviorInCondominiumCB()
        {
            PaymentCBHouse.Enabled = false;
        }

        private async void SearchByDocumentBTN_Click(object sender, EventArgs e)
        {
            await LoadHousingsByTenantDocumentAsync(PaymentTBPropietaryDocument.Text);
        }

        private async Task LoadHousingsByTenantDocumentAsync(string documentNumber)
        {
            try
            {
                PaymentCBHouse.DataSource = null;
                PaymentCBHouse.Items.Clear();
                PaymentCBHouse.Enabled = false;

                if (string.IsNullOrWhiteSpace(documentNumber))
                {
                    PaymentCBHouse.Text = "Ingrese número de documento";
                    return;
                }

                PaymentCBHouse.Text = "Buscando...";

                // ✅ USAR SearchTenantsAsync que ya existe
                var tenants = await _tenantService.SearchTenantsAsync(documentNumber.Trim());

                // Filtrar tenants activos y agrupar por vivienda
                var activeTenants = tenants.Where(t => t.IsActive).ToList();

                if (!activeTenants.Any())
                {
                    PaymentCBHouse.Text = "No se encontraron inquilinos activos";
                    return;
                }

                // Obtener viviendas únicas de los tenants encontrados
                var housingIds = activeTenants
                    .Where(t => t.HousingId > 0)
                    .Select(t => t.HousingId)
                    .Distinct()
                    .ToList();

                if (!housingIds.Any())
                {
                    PaymentCBHouse.Text = "No se encontraron viviendas";
                    return;
                }

                // Cargar información completa de las viviendas
                var housings = new List<Housing>();
                foreach (var housingId in housingIds)
                {
                    var housing = await _housingService.GetHousingByIdAsync(housingId);
                    if (housing != null)
                    {
                        housings.Add(housing);
                    }
                }

                if (!housings.Any())
                {
                    PaymentCBHouse.Text = "No se encontraron viviendas";
                    return;
                }

                // Configurar combobox
                var housingList = housings.Select(h => new
                {
                    h.Id,
                    DisplayText = $"{h.Code} - {h.Block?.Name} - {h.Block?.Condominium?.Name}"
                }).ToList();

                PaymentCBHouse.DataSource = housingList;
                PaymentCBHouse.DisplayMember = "DisplayText";
                PaymentCBHouse.ValueMember = "Id";
                PaymentCBHouse.Enabled = true;
            }
            catch (Exception ex)
            {
                PaymentCBHouse.Text = "Error en la búsqueda";
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchPendingReceiptsBTN_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {

            }
            else
            {
                MessageBox.Show("Por favor, complete correctamente el formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public bool FormIsCorrect()
        {
            bool isHouseValid = int.TryParse(PaymentCBHouse.SelectedValue?.ToString(), out int condoId) && condoId != 0;

            return !(
               string.IsNullOrEmpty(PaymentTBPropietaryDocument.Text) ||
               !isHouseValid
           );
        }
    }
}
