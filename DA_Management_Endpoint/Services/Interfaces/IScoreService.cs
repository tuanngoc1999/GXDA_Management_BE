using System;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IScoreService : IService<Score>
    {
        Task<IEnumerable<ScoreDto>> GetScoresByClassIdAsync(int classId);
        Task AddScoresAsync(int classId, List<CreateScoreDto> scoreDtos, string term, int userId);
        Task UpdateScoresAsync(int classId, List<CreateScoreDto> scoreDtos, string term, int userId);

    }
}

