using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Repositories.Interfaces
{
    public interface IBlockRepository
    {
        Task<IEnumerable<Block>> GetAllBlocksAsync();
        Task<Block> GetBlockByIdAsync(int id);
        Task AddBlockAsync(Block block);
        Task UpdateBlockAsync(Block block);
        Task DeleteBlockAsync(int id);
    }
}

