using System;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Services.Interfaces
{
    public interface IBlockService : IService<Block>
    {
        Task<IEnumerable<BlockDto>> GetAllBlocksDetail();
    }

}

