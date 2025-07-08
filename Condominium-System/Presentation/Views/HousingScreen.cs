using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using System.ComponentModel;

namespace Condominium_System.Presentation.Views
{
    public partial class HousingScreen : Form
    {
        private readonly IHousingEntityService _housingEntityService;
        private readonly IBlockService _blockService;

        User currentUser;

        public HousingScreen(IHousingEntityService housingEntityService, IBlockService blockService)
        {
            InitializeComponent();
            _housingEntityService = housingEntityService;
            _blockService = blockService;
            currentUser = Session.CurrentUser;
        }

        private async void HousingScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureHousingColumns();
            await LoadDataToDataGrid();
            await LoadBlocksIntoComboBox();
        }

        private async Task LoadBlocksIntoComboBox()
        {
            try
            {
                var blocks = await _blockService.GetAllBlocksAsync();

                HousingCBBlock.DisplayMember = "Name";
                HousingCBBlock.ValueMember = "Id";
                HousingCBBlock.DataSource = blocks;

                var placeholder = new Block { Id = 0, Name = "-- Seleccione un bloque --" };
                var listWithPlaceholder = new List<Block> { placeholder };
                listWithPlaceholder.AddRange(blocks);
                HousingCBBlock.DataSource = listWithPlaceholder;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los bloques: {ex.Message}");
            }

        }

        private async Task LoadDataToDataGrid()
        {
            try
            {
                var listHousing = await _housingEntityService.GetAllHousingsAsync();
                var bindingList = new BindingList<Housing>((List<Housing>)(IEnumerable<Housing>)listHousing);
                var source = new BindingSource(bindingList, null);
                HousingDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando condominios: {ex.Message}");
            }
        }

        private void ConfigureHousingColumns()
        {

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 105
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Code",
                HeaderText = "Codigo",
                Name = "CodeColumn",
                Width = 150
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PeopleCount",
                HeaderText = "Cantidad de personas",
                Name = "PeopleCountColumn",
                Width = 180
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomCount",
                HeaderText = "Cantidad de habitaciones",
                Name = "RoomCountColumn",
                Width = 200
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BathroomCount",
                HeaderText = "Numero de baños",
                Name = "BathroomCountColumn",
                Width = 160
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BlockID",
                HeaderText = "Identificacion del bloque",
                Name = "BlockIDColumn",
                Width = 155
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(HousingDTGData);
        }

        private async void HousingPNLBTNCreate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewHouse = new Housing()
                    {
                        Code = HousingTBCode.Text,
                        PeopleCount = Int32.Parse(HousingTBPeopleQuantity.Text),
                        RoomCount = Int32.Parse(HousingTBRoomQuantity.Text),
                        BathroomCount = Int32.Parse(HousingTBBathroomQuantity.Text),
                        BlockId = (int)HousingCBBlock.SelectedValue,
                        Author = currentUser.Username
                    };

                    await _housingEntityService.CreateHousingAsync(NewHouse);

                    MessageBox.Show("La vivienda ha sido creada con exito.");
                    CleanFormHousing();
                    LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando la vivienda: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        public bool FormIsCorrect()
        {
            bool isBlockValid = int.TryParse(HousingCBBlock.SelectedValue?.ToString(), out int condoId) && condoId != 0;

            return !(
               string.IsNullOrEmpty(HousingTBPeopleQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBRoomQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBBathroomQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBCode.Text) ||
               !isBlockValid
           );
        }

        public bool FormIsCorrectToUpdate()
        {
            bool isBlockValid = int.TryParse(HousingCBBlock.SelectedValue?.ToString(), out int condoId) && condoId != 0;

            return !(
               string.IsNullOrEmpty(HousingTBID.Text) ||
               string.IsNullOrEmpty(HousingTBPeopleQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBRoomQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBBathroomQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBCode.Text) ||
               !isBlockValid
           );
        }

        private void CleanFormHousing()
        {
            HousingTBID.Clear();
            HousingTBCode.Clear();
            HousingTBPeopleQuantity.Clear();
            HousingTBRoomQuantity.Clear();
            HousingTBBathroomQuantity.Clear();

            if (HousingCBBlock.Items.Count > 0)
                HousingCBBlock.SelectedIndex = 0;
        }

        private async void HousingPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(HousingTBID.Text))
            {
                try
                {
                    var HousingFound = await _housingEntityService.GetHousingByIdAsync(Int32.Parse(HousingTBID.Text));
                    if (HousingFound != null)
                    {
                        HousingTBID.Text = HousingFound.Id.ToString();
                        HousingTBPeopleQuantity.Text = HousingFound.PeopleCount.ToString();
                        HousingTBRoomQuantity.Text = HousingFound.PeopleCount.ToString();
                        HousingTBBathroomQuantity.Text = HousingFound.BathroomCount.ToString();
                        HousingTBCode.Text = HousingFound.Code;

                        await LoadBlocksIntoComboBox();

                        HousingCBBlock.SelectedValue = HousingFound.BlockId;
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
    }
}
