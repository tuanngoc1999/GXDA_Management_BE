using System;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services.Interfaces;

namespace DA_Management_EndPoint.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            return await _classRepository.GetAllClassesAsync();
        }

        public async Task<Class> GetClassByIdAsync(int id)
        {
            return await _classRepository.GetClassByIdAsync(id);
        }

        public async Task AddClassAsync(Class @class)
        {
            await _classRepository.AddClassAsync(@class);
        }

        public async Task UpdateClassAsync(Class @class)
        {
            await _classRepository.UpdateClassAsync(@class);
        }

        public async Task DeleteClassAsync(int id)
        {
            await _classRepository.DeleteClassAsync(id);
        }
    }
}

