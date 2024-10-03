using System;
using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_EndPoint.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly SchoolContext _context;

        public AttendanceRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _context.Attendances.FindAsync(id);
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddAttendancesRangeAsync(IEnumerable<Attendance> attendances)
        {
            _context.Attendances.AddRange(attendances);
            await _context.SaveChangesAsync();
        }
    }
}

