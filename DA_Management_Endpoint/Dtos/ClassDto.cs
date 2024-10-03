namespace DA_Management_Endpoint.Dtos
{
    public class ClassDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int TotalStudents { get; set; }

        public CoreDto? Block { get; set; }
        public ICollection<CoreDto> Catechists { get; set; } = new HashSet<CoreDto>();
    }
}

