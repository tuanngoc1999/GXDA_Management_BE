using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Dtos
{
    public class StudentAttendanceDto
    {
        public required CoreDto Student { get; set; }
        public CoreDto? Class { get; set; }
        public ICollection<AttendanceDto> Attendances { get; set; } = new HashSet<AttendanceDto>();
    }
}
