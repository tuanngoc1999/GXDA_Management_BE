using System;
using System.Linq.Expressions;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T?> GetFirstOrDefaultByConditionAsync(Expression<Func<T, bool>> expression);
    }
}

