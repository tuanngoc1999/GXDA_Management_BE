using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class CatechistService : Service<Catechist>, ICatechistService
    {
        protected new readonly ICatechistRepository _repository;

        public CatechistService(ICatechistRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<CatechistDto?> GetIncludeClassAsync(int id)
        {
            return await _repository.GetIncludeClassAsync(id);
        }

        public async Task<bool> CreateCatechist(CreateCatechistDto catechist, int userId)
        {
            return await _repository.RegisterUserAndCatechistAsync(catechist, userId);

        }

        public async Task<bool> DeleteCatechist(int catechistId)
        {
            return await _repository.DeleteCatechist(catechistId);
        }

        public async Task<List<CatechistDto>> GetAllIncludeClassAsync()
        {
            return await _repository.GetAllIncludeClassAsync();
        }

        public async Task<bool> UpdateCatechistAsync(int catechistId, CreateCatechistDto catechist, int userId)
        {
            return await _repository.UpdateCatechistAsync(catechistId, catechist, userId);
        }
    }

}

