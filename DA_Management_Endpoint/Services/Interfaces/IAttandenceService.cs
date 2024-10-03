using System;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IAttendanceService : IService<Attendance>
    {
        Task AddAttendancesAsync(int classId, List<CreateAttendanceDto> createAttendanceDtos, int userId);
        Task UpdateAttendancesAsync(int classId, List<CreateAttendanceDto> attendanceDtos, int userId);
    }

}

