using System;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IRegistrationSectionRepository : IRepository<RegistrationSection>
    {
        Task<RegistrationSection?> GetByGuid(string guid);
        Task<RegistrationSection?> GetValid();
        Task<RegistrationSection> CreateRegistrationSection();
        Task<RegistrationSection?> VaildateSection(string guid);

        //IEnumerable<Class> GetClassesByCatechistId(int catechistId);
    }

}

