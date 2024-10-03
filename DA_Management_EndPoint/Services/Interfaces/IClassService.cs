using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Services.Interfaces
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task<Class> GetClassByIdAsync(int id);
        Task AddClassAsync(Class @class);
        Task UpdateClassAsync(Class @class);
        Task DeleteClassAsync(int id);
    }
}

