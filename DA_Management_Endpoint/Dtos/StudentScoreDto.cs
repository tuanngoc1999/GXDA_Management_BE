using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Dtos
{
    public class StudentScoreDto
    {
        public required CoreDto Student { get; set; }
        public CoreDto? Class { get; set; }
        public ICollection<ScoreDto> Scores { get; set; } = new HashSet<ScoreDto>();
    }
}
