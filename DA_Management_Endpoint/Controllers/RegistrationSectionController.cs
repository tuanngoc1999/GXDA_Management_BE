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
    public class RegistrationSectionController : ControllerBase
    {
        private readonly IRegistrationSectionService _service;

        public RegistrationSectionController(IRegistrationSectionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrationSection>>> GetAll()
        {
            var RegistrationSections = await _service.GetAllAsync();
            return Ok(RegistrationSections);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationSection>> GetById(int id)
        {
            var RegistrationSection = await _service.GetByIdAsync(id);
            if (RegistrationSection == null)
            {
                return NotFound();
            }
            return Ok(RegistrationSection);
        }

        [HttpGet("valid")]
        public async Task<ActionResult<RegistrationSection>> GetValid()
        {
            var registrationSection = await _service.GetValid();
            if (registrationSection == null)
            {
                return NotFound();
            }
            return Ok(registrationSection);
        }

        [HttpGet("validation")]
        public async Task<ActionResult<RegistrationSection>> ValidateSection([FromQuery] string guid)
        {
            var registrationSection = await _service.VaildateSection(guid);
            if (registrationSection == null)
            {
                return Unauthorized(new { message = "Invalid section" });
            }
            return Ok(registrationSection);
        }

        //[HttpPost]
        //public async Task<ActionResult> Create(RegistrationSection RegistrationSection)
        //{
        //    await _service.AddAsync(RegistrationSection);
        //    return CreatedAtAction(nameof(GetById), new { Guid = RegistrationSection.Guid }, RegistrationSection);
        //}


        [HttpPost]
        public async Task<ActionResult> Create()
        {
            var result = await _service.CreateRegistrationSection();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, RegistrationSection RegistrationSection)
        {
            if (id != RegistrationSection.Guid)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(RegistrationSection);
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

