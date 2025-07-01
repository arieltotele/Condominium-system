using Condominium_System.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public interface IFurnitureService
    {
        Task<IEnumerable<Furniture>> GetAllFurnituresAsync();
        Task<Furniture> GetFurnitureByIdAsync(int id);
        Task<Furniture> CreateFurnitureAsync(Furniture furniture);
        Task UpdateFurnitureAsync(Furniture furniture);
        Task DeleteFurnitureAsync(int id);
    }
}
