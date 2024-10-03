namespace DA_Management_Endpoint.Dtos
{
    public class CatechistDto
    {
        public int Id { get; set; }
        public required string HolyName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string? Level { get; set; }

        public virtual CoreDto? User { get; set; }
        public ICollection<CoreDto> Classes { get; set; } = new List<CoreDto>();
        public ICollection<CoreDto> CatechistProfiles { get; set; } = new List<CoreDto>();
    }
}

