using System;
using AutoMapper;
using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class BlockRepository : Repository<Block>, IBlockRepository
    {
        public BlockRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<BlockDto>> GetAllBlocksDetail()
        {
            // Truy vấn lấy dữ liệu từ database với các thuộc tính điều hướng được Include
            var blocks = await _context.Blocks
                .Include(x => x.Classes)
                    .ThenInclude(c => c.ClassCatechists)
                        .ThenInclude(cl => cl.Catechist)
                .Include(x => x.Classes)
                    .ThenInclude(c => c.Students)
                .ToListAsync();


            var blockDtos = blocks.Select(block => new BlockDto
            {
                Id = block.Id,
                Name = block.Name,
                Classes = block.Classes.Select(c => new ClassDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Block = new CoreDto
                    {
                        Id = c.Block!.Id,
                        Name = c.Block.Name
                    },
                    Catechists = c.ClassCatechists.Select(x => new CoreDto
                    {
                        Id = x.Id,
                        Name = x.Catechist.HolyName + ' ' + x.Catechist.FirstName + ' ' + x.Catechist.LastName
                    }).ToList(),

                    TotalStudents = c.Students.Count
                }).ToList()
            }).ToList();

            return blockDtos;
        }


    }

}

