using Condominium_System.Business.Services;
using Condominium_System.Data.Entities;
using Condominium_System.Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Condominium_System.Presentation.Views
{
    public partial class UpsertIncidenceScreen : Form
    {
        private readonly IIncidentService _incidentService;
        private readonly ITenantService _tenantService;
        private readonly IServiceProvider _serviceProvider;

        User currentUser;

        public bool IsEditMode { get; set; } = false;
        public UpsertIncidenceScreen(IIncidentService incidentService, ITenantService tenantService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _incidentService = incidentService;
            _tenantService = tenantService;
            currentUser = Session.CurrentUser;
            _serviceProvider = serviceProvider;
        }

        private async void UpsertIncidenceScreen_Load(object sender, EventArgs e)
        {
            await LoadTenantsIntoComboBox();

            if (IsEditMode)
            {
                LoadDataIfIsToUpdate();
            }
        }

        private async void LoadDataIfIsToUpdate()
        {
            if (IsEditMode && Session.IncidenceToUpsert != null)
            {
                var IncidenceToUpdate = Session.IncidenceToUpsert;

                IncidenceTBDescription.Text = IncidenceToUpdate.Description;
                IncidenceDTPDate.Value = IncidenceToUpdate.Date;

                await LoadTenantsIntoComboBox();
                IncidenceCBTenants.SelectedValue = IncidenceToUpdate.TenantId;

            }
        }

        private string FormatDocument(string doc)
        {
            if (!string.IsNullOrEmpty(doc) && doc.Length == 11)
                return $"{doc.Substring(0, 3)}-{doc.Substring(3, 7)}-{doc.Substring(10, 1)}";

            return doc;
        }

        private async Task LoadTenantsIntoComboBox()
        {
            try
            {
                var tenants = (await _tenantService.GetAllAsync()).ToList();

                if (!tenants.Any())
                {
                    IncidenceCBTenants.DataSource = null;
                    IncidenceCBTenants.Items.Clear();
                    IncidenceCBTenants.Text = "No hay propietarios registrados";
                    IncidenceCBTenants.Enabled = false;

                    MessageBox.Show("No se encontraron propietarios registrados. Por favor, registre al menos un propietario.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    if (this.Owner is IncidenceScreen owner) 
                    {
                        await owner.LoadDataToDataGrid();
                    }
                    this.Hide();
                    return;
                }

                var placeholder = new { Id = 0, Display = "-- Seleccione un propietario --" };

                var tenantDisplayList = tenants.Select(t => new
                {
                    Id = t.Id,
                    Display = $"{FormatDocument(t.DocumentNumber)} - {t.FirstName} {t.LastName}"
                }).ToList();

                tenantDisplayList.Insert(0, placeholder);

                IncidenceCBTenants.DisplayMember = "Display";
                IncidenceCBTenants.ValueMember = "Id";
                IncidenceCBTenants.DataSource = tenantDisplayList;
                IncidenceCBTenants.SelectedIndex = 0;
                IncidenceCBTenants.Enabled = true;
            }
            catch (Exception ex)
            {
                IncidenceCBTenants.DataSource = null;
                IncidenceCBTenants.Items.Clear();
                IncidenceCBTenants.Text = "Error al cargar propietarios";
                IncidenceCBTenants.Enabled = false;

                MessageBox.Show($"Error cargando propietarios: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);

                if (this.Owner is IncidenceScreen owner)
                {
                    await owner.LoadDataToDataGrid();
                }
                this.Hide();
            }
            finally
            {
                IncidenceCBTenants.Refresh();
            }
        }

        private void UpsertPNLBTN_Click(object sender, EventArgs e)
        {
            if (IsEditMode) { EditIncidence(); }
            else { SaveIncidence(); }
        }

        private async void EditIncidence()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var IncidenceToUpdate = Session.IncidenceToUpsert;

                    if (IncidenceToUpdate != null)
                    {
                        IncidenceToUpdate.Description = IncidenceTBDescription.Text;
                        IncidenceToUpdate.Date = IncidenceDTPDate.Value;
                        IncidenceToUpdate.TenantId = (int)IncidenceCBTenants.SelectedValue;
                        IncidenceToUpdate.UpdatedAt = DateTime.Now;

                        await _incidentService.UpdateAsync(IncidenceToUpdate);

                        MessageBox.Show("La incidencia ha sido actualizado con exito");
                        CleanForm();
                        await ((IncidenceScreen)this.Owner).LoadDataToDataGrid();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Incidencia no encontrada.");
                        CleanForm();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando incidencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
        }

        private async void SaveIncidence()
        {
            if (FormIsCorrect())
            {
                try
                {
                    var newIncident = new Incident()
                    {
                        Description = IncidenceTBDescription.Text,
                        Date = IncidenceDTPDate.Value,
                        TenantId = (int)IncidenceCBTenants.SelectedValue,
                        Author = currentUser.Username
                    };

                    await _incidentService.CreateAsync(newIncident);

                    MessageBox.Show("La incidencia ha sido creado con exito.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CleanForm();
                    await ((IncidenceScreen)this.Owner).LoadDataToDataGrid();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error guardando incidencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CleanForm();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser completados correctamente.");
            }
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
        private async void CleanForm()
        {
            IncidenceTBDescription.Clear();
            IncidenceDTPDate.Value = DateTime.Today;

            if (IncidenceCBTenants.Items.Count > 0)
                IncidenceCBTenants.SelectedIndex = 0;
        }
    }
}
