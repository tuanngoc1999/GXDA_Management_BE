using System;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IRegistrationSectionService : IService<RegistrationSection>
    {
        Task<RegistrationSection?> GetByGuid(string guid);
        Task<RegistrationSection?> GetValid();
        Task<RegistrationSection> CreateRegistrationSection();
        Task<RegistrationSection?> VaildateSection(string guid);

    }

}

