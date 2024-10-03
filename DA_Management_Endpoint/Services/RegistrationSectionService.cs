using System;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class RegistrationSectionService : Service<RegistrationSection>, IRegistrationSectionService
    {
        protected new readonly IRegistrationSectionRepository _repository;

        public RegistrationSectionService(IRegistrationSectionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<RegistrationSection> CreateRegistrationSection()
        {
            return await _repository.CreateRegistrationSection();
        }

        public async Task<RegistrationSection?> GetByGuid(string guid)
        {
            return await _repository.GetByGuid(guid);
        }

        public async Task<RegistrationSection?> GetValid()
        {
            return await _repository.GetValid();
        }

        public async Task<RegistrationSection?> VaildateSection(string guid)
        {
            return await _repository.VaildateSection(guid);
        }
    }

}

