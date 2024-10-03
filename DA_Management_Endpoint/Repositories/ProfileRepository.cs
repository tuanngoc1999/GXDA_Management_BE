using System;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProfileDto>> GetAll()
        {
            var profiles = await _context.Profiles
                .Include(x => x.CreatedByCatechist)
                .Include(x => x.UpdatedByCatechist)
                .Include(x => x.CatechistProfiles)
                .ToListAsync();

            var dtos = profiles.Select(p => new ProfileDto
            {
                Id = p.Id,
                Name = p.Name,
                P1 = p.P1,
                P2 = p.P2,
                P3 = p.P3,
                P4 = p.P4,
                P5 = p.P5,
                P6 = p.P6,
                P7 = p.P7,
                P8 = p.P8,
                P9 = p.P9,
                P10 = p.P10,
                P11 = p.P11,
                P12 = p.P12,
                P13 = p.P13,
                P14 = p.P14,
                P15 = p.P15,
                P16 = p.P16,
                P17 = p.P17,
                P18 = p.P18,
                P19 = p.P19,
                P20 = p.P20,
                P21 = p.P21,
                P22 = p.P22,
                P23 = p.P23,
                P24 = p.P24,
                QuantityUsed = p.CatechistProfiles.Count,
                CreatedByCatechist = p.CreatedByCatechist != null ? new CoreDto
                {
                    Id = p.CreatedByCatechist.Id,
                    Name = p.CreatedByCatechist.HolyName + ' ' + p.CreatedByCatechist.FirstName + ' ' + p.CreatedByCatechist.LastName
                } : null,
                UpdatedByCatechist = p.UpdatedByCatechist != null ? new CoreDto
                {
                    Id = p.UpdatedByCatechist.Id,
                    Name = p.UpdatedByCatechist.HolyName + ' ' + p.UpdatedByCatechist.FirstName + ' ' + p.UpdatedByCatechist.LastName
                } : null,
            }).ToList();


            return dtos;
        }
    }

}

