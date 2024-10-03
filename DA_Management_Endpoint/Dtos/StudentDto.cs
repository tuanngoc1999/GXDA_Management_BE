namespace DA_Management_Endpoint.Dtos
{
    public partial class StudentDto
    {
        public int Id { get; set; }
        public required string HolyName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? Dad { get; set; }
        public string? Mom { get; set; }
        public string? Note { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? ClassId { get; set; }
        public int? Status { get; set; }
        public string? SacramentBaptism { get; set; }
        public string? SacramentFirstConfession { get; set; }
        public string? SacramentConfirmation { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual CoreDto? Class { get; set; }
        public virtual CoreDto? CreatedByCatechist { get; set; }
        public virtual CoreDto? UpdatedByCatechist { get; set; }
        public virtual ICollection<AttendanceDto> Attendances { get; set; } = new HashSet<AttendanceDto>();
        public virtual ICollection<StudentRevisionDto> StudentRevisions { get; set; } = new HashSet<StudentRevisionDto>();
        public virtual ICollection<ScoreDto> Scores { get; set; } = new HashSet<ScoreDto>();
    }
}

