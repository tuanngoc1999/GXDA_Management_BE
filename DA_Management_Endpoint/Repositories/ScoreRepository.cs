using System;
using AutoMapper;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class ScoreRepository : Repository<Score>, IScoreRepository
    {
        protected readonly IMapper _mapper;
        private new readonly AppDbContext _context;

        public ScoreRepository(AppDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ScoreDto>> GetScoresByClassIdAsync(int classId)
        {
            var data = await _context.Scores.AsNoTracking()
            .Where(s => s.ClassId == classId)
                                 .ToListAsync();
            var dto = _mapper.Map<List<ScoreDto>>(data);
            return dto;
        }

        public async Task AddScoresAsync(List<Score> scores)
        {
            await this._context.Scores.AddRangeAsync(scores);
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateScoresAsync(List<Score> scores)
        {
            this._context.Scores.UpdateRange(scores);
            await this._context.SaveChangesAsync();
        }
    }

}

