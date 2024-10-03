using System;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        private new readonly AppDbContext _context;
        public AttendanceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAttendancesAsync(List<Attendance> attendances)
        {
            await this._context.Attendances.AddRangeAsync(attendances);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateAttendancesAsync(List<Attendance> attendances)
        {
            this._context.Attendances.UpdateRange(attendances);
            await this._context.SaveChangesAsync();
        }
    }

}

