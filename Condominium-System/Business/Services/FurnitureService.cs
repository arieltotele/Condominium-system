using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class FurnitureService : IFurnitureService
    {
        private readonly IRepositoryWithId<Furniture> _furnitureRepository;

        public FurnitureService(IRepositoryWithId<Furniture> furnitureRepository)
        {
            _furnitureRepository = furnitureRepository;
        }

        public async Task<IEnumerable<Furniture>> GetAllFurnituresAsync()
        {
            return await _furnitureRepository.GetAllWithIncludesAsync(f => f.Housings);
        }

        public async Task<Furniture> GetFurnitureByIdAsync(int id)
        {
            return await _furnitureRepository.GetByIdWithIncludesAsync(id, f => f.Housings);
        }

        public async Task<Furniture> CreateFurnitureAsync(Furniture furniture)
        {
            await _furnitureRepository.AddAsync(furniture);
            await _furnitureRepository.SaveChangesAsync();
            return furniture;
        }

        public async Task UpdateFurnitureAsync(Furniture furniture)
        {
            _furnitureRepository.Update(furniture);
            await _furnitureRepository.SaveChangesAsync();
        }

        public async Task DeleteFurnitureAsync(int id)
        {
            var furniture = await _furnitureRepository.GetByIdAsync(id);
            if (furniture != null)
            {
                _furnitureRepository.Remove(furniture);
                await _furnitureRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Furniture>> GetFurnituresByTypeAsync(string type)
        {
            return await _furnitureRepository
            .GetAllWithIncludesAsync(f => f.Housings, f => f.Type == type);
        }
    }
}
