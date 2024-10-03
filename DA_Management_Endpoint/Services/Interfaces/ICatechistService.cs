using System;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface ICatechistService : IService<Catechist>
    {
        Task<List<CatechistDto>> GetAllIncludeClassAsync();
        Task<CatechistDto?> GetIncludeClassAsync(int id);
        Task<bool> CreateCatechist(CreateCatechistDto catechist, int userId);
        Task<bool> UpdateCatechistAsync(int catechistId, CreateCatechistDto catechist, int userId);
        Task<bool> DeleteCatechist(int catechistId);
    }
}

