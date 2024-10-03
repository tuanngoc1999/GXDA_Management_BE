namespace DA_Management_Endpoint.Dtos
{
    public partial class ScoreDto
    {
        public int Id { get; set; }
        public required string CatechismMark { get; set; }
        public required string PrayerMark { get; set; }
        public required string Term { get; set; }
        public string? Note { get; set; }

        public virtual CoreDto? CreatedByCatechist { get; set; }
        public virtual CoreDto? UpdatedByCatechist { get; set; }
    }
}
