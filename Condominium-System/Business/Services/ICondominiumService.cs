using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface ICondominiumService
    {
        Task<IEnumerable<Condominium>> GetAllCondominiumsAsync();
        Task<Condominium> GetCondominiumByIdAsync(int id);
        Task<IEnumerable<Condominium>> SearchCondominiumsAsync(string searchTerm);
        Task<Condominium> CreateCondominiumAsync(Condominium condominium);
        Task UpdateCondominiumAsync(Condominium condominium);
        Task DeleteCondominiumAsync(int id);
    }
}
