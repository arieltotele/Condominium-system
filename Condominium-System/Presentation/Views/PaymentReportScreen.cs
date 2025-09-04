using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
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
    public partial class PaymentReportScreen : Form
    {
        ITenantService _tenantService;
        IHousingEntityService _housingService;
        IReceiptService _receiptService;
        IPaymentService _paymentService;
        IServiceProvider _serviceProvider;
        User? _currentUser;
        

        Tenant tenanToGenerateReport = null;

        public PaymentReportScreen(ITenantService tenantService, IHousingEntityService housingService,
            IReceiptService receiptService, IPaymentService paymentService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _tenantService = tenantService;
            _housingService = housingService;
            _receiptService = receiptService;
            _paymentService = paymentService;
            _serviceProvider = serviceProvider;
        }

        private void PaymentReportScreen_Load(object sender, EventArgs e)
        {
            SetSearchTextBoxStyle();
        }

        private void SetSearchTextBoxStyle()
        {
            PaymentReportTBPropietaryDocument.Text = "Ingrese el documento del propietario";
            PaymentReportTBPropietaryDocument.ForeColor = SystemColors.GrayText;
            PaymentReportTBPropietaryDocument.Enter += (s, e) =>
            {
                if (PaymentReportTBPropietaryDocument.Text == "Ingrese el documento del propietario")
                {
                    PaymentReportTBPropietaryDocument.Text = "";
                    PaymentReportTBPropietaryDocument.ForeColor = SystemColors.WindowText;
                }
            };
            PaymentReportTBPropietaryDocument.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(PaymentReportTBPropietaryDocument.Text))
                {
                    PaymentReportTBPropietaryDocument.Text = "Ingrese el documento del propietario";
                    PaymentReportTBPropietaryDocument.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private async void SearchPropietaryBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormIsCorrect())
                {
                    MessageBox.Show("Por favor ingrese un documento válido de 11 dígitos.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ MOSTRAR LOADING
                //.Enabled = false;
                //SearchPropietaryBTN.Text = "Buscando...";

                string documentNumber = PaymentReportTBPropietaryDocument.Text.Trim();

                // ✅ BUSCAR RECIBOS PAGADOS
                var paidReceipts = await _receiptService.GetPaidReceiptsByTenantDocumentAsync(documentNumber);

                // ✅ MOSTRAR RESULTADOS
                if (paidReceipts.Any())
                {
                    decimal totalPaid = paidReceipts.Sum(r => r.AmountPaid);
                    int receiptCount = paidReceipts.Count();

                    //receipstFound = true;
                    tenanToGenerateReport = (await _tenantService.SearchTenantsAsync(documentNumber)).FirstOrDefault();

                    MessageBox.Show(
                        $"✅ El propietario tiene {receiptCount} recibos pagados.\n" +
                        $"💰 Total pagado: {totalPaid:C2}\n\n",
                        "Reporte de Pagos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // ✅ OPCIONAL: MOSTRAR EN UN DATA GRID
                    //LoadPaidReceiptsToGrid(paidReceipts);
                }
                else
                {
                    MessageBox.Show(
                        "El propietario no tiene recibos pagados en el sistema.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    ClearForm();
                    receipstFound = false;
                    tenanToGenerateReport = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar recibos pagados: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // ✅ RESTAURAR BOTÓN
                //SearchPropietaryBTN.Enabled = true;
                //SearchPropietaryBTN.Text = "Buscar Propietario";
            }
        }

        public bool FormIsCorrect()
        {
            bool isDocumentValid = PaymentReportTBPropietaryDocument.Text != "Ingrese el documento del propietario" &&
                                  !string.IsNullOrWhiteSpace(PaymentReportTBPropietaryDocument.Text);

            bool isDocumentLengthValid = PaymentReportTBPropietaryDocument.Text.Length == 11;


            return isDocumentValid && isDocumentLengthValid;
        }

        private void ClearForm()
        {
            PaymentReportTBPropietaryDocument.Clear();
        }
    }
}
