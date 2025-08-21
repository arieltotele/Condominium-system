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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominium_System.Presentation.Views
{
    public partial class UpsertHousingScreen : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IHousingEntityService _housingEntityService;
        private readonly IBlockService _blockService;

        User? currentUser;

        public bool IsEditMode { get; set; } = false;

        public UpsertHousingScreen(IServiceProvider serviceProvider, IHousingEntityService housingEntityService, IBlockService blockService)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _blockService = blockService;
            _housingEntityService = housingEntityService;
            currentUser = Session.CurrentUser;
        }

        private async void UpsertHousingScreen_Load(object sender, EventArgs e)
        {
            await LoadBlocksIntoComboBox();

            if (IsEditMode)
            {
                LoadDataIfIsToUpdate();
            }
        }

        private void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.CurrentHouse != null)
            {
                var housing = Session.CurrentHouse;
                HousingTBPeopleQuantity.Text = housing.PeopleCount.ToString();
                HousingTBCode.Text = housing.Code;
                HousingTBRoomQuantity.Text = housing.RoomCount.ToString();
                HousingTBBathroomQuantity.Text = housing.BathroomCount.ToString();
                HousingCBBlock.SelectedValue = housing.BlockId;
            }
        }

        private async Task LoadBlocksIntoComboBox()
        {
            try
            {
                var blocks = (await _blockService.GetAllBlocksAsync()).ToList();

                if (!blocks.Any())
                {
                    HousingCBBlock.DataSource = null;
                    HousingCBBlock.Items.Clear();
                    HousingCBBlock.Text = "No hay bloques registrados";
                    HousingCBBlock.Enabled = false;

                    MessageBox.Show("No se encontraron bloques registrados. Por favor, registre al menos un bloque.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    if (this.Owner is HousingBlocksScreen owner)
                    {
                        owner.LoadDataToDataGrid();
                    }
                    this.Hide();
                    return;
                }

                // Configuración normal cuando sí hay bloques
                var placeholder = new Block { Id = 0, Name = "-- Seleccione un bloque --" };
                var listWithPlaceholder = new List<Block> { placeholder };
                listWithPlaceholder.AddRange(blocks);

                HousingCBBlock.DisplayMember = "Name";
                HousingCBBlock.ValueMember = "Id";
                HousingCBBlock.DataSource = listWithPlaceholder;
                HousingCBBlock.SelectedIndex = 0;
                HousingCBBlock.Enabled = true;
            }
            catch (Exception ex)
            {
                HousingCBBlock.DataSource = null;
                HousingCBBlock.Items.Clear();
                HousingCBBlock.Text = "Error al cargar bloques";
                HousingCBBlock.Enabled = false;

                MessageBox.Show($"Error cargando bloques: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);

                // Cierra el modal también en caso de error
                if (this.Owner is HousingBlocksScreen owner)
                {
                    owner.LoadDataToDataGrid();
                }
                this.Hide();
            }
            finally
            {
                HousingCBBlock.Refresh();
            }
        }

        private void UpsertHousingScreen_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditHouse(); }
            else { SaveHouse(); }
        }

        private async void EditHouse()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var HousingToUpdate = Session.CurrentHouse;

                    if (HousingToUpdate != null)
                    {
                        HousingToUpdate.PeopleCount = Int32.Parse(HousingTBPeopleQuantity.Text);
                        HousingToUpdate.RoomCount = Int32.Parse(HousingTBRoomQuantity.Text);
                        HousingToUpdate.BathroomCount = Int32.Parse(HousingTBBathroomQuantity.Text);
                        HousingToUpdate.Code = HousingTBCode.Text.Trim().ToUpper();
                        HousingToUpdate.BlockId = (int)HousingCBBlock.SelectedValue;

                        HousingToUpdate.UpdatedAt = DateTime.Now;

                        await _housingEntityService.UpdateHousingAsync(HousingToUpdate);

                        MessageBox.Show("La vivienda ha sido actualizada con exito.");
                        CleanForm();

                        Session.CurrentHouse = HousingToUpdate;

                        await ((HousingScreen)this.Owner).LoadDataToDataGrid();

                        GoToAddFurnitureScreen(true);
                    }
                    else
                    {
                        MessageBox.Show("Vivienda no encontrada.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando vivienda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveHouse()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewHouse = new Housing()
                    {
                        Code = HousingTBCode.Text.Trim().ToUpper(),
                        PeopleCount = Int32.Parse(HousingTBPeopleQuantity.Text),
                        RoomCount = Int32.Parse(HousingTBRoomQuantity.Text),
                        BathroomCount = Int32.Parse(HousingTBBathroomQuantity.Text),
                        BlockId = (int)HousingCBBlock.SelectedValue,
                        Author = currentUser.Username
                    };

                    Session.CurrentHouse = await _housingEntityService.CreateHousingAsync(NewHouse);

                    MessageBox.Show("La vivienda ha sido creada con exito.");
                    CleanForm();

                    await ((HousingScreen)this.Owner).LoadDataToDataGrid();

                    GoToAddFurnitureScreen(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando vivienda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private void GoToAddFurnitureScreen(bool isGoingToEdit)
        {
            var addFurnitureToHouseScreen = _serviceProvider.GetRequiredService<AddFurnitureScreen>();
            addFurnitureToHouseScreen.IsEditMode = isGoingToEdit;
            addFurnitureToHouseScreen.Owner = this;
            this.Hide();
            addFurnitureToHouseScreen.Show();
        }

        public bool FormIsCorrect()
        {
            bool isBlockValid = int.TryParse(HousingCBBlock.SelectedValue?.ToString(), out int blockId) && blockId != 0;

            return !(
               string.IsNullOrEmpty(HousingTBPeopleQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBRoomQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBBathroomQuantity.Text) ||
               string.IsNullOrEmpty(HousingTBCode.Text) ||
               !isBlockValid
           );
        }

        private void CleanForm()
        {
            HousingTBCode.Clear();
            HousingTBPeopleQuantity.Clear();
            HousingTBRoomQuantity.Clear();
            HousingTBBathroomQuantity.Clear();

            if (HousingCBBlock.Items.Count > 0)
                HousingCBBlock.SelectedIndex = 0;
        }
    }
}
