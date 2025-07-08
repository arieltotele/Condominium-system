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
                Width = 130
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PeopleCount",
                HeaderText = "Cantidad de personas",
                Name = "PeopleCountColumn",
                Width = 150
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomCount",
                HeaderText = "Cantidad de habitaciones",
                Name = "RoomCountColumn",
                Width = 150
            });

            HousingDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BathroomCount",
                HeaderText = "Numero de baños",
                Name = "BathroomCountColumn",
                Width = 130
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(HousingDTGData);
        }

        private void CondominiumPNLBTNCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
