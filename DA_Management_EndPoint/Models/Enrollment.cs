using System;
namespace DA_Management_EndPoint.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int AcademicYearId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // Navigation properties
        public Student Student { get; set; }
        public Class Class { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }

}

