using System;
namespace DA_Management_EndPoint.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        // Relationships
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<StudentAttendance> StudentAttendances { get; set; }
    }
}

