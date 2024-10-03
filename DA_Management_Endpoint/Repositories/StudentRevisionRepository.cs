using System;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;

namespace DA_Management_Endpoint.Repositories
{
    public class StudentRevisionRepository : Repository<StudentRevision>, IStudentRevisionRepository
    {
        public StudentRevisionRepository(AppDbContext context) : base(context)
        {
        }
    }

}

