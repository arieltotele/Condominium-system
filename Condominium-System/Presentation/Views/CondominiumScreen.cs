using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public partial class CondominiumScreen : Form
    {

        private readonly ICondominiumService _condominiumService;
        User currentUser;

        public CondominiumScreen(ICondominiumService condominiumService)
        {
            InitializeComponent();
            _condominiumService = condominiumService;
            LoadDataToDataGrid();
            DisableDataGrid();
            currentUser = Session.CurrentUser;
        }

        private void CondominuiumScreen_Load(object sender, EventArgs e)
        {
            UIUtils.RoundPanelCorners(CondominiumPNLBTNCreate, 10);
            UIUtils.RoundPanelCorners(CondominiumPNLBTNSearch, 10);
            UIUtils.RoundPanelCorners(CondominiumPNLBTNUpdate, 10);
            UIUtils.RoundPanelCorners(CondominiumPNLBTNDelete, 10);
        }

        private async void CondominiumBTNCreate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewCondominium = new Condominium()
                    {
                        Name = CondominiumTIName.Text,
                        Address = CondominiumTIAddress.Text,
                        ReceptionContactNumber = CondominiumMskTBContactNumber.Text,
                        BlockCount = Int32.Parse(CondominiumTIBlocksQuantity.Text),

                        Author = currentUser.Username
                    };

                    await _condominiumService.CreateCondominiumAsync(NewCondominium);

                    MessageBox.Show("El condominio ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando condominio: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        public bool FormIsCorrect() =>
             (String.IsNullOrEmpty(CondominiumTIName.Text) || String.IsNullOrEmpty(CondominiumTIAddress.Text)
                || String.IsNullOrEmpty(CondominiumTIBlocksQuantity.Text) || String.IsNullOrEmpty(CondominiumMskTBContactNumber.Text)
                || CondominiumMskTBContactNumber.Text.Trim().Length != 10) ? false : true;


        public bool FormIsCorrectToUpdate() =>
             (String.IsNullOrEmpty(CondominiumTIId.Text) || String.IsNullOrEmpty(CondominiumTIName.Text)
                || String.IsNullOrEmpty(CondominiumTIAddress.Text) || String.IsNullOrEmpty(CondominiumTIBlocksQuantity.Text)
                || String.IsNullOrEmpty(CondominiumMskTBContactNumber.Text) || CondominiumMskTBContactNumber.Text.Trim().Length != 10) ? false : true;



        private async void CondominiumBTNSearch_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CondominiumTIId.Text))
            {
                try
                {
                    var CondominiumFound = await _condominiumService.GetCondominiumByIdAsync(Int32.Parse(CondominiumTIId.Text));
                    if (CondominiumFound != null)
                    {
                        CondominiumTIId.Text = CondominiumFound.Id.ToString();
                        CondominiumTIName.Text = CondominiumFound.Name;
                        CondominiumTIAddress.Text = CondominiumFound.Address;
                        CondominiumTIBlocksQuantity.Text = CondominiumFound.BlockCount.ToString();
                        CondominiumMskTBContactNumber.Text = CondominiumFound.ReceptionContactNumber;
                    }
                    else
                    {
                        MessageBox.Show("Condominio no encontrado.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando condominio: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe de estar lleno correctamente.");
            }
        }

        private void CondominiumTIId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void LoadDataToDataGrid()
        {
            try
            {
                var listCondominium = await _condominiumService.GetAllCondominiumsAsync();
                var bindingList = new BindingList<Condominium>((List<Condominium>)(IEnumerable<Condominium>)listCondominium);
                var source = new BindingSource(bindingList, null);
                CondominiumDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando condominios: {ex.Message}");
            }
        }

        private void DisableDataGrid()
        {
            CondominiumDTGData.ReadOnly = true;
            CondominiumDTGData.AllowUserToAddRows = false;
            CondominiumDTGData.AllowUserToDeleteRows = false;
            CondominiumDTGData.AllowUserToResizeColumns = false;
            CondominiumDTGData.AllowUserToResizeRows = false;
            CondominiumDTGData.AllowUserToOrderColumns = false;
            //CondominiumDTGData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CondominiumDTGData.MultiSelect = false;
            CondominiumDTGData.ScrollBars = ScrollBars.Both;
        }

        private async void CondominiumBTNUpdate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrectToUpdate())
            {
                try
                {
                    var CondominiumToUpdate = await _condominiumService.GetCondominiumByIdAsync(Int32.Parse(CondominiumTIId.Text));

                    if (CondominiumToUpdate != null)
                    {
                        CondominiumToUpdate.Id = Int32.Parse(CondominiumTIId.Text);
                        CondominiumToUpdate.Name = CondominiumTIName.Text;
                        CondominiumToUpdate.Address = CondominiumTIAddress.Text;
                        CondominiumToUpdate.ReceptionContactNumber = CondominiumMskTBContactNumber.Text;
                        CondominiumToUpdate.BlockCount = Int32.Parse(CondominiumTIBlocksQuantity.Text);
                        CondominiumToUpdate.UpdatedAt = DateTime.Now;

                        _condominiumService.UpdateCondominiumAsync(CondominiumToUpdate);

                        MessageBox.Show("El condominio ha sido actualizado con exito");
                        LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Condominio no encontrado.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving user: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void CondominiumBTNDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CondominiumTIId.Text))
            {
                var CondominiumToDelete = await _condominiumService.GetCondominiumByIdAsync(Int32.Parse(CondominiumTIId.Text));

                if (CondominiumToDelete != null)
                {
                    await _condominiumService.DeleteCondominiumAsync(Int32.Parse(CondominiumTIId.Text));
                    MessageBox.Show("El condominio ha sido borrado con exitosamente.");
                    LoadDataToDataGrid();
                    CleanForm();

                }
                else
                {
                    MessageBox.Show("Incidence not found");
                }
            }
            else
            {
                MessageBox.Show("The ID field must be filled in.");
            }
        }

        private void CleanForm()
        {
            CondominiumTIId.Text = string.Empty;
            CondominiumTIName.Text = string.Empty;
            CondominiumTIAddress.Text = string.Empty;
            CondominiumTIBlocksQuantity.Text = string.Empty;
            CondominiumMskTBContactNumber.Clear();
        }
    }
}
