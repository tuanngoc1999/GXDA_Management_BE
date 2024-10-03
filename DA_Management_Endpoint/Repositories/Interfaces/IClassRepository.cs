using System;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IClassRepository : IRepository<Class>
    {
        IEnumerable<ClassDto> GetAllStudentsByClassId(int classId);
        Task<IEnumerable<ClassDto>> GetClassesByCatechistId(int catechistId);
        Task<IEnumerable<ClassListDto>> GetClassesDetail(int? blockId);
        Task<bool> IsAssignedToBlock(int userId, int blockId);
        Task UpdateClass(Class cls);
    }

}

