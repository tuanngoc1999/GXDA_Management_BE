namespace DA_Management_Endpoint.Dtos
{
    public class ClassListDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public CoreDto? Block { get; set; }
        public ICollection<CoreDto> Catechists { get; set; } = new List<CoreDto>();

        public int TotalStudents { get; set; }
    }
}

