using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DA_Management_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Authorize]
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearService _service;

        public AcademicYearController(IAcademicYearService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var academicYears = await _service.GetAllAsync();
            return Ok(academicYears);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var academicYear = await _service.GetByIdAsync(id);
            if (academicYear == null)
            {
                return NotFound();
            }
            return Ok(academicYear);
        }

        [HttpPost]
        public async Task<ActionResult> Create(AcademicYear academicYear)
        {
            await _service.AddAsync(academicYear);
            return CreatedAtAction(nameof(GetById), new { id = academicYear.Id }, academicYear);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AcademicYear academicYear)
        {
            if (id != academicYear.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(academicYear);
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

