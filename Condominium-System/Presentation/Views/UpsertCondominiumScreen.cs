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
    public partial class UpsertCondominiumScreen : Form
    {
        private readonly ICondominiumService _condominiumService;
        private readonly IServiceProvider _serviceProvider;
        User currentUser;

        public bool IsEditMode { get; set; } = false;
        public UpsertCondominiumScreen(ICondominiumService condominiumService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _condominiumService = condominiumService;
            _serviceProvider = serviceProvider;
            currentUser = Session.CurrentUser;
        }

        private void AddCondominiumScreen_Load(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                //CustomButtonToUpsert();
                LoadDataIfIsToUpdate();
            }
        }

        private void CustomButtonToUpsert()
        {
            UpsertLBLBTN.Text = "Editar";
            UpsertPCTBXBTN.Image = Properties.Resources.pencil_white;
        }

        private void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.CondominiumToUpsert != null)
            {
                var condo = Session.CondominiumToUpsert;
                UpsertTIName.Text = condo.Name;
                UpsertTIAddress.Text = condo.Address;
                UpsertMskTBContactNumber.Text = condo.ReceptionContactNumber;
                UpsertTIBlocksQuantity.Text = condo.BlockCount.ToString();
            }
        }

        private void OnlyAllowLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&
                !char.IsControl(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != 'á' && e.KeyChar != 'é' && e.KeyChar != 'í' &&
                e.KeyChar != 'ó' && e.KeyChar != 'ú' && e.KeyChar != 'ñ' &&
                e.KeyChar != 'Á' && e.KeyChar != 'É' && e.KeyChar != 'Í' &&
                e.KeyChar != 'Ó' && e.KeyChar != 'Ú' && e.KeyChar != 'Ñ')
                {
                    e.Handled = true;
                }
        }

        private void OnlyAllowNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void UpsertLBLBTN_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditCondominium(); }
            else { SaveCondominium(); }
        }

        private async void EditCondominium()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var CondominiumToUpdate = Session.CondominiumToUpsert;

                    if (CondominiumToUpdate != null)
                    {
                        CondominiumToUpdate.Name = UpsertTIName.Text;
                        CondominiumToUpdate.Address = UpsertTIAddress.Text;
                        CondominiumToUpdate.ReceptionContactNumber = UpsertMskTBContactNumber.Text;
                        CondominiumToUpdate.BlockCount = Int32.Parse(UpsertTIBlocksQuantity.Text);
                        CondominiumToUpdate.UpdatedAt = DateTime.Now;

                        await _condominiumService.UpdateCondominiumAsync(CondominiumToUpdate);

                        MessageBox.Show("El condominio ha sido actualizado con exito");
                        CleanForm();
                        ((CondominiumScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Condominio no encontrado.");
                        CleanForm();
                        return;
                    }
                }
                catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    MessageBox.Show("Ya existe un condominio con ese nombre. Por favor elija otro.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando condominio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveCondominium()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var NewCondominium = new Condominium()
                    {
                        Name = UpsertTIName.Text,
                        Address = UpsertTIAddress.Text,
                        ReceptionContactNumber = UpsertMskTBContactNumber.Text,
                        BlockCount = Int32.Parse(UpsertTIBlocksQuantity.Text),

                        Author = currentUser.Username
                    };

                    await _condominiumService.CreateCondominiumAsync(NewCondominium);

                    MessageBox.Show("El condominio ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    ((CondominiumScreen)this.Owner).LoadDataToDataGrid();
                    this.Hide();
                }
                catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlEx && (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    MessageBox.Show("Ya existe un condominio con ese nombre. Por favor elija otro.", "Nombre duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CleanForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando condominio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private void CleanForm()
        {
            UpsertTIName.Text = "";
            UpsertTIAddress.Text = "";
            UpsertTIBlocksQuantity.Text = "";
            UpsertMskTBContactNumber.Clear();
        }

        public bool FormIsCorrect() =>
             (String.IsNullOrEmpty(UpsertTIName.Text) || String.IsNullOrEmpty(UpsertTIAddress.Text)
                || String.IsNullOrEmpty(UpsertTIBlocksQuantity.Text) || String.IsNullOrEmpty(UpsertMskTBContactNumber.Text)
                || UpsertMskTBContactNumber.Text.Trim().Length != 10) ? false : true;
    }
}
