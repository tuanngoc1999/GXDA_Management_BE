using System;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface ICatechistProfileService : IService<CatechistProfile>
    {
        Task<Profile> GetProfileByCatechistId(int catechistId);
        Task<bool> IsAllow(int catechistId, string role);
        Task<bool> IsAllowOnClass(int catechistId, int classId, string role);
    }

}

