using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
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
    public partial class ReceiptScreen : Form
    {
        private readonly IReceiptService _receiptService;
        private readonly ICondominiumService _condominiumService;
        private readonly ITenantService _tenantService;
        private readonly IHousingEntityService _housingService;
        private readonly IServiceProvider _serviceProvider;
        User currentUser;

        public ReceiptScreen(IReceiptService receiptService, ICondominiumService condominiumService, 
            ITenantService tenantService, IHousingEntityService housingService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _receiptService = receiptService;
            _condominiumService = condominiumService;
            _tenantService = tenantService;
            _housingService = housingService;
            _serviceProvider = serviceProvider;
        }

        private async void ReceiptScreen_Load(object sender, EventArgs e)
        {
            SetComboBoxForNextTenYears();
            await LoadCondominiumsIntoComboBox();
        }

        private async void GenerateReceiptsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selecciones
                if (ReceiptCBCondominium.SelectedItem == null)
                {
                    MessageBox.Show("Por favor seleccione un condominio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ReceiptCBYear.SelectedItem == null || ((KeyValuePair<int, string>)ReceiptCBYear.SelectedItem).Key == 0)
                {
                    MessageBox.Show("Por favor seleccione un año válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedCondominium = (Condominium)ReceiptCBCondominium.SelectedItem;
                var selectedYear = ((KeyValuePair<int, string>)ReceiptCBYear.SelectedItem).Key;

                // Confirmar con el usuario
                var result = MessageBox.Show(
                    $"¿Está seguro que desea generar recibos para el condominio '{selectedCondominium.Name}' " +
                    $"para el año {selectedYear}? Esta acción creará recibos para todas las viviendas activas.",
                    "Confirmar generación masiva",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Deshabilitar el panel durante el proceso
                GenerateReceiptsPanel.Enabled = false;
                GenerateReceiptsPanel.BackColor = Color.LightGray; // Cambiar color para indicar deshabilitado

                // Cambiar el texto del label si tienes uno
                var label = GenerateReceiptsPanel.Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                    label.Text = "Generando...";

                // Ejecutar la generación
                var receiptsCreated = await _receiptService.GenerateBulkReceiptsAsync(selectedCondominium.Id, selectedYear);

                MessageBox.Show(
                    $"Se generaron {receiptsCreated} recibos exitosamente para el condominio '{selectedCondominium.Name}'.",
                    "Generación completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al generar recibos: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                // Restaurar el panel
                GenerateReceiptsPanel.Enabled = true;
                GenerateReceiptsPanel.BackColor = SystemColors.Control; // Volver al color original

                // Restaurar el texto del label
                var label = GenerateReceiptsPanel.Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                    label.Text = "Generar Recibos Masivos"; // O el texto original
            }
        }

        private async Task LoadCondominiumsIntoComboBox()
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var condoService = scope.ServiceProvider.GetRequiredService<ICondominiumService>();
                    var condominiums = (await condoService.GetAllCondominiumsAsync()).ToList();

                    if (!condominiums.Any())
                    {
                        ReceiptCBCondominium.DataSource = null;
                        ReceiptCBCondominium.Items.Clear();
                        ReceiptCBCondominium.Text = "No hay condominios registrados";
                        ReceiptCBCondominium.Enabled = false;

                        MessageBox.Show("No se encontraron condominios registrados. Por favor, registre al menos un condominio.",
                                      "Información",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        ((HousingBlocksScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                        return;
                    }

                    ReceiptCBCondominium.DataSource = condominiums;
                    ReceiptCBCondominium.DisplayMember = "Name";
                    ReceiptCBCondominium.ValueMember = "Id";
                    ReceiptCBCondominium.Enabled = true;

                    if (ReceiptCBCondominium.Items.Count > 0)
                    {
                        ReceiptCBCondominium.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ReceiptCBCondominium.DataSource = null;
                ReceiptCBCondominium.Items.Clear();
                ReceiptCBCondominium.Text = "Error al cargar condominios";
                ReceiptCBCondominium.Enabled = false;

                MessageBox.Show($"Error cargando condominios: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                ((HousingBlocksScreen)this.Owner).LoadDataToDataGrid();
                this.Hide();
            }
            finally
            {
                ReceiptCBCondominium.Refresh();
            }
        }

        private void SetComboBoxForNextTenYears()
        {
            var currentYear = DateTime.Now.Year;
            var yearList = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "-- Seleccione un año --")
            };

            for (int i = 0; i <= 10; i++)
            {
                int year = currentYear + i;
                yearList.Add(new KeyValuePair<int, string>(year, year.ToString()));
            }

            ReceiptCBYear.DataSource = yearList;
            ReceiptCBYear.DisplayMember = "Value";
            ReceiptCBYear.ValueMember = "Key";
            ReceiptCBYear.DropDownStyle = ComboBoxStyle.DropDownList;
            ReceiptCBYear.SelectedIndex = 0;
        }
    }
}
