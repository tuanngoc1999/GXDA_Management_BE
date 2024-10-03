using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DA_Management_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    public class BlockController : ControllerBase
    {
        private readonly IBlockService _service;

        public BlockController(IBlockService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var blocks = await _service.GetAllAsync();
            return Ok(blocks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var block = await _service.GetByIdAsync(id);
            if (block == null)
            {
                return NotFound();
            }
            return Ok(block);
        }

        [HttpGet("blocksdetail")]
        public async Task<ActionResult> BlocksDetail()
        {
            try
            {
                var block = await _service.GetAllBlocksDetail();
                if (block == null)
                {
                    return NotFound();
                }
                return Ok(block);
            } catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

