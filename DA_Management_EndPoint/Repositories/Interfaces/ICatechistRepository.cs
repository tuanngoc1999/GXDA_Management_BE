using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Repositories.Interfaces
{
    public interface ICatechistRepository
    {
        Task<IEnumerable<Catechist>> GetAllCatechistsAsync();
        Task<Catechist> GetCatechistByIdAsync(int id);
        Task AddCatechistAsync(Catechist catechist);
        Task UpdateCatechistAsync(Catechist catechist);
        Task DeleteCatechistAsync(int id);
    }
}

