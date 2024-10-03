
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DA_Management_Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var attendance = await _service.GetByIdAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("attendances/{id}")]
        public async Task<IActionResult> AddAttendances(int id, List<CreateAttendanceDto> createAttendanceDtos)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                await _service.AddAttendancesAsync(id, createAttendanceDtos, userId);

                var response = new
                {
                    Message = "Attendances added successfully."
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = $"Internal server error: {ex.Message}"
                };

                return StatusCode(500, errorResponse);
            }
        }

        [HttpPut("attendances/{id}")]
        public async Task<IActionResult> UpdateAttendances(int id, List<CreateAttendanceDto> createAttendanceDtos)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                await _service.UpdateAttendancesAsync(id, createAttendanceDtos, userId);

                var response = new
                {
                    Message = "Attendances updated successfully."
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new
                {
                    Message = $"Internal server error: {ex.Message}"
                };

                return StatusCode(500, errorResponse);
            }
        }

    }
}

