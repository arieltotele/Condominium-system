using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Condominium_System.Helpers.Status;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        IServiceProvider _serviceProvider;
        User? _currentUser;

        public PaymentScreen(ITenantService tenantService, IHousingEntityService housingService,
            IReceiptService receiptService, IPaymentService paymentService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _tenantService = tenantService;
            _housingService = housingService;
            _receiptService = receiptService;
            _paymentService = paymentService;
            _currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
            
        }

        private async void PaymentScreen_Load(object sender, EventArgs e)
        {
            PaymentDTGData.CellPainting += PaymentDTGData_CellPainting;
            PaymentDTGData.CellClick += PaymentDTGData_CellClick;

            SetDataGridStyle();
            ConfigureCondominiumColumns();

            SetSearchTextBoxStyleAndBehavior();
            ManageInitialBehaviorInCondominiumCB();

            InitializeProgressBar();
        }

        private void InitializeProgressBar()
        {
            toolStripProgressBar1.Visible = false;
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar1.Minimum = 0;
            toolStripProgressBar1.Maximum = 100;

            toolStripStatusLabel2.Visible = false;
            toolStripStatusLabel2.TextAlign = ContentAlignment.MiddleRight;
        }

        private async Task UpdateProgressBar(int housingId)
        {
            try
            {
                double percentage = await _receiptService.GetCompletionPercentageAsync(housingId);

                var allReceipts = await _receiptService.GetReceiptsByHousingIdAsync(housingId);
                var completed = allReceipts.Count(r =>
                    r.Status == ReceiptStatusHelper.Completed ||
                    r.Status == "Paid");
                var total = allReceipts.Count();

                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        toolStripProgressBar1.Value = (int)percentage;
                        toolStripStatusLabel2.Text = $"{percentage}% ({completed}/{total})";
                        toolStripProgressBar1.Visible = true;
                        toolStripStatusLabel2.Visible = true;

                        if (percentage >= 75)
                            toolStripProgressBar1.ForeColor = Color.Green;
                        else if (percentage >= 50)
                            toolStripProgressBar1.ForeColor = Color.Orange;
                        else
                            toolStripProgressBar1.ForeColor = Color.Red;
                    }));
                }
                else
                {
                    toolStripProgressBar1.Value = (int)percentage;
                    toolStripStatusLabel2.Text = $"{percentage}% ({completed}/{total})";
                    toolStripProgressBar1.Visible = true;
                    toolStripStatusLabel2.Visible = true;

                    if (percentage >= 75)
                        toolStripProgressBar1.ForeColor = Color.Green;
                    else if (percentage >= 50)
                        toolStripProgressBar1.ForeColor = Color.Orange;
                    else
                        toolStripProgressBar1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        toolStripProgressBar1.Visible = false;
                        toolStripStatusLabel2.Visible = false;
                    }));
                }
                else
                {
                    toolStripProgressBar1.Visible = false;
                    toolStripStatusLabel2.Visible = false;
                }
                Console.WriteLine($"Error actualizando progress bar: {ex.Message}");
            }
        }

        private async void PaymentCBHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentCBHouse.SelectedValue != null &&
                int.TryParse(PaymentCBHouse.SelectedValue.ToString(), out int housingId) &&
                housingId > 0)
            {
                await UpdateProgressBar(housingId);
            }
            else
            {
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel2.Visible = false;
            }
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(PaymentDTGData);
        }


        private void PaymentDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && PaymentDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                e.PaintBackground(e.CellBounds, true);

                int padding = 4;
                Rectangle buttonRect = new Rectangle(
                    e.CellBounds.Left + padding,
                    e.CellBounds.Top + padding,
                    e.CellBounds.Width - (padding * 2),
                    e.CellBounds.Height - (padding * 2)
                );

                using (Brush brush = new SolidBrush(Color.FromArgb(0, 123, 255))) // Color azul
                {
                    e.Graphics.FillRectangle(brush, buttonRect);

                }

                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;

                    using (Font font = new Font("Segoe UI", 8, FontStyle.Bold)) // Font size reducido
                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString("PAGAR", font, textBrush, buttonRect, format);
                    }
                }

                using (Pen pen = new Pen(Color.FromArgb(0, 86, 179), 1)) // Borde azul oscuro
                {
                    e.Graphics.DrawRectangle(pen, buttonRect);
                }

                e.Handled = true;
            }
        }

        private async void PaymentDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && PaymentDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var selectedRow = PaymentDTGData.Rows[e.RowIndex];
                var selectedReceipt = selectedRow.DataBoundItem as Receipt;

                if (selectedReceipt == null)
                {
                    MessageBox.Show("No se pudo identificar el recibo.");
                    return;
                }

                if (selectedReceipt.AmountPaid >= selectedReceipt.Amount)
                {
                    MessageBox.Show("Este recibo ya está completamente pagado.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                PaymentDTGData.InvalidateCell(e.ColumnIndex, e.RowIndex);
                await Task.Delay(100);
                PaymentDTGData.InvalidateCell(e.ColumnIndex, e.RowIndex);

                Session.CurrentReceipt = selectedReceipt;
                GoToUpsertScreen();
            }
        }

        private void GoToUpsertScreen()
        {           
            if (PaymentDTGData.CurrentRow == null)
            {
                MessageBox.Show("Por favor, selecciona un recibo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedReceipt = PaymentDTGData.CurrentRow.DataBoundItem as Receipt;

            if (selectedReceipt == null)
            {
                MessageBox.Show("Error al obtener el recibo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Session.CurrentReceipt = selectedReceipt;        

            var addPaymentScreen = _serviceProvider.GetRequiredService<AddPaymentScreen>();
            addPaymentScreen.Owner = this;
            addPaymentScreen.Show();
        }

        private void ConfigureCondominiumColumns()
        {
            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 120
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Monto",
                Name = "AmountColumn",
                Width = 90
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AmountPaid",
                HeaderText = "Monto abonado",
                Name = "AmountPaidColumn",
                Width = 145
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DueDate",
                HeaderText = "Fecha de Vencimieto",
                Name = "DueDateColumn",
                Width = 185
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detail",
                HeaderText = "Detalle",
                Name = "DetailColumn",
                Width = 260
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Estado",
                Name = "StatusColumn",
                Width = 150
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 80
            });
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

        public async Task LoadHousingsByTenantDocumentAsync(string documentNumber)
        {
            try
            {
                PaymentCBHouse.DataSource = null;
                PaymentCBHouse.Items.Clear();
                PaymentCBHouse.Enabled = false;

                if (String.IsNullOrEmpty(PaymentTBPropietaryDocument.Text) || PaymentTBPropietaryDocument.Text.Length != 11)
                {
                    MessageBox.Show("Por favor, complete correctamente el campo de documento.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearForm();
                    return;
                }

                PaymentCBHouse.Text = "Buscando...";

                var tenants = await _tenantService.SearchTenantsAsync(documentNumber.Trim());

                if (tenants == null || !tenants.Any())
                {
                    PaymentCBHouse.Text = "No se encontraron inquilinos";
                    MessageBox.Show("No se encontraron inquilinos con el documento proporcionado.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var activeTenants = tenants.Where(t => t.IsActive).ToList();

                if (!activeTenants.Any())
                {
                    PaymentCBHouse.Text = "No se encontraron inquilinos activos";
                    MessageBox.Show("El inquilino existe pero no está activo en el sistema.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Session.TenantToUpsert = activeTenants.First();

                var housingIds = activeTenants
                    .Where(t => t.HousingId > 0)
                    .Select(t => t.HousingId)
                    .Distinct()
                    .ToList();

                if (!housingIds.Any())
                {
                    PaymentCBHouse.Text = "No tiene viviendas asignadas";
                    MessageBox.Show("El inquilino no tiene viviendas asignadas en el sistema.",
                                  "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var housings = new List<Housing>();
                foreach (var housingId in housingIds)
                {
                    try
                    {
                        var housing = await _housingService.GetHousingByIdAsync(housingId);
                        if (housing != null)
                        {
                            housings.Add(housing);
                        }
                    }
                    catch (KeyNotFoundException ex)
                    {
                        Console.WriteLine($"Vivienda {housingId} no encontrada: {ex.Message}");
                        continue;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine($"Error al cargar vivienda {housingId}: {ex.Message}");
                        continue;
                    }
                }

                if (!housings.Any())
                {
                    PaymentCBHouse.Text = "Error al cargar viviendas";
                    MessageBox.Show("No se pudieron cargar las viviendas asignadas al inquilino.",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

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
            catch (KeyNotFoundException ex)
            {
                PaymentCBHouse.Text = "No se encontraron registros";
                MessageBox.Show("No se encontraron registros que coincidan con la búsqueda.",
                              "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine($"KeyNotFoundException: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                PaymentCBHouse.Text = "Error en la operación";
                MessageBox.Show("Ocurrió un error al procesar la información. Por favor, intente nuevamente.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"InvalidOperationException: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                PaymentCBHouse.Text = "Datos inválidos";
                MessageBox.Show("Los datos proporcionados no son válidos para la búsqueda.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"ArgumentException: {ex.Message}");
            }
            catch (SqlException ex)
            {
                PaymentCBHouse.Text = "Error de base de datos";
                MessageBox.Show("Error al acceder a la base de datos. Contacte al administrador.",
                              "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"SqlException: {ex.Message}");
            }
            catch (Exception ex)
            {
                PaymentCBHouse.Text = "Error inesperado";
                MessageBox.Show($"Error inesperado: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private async void SearchPendingReceiptsBTN_Click(object sender, EventArgs e)
        {
            SearchPendingReceipts(true);
        }

        public async void SearchPendingReceipts(bool showMessage)
        {
            if (!FormIsCorrect())
            {
                MessageBox.Show("Por favor, complete correctamente el formulario.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SearchPendingReceiptsBTNLBL.Text = "Buscando...";
                PaymentDTGData.DataSource = null;

                int housingId = (int)PaymentCBHouse.SelectedValue;

                await UpdateProgressBar(housingId);

                var pendingReceipts = await _receiptService.GetReceiptsByStatusAndHousingAsync(
                    housingId,
                    "Pending",
                    "PartiallyPaid"
                );

                PaymentDTGData.DataSource = pendingReceipts.ToList();
                FormatDataGridColumns();

                if (showMessage)
                {
                    MessageBox.Show($"Se encontraron {pendingReceipts.Count()} recibos pendientes/parciales.",
                                   "Búsqueda completada",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar recibos: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            finally
            {
                SearchPendingReceiptsBTNLBL.Text = "Buscar Recibos";
            }
        }

        private void FormatDataGridColumns()
        {
            if (PaymentDTGData.Columns["AmountColumn"] != null)
            {
                PaymentDTGData.Columns["AmountColumn"].DefaultCellStyle.Format = "C0";
                PaymentDTGData.Columns["AmountColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (PaymentDTGData.Columns["AmountPaidColumn"] != null)
            {
                PaymentDTGData.Columns["AmountPaidColumn"].DefaultCellStyle.Format = "C0";
                PaymentDTGData.Columns["AmountPaidColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            PaymentDTGData.CellFormatting += PaymentDTGData_CellFormatting;
        }

        private void PaymentDTGData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (PaymentDTGData.Columns[e.ColumnIndex].Name == "StatusColumn" && e.Value != null)
            {
                var status = e.Value.ToString();
                e.Value = ReceiptStatusTranslator.TranslateStatus(status);

            }

            if (PaymentDTGData.Columns[e.ColumnIndex].Name == "AmountColumn" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = amount.ToString("C0");
                    e.FormattingApplied = true;
                }
            }

            if (PaymentDTGData.Columns[e.ColumnIndex].Name == "AmountPaidColumn" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amountPaid))
                {
                    e.Value = amountPaid.ToString("C0");
                    e.FormattingApplied = true;
                }
            }
        }

        public bool FormIsCorrect()
        {
            bool isDocumentValid = PaymentTBPropietaryDocument.Text != "Ingrese el documento del propietario" &&
                                  !string.IsNullOrWhiteSpace(PaymentTBPropietaryDocument.Text);

            if (isDocumentValid)
            {
                string document = PaymentTBPropietaryDocument.Text.Trim();
                isDocumentValid = document.Length == 11;
            }

            bool isHouseValid = PaymentCBHouse.SelectedValue != null &&
                               int.TryParse(PaymentCBHouse.SelectedValue.ToString(), out int houseId) &&
                               houseId > 0;

            return isDocumentValid && isHouseValid;
        }

        private void ClearForm()
        {
            PaymentTBPropietaryDocument.Clear();

            if (PaymentCBHouse.Items.Count > 0)
                PaymentCBHouse.SelectedIndex = 0;
        }
        
    }
}
