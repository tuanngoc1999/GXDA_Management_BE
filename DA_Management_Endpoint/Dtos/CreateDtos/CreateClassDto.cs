namespace DA_Management_Endpoint.Dto.CreateDtos
{
    public class CreateClassDto
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public int BlockId { get; set; }
        public List<int> Catechists { get; set; } = new List<int>();
    }
}
