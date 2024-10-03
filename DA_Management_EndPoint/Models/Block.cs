using System;
using System.Security.Claims;

namespace DA_Management_EndPoint.Models
{
    public class Block
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relationships
        public int AcademicYearId { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}

