using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System.Presentation.Views
{
    public partial class HousingBlocksScreen : Form
    {
        private readonly IBlockService _blockService;
        private readonly ICondominiumService _condominiumService;
        private readonly IServiceProvider _serviceProvider;
        User currentUser;

        public HousingBlocksScreen(IBlockService blockService, ICondominiumService condominiumService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _blockService = blockService;
            _condominiumService = condominiumService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void HousingBlocksScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureBlockColumns();
            LoadDataToDataGrid();
            SetComboBoxForTypeOfHousing();
            await LoadCondominiumsIntoComboBox();
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

        private async void LoadDataToDataGrid()
        {
            try
            {
                var listBlock = await _blockService.GetAllBlocksAsync();
                var bindingList = new BindingList<Block>((List<Block>)(IEnumerable<Block>)listBlock);
                var source = new BindingSource(bindingList, null);
                BlockDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando condominios: {ex.Message}");
            }
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(BlockDTGData);
        }

        private void ConfigureBlockColumns()
        {

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 105
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                Name = "NameColumn",
                Width = 130
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Feature",
                HeaderText = "Caracteristica",
                Name = "FeatureColumn",
                Width = 130
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HousingType",
                HeaderText = "Tipos de vivienda",
                Name = "HousingTypeColumn",
                Width = 120
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HousingCount",
                HeaderText = "Numero de casas",
                Name = "HousingCountColumn",
                Width = 110
            });

            BlockDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Direccion",
                Name = "AddressColumn",
                Width = 120
            });
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
                    var condominiums = await condoService.GetAllCondominiumsAsync();

                    BlockCBCondominium.DataSource = condominiums;
                    BlockCBCondominium.DisplayMember = "Name";  // ajusta según tu modelo
                    BlockCBCondominium.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando condominios: {ex.Message}");
            }
        }

        private async void BlockPNLBTNCreate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewBlock = new Block()
                    {
                        Name = BlockTBName.Text,
                        Address = BlockTBAddress.Text,
                        HousingType = BlockCBTypeHousing.Text,
                        HousingCount = Int32.Parse(BlockTBHouseQuantity.Text),
                        Feature = BlockTBFeature.Text,
                        CondominiumId = (int)BlockCBCondominium.SelectedValue,
                        Author = currentUser.Username
                    };

                    await _blockService.CreateBlockAsync(NewBlock);

                    MessageBox.Show("El bloque de casas ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando el bloque de casas: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
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

        public bool FormIsCorrectToUpdate()
        {
            bool isTypeValid = int.TryParse(BlockCBTypeHousing.SelectedValue?.ToString(), out int typeId) && typeId != 0;
            bool isCondoValid = int.TryParse(BlockCBCondominium.SelectedValue?.ToString(), out int condoId) && condoId != 0;

            return !(
               string.IsNullOrEmpty(BlockTBID.Text) ||
               string.IsNullOrEmpty(BlockTBName.Text) ||
               string.IsNullOrEmpty(BlockTBAddress.Text) ||
               string.IsNullOrEmpty(BlockTBHouseQuantity.Text) ||
               string.IsNullOrEmpty(BlockTBFeature.Text) ||
               !isTypeValid ||
               !isCondoValid
           );
        }

        private async void BlockPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(BlockTBID.Text))
            {
                try
                {
                    var BlockFound = await _blockService.GetBlockByIdAsync(Int32.Parse(BlockTBID.Text));
                    if (BlockFound != null)
                    {
                        BlockTBID.Text = BlockFound.Id.ToString();
                        BlockTBName.Text = BlockFound.Name;
                        BlockTBAddress.Text = BlockFound.Address;
                        BlockTBHouseQuantity.Text = BlockFound.HousingCount.ToString();
                        BlockTBFeature.Text = BlockFound.Feature;

                        await LoadCondominiumsIntoComboBox();

                        BlockCBCondominium.SelectedValue = BlockFound.CondominiumId;

                        if (BlockFound.HousingType == "Casa")
                            BlockCBTypeHousing.SelectedValue = 1;
                        else if (BlockFound.HousingType == "Apartamento")
                            BlockCBTypeHousing.SelectedValue = 2;
                        else
                            BlockCBTypeHousing.SelectedValue = 0;
                    }
                    else
                    {
                        MessageBox.Show("Bloque de casa no encontrado.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando el bloque de casa: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe de estar lleno correctamente.");
            }
        }

        private async void BlockPNLBTNUpdate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrectToUpdate())
            {
                try
                {
                    var BlockToUpdate = await _blockService.GetBlockByIdAsync(Int32.Parse(BlockTBID.Text));

                    if (BlockToUpdate != null)
                    {
                        BlockToUpdate.Id = int.Parse(BlockTBID.Text);
                        BlockToUpdate.Name = BlockTBName.Text;
                        BlockToUpdate.Feature = BlockTBFeature.Text;
                        BlockToUpdate.HousingCount = Int32.Parse(BlockTBHouseQuantity.Text);
                        BlockToUpdate.Address = BlockTBAddress.Text;
                        BlockToUpdate.CondominiumId = (int)BlockCBCondominium.SelectedValue;
                        BlockToUpdate.HousingType = BlockCBTypeHousing.Text;

                        BlockToUpdate.UpdatedAt = DateTime.Now;

                        await _blockService.UpdateBlockAsync(BlockToUpdate);

                        MessageBox.Show("El bloque de vivienda ha sido actualizado con exito");
                        LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Bloque de vivienda no encontrado.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando el bloque de vivienda: {ex.Message}");
                }
            }
        }

        private async void BlockPNLBTNDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(BlockTBID.Text))
            {
                var BlockToDelete = await _blockService.GetBlockByIdAsync(Int32.Parse(BlockTBID.Text));

                if (BlockToDelete != null)
                {
                    BlockToDelete.DeletedAt = DateTime.Now;
                    await _blockService.DeleteBlockAsync(Int32.Parse(BlockTBID.Text));
                    MessageBox.Show("El bloque de viviendas ha sido borrado con exitosamente.");
                    LoadDataToDataGrid();
                    CleanForm();
                }
                else
                {
                    MessageBox.Show("Bloque de viviendas no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("El campo de Id debe de estar lleno.");
            }
        }

        private void CleanForm()
        {
            BlockTBID.Clear();
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
