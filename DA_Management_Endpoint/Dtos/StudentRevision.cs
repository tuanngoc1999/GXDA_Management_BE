namespace DA_Management_Endpoint.Dtos
{
    public partial class StudentRevisionDto
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int StudentId { get; set; }
        public required string History { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }

        public virtual CoreDto? Class { get; set; }
        public virtual CoreDto? Student { get; set; }
        public virtual CoreDto? CreatedByCatechist { get; set; }
    }
}

