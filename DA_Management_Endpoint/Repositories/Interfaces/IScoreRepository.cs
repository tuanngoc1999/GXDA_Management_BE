using System;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IScoreRepository : IRepository<Score>
    {
        Task<IEnumerable<ScoreDto>> GetScoresByClassIdAsync(int classId);
        Task AddScoresAsync(List<Score> scores);
        Task UpdateScoresAsync(List<Score> scores);
    }

}

