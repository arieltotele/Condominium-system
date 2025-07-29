using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace Condominium_System.Presentation.Views
{
    public partial class InvoiceScreen : Form
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;
        private User currentUser;

        public InvoiceScreen(IInvoiceService invoiceService, ITenantService tenantService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _invoiceService = invoiceService;
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void InvoiceScreen_Load(object sender, EventArgs e)
        {
            InvoiceDTGData.CellPainting += InvoiceDTGData_CellPainting;
            InvoiceDTGData.CellClick += InvoiceDTGData_CellClick;

            SetDataGridStyle();
            ConfigureInvoiceColumns();
            await LoadDataToDataGrid();
        }

        private void InvoiceDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && InvoiceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                int iconWidth = 16;
                int iconHeight = 16;
                int padding = 5;

                int x = e.CellBounds.Left + padding;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(Properties.Resources.pencil_blue, new Rectangle(x, y, iconWidth, iconHeight));

                x += iconWidth + padding;
                e.Graphics.DrawImage(Properties.Resources.trash_red, new Rectangle(x, y, iconWidth, iconHeight));

                e.Handled = true;
            }
        }

        private async void InvoiceDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && InvoiceDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = InvoiceDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = InvoiceDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = InvoiceDTGData.Rows[e.RowIndex];
                var selectedInvoice = selectedRow.DataBoundItem as Invoice;

                if (selectedInvoice == null)
                {
                    MessageBox.Show("No se pudo identificar la factura.");
                    return;
                }

                if (relativeX < 26) // 🟢 Editar
                {
                    Session.InvoiceToUpsert = selectedInvoice;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52) // 🔴 Eliminar
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar la factura '{selectedInvoice.Id}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _invoiceService.DeleteAsync(selectedInvoice.Id);
                            MessageBox.Show("Factura eliminada correctamente.");
                            LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar la factura: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (InvoiceDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona una factura para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedInvoice = InvoiceDTGData.CurrentRow.DataBoundItem as Invoice;
                if (selectedInvoice == null)
                {
                    MessageBox.Show("Error al obtener la factura seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.InvoiceToUpsert = selectedInvoice;
            }
            else
            {
                Session.InvoiceToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertInvoiceScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        //private async Task LoadTenantsIntoComboBox()
        //{
        //    try
        //    {
        //        var tenants = await _tenantService.GetAllAsync();
        //        var placeholder = new { Id = 0, Display = "-- Seleccione un inquilino --" };

        //        var tenantDisplayList = tenants.Select(t => new
        //        {
        //            Id = t.Id,
        //            Display = $"{FormatDocument(t.DocumentNumber)} - {t.FirstName} {t.LastName}"
        //        }).ToList();

        //        tenantDisplayList.Insert(0, placeholder);

        //        InvoiceCBTenants.DisplayMember = "Display";
        //        InvoiceCBTenants.ValueMember = "Id";
        //        InvoiceCBTenants.DataSource = tenantDisplayList;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error cargando los inquilinos: {ex.Message}");
        //    }
        //}

        private string FormatDocument(string doc)
        {
            if (!string.IsNullOrEmpty(doc) && doc.Length == 11)
                return $"{doc.Substring(0, 3)}-{doc.Substring(3, 7)}-{doc.Substring(10, 1)}";
            return doc;
        }

        public async Task LoadDataToDataGrid()
        {
            try
            {
                var invoices = await _invoiceService.GetAllAsync();
                var bindingList = new BindingList<Invoice>((List<Invoice>)invoices);
                var source = new BindingSource(bindingList, null);
                InvoiceDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando facturas: {ex.Message}");
            }
        }

        private void ConfigureInvoiceColumns()
        {
            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Name = "IdColumn",
                Width = 60
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IssueDate",
                HeaderText = "Fecha",
                Name = "DateColumn",
                Width = 150
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detail",
                HeaderText = "Detalle",
                Name = "DetailColumn",
                Width = 200
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Monto Total",
                Name = "AmountColumn",
                Width = 150
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenantId",
                HeaderText = "Inquilino",
                Name = "TenantColumn",
                Width = 150
            });

            InvoiceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(InvoiceDTGData);
        }

        private void CleanForm()
        {
            InvoiceTBID.Clear();
        }

        private async void InvoicePNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private async void InvoicePNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InvoiceTBID.Text))
            {
                try
                {
                    int id = int.Parse(InvoiceTBID.Text);
                    var invoiceFound = await _invoiceService.GetByIdAsync(id);

                    if (invoiceFound != null)
                    {
                        InvoiceDTGData.DataSource = new List<Invoice> { invoiceFound };
                    }
                    else
                    {
                        MessageBox.Show("Factura no encontrada.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                        await LoadDataToDataGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                    await LoadDataToDataGrid();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
                await LoadDataToDataGrid();                
            }        
        }
    }
}