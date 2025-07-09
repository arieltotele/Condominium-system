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
    public partial class InvoiceScreen : Form
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ITenantService _tenantService;
        private User currentUser;

        public InvoiceScreen(IInvoiceService invoiceService, ITenantService tenantService)
        {
            InitializeComponent();
            _invoiceService = invoiceService;
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
        }

        private async void InvoiceScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureInvoiceColumns();
            await LoadDataToDataGrid();
            await LoadTenantsIntoComboBox();
        }

        private async Task LoadTenantsIntoComboBox()
        {
            try
            {
                var tenants = await _tenantService.GetAllAsync();
                var placeholder = new { Id = 0, Display = "-- Seleccione un inquilino --" };

                var tenantDisplayList = tenants.Select(t => new
                {
                    Id = t.Id,
                    Display = $"{FormatDocument(t.DocumentNumber)} - {t.FirstName} {t.LastName}"
                }).ToList();

                tenantDisplayList.Insert(0, placeholder);

                InvoiceCBTenants.DisplayMember = "Display";
                InvoiceCBTenants.ValueMember = "Id";
                InvoiceCBTenants.DataSource = tenantDisplayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los inquilinos: {ex.Message}");
            }
        }

        private string FormatDocument(string doc)
        {
            if (!string.IsNullOrEmpty(doc) && doc.Length == 11)
                return $"{doc.Substring(0, 3)}-{doc.Substring(3, 7)}-{doc.Substring(10, 1)}";
            return doc;
        }

        private async Task LoadDataToDataGrid()
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
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(InvoiceDTGData);
        }

        private void CleanForm()
        {
            InvoiceTBID.Clear();
            InvoiceTBDetail.Clear();
            InvoiceTBTotal.Clear();

            if (InvoiceCBTenants.Items.Count > 0)
                InvoiceCBTenants.SelectedIndex = 0;
        }

        public bool FormIsCorrect()
        {
            bool isTenantValid = int.TryParse(InvoiceCBTenants.SelectedValue?.ToString(), out int tenantId) && tenantId != 0;

            return !(
               string.IsNullOrEmpty(InvoiceTBDetail.Text) ||
               string.IsNullOrEmpty(InvoiceTBTotal.Text) ||
               !isTenantValid
           );
        }

        public bool FormIsCorrectToUpdate()
        {
            bool isTenantValid = int.TryParse(InvoiceCBTenants.SelectedValue?.ToString(), out int tenantId) && tenantId != 0;

            return !(
               string.IsNullOrEmpty(InvoiceTBID.Text) ||
               string.IsNullOrEmpty(InvoiceTBDetail.Text) ||
               string.IsNullOrEmpty(InvoiceTBTotal.Text) ||
               !isTenantValid
           );
        }

        private async void InvoicePNLBTNCreate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var newInvoice = new Invoice()
                    {
                        Detail = InvoiceTBDetail.Text,
                        TotalAmount = InvoiceTBTotal.Text,
                        TenantId = (int)InvoiceCBTenants.SelectedValue,
                        Author = currentUser.Username
                    };

                    await _invoiceService.CreateAsync(newInvoice);

                    MessageBox.Show("La factura ha sido creada con éxito.");
                    CleanForm();
                    await LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear la factura: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos correctamente.");
            }
        }

        private async void InvoicePNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InvoiceTBID.Text))
            {
                try
                {
                    var invoice = await _invoiceService.GetByIdAsync(int.Parse(InvoiceTBID.Text));

                    if (invoice != null)
                    {
                        InvoiceTBDetail.Text = invoice.Detail;
                        InvoiceTBTotal.Text = invoice.TotalAmount;

                        await LoadTenantsIntoComboBox();
                        InvoiceCBTenants.SelectedValue = invoice.TenantId;
                    }
                    else
                    {
                        MessageBox.Show("Factura no encontrada.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar la factura: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno.");
            }
        }

        private async void InvoicePNLBTNUpdate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrectToUpdate())
            {
                try
                {
                    var invoiceToUpdate = await _invoiceService.GetByIdAsync(int.Parse(InvoiceTBID.Text));

                    if (invoiceToUpdate != null)
                    {
                        invoiceToUpdate.Detail = InvoiceTBDetail.Text;
                        invoiceToUpdate.TotalAmount = InvoiceTBTotal.Text;
                        invoiceToUpdate.TenantId = (int)InvoiceCBTenants.SelectedValue;
                        invoiceToUpdate.UpdatedAt = DateTime.Now;

                        await _invoiceService.UpdateAsync(invoiceToUpdate);

                        MessageBox.Show("La factura ha sido actualizada con éxito.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Factura no encontrada.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar la factura: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos correctamente.");
            }
        }

        private async void InvoicePNLBTNDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(InvoiceTBID.Text))
            {
                try
                {
                    var invoiceToDelete = await _invoiceService.GetByIdAsync(int.Parse(InvoiceTBID.Text));

                    if (invoiceToDelete != null)
                    {
                        invoiceToDelete.DeletedAt = DateTime.Now;

                        await _invoiceService.DeleteAsync(invoiceToDelete.Id);

                        MessageBox.Show("La factura ha sido eliminada exitosamente.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Factura no encontrada.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la factura: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno.");
            }
        }
    }
}