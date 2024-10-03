using System;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IClassService : IService<Class>
    {
        Task<IEnumerable<ClassListDto>> GetClassesDetail(int? blockId);
        Task AddAsync(CreateClassDto dto, int userId);
        Task UpdateAsync(CreateClassDto dto, int userId);
        Task<IEnumerable<ClassDto>> GetClassesByCatechistId(int catechistId);

    }

}

