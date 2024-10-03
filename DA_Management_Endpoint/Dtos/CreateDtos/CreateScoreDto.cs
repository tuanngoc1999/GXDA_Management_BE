namespace DA_Management_Endpoint.Dto.CreateDtos
{
    public class CreateScoreDto
    {
        public int StudentId { get; set; }
        public required string CatechismMark { get; set; }
        public required string PrayerMark { get; set; }
        public string? Note { get; set; }
    }
}
