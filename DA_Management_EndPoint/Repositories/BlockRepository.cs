using System;
using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_EndPoint.Repositories
{
    public class BlockRepository : IBlockRepository
    {
        private readonly SchoolContext _context;

        public BlockRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Block>> GetAllBlocksAsync()
        {
            return await _context.Blocks.ToListAsync();
        }

        public async Task<Block> GetBlockByIdAsync(int id)
        {
            return await _context.Blocks.FindAsync(id);
        }

        public async Task AddBlockAsync(Block block)
        {
            _context.Blocks.Add(block);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBlockAsync(Block block)
        {
            _context.Blocks.Update(block);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBlockAsync(int id)
        {
            var block = await _context.Blocks.FindAsync(id);
            if (block != null)
            {
                _context.Blocks.Remove(block);
                await _context.SaveChangesAsync();
            }
        }
    }
}

