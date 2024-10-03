using System;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services.Interfaces;

namespace DA_Management_EndPoint.Services
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly IAcademicYearRepository _academicYearRepository;

        public AcademicYearService(IAcademicYearRepository academicYearRepository)
        {
            _academicYearRepository = academicYearRepository;
        }

        public async Task<IEnumerable<AcademicYear>> GetAllAcademicYearsAsync()
        {
            return await _academicYearRepository.GetAllAcademicYearsAsync();
        }

        public async Task<AcademicYear> GetAcademicYearByIdAsync(int id)
        {
            return await _academicYearRepository.GetAcademicYearByIdAsync(id);
        }

        public async Task AddAcademicYearAsync(AcademicYear academicYear)
        {
            await _academicYearRepository.AddAcademicYearAsync(academicYear);
        }

        public async Task UpdateAcademicYearAsync(AcademicYear academicYear)
        {
            await _academicYearRepository.UpdateAcademicYearAsync(academicYear);
        }

        public async Task DeleteAcademicYearAsync(int id)
        {
            await _academicYearRepository.DeleteAcademicYearAsync(id);
        }
    }
}

