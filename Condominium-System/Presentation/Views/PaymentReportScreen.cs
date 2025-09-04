using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using FastReport;
using FastReport.Data;
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


        IEnumerable<Tenant> tenanToGenerateReport = null;
        IEnumerable<Receipt> receiptsToGenerateReport = null;

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

                string documentNumber = PaymentReportTBPropietaryDocument.Text.Trim();

                var paidReceipts = await _receiptService.GetPaidReceiptsByTenantDocumentAsync(documentNumber);

                if (paidReceipts.Any())
                {
                    decimal totalPaid = paidReceipts.Sum(r => r.AmountPaid);
                    int receiptCount = paidReceipts.Count();

                    receiptsToGenerateReport = paidReceipts;

                    tenanToGenerateReport = await _tenantService.SearchTenantsAsync(documentNumber);

                    MessageBox.Show(
                        $"✅ El propietario tiene {receiptCount} recibos pagados.\n" +
                        $"💰 Total pagado: {totalPaid:C2}\n\n",
                        "Reporte de Pagos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

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
                    tenanToGenerateReport = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar recibos pagados: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneratePaymentReportBTN_Click(object sender, EventArgs e)
        {
            try
            {

                if (!FormIsCorrect())
                {
                    MessageBox.Show("Por favor ingrese un documento válido de 11 dígitos.",
                                  "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IEnumerable<Receipt> receipts = receiptsToGenerateReport;

                if (receipts == null || !receipts.Any())
                {
                    MessageBox.Show("No se encontraron los recibos para el informe. Asegúrese de haber buscado primero.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalPaid = receipts.Sum(r => r.AmountPaid);

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/PaymentsCompletedReport.frx");

                report.RegisterData(receipts.ToList(), "Receipts");
                report.GetDataSource("Receipts").Enabled = true;

                report.RegisterData(tenanToGenerateReport.ToList(), "Tenants");
                report.GetDataSource("Tenants").Enabled = true;

                report.SetParameterValue("Total", totalPaid);


                var viewer = new ReportViewerForm(report);
                viewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generando reporte: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
