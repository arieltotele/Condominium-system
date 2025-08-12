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
        Task<IEnumerable<Data.Entities.Condominium>> GetAllCondominiumsAsync();
        Task<Data.Entities.Condominium> GetCondominiumByIdAsync(int id);
        Task<IEnumerable<Data.Entities.Condominium>> SearchCondominiumsAsync(string searchTerm);
        Task<Data.Entities.Condominium> CreateCondominiumAsync(Data.Entities.Condominium condominium);
        Task UpdateCondominiumAsync(Condominium_System.Data.Entities.Condominium condominium);
        Task DeleteCondominiumAsync(int id);
    }
}
