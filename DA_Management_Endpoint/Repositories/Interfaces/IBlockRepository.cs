using System;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

namespace DA_Management_Endpoint.Repositories.Interfaces
{
    public interface IBlockRepository : IRepository<Block>
    {
        Task<IEnumerable<BlockDto>> GetAllBlocksDetail();
    }


}

