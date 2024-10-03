namespace DA_Management_Endpoint.Dto.CreateDtos
{
    public partial class CreateAttendanceDto
    {
        public int StudentId { get; set; }
        public required string Date { get; set; }
        public int Status { get; set; }
    }
}
