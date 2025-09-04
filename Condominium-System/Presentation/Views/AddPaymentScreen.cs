using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System.Presentation.Views
{
    public partial class AddPaymentScreen : Form
    {
        IReceiptService _receiptService;
        IPaymentService _paymentService;
        IServiceProvider _serviceProvider;

        Receipt? currentReceipt;
        User? currentUser;
        Tenant? currentTenant;
        IEnumerable<Receipt> receiptsToPaid;
        private bool _isFormatting = false;

        public AddPaymentScreen(IPaymentService paymentService, IReceiptService receiptService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _paymentService = paymentService;
            _receiptService = receiptService;
            _serviceProvider = serviceProvider;

            currentUser = Session.CurrentUser;
            currentReceipt = Session.CurrentReceipt;
            currentTenant = Session.TenantToUpsert;
            receiptsToPaid = Session.ReceiptsToPaid!;
        }

        private async void AddPaymentScreen_Load(object sender, EventArgs e)
        {
            SetComboBoxForTypeOfUsers();
            await CheckAndDisplayLateFee();
            LoadPendingAmount();
            UIUtils.ConfigureFormSize(this, true);
            //ForceLateFeeForTesting();
        }

        private void LoadPendingAmount()
        {
            if (currentReceipt != null)
            {
                decimal remainingAmount = currentReceipt.Amount - currentReceipt.AmountPaid;
                PaymentTBAmount.Text = FormatCurrency(remainingAmount);
            }
        }

        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("C0", CultureInfo.CurrentCulture);
        }

        private decimal ParseCurrency(string currencyText)
        {
            if (string.IsNullOrWhiteSpace(currencyText))
                return 0;

            string cleanText = currencyText.Replace("$", "").Replace(",", "").Trim();

            if (decimal.TryParse(cleanText, out decimal result))
            {
                return result;
            }
            return 0;
        }

        private async Task CheckAndDisplayLateFee()
        {
            if (currentReceipt == null) return;

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var lateFeeService = scope.ServiceProvider.GetRequiredService<ILateFeeService>();

                    var lateFeeAmount = await lateFeeService.CalculateLateFeeAsync(currentReceipt.Id);

                    if (lateFeeAmount > 0)
                    {
                        MessageBox.Show($"⚠️ Este recibo tiene una mora pendiente de ${lateFeeAmount}\n" +
                                       $"La mora se aplicará automáticamente al registrar el pago.",
                                       "Mora Pendiente",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);

                        UpdateUIShowingLateFee(lateFeeAmount);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar mora: {ex.Message}");
            }
        }

        private void UpdateUIShowingLateFee(int lateFeeAmount)
        {
            var lateFeeLabel = new Label()
            {
                Text = $"Mora pendiente: ${lateFeeAmount:N0}",
                ForeColor = Color.Red,
                Font = new Font(this.Font, FontStyle.Bold),
                Location = new Point(20, 100),
                AutoSize = true
            };

            this.Controls.Add(lateFeeLabel);

            if (currentReceipt != null)
            {
                decimal totalAmount = currentReceipt.Amount + lateFeeAmount;
                decimal remainingAmount = totalAmount - currentReceipt.AmountPaid;

                PaymentTBAmount.Text = FormatCurrency(remainingAmount);
            }
        }

        private void SetComboBoxForTypeOfUsers()
        {
            var payMethods = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "-- Seleccione un metodo de pago --"),
                new KeyValuePair<int, string>(1, "Efectivo"),
                new KeyValuePair<int, string>(2, "Tarjeta"),
                new KeyValuePair<int, string>(3, "Transferencia"),
                new KeyValuePair<int, string>(4, "Otro")
            };

            PaymentCBPayMethod.DataSource = payMethods;
            PaymentCBPayMethod.DisplayMember = "Value";
            PaymentCBPayMethod.ValueMember = "Key";
            PaymentCBPayMethod.SelectedIndex = 0;
        }

        private async void PaymentSaveBTN_Click(object sender, EventArgs e)
        {
            if (!IsFormCorrect())
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currentReceipt == null)
            {
                MessageBox.Show("No se ha seleccionado un recibo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                PaymentSaveBTNLBL.Text = "Guardando...";

                decimal amountToPay = ParseCurrency(PaymentTBAmount.Text);

                if (amountToPay <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var scope = _serviceProvider.CreateScope())
                {
                    var lateFeeService = scope.ServiceProvider.GetRequiredService<ILateFeeService>();
                    bool lateFeeApplied = await lateFeeService.ApplyLateFeeIfNeededAsync(currentReceipt.Id);

                    if (lateFeeApplied)
                    {
                        currentReceipt = await _receiptService.GetReceiptByIdAsync(currentReceipt.Id);

                        MessageBox.Show($"✅ Se aplicó mora de ${currentReceipt.LateFee:N0} al recibo",
                                       "Mora Aplicada",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                }

                decimal remainingAmount = currentReceipt.Amount - currentReceipt.AmountPaid;
                if (amountToPay > remainingAmount)
                {
                    MessageBox.Show($"El monto a pagar (${amountToPay:N0}) excede el saldo pendiente (${remainingAmount:N0}).",
                                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string paymentMethod = GetPaymentMethodText(PaymentCBPayMethod.SelectedValue);

                var payment = new Payment
                {
                    Date = DateTime.Now,
                    AmountPaid = (int)amountToPay,
                    PaymentMethod = paymentMethod,
                    Detail = PaymentCBDetail.Text,
                    ReceiptId = currentReceipt.Id,
                    Author = currentUser?.Username ?? "System",
                    CreatedAt = DateTime.Now,
                    IsActive = true
                };

                await _paymentService.CreatePaymentAsync(payment);

                MessageBox.Show("Pago registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                this.DialogResult = DialogResult.OK;

                ((PaymentScreen)this.Owner).SearchPendingReceipts(false);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PaymentSaveBTNLBL.Text = "Guardar";
            }
        }

        private void PaymentTBAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void PaymentTBAmount_TextChanged(object sender, EventArgs e)
        {
            if (_isFormatting) return;

            try
            {
                _isFormatting = true;

                if (string.IsNullOrWhiteSpace(PaymentTBAmount.Text))
                    return;

                int cursorPosition = PaymentTBAmount.SelectionStart;

                decimal currentValue = ParseCurrency(PaymentTBAmount.Text);

                PaymentTBAmount.Text = FormatCurrency(currentValue);

                PaymentTBAmount.SelectionStart = cursorPosition + (PaymentTBAmount.Text.Length - PaymentTBAmount.Text.Replace(",", "").Length);

                if (currentReceipt != null)
                {
                    decimal potentialLateFee = 0;

                    if (DateTime.Now > currentReceipt.DueDate && !currentReceipt.LateFeeApplied)
                    {
                        int daysLate = (DateTime.Now - currentReceipt.DueDate).Days;
                        decimal monthlyFee = currentReceipt.Amount * 0.05m;
                        int monthsLate = (int)Math.Ceiling(daysLate / 30.0);
                        potentialLateFee = (int)(monthlyFee * monthsLate);
                    }

                    decimal totalAmount = currentReceipt.Amount + potentialLateFee;
                    decimal remainingAmount = totalAmount - currentReceipt.AmountPaid;

                    if (currentValue > remainingAmount)
                    {
                        PaymentTBAmount.ForeColor = Color.Red;
                        ToolTip toolTip = new ToolTip();
                        toolTip.Show($"Máximo permitido: {FormatCurrency(remainingAmount)} (incluye mora potencial: {FormatCurrency(potentialLateFee)})",
                                   PaymentTBAmount, 0, -20, 2000);
                    }
                    else
                    {
                        PaymentTBAmount.ForeColor = SystemColors.WindowText;
                    }
                }
            }
            finally
            {
                _isFormatting = false;
            }
        }

        private void PaymentTBAmount_Enter(object sender, EventArgs e)
        {
            if (!_isFormatting)
            {
                decimal currentValue = ParseCurrency(PaymentTBAmount.Text);
                PaymentTBAmount.Text = currentValue.ToString("N0");
            }
        }

        private void PaymentTBAmount_Leave(object sender, EventArgs e)
        {
            if (!_isFormatting)
            {
                decimal currentValue = ParseCurrency(PaymentTBAmount.Text);
                PaymentTBAmount.Text = FormatCurrency(currentValue);
            }
        }

        private string GetPaymentMethodText(object selectedValue)
        {
            if (selectedValue == null) return "Otro";

            int methodId;
            if (int.TryParse(selectedValue.ToString(), out methodId))
            {
                return methodId switch
                {
                    1 => "Efectivo",
                    2 => "Tarjeta",
                    3 => "Transferencia",
                    4 => "Otro",
                    _ => "Otro"
                };
            }
            return "Otro";
        }

        private bool IsFormCorrect()
        {
            bool isMethodValid = PaymentCBPayMethod.SelectedValue != null &&
                                int.TryParse(PaymentCBPayMethod.SelectedValue.ToString(), out int methodId) &&
                                methodId != 0;

            decimal amount = ParseCurrency(PaymentTBAmount.Text);
            bool isAmountValid = amount > 0;

            bool isDetailValid = !string.IsNullOrWhiteSpace(PaymentCBDetail.Text);

            return isMethodValid && isAmountValid && isDetailValid;
        }

        private void ClearFields()
        {
            PaymentTBAmount.Text = string.Empty;
            PaymentCBDetail.Text = string.Empty;
            PaymentCBPayMethod.SelectedIndex = 0;
        }

        private void ForceLateFeeForTesting()
        {
            if (currentReceipt != null)
            {
                currentReceipt.DueDate = DateTime.Now.AddDays(-45);

                MessageBox.Show($"✅ Fecha forzada para testing: {currentReceipt.DueDate.ToShortDateString()}\n" +
                               $"El recibo ahora está vencido hace 45 días.",
                               "Testing - Mora Forzada",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay recibo seleccionado para forzar mora", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}