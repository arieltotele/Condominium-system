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
    public partial class IncidenceScreen : Form
    {
        private readonly IIncidentService _incidentService;
        private readonly ITenantService _tenantService;

        User currentUser;

        public IncidenceScreen(IIncidentService incidentService, ITenantService tenantService)
        {
            InitializeComponent();
            _incidentService = incidentService;
            _tenantService = tenantService;            
            currentUser = Session.CurrentUser;
        }

        private async void IncidenceScreen_Load(object sender, EventArgs e)
        {
            SetDataGridStyle();
            ConfigureIncidenceColumns();
            await LoadDataToDataGrid();
            await LoadTenantsIntoComboBox();
        }

        private async Task LoadTenantsIntoComboBox()
        {
            try
            {
                var tenants = await _tenantService.GetAllAsync();

                var placeholder = new { Id = 0, Display = "-- Seleccione un inquilino --" };

                var tenantDisplayList = tenants.Select(t => new
                {
                    Id = t.Id,
                    Display = $"{FormatDocument(t.DocumentNumber)} - {t.FirstName} {t.LastName}"
                }).ToList();

                tenantDisplayList.Insert(0, placeholder);

                IncidenceCBTenants.DisplayMember = "Display";
                IncidenceCBTenants.ValueMember = "Id";
                IncidenceCBTenants.DataSource = tenantDisplayList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando los inquilinos: {ex.Message}");
            }
        }

        private string FormatDocument(string doc)
        {
            if (!string.IsNullOrEmpty(doc) && doc.Length == 11)
                return $"{doc.Substring(0, 3)}-{doc.Substring(3, 7)}-{doc.Substring(10, 1)}";

            return doc;
        }

        private async Task LoadDataToDataGrid()
        {
            try
            {
                var listIncidence = await _incidentService.GetAllAsync();
                var bindingList = new BindingList<Incident>((List<Incident>)(IEnumerable<Incident>)listIncidence);
                var source = new BindingSource(bindingList, null);
                IncidenceDTGData.DataSource = source;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando las incidencias: {ex.Message}");
            }
        }
        private void ConfigureIncidenceColumns()
        {

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Identificacion",
                Name = "IdColumn",
                Width = 110
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Fecha",
                Name = "DateColumn",
                Width = 220
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Description",
                HeaderText = "Descripción",
                Name = "DescriptionColumn",
                Width = 280
            });

            IncidenceDTGData.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TenantId",
                HeaderText = "Documentacion del inquilino",
                Name = "TenantIdColumn",
                Width = 300
            });            
        }

        private void SetDataGridStyle()
        {
            UIUtils.SetDataGridStyle(IncidenceDTGData);
        }

        private async void IncidentPNLBTNCreate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrect())
            {
                try
                {
                    var newIncident = new Incident()
                    {
                        Description = IncidenceTBDescription.Text,
                        Date = IncidenceDTPDate.Value,
                        TenantId = (int) IncidenceCBTenants.SelectedValue,
                        Author = currentUser.Username
                    };

                    await _incidentService.CreateAsync(newIncident);

                    MessageBox.Show("La incidencia ha sido creada con éxito.");
                    CleanForm();
                    await LoadDataToDataGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar la incidencia: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completados correctamente.");
            }
        }

        private async void IncidentPNLBTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IncidenceTBID.Text))
            {
                try
                {
                    var IncidenceToSearch = await _incidentService.GetByIdAsync(int.Parse(IncidenceTBID.Text));

                    if (IncidenceToSearch != null)
                    {
                        IncidenceTBID.Text = IncidenceTBID.Text;
                        IncidenceTBDescription.Text = IncidenceToSearch.Description;
                        IncidenceDTPDate.Value = IncidenceToSearch.Date;

                        await LoadTenantsIntoComboBox();

                        IncidenceCBTenants.SelectedValue = IncidenceToSearch.TenantId;
                    }
                    else
                    {
                        MessageBox.Show("Incidencia no encontrada.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar la incidencia: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno correctamente.");
            }
        }

        private async void IncidencePNLBTNUpdate_Click(object sender, EventArgs e)
        {
            if (FormIsCorrectToUpdate())
            {
                try
                {
                    var incidentToUpdate = await _incidentService.GetByIdAsync(int.Parse(IncidenceTBID.Text));

                    if (incidentToUpdate != null)
                    {
                        incidentToUpdate.Description = IncidenceTBDescription.Text;
                        incidentToUpdate.Date = IncidenceDTPDate.Value;
                        incidentToUpdate.TenantId = (int) IncidenceCBTenants.SelectedValue;
                        incidentToUpdate.UpdatedAt = DateTime.Now;

                        await _incidentService.UpdateAsync(incidentToUpdate);

                        MessageBox.Show("La incidencia ha sido actualizada con éxito.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Incidencia no encontrada.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error actualizando la incidencia: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben estar completos correctamente.");
            }
        }

        private async void IncidencePNLBTNDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(IncidenceTBID.Text))
            {
                try
                {
                    var incidentToDelete = await _incidentService.GetByIdAsync(int.Parse(IncidenceTBID.Text));

                    if (incidentToDelete != null)
                    {
                        incidentToDelete.DeletedAt = DateTime.Now;

                        await _incidentService.DeleteAsync(incidentToDelete.Id);

                        MessageBox.Show("La incidencia ha sido eliminada exitosamente.");
                        await LoadDataToDataGrid();
                        CleanForm();
                    }
                    else
                    {
                        MessageBox.Show("Incidencia no encontrada.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error eliminando la incidencia: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El campo ID debe estar lleno.");
            }
        }

        private void CleanForm()
        {
            IncidenceTBID.Clear();
            IncidenceTBDescription.Clear();
            IncidenceDTPDate.Value = DateTime.Today;

            if (IncidenceCBTenants.Items.Count > 0)
                IncidenceCBTenants.SelectedIndex = 0;
        }

        public bool FormIsCorrect()
        {
            bool isTenantValid = int.TryParse(IncidenceCBTenants.SelectedValue?.ToString(), out int tenantId) && tenantId != 0;

            return !(
               string.IsNullOrEmpty(IncidenceDTPDate.Text) ||
               string.IsNullOrEmpty(IncidenceTBDescription.Text) ||
               !isTenantValid
           );
        }

        public bool FormIsCorrectToUpdate()
        {
            bool isTenantValid = int.TryParse(IncidenceCBTenants.SelectedValue?.ToString(), out int tenantId) && tenantId != 0;

            return !(
               string.IsNullOrEmpty(IncidenceTBID.Text) ||
               string.IsNullOrEmpty(IncidenceDTPDate.Text) ||
               string.IsNullOrEmpty(IncidenceTBDescription.Text) ||
               !isTenantValid
           );
        }
    }
}
