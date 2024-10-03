using System;
using AutoMapper;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DA_Management_Endpoint.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {

        public ClassRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClassDto>> GetClassesByCatechistId(int catechistId)
        {
            //TODO
            var catechistProfile = await _context.CatechistProfiles.Where(x => x.CatechistId == catechistId).ToListAsync();
            var getAll = true;
            var asignedBlock = 1;
            //var data = await _context.Classes
            //    .AsNoTracking()
            //    .Include(x => x.Catechists)
            //    .Where(x => getAll
            //        || (asignedBlock > 0 && x.BlockId == asignedBlock)
            //        || x.Catechists == catechistId)
            //    .Include(x => x.Block)
            //    .Include(x => x.Students)
            //    .ToListAsync();

            var data = await _context.ClassCatechists
                .AsNoTracking()
                .Include(x => x.Class)
                    .ThenInclude(c => c.Block)
                .Include(x => x.Class)
                    .ThenInclude(c => c.Students)
                .Where(x => x.CatechistId == catechistId)
                .ToListAsync();

            var cls = data.Select(x => x.Class);

            var classDtos = cls.Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                Block = c.Block != null ? new CoreDto
                {
                    Id = c.Block.Id,
                    Name = c.Block.Name
                } : null,

                //Catechists = c.Catechists.Select(x => new CoreDto
                //{
                //    Id = x.Id,
                //    Name = x.HolyName + ' ' + x.FirstName + ' ' + x.LastName
                //}).ToList(),
                TotalStudents = c.Students.Count
            }).ToList();

            return classDtos;
        }

        public IEnumerable<ClassDto> GetAllStudentsByClassId(int classId)
        {
            var data = _context.Classes
                .AsNoTracking()
                .Where(x => x.Id == classId)
                .Include(x => x.Students)
                .Include(x => x.ClassCatechists)
                    .ThenInclude(c => c.Catechist)
                .FirstOrDefault();

            if (data == null)
            {
                return Enumerable.Empty<ClassDto>();
            }

            var classDto = new ClassDto
            {
                Id = data.Id,
                Name = data.Name,
                Block = data.Block != null ? new CoreDto
                {
                    Id = data.Block.Id,
                    Name = data.Block.Name
                } : null,
                Catechists = data.ClassCatechists.Select(x => new CoreDto
                {
                    Id = x.Catechist.Id,
                    Name = x.Catechist.HolyName + ' ' + x.Catechist.FirstName + ' ' + x.Catechist.LastName
                }).ToList(),
                TotalStudents = data.Students.Count
            };

            return new List<ClassDto> { classDto };
        }

        public IEnumerable<ClassDto> GetAllStudentByBlockId(int blockId)
        {
            var data = _context.Classes
                .AsNoTracking()
                .Where(x => x.BlockId == blockId)
                .Include(x => x.Students)
                .Include(x => x.ClassCatechists)
                    .ThenInclude(c => c.Catechist)
                .ToList();

            var classDtos = data.Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name,
                Block = new CoreDto
                {
                    Id = c.Block.Id,
                    Name = c.Block.Name
                },
                Catechists = c.ClassCatechists.Select(x => new CoreDto
                {
                    Id = x.Catechist.Id,
                    Name = x.Catechist.HolyName + ' ' + x.Catechist.FirstName + ' ' + x.Catechist.LastName
                }).ToList(),
                TotalStudents = c.Students.Count
            }).ToList();

            return classDtos;
        }


        public async Task<IEnumerable<ClassListDto>> GetClassesDetail(int? blockId)
        {
            var query = _context.Classes
                .AsNoTracking()
                .AsQueryable();

            if (blockId.HasValue)
            {
                query = query.Where(x => x.BlockId == blockId);
            }

            var data = await query
                .OrderBy(x => x.BlockId)
                .ThenBy(cls => cls.Id)
                .Include(x => x.Block)
                .Include(x => x.Students)
                .Include(x => x.ClassCatechists)
                    .ThenInclude(c => c.Catechist)
                .ToListAsync();

            var classDtos = data.Select(c => new ClassListDto
            {
                Id = c.Id,
                Name = c.Name,
                Block = c.Block != null ? new CoreDto
                {
                    Id = c.Block.Id,
                    Name = c.Block.Name
                } : null,
                Catechists = c.ClassCatechists.Select(x => new CoreDto
                {
                    Id = x.Catechist.Id,
                    Name = x.Catechist.HolyName + ' ' + x.Catechist.FirstName + ' ' + x.Catechist.LastName
                }).ToList(),
                TotalStudents = c.Students.Count
            }).ToList();

            return classDtos;
        }

        public async Task<bool> IsAssignedToBlock(int userId, int blockId)
        {
            var cls = await _context.Classes
                                    .AsNoTracking()
                                    .Include(x => x.Block)
                                    .Where(x => x.BlockId == blockId)

                                    .FirstOrDefaultAsync();
            return true;

        }

        public async Task UpdateClass(Class cls)
        {
            if (cls.ClassCatechists.Any())
            {
                var clsCatechists = new List<ClassCatechist>();
                foreach (ClassCatechist item in cls.ClassCatechists)
                {
                    var isMain = true;
                    var clsCatechist = await _context.ClassCatechists.Where(x => x.CatechistId == item.CatechistId && x.ClassId == cls.Id).FirstOrDefaultAsync();

                    if (clsCatechist == null)
                    {
                        clsCatechist = new ClassCatechist
                        {
                            CatechistId = item.CatechistId,
                            IsMainCatechist = isMain
                        };
                        _context.Entry(clsCatechist).State = EntityState.Added;
                        isMain = false;
                        clsCatechists.Add(clsCatechist);
                    }
                }
                cls.ClassCatechists = clsCatechists;
            }
            _context.Classes.Update(cls);
            await _context.SaveChangesAsync();

        }
    }
}

