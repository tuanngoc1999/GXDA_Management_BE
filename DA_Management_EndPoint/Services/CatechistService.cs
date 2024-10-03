using System;
using DA_Management_EndPoint.Models;
using DA_Management_EndPoint.Repositories.Interfaces;
using DA_Management_EndPoint.Services.Interfaces;

namespace DA_Management_EndPoint.Services
{
    public class CatechistService : ICatechistService
    {
        private readonly ICatechistRepository _catechistRepository;

        public CatechistService(ICatechistRepository catechistRepository)
        {
            _catechistRepository = catechistRepository;
        }

        public async Task<IEnumerable<Catechist>> GetAllCatechistsAsync()
        {
            return await _catechistRepository.GetAllCatechistsAsync();
        }

        public async Task<Catechist> GetCatechistByIdAsync(int id)
        {
            return await _catechistRepository.GetCatechistByIdAsync(id);
        }

        public async Task AddCatechistAsync(Catechist catechist)
        {
            await _catechistRepository.AddCatechistAsync(catechist);
        }

        public async Task UpdateCatechistAsync(Catechist catechist)
        {
            await _catechistRepository.UpdateCatechistAsync(catechist);
        }

        public async Task DeleteCatechistAsync(int id)
        {
            await _catechistRepository.DeleteCatechistAsync(id);
        }
    }
}

