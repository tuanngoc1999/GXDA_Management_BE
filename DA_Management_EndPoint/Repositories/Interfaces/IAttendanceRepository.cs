using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
        Task<Attendance> GetAttendanceByIdAsync(int id);
        Task AddAttendanceAsync(Attendance attendance);
        Task UpdateAttendanceAsync(Attendance attendance);
        Task DeleteAttendanceAsync(int id);
        Task AddAttendancesRangeAsync(IEnumerable<Attendance> attendances);
        Task<IEnumerable<Attendance>> GetAttendancesByStudentAsync(int studentId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<Attendance>> GetAttendancesByClassAsync(int classId, DateTime startDate, DateTime endDate);
    }
}

