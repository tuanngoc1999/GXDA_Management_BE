using System;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services.Interfaces;

namespace DA_Management_EndPoint.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
        {
            return await _attendanceRepository.GetAllAttendancesAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            return await _attendanceRepository.GetAttendanceByIdAsync(id);
        }

        public async Task AddAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.AddAttendanceAsync(attendance);
        }

        public async Task UpdateAttendanceAsync(Attendance attendance)
        {
            await _attendanceRepository.UpdateAttendanceAsync(attendance);
        }

        public async Task DeleteAttendanceAsync(int id)
        {
            await _attendanceRepository.DeleteAttendanceAsync(id);
        }

        public async Task AddAttendancesRangeAsync(IEnumerable<Attendance> attendances)
        {
            await _attendanceRepository.AddAttendancesRangeAsync(attendances);
        }
    }
}

