using DA_Management_Endpoint.Dto.CreateDtos;
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
    public class CatechistController : ControllerBase
    {
        private readonly ICatechistService _service;
        private readonly ICatechistProfileService _profileService;

        public CatechistController(ICatechistService service, ICatechistProfileService profileService)
        {
            _service = service;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                if (!(await _profileService.IsAllow(userId, "CATECHIST_MANAGEMENT_ADD"))) return Forbid();
                var catechists = await _service.GetAllIncludeClassAsync();
                return Ok(catechists);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CATECHIST_MANAGEMENT_ADD"))) return Forbid();
            var catechist = await _service.GetByIdAsync(id);
            if (catechist == null)
            {
                return NotFound();
            }
            return Ok(catechist);
        }

        [HttpGet("{id}/classes")]
        public async Task<ActionResult> GetIncludeClassAsync(int id)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CATECHIST_MANAGEMENT_ADD"))) return Forbid();
            var catechist = await _service.GetIncludeClassAsync(id);
            if (catechist == null)
            {
                return NotFound();
            }
            return Ok(catechist);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCatechistDto catechist)
        {
            try {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                if (!(await _profileService.IsAllow(userId, "CATECHIST_MANAGEMENT_ADD"))) return Forbid();
                var result = await _service.CreateCatechist(catechist, userId);
                if (result)
                {
                    return Ok(new { message = "User and Catechist registered successfully." });
                }
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
            return StatusCode(500, new { message = "An error occurred during registration." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CreateCatechistDto catechist)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CATECHIST_MANAGEMENT_EDIT"))) return Forbid();
            await _service.UpdateCatechistAsync(id, catechist, userId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "CATECHIST_MANAGEMENT_DELETE"))) return Forbid();
            await _service.DeleteCatechist(id);
            return NoContent();
        }

        [HttpGet("profile")]
        public async Task<ActionResult> GetProfileByCatechistId()
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            var catechist = await _profileService.GetProfileByCatechistId(userId);
            if (catechist == null)
            {
                return NotFound();
            }
            return Ok(catechist);
        }
    }
}

