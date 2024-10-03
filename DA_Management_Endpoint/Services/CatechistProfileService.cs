using System;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class CatechistProfileService : Service<CatechistProfile>, ICatechistProfileService
    {
        protected new readonly ICatechistProfileRepository _repository;
        protected readonly ICatechistRepository _catechistRepository;
        protected readonly IClassRepository _classRepository;

        public CatechistProfileService(ICatechistProfileRepository repository, ICatechistRepository catechistRepository,
            IClassRepository classRepository) : base(repository)
        {
            _repository = repository;
            _catechistRepository = catechistRepository;
            _classRepository = classRepository;
        }

        public async Task<Profile> GetProfileByCatechistId(int catechistId)
        {
            return await _repository.GetProfileByCatechistId(catechistId);
        }

        public async Task<bool> IsAllow(int catechistId, string role)
        {
            return await _repository.IsAllow(catechistId, role);
        }

        public async Task<bool> IsAllowOnClass(int catechistId, int classId, string role)
        {
            var isAssignToClass = await _catechistRepository.IsAssignedToClass(catechistId, classId);
            if (isAssignToClass) return true;

            var profile = await _repository.GetProfileByCatechistId(catechistId);

            if (role == "VIEW_STUDENT")
            {
                //View all
                if (profile.P1) return true;
                //View by block
                if (profile.P2)
                {
                    //TODO
                    //var cls = _classRepository..
                }
            }

            return false;
        }
    }

}

