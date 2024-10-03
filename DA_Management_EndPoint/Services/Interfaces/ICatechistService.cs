using System;
using DA_Management_EndPoint.Models;

namespace DA_Management_EndPoint.Services.Interfaces
{
    public interface ICatechistService
    {
        Task<IEnumerable<Catechist>> GetAllCatechistsAsync();
        Task<Catechist> GetCatechistByIdAsync(int id);
        Task AddCatechistAsync(Catechist catechist);
        Task UpdateCatechistAsync(Catechist catechist);
        Task DeleteCatechistAsync(int id);
    }
}

