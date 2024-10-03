using System;
using System.Text;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;
using DA_Management_Endpoint.Dto.CreateDtos;

namespace DA_Management_Endpoint.Repositories
{
    public class CatechistRepository : Repository<Catechist>, ICatechistRepository
    {


        public CatechistRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<CatechistDto>> GetAllIncludeClassAsync()
        {
            // Truy vấn dữ liệu từ database
            var catechists = await _context.Catechists
                .AsNoTracking()
                .Include(x => x.User)
                .Include(c => c.ClassCatechists)
                    .ThenInclude(c => c.Class)
                        .ThenInclude(b => b.Block)
                .Include(c => c.CatechistProfiles)
                    .ThenInclude(p => p.Profile)
                .ToListAsync();

            // Ánh xạ thủ công từ Catechist sang CatechistDto
            var catechistDtos = catechists.Select(catechist => new CatechistDto
            {
                Id = catechist.Id,
                HolyName = catechist.HolyName,
                FirstName = catechist.FirstName,
                LastName = catechist.LastName,
                BirthDate = catechist.BirthDate,
                Address = catechist.Address,
                Contact = catechist.Contact,
                JoinedDate = catechist.JoinedDate,
                Level = catechist.Level,
                User = catechist.User != null ? new CoreDto
                {
                    Id = catechist.User.Id,
                    Name = catechist.User.Username
                } : null,
                Classes = catechist.ClassCatechists.Select(c => new CoreDto
                {
                    Id = c.Id,
                    Name = c.Class.Block?.Name + ' ' + c.Class.Name
                }).ToList(),
                CatechistProfiles = catechist.CatechistProfiles.Select(cp => new CoreDto
                {
                    Id = cp.ProfileId,
                    Name = cp.Profile!.Name
                }).ToList()
            }).ToList();

            return catechistDtos;
        }

        public async Task<CatechistDto?> GetIncludeClassAsync(int id)
        {
            // Truy vấn dữ liệu từ database
            var catechist = await _context.Catechists
                .AsNoTracking()
                .Include(x => x.User)
                .Include(c => c.ClassCatechists)
                    .ThenInclude(c => c.Class)
                        .ThenInclude(b => b.Block)
                .Include(c => c.CatechistProfiles)
                    .ThenInclude(cp => cp.Profile) // Bao gồm Profile trong CatechistProfiles
                .FirstOrDefaultAsync(c => c.Id == id);

            if (catechist == null)
            {
                return null;
            }

            // Ánh xạ thủ công từ Catechist sang CatechistDto
            var catechistDto = new CatechistDto
            {
                Id = catechist.Id,
                HolyName = catechist.HolyName,
                FirstName = catechist.FirstName,
                LastName = catechist.LastName,
                BirthDate = catechist.BirthDate,
                Address = catechist.Address,
                Contact = catechist.Contact,
                JoinedDate = catechist.JoinedDate,
                Level = catechist.Level,
                User = catechist.User != null ? new CoreDto
                {
                    Id = catechist.User.Id,
                    Name = catechist.User.Username // Điều chỉnh tùy thuộc vào cấu trúc CoreDto
                } : null,
                Classes = catechist.ClassCatechists.Select(c => new CoreDto
                {
                    Id = c.Id,
                    Name = c.Class.Block?.Name + ' ' + c.Class.Name
                }).ToList(),
                CatechistProfiles = catechist.CatechistProfiles.Select(cp => new CoreDto
                {
                    Id = cp.ProfileId,
                    Name = cp.Profile!.Name
                }).ToList()
            };

            return catechistDto;
        }

        public async Task<bool> RegisterUserAndCatechistAsync(CreateCatechistDto catechist, int userId)
        {
            using (IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (await _context.Users.AnyAsync(u => u.Username == catechist.UserName))
                    {
                        throw new InvalidOperationException("User already exists.");
                    }

                    Catechist entity = new Catechist
                    {
                        HolyName = catechist.HolyName,
                        FirstName = catechist.FirstName,
                        LastName = catechist.LastName,
                        BirthDate = catechist.BirthDate!.Value,
                        Address = catechist.Address,
                        Contact = catechist.Contact,
                        Level = catechist.Level,
                        JoinedDate = DateTime.UtcNow,
                        CreatedBy = userId,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedBy = userId,
                        UpdatedDate = DateTime.UtcNow
                    };
                    await _context.Catechists.AddAsync(entity);
                    await _context.SaveChangesAsync();

                    var newUser = new User
                    {
                        Id = entity.Id,
                        Username = catechist.UserName,
                        Password = ComputeHash(catechist.Password),
                        Role = "",
                        Status = true
                    };

                    await _context.Users.AddAsync(newUser);
                    await _context.SaveChangesAsync();

                    if(catechist.profileIds != null && catechist.profileIds.Any())
                    {
                        List<CatechistProfile> catechistProfiles = new List<CatechistProfile>();
                        foreach (var id in catechist.profileIds)
                        {
                            CatechistProfile profile = new CatechistProfile
                            {
                                CatechistId = entity.Id,
                                ProfileId = id,
                                CreatedBy = 1,
                                CreatedDate = DateTime.UtcNow,
                                UpdatedBy = 1,
                                UpdatedDate = DateTime.UtcNow
                            };
                            catechistProfiles.Add(profile);
                        }
                        _context.CatechistProfiles.AddRange(catechistProfiles);
                        await _context.SaveChangesAsync();

                    }


                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        private static string ComputeHash(string input)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Convert.ToBase64String(bytes);
            }
        }

        public async Task<bool> DeleteCatechist(int catechistId)
        {
            using (IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var catechist = await _context.Catechists.FindAsync(catechistId);
                    var user = await _context.Users.FindAsync(catechistId);
                    var profiles = await _context.CatechistProfiles.Where(x => x.CatechistId == catechistId).ToListAsync();
                    if (catechist == null || user == null)
                    {
                        throw new InvalidOperationException("User not exists.");
                    }

                    
                    _context.Catechists.Remove(catechist);
                    _context.Users.Remove(user);
                    _context.CatechistProfiles.RemoveRange(profiles);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<bool> UpdateCatechistAsync(int catechistId, CreateCatechistDto catechist, int userId)
        {
            using (IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var entity = await _context.Catechists.Where(u => u.Id == catechistId).FirstOrDefaultAsync();
                    if (entity == null)
                    {
                        throw new InvalidOperationException("User does not exist.");
                    }

                    entity.HolyName = catechist.HolyName;
                    entity.FirstName = catechist.FirstName;
                    entity.LastName = catechist.LastName;
                    entity.BirthDate = catechist.BirthDate!.Value;
                    entity.Address = catechist.Address;
                    entity.Contact = catechist.Contact;
                    entity.Level = catechist.Level;
                    entity.JoinedDate = DateTime.UtcNow;
                    entity.UpdatedBy = userId;
                    entity.UpdatedDate = DateTime.UtcNow;

                    _context.Catechists.Update(entity);

                    var profiles = await _context.CatechistProfiles.Where(x => x.CatechistId == entity.Id).ToListAsync();
                    _context.RemoveRange(profiles);

                    if (catechist.profileIds != null && catechist.profileIds.Any())
                    {
                        List<CatechistProfile> catechistProfiles = new List<CatechistProfile>();
                        foreach (var id in catechist.profileIds)
                        {
                            CatechistProfile profile = new CatechistProfile
                            {
                                CatechistId = entity.Id,
                                ProfileId = id,
                                CreatedBy = 1,
                                CreatedDate = DateTime.UtcNow,
                                UpdatedBy = 1,
                                UpdatedDate = DateTime.UtcNow
                            };
                            catechistProfiles.Add(profile);
                        }
                        _context.CatechistProfiles.AddRange(catechistProfiles);

                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<bool> IsAssignedToClass(int userId, int classId)
        {
            var clsCatechist = await _context.ClassCatechists
                                    .AsNoTracking()
                                    .Where(x => x.ClassId == classId && x.CatechistId == userId)
                                    .FirstOrDefaultAsync();

            if (clsCatechist != null) return true;

            return false;
        }
    }

}

