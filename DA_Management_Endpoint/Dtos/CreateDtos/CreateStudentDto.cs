namespace DA_Management_Endpoint.Dto.CreateDtos
{
    public class CreateStudentDto
    {
        public required string HolyName { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
        public string? Dad { get; set; }
        public string? Mom { get; set; }
        public string? Note { get; set; }
        public int? ClassId { get; set; }
        public string? SacramentBaptism { get; set; }
        public string? SacramentFirstConfession { get; set; }
        public string? SacramentConfirmation { get; set; }
    }
}

