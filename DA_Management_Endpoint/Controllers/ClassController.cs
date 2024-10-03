using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Services;
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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _service;
        private readonly ICatechistProfileService _profileService;

        public ClassController(IClassService service, ICatechistProfileService profileService)
        {
            _service = service;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CLASS_MANAGEMENT_ADD"))) return Forbid();
            var classes = await _service.GetClassesDetail(null);
            return Ok(classes);
        }

        [HttpGet("asignedclasses")]
        public async Task<ActionResult> GetAsignedClass()
        {
            var catechistId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            var classes = await _service.GetClassesByCatechistId(catechistId);
            return Ok(classes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CLASS_MANAGEMENT_ADD"))) return Forbid();
            var classObj = await _service.GetByIdAsync(id);
            if (classObj == null)
            {
                return NotFound();
            }
            return Ok(classObj);
        }

        [HttpGet("block/{id}")]
        public async Task<ActionResult> GetByBlockId(int blockId)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CLASS_MANAGEMENT_ADD"))) return Forbid();
            var classObj = await _service.GetClassesDetail(blockId);
            if (classObj == null)
            {
                return NotFound();
            }
            return Ok(classObj);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateClassDto cls)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                if (!(await _profileService.IsAllow(userId, "CLASS_MANAGEMENT_ADD"))) return Forbid();
                await _service.AddAsync(cls, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut()]
        public async Task<ActionResult> Update(CreateClassDto classObj)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                if (!(await _profileService.IsAllow(userId, "CLASS_MANAGEMENT_EDIT"))) return Forbid();
                await _service.UpdateAsync(classObj, userId);
                return NoContent();
            } catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CLASS_MANAGEMENT_DELETE"))) return Forbid();
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

