using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using FastReport;
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
using Timer = System.Windows.Forms.Timer;

namespace Condominium_System.Presentation.Views
{
    public partial class UsersScreen : Form
    {

        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;
        private readonly ICondominiumService _condominiumService;

        User currentUser;

        private CancellationTokenSource _searchCts;
        private DateTime _lastSearchTime;

        public UsersScreen(IUserService userService, IServiceProvider serviceProvider, ICondominiumService condominiumService)
        {
            InitializeComponent();
            _userService = userService;
            _serviceProvider = serviceProvider;
            _condominiumService = condominiumService;

            currentUser = Session.CurrentUser;

            _searchCts = new CancellationTokenSource();

            SetSearchTextBoxStyleAndBehavior();
        }

        private void SetSearchTextBoxStyleAndBehavior()
        {
            UserTxtBxPId.Text = "Criterio de busqueda";
            UserTxtBxPId.ForeColor = SystemColors.GrayText;
            UserTxtBxPId.Enter += (s, e) =>
            {
                if (UserTxtBxPId.Text == "Criterio de busqueda")
                {
                    UserTxtBxPId.Text = "";
                    UserTxtBxPId.ForeColor = SystemColors.WindowText;
                }
            };
            UserTxtBxPId.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(UserTxtBxPId.Text))
                {
                    UserTxtBxPId.Text = "Criterio de busqueda";
                    UserTxtBxPId.ForeColor = SystemColors.GrayText;
                }
            };
        }

        private void UsersScreen_Load(object sender, EventArgs e)
        {
            UserDTGData.CellPainting += UserDTGData_CellPainting;
            UserDTGData.CellClick += UserDTGData_CellClick;

            SetDataGridStyle();
            ConfigureUserColumns();
            LoadDataToDataGrid();
        }

        private void UserDTGData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && UserDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
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

        private async void UserDTGData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && UserDTGData.Columns[e.ColumnIndex].Name == "ActionsColumn")
            {
                var cellBounds = UserDTGData.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                var clickPosition = UserDTGData.PointToClient(Cursor.Position);
                int relativeX = clickPosition.X - cellBounds.Left;

                var selectedRow = UserDTGData.Rows[e.RowIndex];
                var selectedUser = selectedRow.DataBoundItem as User;

                if (selectedUser == null)
                {
                    MessageBox.Show("No se pudo identificar el usuario.");
                    return;
                }

                if (relativeX < 26)
                {
                    Session.UserToUpsert = selectedUser;
                    GoToUpsertScreen(true);
                }
                else if (relativeX >= 26 && relativeX < 52)
                {
                    var confirm = MessageBox.Show($"¿Deseas eliminar el usuario '{selectedUser.Username}'?",
                                                  "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            await _userService.DeleteAsync(selectedUser.Id);
                            MessageBox.Show("Usuario eliminado correctamente.");
                            LoadDataToDataGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar usuario: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void GoToUpsertScreen(bool isToUpdate)
        {
            if (isToUpdate)
            {
                if (UserDTGData.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, selecciona un usuario para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedUser = UserDTGData.CurrentRow.DataBoundItem as User;
                if (selectedUser == null)
                {
                    MessageBox.Show("Error al obtener el usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Session.UserToUpsert = selectedUser;
            }
            else
            {
                Session.UserToUpsert = null;
            }

            var upsertScreen = _serviceProvider.GetRequiredService<SignUpScreen>();
            upsertScreen.IsEditMode = isToUpdate;
            upsertScreen.Owner = this;
            upsertScreen.Show();
        }

        private void ConfigureUserColumns()
        {

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 110
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "Nombre",
                Name = "FirstNameColumn",
                Width = 150
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Apellido",
                Name = "LastNameColumn",
                Width = 150
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DocumentNumber",
                HeaderText = "Cedula",
                Name = "DocumentNumberColumn",
                Width = 130
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Username",
                HeaderText = "Nombre de Usuario",
                Name = "UsernameColumn",
                Width = 160
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Password",
                HeaderText = "Contraseña",
                Name = "PasswordColumn",
                Width = 100
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Type",
                HeaderText = "Tipo",
                Name = "TypeColumn",
                Width = 100
            });

            UserDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Acciones",
                Name = "ActionsColumn",
                Width = 100
            });
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(UserDTGData);
        }

        private void UserBTNCreate_Click(object sender, EventArgs e)
        {
            GoToUpsertScreen(false);
        }

        public async void LoadDataToDataGrid()
        {
            try
            {
                var listUser = await _userService.GetAllAsync();
                var bindingList = new BindingList<User>((List<User>)(IEnumerable<User>)listUser);
                var source = new BindingSource(bindingList, null);
                UserDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los usuarios: {ex.Message}");
            }
        }

        private async void UserBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(UserTxtBxPId.Text))
            {
                try
                {
                    int id = int.Parse(UserTxtBxPId.Text);
                    var userFound = await _userService.GetByIdAsync(id);

                    if (userFound != null)
                    {
                        UserDTGData.DataSource = new List<User> { userFound };
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CleanForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error buscando usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("El campo Id debe estar lleno correctamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CleanForm();
            }
        }

        private void CleanForm()
        {
            UserTxtBxPId.Clear();
            LoadDataToDataGrid();
        }

        private async void UserTxtBxPId_TextChanged(object sender, EventArgs e)
        {
            if (!this.IsHandleCreated || this.IsDisposed) return;
            if (UserTxtBxPId.Text == "Criterio de busqueda") return;

            _searchCts?.Cancel();
            _searchCts = new CancellationTokenSource();

            try
            {
                string searchTerm = UserTxtBxPId.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    LoadDataToDataGrid();
                    return;
                }

                await Task.Delay(500, _searchCts.Token);

                bool shouldSearch = string.IsNullOrEmpty(searchTerm) || searchTerm.Length >= 2;

                if (shouldSearch && !_searchCts.IsCancellationRequested)
                {
                    var filteredUsers = await _userService.SearchUsersAsync(searchTerm);

                    if (!_searchCts.IsCancellationRequested)
                    {
                        _lastSearchTime = DateTime.Now;

                        if (this.IsHandleCreated && !this.IsDisposed && !_searchCts.IsCancellationRequested)
                        {
                            this.BeginInvoke((MethodInvoker)delegate
                            {
                                if (this.IsHandleCreated && !this.IsDisposed && UserDTGData != null && !UserDTGData.IsDisposed)
                                {
                                    try
                                    {
                                        UserDTGData.DataSource = filteredUsers?.ToList() ?? new List<User>();

                                        if (filteredUsers != null && !filteredUsers.Any() && !string.IsNullOrEmpty(searchTerm))
                                        {
                                            ShowStatusMessage("No se encontraron usuarios", 3000);
                                        }
                                        else if (statusLabel != null)
                                        {
                                            statusLabel.Visible = false;
                                        }
                                    }
                                    catch (ObjectDisposedException) { }
                                }
                            });
                        }
                    }
                }
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                if (this.IsHandleCreated && !this.IsDisposed && !_searchCts.IsCancellationRequested)
                {
                    this.BeginInvoke((MethodInvoker)delegate
                    {
                        if (this.IsHandleCreated && !this.IsDisposed && statusLabel != null)
                        {
                            try
                            {
                                ShowStatusMessage($"Error: {ex.Message}", 3000);
                            }
                            catch (ObjectDisposedException) { }
                        }
                    });
                }
            }
        }

        private void ShowStatusMessage(string message, int durationMs)
        {
            if (statusLabel == null || this.IsDisposed || !this.IsHandleCreated)
                return;

            try
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (this.IsHandleCreated && !this.IsDisposed && statusLabel != null)
                    {
                        statusLabel.Text = message;
                        statusLabel.Visible = true;

                        var timer = new Timer { Interval = durationMs };
                        timer.Tick += (s, e) =>
                        {
                            if (statusLabel != null && this.IsHandleCreated && !this.IsDisposed)
                            {
                                statusLabel.Visible = false;
                            }
                            timer.Stop();
                            timer.Dispose();
                        };
                        timer.Start();
                    }
                });
            }
            catch (ObjectDisposedException) { }
            catch (InvalidOperationException) { }
        }

        private void GenerateUserReportFromFilteredData_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<User> users = null;

                if (UserDTGData.DataSource is BindingSource bindingSource)
                {
                    users = bindingSource.DataSource as IEnumerable<User>;
                }
                else if (UserDTGData.DataSource is IEnumerable<User> list)
                {
                    users = list;
                }

                if (users == null || !users.Any())
                {
                    MessageBox.Show("No se encontraron usuarios para el informe.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var report = new Report();
                report.Load("Presentation/Reports/Filtered Reports/UserReportFiltered.frx");

                report.RegisterData(users.ToList(), "Users");
                report.GetDataSource("Users").Enabled = true;

                var viewer = new ReportViewerForm(report);
                viewer.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generando reporte: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
