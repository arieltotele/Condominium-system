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
    public partial class AddPaymentScreen : Form
    {
        IReceiptService _receiptService;
        IPaymentService _paymentService;
        IServiceProvider _serviceProvider;

        Receipt? currentReceipt;
        User? currentUser;
        Tenant? currentTenant;
        public AddPaymentScreen(IPaymentService paymentService, IReceiptService receiptService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _paymentService = paymentService;
            _receiptService = receiptService;
            _serviceProvider = serviceProvider;

            currentUser = Session.CurrentUser;
            currentReceipt = Session.CurrentReceipt;
            currentTenant = Session.TenantToUpsert;
        }

        private async void AddPaymentScreen_Load(object sender, EventArgs e)
        {
            SetComboBoxForTypeOfUsers();
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
                // Deshabilitar botón durante el proceso
                //PaymentSaveBTN.Enabled = false;
                PaymentSaveBTNLBL.Text = "Guardando...";

                // Validar que el monto no exceda el saldo pendiente
                decimal amountToPay;
                if (!decimal.TryParse(PaymentTBAmount.Text, out amountToPay) || amountToPay <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal remainingAmount = currentReceipt.Amount - currentReceipt.AmountPaid;
                if (amountToPay > remainingAmount)
                {
                    MessageBox.Show($"El monto a pagar (${amountToPay}) excede el saldo pendiente (${remainingAmount}).",
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
              
                await ((PaymentScreen)this.Owner).LoadHousingsByTenantDocumentAsync(currentTenant!.DocumentNumber);
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
            if (currentReceipt != null && decimal.TryParse(PaymentTBAmount.Text, out decimal amount))
            {
                decimal remainingAmount = currentReceipt.Amount - currentReceipt.AmountPaid;

                if (amount > remainingAmount)
                {
                    PaymentTBAmount.ForeColor = Color.Red;
                    ToolTip toolTip = new ToolTip();
                    toolTip.Show($"Máximo permitido: ${remainingAmount}", PaymentTBAmount, 0, -20, 2000);
                }
                else
                {
                    PaymentTBAmount.ForeColor = SystemColors.WindowText;
                }
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

            bool isAmountValid = decimal.TryParse(PaymentTBAmount.Text, out decimal amount) && amount > 0;

            bool isDetailValid = !string.IsNullOrWhiteSpace(PaymentCBDetail.Text);

            return isMethodValid && isAmountValid && isDetailValid;
        }

        private void ClearFields()
        {
            PaymentTBAmount.Text = string.Empty;
            PaymentCBDetail.Text = string.Empty;
            PaymentCBPayMethod.SelectedIndex = 0;
        }
    }
}
