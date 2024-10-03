using System;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class StudentRevisionService : Service<StudentRevision>, IStudentRevisionService
    {
        public StudentRevisionService(IStudentRevisionRepository repository) : base(repository)
        {
        }
    }

}

