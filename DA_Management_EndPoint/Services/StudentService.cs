using System;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services.Interfaces;

namespace DA_Management_EndPoint.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepository.AddStudentAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
        }

        public async Task<IEnumerable<Student>> GetStudentsByAcademicYearAsync(int academicYearId)
        {
            return await _studentRepository.GetStudentsByAcademicYearAsync(academicYearId);
        }

        public async Task<IEnumerable<Student>> GetStudentsByAcademicYearAndBlockAsync(int academicYearId, int blockId)
        {
            return await _studentRepository.GetStudentsByAcademicYearAndBlockAsync(academicYearId, blockId);
        }

        public async Task<IEnumerable<Student>> GetStudentsByAcademicYearBlockAndClassAsync(int academicYearId, int blockId, int classId)
        {
            return await _studentRepository.GetStudentsByAcademicYearBlockAndClassAsync(academicYearId, blockId, classId);
        }

    }
}

