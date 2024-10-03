using System;
using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_EndPoint.Repositories
{
    public class CatechistRepository : ICatechistRepository
    {
        private readonly SchoolContext _context;

        public CatechistRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Catechist>> GetAllCatechistsAsync()
        {
            return await _context.Catechists.ToListAsync();
        }

        public async Task<Catechist> GetCatechistByIdAsync(int id)
        {
            return await _context.Catechists.FindAsync(id);
        }

        public async Task AddCatechistAsync(Catechist catechist)
        {
            _context.Catechists.Add(catechist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCatechistAsync(Catechist catechist)
        {
            _context.Catechists.Update(catechist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCatechistAsync(int id)
        {
            var catechist = await _context.Catechists.FindAsync(id);
            if (catechist != null)
            {
                _context.Catechists.Remove(catechist);
                await _context.SaveChangesAsync();
            }
        }
    }
}

