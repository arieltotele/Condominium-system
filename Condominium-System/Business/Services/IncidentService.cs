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

        public IncidentService(IRepositoryWithId<Incident> incidentRepository)
        {
            _repository = incidentRepository;
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
    }
}
