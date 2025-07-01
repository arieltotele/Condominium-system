using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class TenantService : ITenantService
    {
        private readonly IRepositoryWithId<Tenant> _tenantRepository;

        public TenantService(IRepositoryWithId<Tenant> tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            return await _tenantRepository.GetAllWithIncludesAsync(
                t => t.Housing,
                t => t.Incidents,
                t => t.Invoices
            );
        }

        public async Task<Tenant> GetByIdAsync(int id)
        {
            return await _tenantRepository.GetByIdWithIncludesAsync(
                id,
                t => t.Housing,
                t => t.Incidents,
                t => t.Invoices
            );
        }

        public async Task<Tenant> CreateAsync(Tenant tenant)
        {
            await _tenantRepository.AddAsync(tenant);
            await _tenantRepository.SaveChangesAsync();
            return tenant;
        }

        public async Task UpdateAsync(Tenant tenant)
        {
            _tenantRepository.Update(tenant);
            await _tenantRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tenant = await _tenantRepository.GetByIdAsync(id);
            if (tenant != null)
            {
                _tenantRepository.Remove(tenant);
                await _tenantRepository.SaveChangesAsync();
            }
        }
    }
}
