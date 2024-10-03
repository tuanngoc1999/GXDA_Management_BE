namespace DA_Management_Endpoint.Dtos
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public required string Date { get; set; }
        public int Status { get; set; }

        public virtual CoreDto? CreatedByCatechist { get; set; }
        public virtual CoreDto? UpdatedByCatechist { get; set; }
    }
}
