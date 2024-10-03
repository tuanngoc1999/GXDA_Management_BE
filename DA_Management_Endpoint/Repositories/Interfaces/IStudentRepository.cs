using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<IEnumerable<StudentDto>> GetStudentsByClassIdAsync(int classId, int userId);
        Task<IEnumerable<StudentDto>> GetStudentsByBlockIdAsync(int blockId, int userId);
        Task<StudentDto?> GetWaitingForApprove(int userId);
        Task<List<StudentAttendanceDto>> GetAttendancesByClassIdAsync(int classId, int userId, int month = 0);
        Task<List<StudentScoreDto>> GetScoresByClassIdAsync(int classId, int userId, string term = "");
        Task ImportRange(List<Student> students, int userId);
        Task UpdateAsync(int id, CreateStudentDto students, int userId);

    }
}

