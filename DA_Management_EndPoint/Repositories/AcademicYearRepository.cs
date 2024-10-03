using System;
using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_EndPoint.Repositories
{
    public class AcademicYearRepository : IAcademicYearRepository
    {
        private readonly SchoolContext _context;

        public AcademicYearRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AcademicYear>> GetAllAcademicYearsAsync()
        {
            return await _context.AcademicYears.ToListAsync();
        }

        public async Task<AcademicYear> GetAcademicYearByIdAsync(int id)
        {
            return await _context.AcademicYears.FindAsync(id);
        }

        public async Task AddAcademicYearAsync(AcademicYear academicYear)
        {
            _context.AcademicYears.Add(academicYear);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAcademicYearAsync(AcademicYear academicYear)
        {
            _context.AcademicYears.Update(academicYear);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAcademicYearAsync(int id)
        {
            var academicYear = await _context.AcademicYears.FindAsync(id);
            if (academicYear != null)
            {
                _context.AcademicYears.Remove(academicYear);
                await _context.SaveChangesAsync();
            }
        }
    }
}

