using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Repositories.Interfaces
{
    public interface IAcademicYearRepository
    {
        Task<IEnumerable<AcademicYear>> GetAllAcademicYearsAsync();
        Task<AcademicYear> GetAcademicYearByIdAsync(int id);
        Task AddAcademicYearAsync(AcademicYear academicYear);
        Task UpdateAcademicYearAsync(AcademicYear academicYear);
        Task DeleteAcademicYearAsync(int id);
    }
}

