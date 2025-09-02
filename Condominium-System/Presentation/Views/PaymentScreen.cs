using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Condominium_System.Helpers.Status;
using Microsoft.Extensions.DependencyInjection;
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


        private void PaymentScreen_Load(object sender, EventArgs e)
        {
            PaymentDTGData.CellPainting += PaymentDTGData_CellPainting;
            PaymentDTGData.CellClick += PaymentDTGData_CellClick;

            SetDataGridStyle();
            ConfigureCondominiumColumns();

            SetSearchTextBoxStyleAndBehavior();
            ManageInitialBehaviorInCondominiumCB();
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
                e.PaintContent(e.CellBounds);

                int iconWidth = 16;
                int iconHeight = 16;
                int padding = 5;

                int x = e.CellBounds.Left + padding;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(Properties.Resources.pay, new Rectangle(x, y, iconWidth, iconHeight));

                e.Handled = true;
            }
        }

        private async void PaymentDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && PaymentDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = PaymentDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = PaymentDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = PaymentDTGData.Rows[e.RowIndex];
                var selectedReceipt = selectedRow.DataBoundItem as Receipt;

                if (selectedReceipt == null)
                {
                    MessageBox.Show("No se pudo identificar el recibo.");
                    return;
                }

                if (relativeX < 26)
                {
                    Session.CurrentReceipt = selectedReceipt;
                    GoToUpsertScreen();
                }
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
                Width = 100
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AmountPaid",
                HeaderText = "Monto abonado",
                Name = "AmountPaidColumn",
                Width = 170
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detail",
                HeaderText = "Detalle",
                Name = "DetailColumn",
                Width = 320
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Estado",
                Name = "StatusColumn",
                Width = 220
            });

            PaymentDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
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

                if (string.IsNullOrWhiteSpace(documentNumber))
                {
                    PaymentCBHouse.Text = "Ingrese número de documento";
                    return;
                }

                PaymentCBHouse.Text = "Buscando...";

                var tenants = await _tenantService.SearchTenantsAsync(documentNumber.Trim());

                // Filtrar tenants activos y agrupar por vivienda
                var activeTenants = tenants.Where(t => t.IsActive).ToList();

                Session.TenantToUpsert = activeTenants.First();

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

        private void PaymentTBPropietaryDocument_TextChanged(object sender, EventArgs e)
        {
            if (PaymentTBPropietaryDocument.Text != "Ingrese el documento del propietario")
            {
                string document = PaymentTBPropietaryDocument.Text.Trim();

                if (document.Length > 11)
                {
                    // Cortar el texto a 11 caracteres
                    PaymentTBPropietaryDocument.Text = document.Substring(0, 11);
                    PaymentTBPropietaryDocument.SelectionStart = 11;
                }

                // Cambiar color para indicar validación
                PaymentTBPropietaryDocument.ForeColor = document.Length == 11 ?
                    SystemColors.WindowText : Color.Red;
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
                MessageBox.Show("Por favor, complete correctamente el formulario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Mostrar loading
                SearchPendingReceiptsBTNLBL.Text = "Buscando...";
                PaymentDTGData.DataSource = null;

                // Obtener el ID de la vivienda seleccionada
                int housingId = (int)PaymentCBHouse.SelectedValue;

                // Buscar recibos pendientes y parcialmente pagados
                var pendingReceipts = await _receiptService.GetReceiptsByStatusAndHousingAsync(
                    housingId,
                    "Pending",
                    "PartiallyPaid"
                );

                // Configurar el DataGridView
                PaymentDTGData.DataSource = pendingReceipts.ToList();

                // Aplicar formato a las columnas
                FormatDataGridColumns();

                if (showMessage)
                {
                    // Mostrar resultados
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

            // Traducir la columna de Status
            if (PaymentDTGData.Columns[e.ColumnIndex].Name == "StatusColumn" && e.Value != null)
            {
                var status = e.Value.ToString();
                e.Value = ReceiptStatusTranslator.TranslateStatus(status);

            }

            // Formatear columnas monetarias
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
            // Validar que el texto no sea el placeholder y no esté vacío
            bool isDocumentValid = PaymentTBPropietaryDocument.Text != "Ingrese el documento del propietario" &&
                                  !string.IsNullOrWhiteSpace(PaymentTBPropietaryDocument.Text);

            // Validar longitud exacta del documento (11 caracteres)
            if (isDocumentValid)
            {
                string document = PaymentTBPropietaryDocument.Text.Trim();
                isDocumentValid = document.Length == 11;
            }

            // Validar que se haya seleccionado una vivienda válida
            bool isHouseValid = PaymentCBHouse.SelectedValue != null &&
                               int.TryParse(PaymentCBHouse.SelectedValue.ToString(), out int houseId) &&
                               houseId > 0;

            return isDocumentValid && isHouseValid;
        }
    }
}
