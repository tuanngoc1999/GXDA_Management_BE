using System;
using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_EndPoint.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly SchoolContext _context;

        public ClassRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task AddClassAsync(Class @class)
        {
            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClassAsync(Class @class)
        {
            _context.Classes.Update(@class);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(int id)
        {
            var @class = await _context.Classes.FindAsync(id);
            if (@class != null)
            {
                _context.Classes.Remove(@class);
                await _context.SaveChangesAsync();
            }
        }
    }
}

