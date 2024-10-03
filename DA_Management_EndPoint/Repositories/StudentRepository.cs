using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;

namespace DA_Management_EndPoint.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Student>> GetStudentsByAcademicYearAsync(int academicYearId)
        {
            return await _context.Students
                .Join(_context.Enrollments,
                      s => s.Id,
                      e => e.StudentId,
                      (s, e) => new { Student = s, Enrollment = e })
                .Where(se => se.Enrollment.AcademicYearId == academicYearId)
                .Select(se => se.Student)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsByAcademicYearAndBlockAsync(int academicYearId, int blockId)
        {
            return await _context.Students
                .Join(_context.Enrollments,
                      s => s.Id,
                      e => e.StudentId,
                      (s, e) => new { Student = s, Enrollment = e })
                .Join(_context.Classes,
                      se => se.Enrollment.ClassId,
                      c => c.Id,
                      (se, c) => new { se.Student, se.Enrollment, Class = c })
                .Join(_context.Blocks,
                      sec => sec.Class.BlockId,
                      b => b.Id,
                      (sec, b) => new { sec.Student, sec.Enrollment, sec.Class, Block = b })
                .Where(secb => secb.Enrollment.AcademicYearId == academicYearId
                             && secb.Block.Id == blockId)
                .Select(secb => secb.Student)
                .ToListAsync();
        }

        public async Task<IEnumerable<Student>> GetStudentsByAcademicYearBlockAndClassAsync(int academicYearId, int blockId, int classId)
        {
            return await _context.Students
                .Join(_context.Enrollments,
                      s => s.Id,
                      e => e.StudentId,
                      (s, e) => new { Student = s, Enrollment = e })
                .Join(_context.Classes,
                      se => se.Enrollment.ClassId,
                      c => c.Id,
                      (se, c) => new { se.Student, se.Enrollment, Class = c })
                .Join(_context.Blocks,
                      sec => sec.Class.BlockId,
                      b => b.Id,
                      (sec, b) => new { sec.Student, sec.Enrollment, sec.Class, Block = b })
                .Where(secb => secb.Enrollment.AcademicYearId == academicYearId
                             && secb.Block.Id == blockId
                             && secb.Class.Id == classId)
                .Select(secb => secb.Student)
                .ToListAsync();
        }

    }
}


