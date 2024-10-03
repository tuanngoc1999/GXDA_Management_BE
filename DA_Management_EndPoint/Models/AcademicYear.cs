using System;
namespace DA_Management_EndPoint.Models
{
    public class AcademicYear
    {
        public int Id { get; set; }
        public string Year { get; set; }

        // Relationships
        public ICollection<Block> Blocks { get; set; }
    }
}

