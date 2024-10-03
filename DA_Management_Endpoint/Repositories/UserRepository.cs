using System;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckUserName(string userName)
        {
            var isExist = await _context.Users.AsNoTracking().AnyAsync(x => x.Username == userName);
            return isExist;
        }
    }

}

