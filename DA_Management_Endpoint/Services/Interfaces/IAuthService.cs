using System;
using System.Security.Claims;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ClaimsPrincipal> AuthenticateAsync(string username, string password);
    }

}

