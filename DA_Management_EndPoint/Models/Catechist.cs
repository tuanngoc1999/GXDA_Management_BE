using System;
namespace DA_Management_EndPoint.Models
{
    public class Catechist
    {
        public int Id { get; set; }
        public string HolyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Contact { get; set; }
        public string Level { get; set; }
        public DateTime JoinedDate { get; set; }

        // Relationships
        public ICollection<Class> Classes { get; set; }
    }
}

