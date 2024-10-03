using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Services.Interfaces
{
    public interface IAcademicYearService
    {
        Task<IEnumerable<AcademicYear>> GetAllAcademicYearsAsync();
        Task<AcademicYear> GetAcademicYearByIdAsync(int id);
        Task AddAcademicYearAsync(AcademicYear academicYear);
        Task UpdateAcademicYearAsync(AcademicYear academicYear);
        Task DeleteAcademicYearAsync(int id);
    }
}

