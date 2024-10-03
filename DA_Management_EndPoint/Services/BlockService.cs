using System;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services.Interfaces;

namespace DA_Management_EndPoint.Services
{
    public class BlockService : IBlockService
    {
        private readonly IBlockRepository _blockRepository;

        public BlockService(IBlockRepository blockRepository)
        {
            _blockRepository = blockRepository;
        }

        public async Task<IEnumerable<Block>> GetAllBlocksAsync()
        {
            return await _blockRepository.GetAllBlocksAsync();
        }

        public async Task<Block> GetBlockByIdAsync(int id)
        {
            return await _blockRepository.GetBlockByIdAsync(id);
        }

        public async Task AddBlockAsync(Block block)
        {
            await _blockRepository.AddBlockAsync(block);
        }

        public async Task UpdateBlockAsync(Block block)
        {
            await _blockRepository.UpdateBlockAsync(block);
        }

        public async Task DeleteBlockAsync(int id)
        {
            await _blockRepository.DeleteBlockAsync(id);
        }
    }
}

