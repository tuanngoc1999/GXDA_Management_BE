using System;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface ICatechistRepository : IRepository<Catechist>
    {
        Task<List<CatechistDto>> GetAllIncludeClassAsync();
        Task<CatechistDto?> GetIncludeClassAsync(int id);
        Task<bool> RegisterUserAndCatechistAsync(CreateCatechistDto catechist, int userId);
        Task<bool> DeleteCatechist(int catechistId);
        Task<bool> UpdateCatechistAsync(int catechistId, CreateCatechistDto catechist, int userId);
        Task<bool> IsAssignedToClass(int userId, int classId);
    }
}

