namespace DA_Management_Endpoint.Dto.CreateDtos
{
    public class CreateCatechistDto
    {
        public required string HolyName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? Level { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public IEnumerable<int>? profileIds { get; set; }
    }
}
