using Condominium_System.Data.Entities;
using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_System.Business.Services
{
    public class CondominiumService : ICondominiumService
    {
        private readonly IRepositoryWithId<Condominium> _condominiumRepository;

        public CondominiumService(IRepositoryWithId<Condominium> condominiumRepository)
        {
            _condominiumRepository = condominiumRepository;
        }

        public async Task<IEnumerable<Condominium>> GetAllCondominiumsAsync()
        {
            return await _condominiumRepository.GetAllWithIncludesAsync(c => c.Users, c => c.Blocks);
        }

        public async Task<Condominium> GetCondominiumByIdAsync(int id)
        {
            return await _condominiumRepository.GetByIdWithIncludesAsync(id, c => c.Users, c => c.Blocks);
        }

        public async Task<Condominium> CreateCondominiumAsync(Condominium condominium)
        {
            await _condominiumRepository.AddAsync(condominium);
            await _condominiumRepository.SaveChangesAsync();
            return condominium;
        }

        public async Task UpdateCondominiumAsync(Condominium condominium)
        {
            _condominiumRepository.Update(condominium);
            await _condominiumRepository.SaveChangesAsync();
        }

        public async Task DeleteCondominiumAsync(int id)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(id);
            if (condominium != null)
            {
                _condominiumRepository.Remove(condominium);
                await _condominiumRepository.SaveChangesAsync();
            }
        }
    }
}
