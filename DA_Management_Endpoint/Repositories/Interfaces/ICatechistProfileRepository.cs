using System;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface ICatechistProfileRepository : IRepository<CatechistProfile>
    {
        Task<Profile> GetProfileByCatechistId(int catechistId);
        Task<bool> IsAllow(int userId, string role);
    }

}

