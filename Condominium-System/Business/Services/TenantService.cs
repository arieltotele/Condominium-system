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
        private readonly IRepositoryNoId<HousingService> _housingServiceRepository;

        public TenantService(IRepositoryWithId<Tenant> tenantRepository,
            IRepositoryNoId<HousingService> housingServiceRepository)
        {
            _tenantRepository = tenantRepository;
            _housingServiceRepository = housingServiceRepository;
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

        public async Task<IEnumerable<Tenant>> SearchTenantsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllAsync();
            }

            var results = new List<Tenant>();

            if (searchTerm.All(char.IsDigit))
            {
                if (searchTerm.Length <= 9 && int.TryParse(searchTerm, out int id))
                {
                    var tenantById = await GetByIdAsync(id);
                    if (tenantById != null)
                    {
                        results.Add(tenantById);
                    }
                }

                var tenantsByDoc = await _tenantRepository.FindAsync(t =>
                    t.DocumentNumber.Contains(searchTerm));

                results.AddRange(tenantsByDoc);
            }
            else
            {
                var tenantsByName = await _tenantRepository.FindAsync(t =>
                    t.FirstName.Contains(searchTerm) ||
                    t.LastName.Contains(searchTerm));

                results.AddRange(tenantsByName);
            }

            return results.DistinctBy(t => t.Id).ToList();        
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

        public async Task<decimal> CalculateTotalServicesByTenantAsync(int tenantId)
        {
            var tenant = await _tenantRepository.GetByIdWithIncludesAsync(tenantId, t => t.Housing);
            if (tenant?.Housing == null) return 0;

            var housingServices = await _housingServiceRepository.FindAsync(
                hs => hs.HousingId == tenant.HousingId && hs.IsActive,
                false);

            var services = new List<Service>();
            foreach (var hs in housingServices)
            {
                await _housingServiceRepository.Context.Entry(hs)
                    .Reference(h => h.Service)
                    .LoadAsync();

                if (hs.Service != null && hs.Service.IsActive)
                {
                    services.Add(hs.Service);
                }
            }

            return services.Sum(s => s.Cost);
        }
    }
}
