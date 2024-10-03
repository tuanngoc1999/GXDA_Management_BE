using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task<IEnumerable<Student>> GetStudentsByAcademicYearAsync(int academicYearId);
        Task<IEnumerable<Student>> GetStudentsByAcademicYearAndBlockAsync(int academicYearId, int blockId);
        Task<IEnumerable<Student>> GetStudentsByAcademicYearBlockAndClassAsync(int academicYearId, int blockId, int classId);
    }
}

