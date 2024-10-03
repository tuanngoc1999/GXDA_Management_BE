using System;
using AutoMapper;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class ProfileService : Service<DA_Management_Endpoint.Models.Profile>, IProfileService
    {
        protected new readonly IProfileRepository _repository;
        protected readonly IMapper _mapper;

        public ProfileService(IProfileRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateProfile(CreateProfileDto createProfileDto, int userId)
        {
            var existed = await _repository.GetFirstOrDefaultByConditionAsync(x => x.Name == createProfileDto.Name);
            if (existed != null) throw new InvalidOperationException("Class already exists.");
            var entity = _mapper.Map<DA_Management_Endpoint.Models.Profile>(createProfileDto);
            entity.CreatedBy = userId;
            entity.UpdatedBy = userId;
            await _repository.AddAsync(entity);
        }

        public async Task<IEnumerable<ProfileDto>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task UpdateProfile(int id, CreateProfileDto createProfileDto, int userId)
        {
            var existed = await _repository.GetByIdAsync(id);
            if (existed.Name == null) throw new InvalidOperationException("Class already exists.");

            existed.Name = createProfileDto.Name;
            existed.P1 = createProfileDto.P1;
            existed.P2 = createProfileDto.P2;
            existed.P3 = createProfileDto.P3;
            existed.P4 = createProfileDto.P4;
            existed.P5 = createProfileDto.P5;
            existed.P6 = createProfileDto.P6;
            existed.P7 = createProfileDto.P7;
            existed.P8 = createProfileDto.P8;
            existed.P9 = createProfileDto.P9;
            existed.P10 = createProfileDto.P10;
            existed.P11 = createProfileDto.P11;
            existed.P12 = createProfileDto.P12;
            existed.P13 = createProfileDto.P13;
            existed.P14 = createProfileDto.P14;
            existed.P15 = createProfileDto.P15;
            existed.P16 = createProfileDto.P16;
            existed.P17 = createProfileDto.P17;
            existed.P18 = createProfileDto.P18;
            existed.P19 = createProfileDto.P19;
            existed.P20 = createProfileDto.P20;
            existed.P21 = createProfileDto.P21;
            existed.P22 = createProfileDto.P22;
            existed.P23 = createProfileDto.P23;
            existed.P24 = createProfileDto.P24;

            existed.UpdatedBy = userId;
            await _repository.UpdateAsync(existed);
        }

    }

}

