using System;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;

namespace DA_Management_Endpoint.Repositories
{
    public class AcademicYearRepository : Repository<AcademicYear>, IAcademicYearRepository
    {
        public AcademicYearRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }


}

