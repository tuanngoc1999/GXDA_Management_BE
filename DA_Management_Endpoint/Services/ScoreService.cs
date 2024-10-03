using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class ScoreService : Service<Score>, IScoreService
    {
        private readonly IScoreRepository _scoresRepository;

        public ScoreService(IScoreRepository repository) : base(repository)
        {
            _scoresRepository = repository;
        }

        public async Task<IEnumerable<ScoreDto>> GetScoresByClassIdAsync(int classId)
        {
            return await _scoresRepository.GetScoresByClassIdAsync(classId);
        }

        public async Task AddScoresAsync(int classId, List<CreateScoreDto> scoreDtos, string term, int userId)
        {
            var scores = new List<Score>();

            foreach (var dto in scoreDtos)
            {
                var scoreEntity = await _scoresRepository.GetFirstOrDefaultByConditionAsync(x => x.StudentId == dto.StudentId && x.ClassId == classId && x.Term == term);
                if (scoreEntity != null) throw new InvalidOperationException("Score already exists.");
                var scoreEntry = new Score
                {
                    ClassId = classId,
                    StudentId = dto.StudentId,
                    Term = term,
                    CatechismMark = float.Parse(dto.CatechismMark),
                    PrayerMark = float.Parse(dto.PrayerMark),
                    Note = dto.Note,
                    CreatedBy = userId,
                    UpdatedBy = userId
                };

                scores.Add(scoreEntry);
            }

            await _scoresRepository.AddScoresAsync(scores);
        }

        public async Task UpdateScoresAsync(int classId, List<CreateScoreDto> scoreDtos, string term, int userId)
        {
            var scores = new List<Score>();
            foreach(var dto in scoreDtos)
            {
                var scoreEntity = await _scoresRepository.GetFirstOrDefaultByConditionAsync(x => x.StudentId == dto.StudentId && x.ClassId == classId && x.Term == term);
                if (scoreEntity == null) throw new InvalidOperationException("Score does not exist.");
                scoreEntity.PrayerMark = float.Parse(dto.PrayerMark);
                scoreEntity.CatechismMark = float.Parse(dto.CatechismMark);
                scoreEntity.Note = dto.Note;
                scoreEntity.UpdatedBy = userId;
                scores.Add(scoreEntity);
            }
            await _scoresRepository.UpdateScoresAsync(scores);
            
        }
    }

}

