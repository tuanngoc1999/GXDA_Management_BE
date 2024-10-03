using System;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IStudentService : IService<Student>
    {
        Task AddAsync(CreateStudentDto st, int userId);
        Task UpdateAsync(int id, CreateStudentDto st, int userId);
        Task<IEnumerable<StudentDto>> GetStudentsByClassIdAsync(int classId, int userId);
        Task<IEnumerable<StudentDto>> GetStudentsByBlockIdAsync(int blockId, int userId);
        Task<StudentDto?> GetWaitingForApprove(int userId);
        Task Regist(CreateStudentDto st);
        Task ApproveRegistration(Student student, int userId);
        Task<List<StudentAttendanceDto>> GetAttendancesByClassIdAsync(int classId, int userId, int month = 0);
        Task<List<StudentScoreDto>> GetScoresByClassIdAsync(int classId, int userId, string term = "");
        Task ImportRange(List<CreateStudentDto> students, int userId);
    }
}

