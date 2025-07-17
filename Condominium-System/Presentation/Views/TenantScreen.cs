using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Condominium_System.Presentation.Views
{
    public partial class TenantScreen : Form
    {

        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;

        User currentUser;

        public TenantScreen(ITenantService tenantService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void TenantScreen_Load(object sender, EventArgs e)
        {

            TenantDTGData.CellPainting += TenantDTGData_CellPainting;
            TenantDTGData.CellClick += TenantDTGData_CellClick;

            SetDataGridStyle();
            ConfigureHousingColumns();
            await LoadDataToDataGrid();
        }

        private void TenantDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && TenantDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                e.PaintBackground(e.CellBounds, true);
                e.PaintContent(e.CellBounds);

                int iconWidth = 16;
                int iconHeight = 16;
                int padding = 5;

                int x = e.CellBounds.Left + padding;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconHeight) / 2;

                e.Graphics.DrawImage(Properties.Resources.pencil_blue, new Rectangle(x, y, iconWidth, iconHeight));

                x += iconWidth + padding;
                e.Graphics.DrawImage(Properties.Resources.trash_red, new Rectangle(x, y, iconWidth, iconHeight));

                e.Handled = true;
            }
        }

        private async void TenantDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && TenantDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = TenantDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = TenantDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = TenantDTGData.Rows[e.RowIndex];
                var selectedTenant = selectedRow.DataBoundItem as Tenant;

                if (selectedTenant == null)
                {
                    MessageBox.Show("No se pudo identificar el inqulino.");
                    return;
                }

                if (relativeX < 26) // 🟢 Editar
                {
                    Session.TenantToUpsert = selectedTenant;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52) // 🔴 Eliminar
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el inquilino '{selectedTenant.FirstName}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _tenantService.DeleteAsync(selectedTenant.Id);
                            MessageBox.Show("Inquilino eliminado correctamente.");
                            LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar inquilino: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (TenantDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un inquilino para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedTenant = TenantDTGData.CurrentRow.DataBoundItem as Tenant;
                if (selectedTenant == null)
                {
                    MessageBox.Show("Error al obtener el inquilino seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.TenantToUpsert = selectedTenant;
            }
            else
            {
                Session.TenantToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<UpsertTenantScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }               

        public async Task LoadDataToDataGrid()
        {
            try
            {
                var listTenant = await _tenantService.GetAllAsync();
                var bindingList = new BindingList<Tenant>((List<Tenant>)(IEnumerable<Tenant>)listTenant);
                var source = new BindingSource(bindingList, null);
                TenantDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando inquilinos: {ex.Message}");
            }
        }

        private void ConfigureHousingColumns()
        {

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 105
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "Nombre",
                Name = "FirstNameColumn",
                Width = 120
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Apellido",
                Name = "LastNameColumn",
                Width = 130
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DocumentNumber",
                HeaderText = "Cantidad de habitaciones",
                Name = "DocumentNumberColumn",
                Width = 150
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PhoneNumber",
                HeaderText = "Numero de teléfono",
                Name = "PhoneNumberColumn",
                Width = 155
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Gender",
                HeaderText = "Sexo",
                Name = "GenderColumn",
                Width = 100
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HousingId",
                HeaderText = "Identificación de la vivienda",
                Name = "HousingIdColumn",
                Width = 130
            });

            TenantDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(TenantDTGData);
        }

        private async void CleanForm()
        {
            TenantTBID.Clear();
            await LoadDataToDataGrid();
        }

        private async void TenantPNLBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        private async void TenantPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TenantTBID.Text))
            {
                try
                {
                    int id = int.Parse(TenantTBID.Text);
                    var TenantFound = await _tenantService.GetByIdAsync(id);

                    if (TenantFound != null)
                    {
                        TenantDTGData.DataSource = new List<Tenant> { TenantFound };
                    }
                    else
                    {
                        MessageBox.Show("Inquilino no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando inquilino: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
            }
        }
                
        private async void TenantPNLBTNDelete_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TenantTBID.Text))
            {
                var TenantToDelete = await _tenantService.GetByIdAsync(Int32.Parse(TenantTBID.Text));

                if (TenantToDelete != null)
                {
                    TenantToDelete.DeletedAt = DateTime.Now;

                    await _tenantService.DeleteAsync(Int32.Parse(TenantTBID.Text));
                    MessageBox.Show("El inquilino ha sido borrado con exitosamente.");

                    await LoadDataToDataGrid();
                    CleanForm();
                }
                else
                {
                    MessageBox.Show("Inquilino no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("El campo de Id debe de estar lleno.");
            }
        }
    }
}
