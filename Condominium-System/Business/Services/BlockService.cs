using Condominium_System.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Condominium_System.Data.Entities;

namespace Condominium_System.Business.Services
{
    public class BlockService : IBlockService
    {
        private readonly IRepositoryWithId<Block> _blockRepository;

        public BlockService(IRepositoryWithId<Block> blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public async Task<IEnumerable<Block>> GetAllBlocksAsync()
        {
            return await _blockRepository.GetAllWithIncludesAsync(b => b.Condominium, b => b.Housings);
        }

        public async Task<Block> GetBlockByIdAsync(int id)
        {
            return await _blockRepository.GetByIdWithIncludesAsync(id, b => b.Condominium, b => b.Housings);
        }

        public async Task<Block> CreateBlockAsync(Block block)
        {
            await _blockRepository.AddAsync(block);
            await _blockRepository.SaveChangesAsync();
            return block;
        }

        public async Task UpdateBlockAsync(Block block)
        {
            _blockRepository.Update(block);
            await _blockRepository.SaveChangesAsync();
        }

        public async Task DeleteBlockAsync(int id)
        {
            var block = await _blockRepository.GetByIdAsync(id);
            if (block != null)
            {
                _blockRepository.Remove(block);
                await _blockRepository.SaveChangesAsync();
            }
        }
    }
}
