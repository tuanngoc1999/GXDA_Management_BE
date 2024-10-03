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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _service;
        private readonly ICatechistProfileService _profileService;

        public ProfileController(IProfileService service, ICatechistProfileService profileService)
        {
            _service = service;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "PROFILE_MANAGEMENT"))) return Forbid();
            var profiles = await _service.GetAll();
            return Ok(profiles);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateProfileDto profile)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "PROFILE_MANAGEMENT"))) return Forbid();
            await _service.CreateProfile(profile, userId);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateProfileDto profile)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "PROFILE_MANAGEMENT"))) return Forbid();
            var catechistId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            await _service.UpdateProfile(id, profile, catechistId);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "PROFILE_MANAGEMENT"))) return Forbid();
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

