using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Condominium_System.Data.Entities;

namespace Condominium_System.Business.Services
{
    public interface IBlockService
    {
        Task<IEnumerable<Block>> GetAllBlocksAsync();
        Task<Block> GetBlockByIdAsync(int id);
        Task<Block> CreateBlockAsync(Block block);
        Task UpdateBlockAsync(Block block);
        Task DeleteBlockAsync(int id);
    }
}
