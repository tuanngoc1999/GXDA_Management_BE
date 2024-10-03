using System;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<IEnumerable<ProfileDto>> GetAll();
    }

}

