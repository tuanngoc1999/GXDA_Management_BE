using System;
namespace DA_Management_EndPoint.Models
{
    public class StudentAttendance
    {
        public int Id { get; set; }

        // Relationships
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int AttendanceId { get; set; }
        public Attendance Attendance { get; set; }

        public bool IsPresent { get; set; }
    }
}

