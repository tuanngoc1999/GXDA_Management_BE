using System;
namespace DA_Management_EndPoint.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public int BlockId { get; set; }
        public Block Block { get; set; }
        public ICollection<Catechist> Catechists { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}

