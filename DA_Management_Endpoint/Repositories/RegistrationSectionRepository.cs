using System;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class RegistrationSectionRepository : Repository<RegistrationSection>, IRegistrationSectionRepository
    {
        public RegistrationSectionRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<RegistrationSection> CreateRegistrationSection()
        {
            var records = await _context.RegistrationSections.ToListAsync();

            _context.RegistrationSections.RemoveRange(records);
            await _context.SaveChangesAsync();

            RegistrationSection registrationSection = new RegistrationSection
            {
                Guid = Guid.NewGuid().ToString(),
                InitDate = DateTime.UtcNow,
                Status = true
            };
            await _context.RegistrationSections.AddAsync(registrationSection);
            await _context.SaveChangesAsync();

            return registrationSection;
        }

        public async Task<RegistrationSection?> GetByGuid(string guid)
        {
            return await base._context.RegistrationSections.AsNoTracking().Where(x => x.Guid == guid).FirstOrDefaultAsync();

        }

        public async Task<RegistrationSection?> VaildateSection(string guid)
        {
            return await base._context.RegistrationSections.Where(x => x.Guid == guid && x.Status!.Value && x.InitDate > DateTime.UtcNow.AddMinutes(-30)).FirstOrDefaultAsync();

        }

        public async Task<RegistrationSection?> GetValid()
        {
            return await base._context.RegistrationSections.AsNoTracking().Where(x => x.Status!.Value && x.InitDate > DateTime.UtcNow.AddMinutes(-30)).FirstOrDefaultAsync();

        }
    }
}

