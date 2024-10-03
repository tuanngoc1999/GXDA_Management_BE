using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DA_Management_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    public class CatechistProfileController : ControllerBase
    {
        //private readonly ICatechistRoleService _service;

        //public CatechistRoleController(ICatechistRoleService service)
        //{
        //    _service = service;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CatechistRole>>> GetAll()
        //{
        //    var catechistRoles = await _service.GetAllAsync();
        //    return Ok(catechistRoles);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<CatechistRole>> GetById(int id)
        //{
        //    var catechistRole = await _service.GetByIdAsync(id);
        //    if (catechistRole == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(catechistRole);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create(CatechistRole catechistRole)
        //{
        //    await _service.AddAsync(catechistRole);
        //    return CreatedAtAction(nameof(GetById), new { id = catechistRole.Id }, catechistRole);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, CatechistRole catechistRole)
        //{
        //    if (id != catechistRole.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await _service.UpdateAsync(catechistRole);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await _service.DeleteAsync(id);
        //    return NoContent();
        //}
    }
}

