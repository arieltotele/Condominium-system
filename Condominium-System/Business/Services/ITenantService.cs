using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetAllAsync();
        Task<Tenant> GetByIdAsync(int id);
        Task<decimal> CalculateTotalServicesByTenantAsync(int tenantId);
        Task<IEnumerable<Tenant>> SearchTenantsAsync(string searchTerm);
        Task<Tenant> CreateAsync(Tenant tenant);
        Task UpdateAsync(Tenant tenant);
        Task DeleteAsync(int id);
    }
}
