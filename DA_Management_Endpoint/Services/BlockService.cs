using System;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using DA_Management_Endpoint.Services.Interfaces;

namespace DA_Management_Endpoint.Services
{
    public class BlockService : Service<Block>, IBlockService
    {
        protected new readonly IBlockRepository _repository;

        public BlockService(IBlockRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BlockDto>> GetAllBlocksDetail()
        {
            return await _repository.GetAllBlocksDetail();
        }
    }

}

