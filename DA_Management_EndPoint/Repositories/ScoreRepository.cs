using System;
using DA_Management_EndPoint.Data;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_EndPoint.Repositories
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly SchoolContext _context;

        public ScoreRepository(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Score>> GetAllScoresAsync()
        {
            return await _context.Scores.ToListAsync();
        }

        public async Task<Score> GetScoreByIdAsync(int id)
        {
            return await _context.Scores.FindAsync(id);
        }

        public async Task AddScoreAsync(Score score)
        {
            _context.Scores.Add(score);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateScoreAsync(Score score)
        {
            _context.Scores.Update(score);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteScoreAsync(int id)
        {
            var score = await _context.Scores.FindAsync(id);
            if (score != null)
            {
                _context.Scores.Remove(score);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddScoresAsync(IEnumerable<Score> scores) // Cập nhật phương thức mới
        {
            _context.Scores.AddRange(scores);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Score>> GetScoresByStudentAsync(int studentId, int academicYearId)
        {
            return await _context.Scores
                .Where(s => s.StudentId == studentId && s.AcademicYearId == academicYearId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Score>> GetScoresByClassAsync(int classId, int academicYearId)
        {
            return await _context.Scores
                .Where(s => s.ClassId == classId && s.AcademicYearId == academicYearId)
                .ToListAsync();
        }
    }
}

