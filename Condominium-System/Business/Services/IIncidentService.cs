using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident> GetByIdAsync(int id);
        Task<IEnumerable<Incident>> SearchIncidentsAsync(string searchTerm);
        Task<Incident> CreateAsync(Incident incident);
        Task UpdateAsync(Incident incident);
        Task DeleteAsync(int id);
    }
}
