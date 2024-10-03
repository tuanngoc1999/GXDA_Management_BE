using System;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IProfileService : IService<Profile>
    {
        Task<IEnumerable<ProfileDto>> GetAll();
        Task CreateProfile(CreateProfileDto createProfileDto, int userId);
        Task UpdateProfile(int id, CreateProfileDto createProfileDto, int userId);
    }

}

