using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Services.Interfaces
{
    public interface IBlockService
    {
        Task<IEnumerable<Block>> GetAllBlocksAsync();
        Task<Block> GetBlockByIdAsync(int id);
        Task AddBlockAsync(Block block);
        Task UpdateBlockAsync(Block block);
        Task DeleteBlockAsync(int id);
    }
}

