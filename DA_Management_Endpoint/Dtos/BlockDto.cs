namespace DA_Management_Endpoint.Dtos
{
    public class BlockDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<ClassDto> Classes { get; set; } = new HashSet<ClassDto>();
    }
}

