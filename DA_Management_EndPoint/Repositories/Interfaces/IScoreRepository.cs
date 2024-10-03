using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Repositories.Interfaces
{
    public interface IScoreRepository
    {
        Task<IEnumerable<Score>> GetAllScoresAsync();
        Task<Score> GetScoreByIdAsync(int id);
        Task AddScoreAsync(Score score);
        Task UpdateScoreAsync(Score score);
        Task DeleteScoreAsync(int id);
        Task AddScoresAsync(IEnumerable<Score> scores); // Thêm phương thức mới
        Task<IEnumerable<Score>> GetScoresByStudentAsync(int studentId, int academicYearId);
        Task<IEnumerable<Score>> GetScoresByClassAsync(int classId, int academicYearId);

    }
}

