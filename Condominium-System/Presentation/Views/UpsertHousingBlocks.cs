using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public partial class UpsertHousingBlocks : Form
    {
        private readonly IBlockService _blockService;
        private readonly ICondominiumService _condominiumService;
        private readonly IServiceProvider _serviceProvider;
        User currentUser;

        public bool IsEditMode { get; set; } = false;
        public UpsertHousingBlocks(IBlockService blockService, ICondominiumService condominiumService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _blockService = blockService;
            _condominiumService = condominiumService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void UpsertHousingBlocks_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                LoadDataIfIsToUpdate();
            }

            SetComboBoxForTypeOfHousing();
            await LoadCondominiumsIntoComboBox();
        }

        private async void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.BlockToUpsert != null)
            {
                var block = Session.BlockToUpsert;
                BlockTBName.Text = block.Name;
                BlockTBAddress.Text = block.Address;
                BlockTBHouseQuantity.Text = block.HousingCount.ToString();
                BlockTBFeature.Text = block.Feature;

                await LoadCondominiumsIntoComboBox();

                BlockCBCondominium.SelectedValue = block.CondominiumId;

                if (block.HousingType == "Casa")
                    BlockCBTypeHousing.SelectedValue = 1;
                else if (block.HousingType == "Apartamento")
                    BlockCBTypeHousing.SelectedValue = 2;
                else
                    BlockCBTypeHousing.SelectedValue = 0;
            }
        }

        private void BlockTBHouseQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
                        BlockCBCondominium.DataSource = null;
                        BlockCBCondominium.Items.Clear();
                        BlockCBCondominium.Text = "No hay condominios registrados";
                        BlockCBCondominium.Enabled = false;

                        MessageBox.Show("No se encontraron condominios registrados. Por favor, registre al menos un condominio.",
                                      "Información",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        ((HousingBlocksScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                        return;
                    }

                    BlockCBCondominium.DataSource = condominiums;
                    BlockCBCondominium.DisplayMember = "Name";
                    BlockCBCondominium.ValueMember = "Id";
                    BlockCBCondominium.Enabled = true;

                    if (BlockCBCondominium.Items.Count > 0)
                    {
                        BlockCBCondominium.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                BlockCBCondominium.DataSource = null;
                BlockCBCondominium.Items.Clear();
                BlockCBCondominium.Text = "Error al cargar condominios";
                BlockCBCondominium.Enabled = false;

                MessageBox.Show($"Error cargando condominios: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                ((HousingBlocksScreen)this.Owner).LoadDataToDataGrid();
                this.Hide();
            }
            finally
            {
                BlockCBCondominium.Refresh();
            }
        }

        public bool FormIsCorrect()
        {
            bool isTypeValid = int.TryParse(BlockCBTypeHousing.SelectedValue?.ToString(), out int typeId) && typeId != 0;
            bool isCondoValid = int.TryParse(BlockCBCondominium.SelectedValue?.ToString(), out int condoId) && condoId != 0;

            return !(
               string.IsNullOrEmpty(BlockTBName.Text) ||
               string.IsNullOrEmpty(BlockTBAddress.Text) ||
               string.IsNullOrEmpty(BlockTBHouseQuantity.Text) ||
               string.IsNullOrEmpty(BlockTBFeature.Text) ||
               !isTypeValid ||
               !isCondoValid
           );
        }

        private void UpsertLBLBTN_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditBlock(); }
            else { SaveBlock(); }
        }

        private async void EditBlock()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var BlockToUpdate = Session.BlockToUpsert;

                    if (BlockToUpdate != null)
                    {
                        BlockToUpdate.Name = BlockTBName.Text.Trim().ToUpper();
                        BlockToUpdate.Feature = BlockTBFeature.Text.Trim().ToUpper();
                        BlockToUpdate.HousingCount = Int32.Parse(BlockTBHouseQuantity.Text);
                        BlockToUpdate.Address = BlockTBAddress.Text.Trim().ToUpper();
                        BlockToUpdate.CondominiumId = (int)BlockCBCondominium.SelectedValue;
                        BlockToUpdate.HousingType = BlockCBTypeHousing.Text;

                        await _blockService.UpdateBlockAsync(BlockToUpdate);

                        MessageBox.Show("El bloque ha sido actualizado con exito");
                        CleanForm();
                        ((HousingBlocksScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Bloque no encontrado.");
                        CleanForm();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando bloque: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveBlock()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewBlock = new Block()
                    {
                        Name = BlockTBName.Text.Trim().ToUpper(),
                        Address = BlockTBAddress.Text.Trim().ToUpper(),
                        HousingType = BlockCBTypeHousing.Text,
                        HousingCount = Int32.Parse(BlockTBHouseQuantity.Text),
                        Feature = BlockTBFeature.Text.Trim().ToUpper(),
                        CondominiumId = (int)BlockCBCondominium.SelectedValue,

                        Author = currentUser.Username
                    };

                    await _blockService.CreateBlockAsync(NewBlock);

                    MessageBox.Show("El bloque ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    ((HousingBlocksScreen)this.Owner).LoadDataToDataGrid();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando bloque: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private void SetComboBoxForTypeOfHousing()
        {
            var userTypes = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(0, "-- Seleccione un tipo de vivienda --"),
                new KeyValuePair<int, string>(1, "Casa"),
                new KeyValuePair<int, string>(2, "Apartamento")
            };

            BlockCBTypeHousing.DataSource = userTypes;
            BlockCBTypeHousing.DisplayMember = "Value";
            BlockCBTypeHousing.ValueMember = "Key";
            BlockCBTypeHousing.DropDownStyle = ComboBoxStyle.DropDownList;
            BlockCBTypeHousing.SelectedIndex = 0;
        }

        private void CleanForm()
        {
            BlockTBName.Clear();
            BlockTBAddress.Clear();
            BlockTBHouseQuantity.Clear();
            BlockTBFeature.Clear();

            if (BlockCBTypeHousing.Items.Count > 0)
                BlockCBTypeHousing.SelectedIndex = 0;

            if (BlockCBCondominium.Items.Count > 0)
                BlockCBCondominium.SelectedIndex = 0;
        }
    }
}
