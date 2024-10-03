using System;
namespace DA_Management_EndPoint.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string HolyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string DadName { get; set; }
        public string MomName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Note { get; set; }
        //public ICollection<Enrollment> Enrollments { get; set; }
        //public ICollection<Score> Scores { get; set; }
    }

}

