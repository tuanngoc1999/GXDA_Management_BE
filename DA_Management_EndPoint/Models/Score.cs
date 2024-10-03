using System;
namespace DA_Management_EndPoint.Models
{
    public class Score
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public double Value { get; set; }
        public string Term { get; set; }

        // Relationships
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
    }
}

