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
            currentUser = Session.CurrentUser;
        }

        private void CondominuiumScreen_Load(object sender, EventArgs e)
        {
            UIUtils.RoundPanelCorners(CondominiumPNLBTNCreate, 10);
            //UIUtils.RoundPanelCorners(CondominiumPNLBTNSearch, 10);
            //UIUtils.RoundPanelCorners(CondominiumPNLBTNUpdate, 10);
            //UIUtils.RoundPanelCorners(CondominiumPNLBTNDelete, 10);

            CondominiumDTGData.CellPainting += CondominiumDTGData_CellPainting;
            CondominiumDTGData.CellClick += CondominiumDTGData_CellClick;

            SetDataGridStyle();
            ConfigureCondominiumColumns();
            LoadDataToDataGrid();
        }

        private async void LoadDataToDataGrid()
        {
            try
            {
                var listCondominium = await _condominiumService.GetAllCondominiumsAsync();
                var bindingList = new BindingList<Condominium>((List<Condominium>)(IEnumerable<Condominium>)listCondominium);
                var source = new BindingSource(bindingList, null);
                CondominiumDTGData.DataSource = source;

                CondominiumDTGData.EnableHeadersVisualStyles = false;
                CondominiumDTGData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 65, 194);
                CondominiumDTGData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                CondominiumDTGData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando condominios: {ex.Message}");
            }
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(CondominiumDTGData);
        }

        private void ConfigureCondominiumColumns()
        {

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 120
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre",
                Name = "NameColumn",
                Width = 200
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Address",
                HeaderText = "Direccion",
                Name = "AddressColumn",
                Width = 200
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ReceptionContactNumber",
                HeaderText = "Numero de recepcion",
                Name = "ReceptionContactNumberColumn",
                Width = 200
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BlockCount",
                HeaderText = "Numero de bloques",
                Name = "BlockCountColumn",
                Width = 180
            });

            CondominiumDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void CondominiumDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && CondominiumDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                int iconWidth = 16;
                int iconHeight = 16;
                int padding = 5;

                // Calcula posición para los íconos
                int x = e.CellBounds.Left + padding;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                // Dibuja el ícono de editar
                e.Graphics.DrawImage(Properties.Resources.pencil_blue, new Rectangle(x, y, iconWidth, iconHeight));

                // Dibuja el ícono de eliminar al lado derecho
                x += iconWidth + padding;
                e.Graphics.DrawImage(Properties.Resources.trash_red, new Rectangle(x, y, iconWidth, iconHeight));

                e.Handled = true;
            }
        }

        private void CondominiumDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && CondominiumDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = CondominiumDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = CondominiumDTGData.PointToClient(Cursor.Position);

                int relativeX = clickPosition.X - cellBounds.Left;

                if (relativeX < 26) // Primer botón (Editar)
                {
                    MessageBox.Show("Editar fila: " + e.RowIndex);
                }
                else if (relativeX >= 26 && relativeX < 52) // Segundo botón (Eliminar)
                {
                    MessageBox.Show("Eliminar fila: " + e.RowIndex);
                }
            }
        }

        private async void CondominiumBTNCreate_Click(object sender, EventArgs e)
        {
            //if (FormIsCorrect())
            //{
            //    try
            //    {
            //        var NewCondominium = new Condominium()
            //        {
            //            Name = CondominiumTIName.Text,
            //            Address = CondominiumTIAddress.Text,
            //            ReceptionContactNumber = CondominiumMskTBContactNumber.Text,
            //            BlockCount = Int32.Parse(CondominiumTIBlocksQuantity.Text),

            //            Author = currentUser.Username
            //        };

            //        await _condominiumService.CreateCondominiumAsync(NewCondominium);

            //        MessageBox.Show("El condominio ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        LoadDataToDataGrid();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error guardando condominio: {ex.Message}");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Todos los campos deben ser completados correctamente.");
            //}
        }

        //public bool FormIsCorrect() =>
        //     (String.IsNullOrEmpty(CondominiumTIName.Text) || String.IsNullOrEmpty(CondominiumTIAddress.Text)
        //        || String.IsNullOrEmpty(CondominiumTIBlocksQuantity.Text) || String.IsNullOrEmpty(CondominiumMskTBContactNumber.Text)
        //        || CondominiumMskTBContactNumber.Text.Trim().Length != 10) ? false : true;


        //public bool FormIsCorrectToUpdate() =>
        //     (String.IsNullOrEmpty(CondominiumTIId.Text) || String.IsNullOrEmpty(CondominiumTIName.Text)
        //        || String.IsNullOrEmpty(CondominiumTIAddress.Text) || String.IsNullOrEmpty(CondominiumTIBlocksQuantity.Text)
        //        || String.IsNullOrEmpty(CondominiumMskTBContactNumber.Text) || CondominiumMskTBContactNumber.Text.Trim().Length != 10) ? false : true;

        private async void CondominiumBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CondominiumTIId.Text))
            {
                try
                {
                    int id = int.Parse(CondominiumTIId.Text);
                    var condominiumFound = await _condominiumService.GetCondominiumByIdAsync(id);

                    if (condominiumFound != null)
                    {
                        // Mostrar solo el condominio encontrado
                        CondominiumDTGData.DataSource = new List<Condominium> { condominiumFound };
                    }
                    else
                    {
                        MessageBox.Show("Condominio no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando condominio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CondominiumTIId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }       

        private async void CondominiumBTNUpdate_Click(object sender, EventArgs e)
        {
            //if (FormIsCorrectToUpdate())
            //{
            //    try
            //    {
            //        var CondominiumToUpdate = await _condominiumService.GetCondominiumByIdAsync(Int32.Parse(CondominiumTIId.Text));

            //        if (CondominiumToUpdate != null)
            //        {
            //            //CondominiumToUpdate.Id = Int32.Parse(CondominiumTIId.Text);
            //            //CondominiumToUpdate.Name = CondominiumTIName.Text;
            //            //CondominiumToUpdate.Address = CondominiumTIAddress.Text;
            //            //CondominiumToUpdate.ReceptionContactNumber = CondominiumMskTBContactNumber.Text;
            //            //CondominiumToUpdate.BlockCount = Int32.Parse(CondominiumTIBlocksQuantity.Text);
            //            //CondominiumToUpdate.UpdatedAt = DateTime.Now;

            //            CondominiumToUpdate.UpdatedAt = DateTime.Now;

            //            await _condominiumService.UpdateCondominiumAsync(CondominiumToUpdate);

            //            MessageBox.Show("El condominio ha sido actualizado con exito");
            //            LoadDataToDataGrid();
            //            CleanForm();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Condominio no encontrado.");
            //            return;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Error guardando el condominio: {ex.Message}");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Todos los campos deben ser completados correctamente.");
            //}
        }

        private async void CondominiumBTNDelete_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(CondominiumTIId.Text))
            {
                
                var CondominiumToDelete = await _condominiumService.GetCondominiumByIdAsync(Int32.Parse(CondominiumTIId.Text));

                if (CondominiumToDelete != null)
                {
                    CondominiumToDelete.DeletedAt = DateTime.Now;
                    await _condominiumService.DeleteCondominiumAsync(Int32.Parse(CondominiumTIId.Text));
                    MessageBox.Show("El condominio ha sido borrado con exitosamente.");
                    LoadDataToDataGrid();
                    CleanForm();
                }
                else
                {
                    MessageBox.Show("Condominio no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("El campo de Id debe de estar lleno.");
            }
        }

        private void CleanForm()
        {
            CondominiumTIId.Text = string.Empty;
            //CondominiumTIName.Text = string.Empty;
            //CondominiumTIAddress.Text = string.Empty;
            //CondominiumTIBlocksQuantity.Text = string.Empty;
            //CondominiumMskTBContactNumber.Clear();
        }
    }
}
