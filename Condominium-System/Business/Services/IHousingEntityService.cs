using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface IHousingEntityService
    {
        Task<IEnumerable<Housing>> GetAllHousingsAsync();
        Task<Housing> GetHousingByIdAsync(int id);
        Task<IEnumerable<Housing>> SearchHousingsAsync(string searchTerm);
        Task<Housing> CreateHousingAsync(Housing housing);
        Task UpdateHousingAsync(Housing housing);
        Task DeleteHousingAsync(int id);
    }
}
