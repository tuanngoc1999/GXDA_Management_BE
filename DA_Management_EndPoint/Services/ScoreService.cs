using System;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services.Interfaces;

namespace DA_Management_EndPoint.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreService(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<IEnumerable<Score>> GetAllScoresAsync()
        {
            return await _scoreRepository.GetAllScoresAsync();
        }

        public async Task<Score> GetScoreByIdAsync(int id)
        {
            return await _scoreRepository.GetScoreByIdAsync(id);
        }

        public async Task AddScoreAsync(Score score)
        {
            await _scoreRepository.AddScoreAsync(score);
        }

        public async Task UpdateScoreAsync(Score score)
        {
            await _scoreRepository.UpdateScoreAsync(score);
        }

        public async Task DeleteScoreAsync(int id)
        {
            await _scoreRepository.DeleteScoreAsync(id);
        }

        public async Task AddScoresAsync(IEnumerable<Score> scores) // Cập nhật phương thức mới
        {
            await _scoreRepository.AddScoresAsync(scores);
        }

        public async Task<IEnumerable<Score>> GetScoresByStudentAsync(int studentId, int academicYearId)
        {
            return await _scoreRepository.GetScoresByStudentAsync(studentId, academicYearId);
        }
    }
}

