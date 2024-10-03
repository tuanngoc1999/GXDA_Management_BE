using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task<Class> GetClassByIdAsync(int id);
        Task AddClassAsync(Class @class);
        Task UpdateClassAsync(Class @class);
        Task DeleteClassAsync(int id);
    }
}

