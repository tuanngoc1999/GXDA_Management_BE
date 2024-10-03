using System;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Task AddAttendancesAsync(List<Attendance> attendances);
        Task UpdateAttendancesAsync(List<Attendance> attendances);
    }

}

