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
    public class StudentRevisionController : ControllerBase
    {
        private readonly IStudentRevisionService _service;

        public StudentRevisionController(IStudentRevisionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var studentRevisions = await _service.GetAllAsync();
            return Ok(studentRevisions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var studentRevision = await _service.GetByIdAsync(id);
            if (studentRevision == null)
            {
                return NotFound();
            }
            return Ok(studentRevision);
        }

        [HttpPost]
        public async Task<ActionResult> Create(StudentRevision studentRevision)
        {
            await _service.AddAsync(studentRevision);
            return CreatedAtAction(nameof(GetById), new { id = studentRevision.Id }, studentRevision);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, StudentRevision studentRevision)
        {
            if (id != studentRevision.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(studentRevision);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

