using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IRepositoryWithId<Incident> _repository;
        private readonly IRepositoryWithId<Tenant> _tenantRepository;

        public IncidentService(IRepositoryWithId<Incident> incidentRepository, 
            IRepositoryWithId<Tenant> tenantRepository)
        {
            _repository = incidentRepository;
            _tenantRepository = tenantRepository;
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            return await _repository.GetAllWithIncludesAsync(i => i.Tenant);
        }

        public async Task<Incident> GetByIdAsync(int id)
        {
            return await _repository.GetByIdWithIncludesAsync(id, i => i.Tenant);
        }

        public async Task<Incident> CreateAsync(Incident incident)
        {
            await _repository.AddAsync(incident);
            await _repository.SaveChangesAsync();
            return incident;
        }

        public async Task UpdateAsync(Incident incident)
        {
            _repository.Update(incident);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var incident = await _repository.GetByIdAsync(id);
            if (incident != null)
            {
                _repository.Remove(incident);
                await _repository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Incident>> SearchIncidentsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _repository.GetAllWithIncludesAsync(i => i.Tenant);
            }

            // Búsqueda por ID exacto (si es completamente numérico)
            if (searchTerm.All(char.IsDigit) && int.TryParse(searchTerm, out int id))
            {
                var incident = await _repository.GetByIdWithIncludesAsync(id, i => i.Tenant);
                return incident != null ? new List<Incident> { incident } : Enumerable.Empty<Incident>();
            }

            // Búsqueda por descripción (contains)
            var results = await _repository.FindAsync(i =>
                i.Description.Contains(searchTerm) ||
                (i.Tenant != null && i.Tenant.FirstName.Contains(searchTerm)));

            return await LoadTenantsForIncidents(results.ToList());
        }

        private async Task<IEnumerable<Incident>> LoadTenantsForIncidents(List<Incident> incidents)
        {
            if (!incidents.Any()) return incidents;

            // Obtener IDs de tenants únicos
            var tenantIds = incidents.Where(i => i.TenantId > 0)
                                   .Select(i => i.TenantId)
                                   .Distinct()
                                   .ToList();

            if (!tenantIds.Any()) return incidents;

            // Obtener los tenants usando el repositorio correcto
            var tenants = await _tenantRepository.FindAsync(t => tenantIds.Contains(t.Id));

            // Asignar tenants a los incidentes
            var tenantDict = tenants.ToDictionary(t => t.Id);
            foreach (var incident in incidents.Where(i => i.TenantId > 0))
            {
                if (tenantDict.TryGetValue(incident.TenantId, out var tenant))
                {
                    incident.Tenant = tenant; // Ahora sí son tipos compatibles
                }
            }

            return incidents;
        }
    }
}
