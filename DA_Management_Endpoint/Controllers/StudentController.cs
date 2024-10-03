using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Services;
using DA_Management_Endpoint.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DA_Management_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ICatechistProfileService _profileService;

        public StudentController(IStudentService service, ICatechistProfileService profileService)
        {
            _service = service;
            _profileService = profileService;
        }

        [Authorize]
        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            if (!(await _profileService.IsAllow(userId, "VIEW_ALL_STUDENTS"))) return Forbid();
            var students = await _service.GetAllAsync();
            return Ok(students);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Authorize]
        [HttpGet("classes/{classId}")]
        public async Task<ActionResult> GetByClassId(int classId)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            var student = await _service.GetStudentsByClassIdAsync(classId, userId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStudentDto student)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            await _service.AddAsync(student, userId);
            return Ok();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CreateStudentDto student)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            await _service.UpdateAsync(id, student, userId);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [Authorize]
        [HttpGet("waitingregistration")]
        public async Task<ActionResult> PeakWaitingRegistration()
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            var student  = await _service.GetWaitingForApprove(userId);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [Authorize]
        [HttpPost("approval")]
        public async Task<ActionResult> Approve([FromBody] Student student, [FromQuery] string processingGuid)
        {
            var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
            await _service.ApproveRegistration(student, userId);
            return NoContent();
        }

        [HttpPost("registration")]
        public async Task<ActionResult> Regist([FromBody] CreateStudentDto student)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                await _service.Regist(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [Authorize]
        [HttpGet("attendancesbyclass/{id}")]
        public async Task<ActionResult> GetAttendancesByClassIdAsync(int id, [FromQuery] int month)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                var attendances = await _service.GetAttendancesByClassIdAsync(id, userId, month);
                if (attendances == null)
                {
                    return NotFound();
                }
                return Ok(attendances);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpGet("scoresbyclass/{id}")]
        public async Task<ActionResult> GetScoreByClassIdAsync(int id, [FromQuery] string term)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                var scores = await _service.GetScoresByClassIdAsync(id, userId, term);
                if (scores == null)
                {
                    return NotFound();
                }
                return Ok(scores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Authorize]
        [HttpPost("range")]
        public async Task<ActionResult> ImportRange([FromBody] List<CreateStudentDto> createStudentDtos)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                await _service.ImportRange(createStudentDtos, userId);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

