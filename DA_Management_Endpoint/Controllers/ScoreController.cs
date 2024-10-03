using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DA_Management_Endpoint.Dto.CreateDtos;
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
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _service;
        private readonly ICatechistProfileService _profileService;

        public ScoreController(IScoreService service, ICatechistProfileService profileService)
        {
            _service = service;
            _profileService = profileService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var scores = await _service.GetAllAsync();
            return Ok(scores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var score = await _service.GetByIdAsync(id);
            if (score == null)
            {
                return NotFound();
            }
            return Ok(score);
        }

        [HttpPost("scores/{id}")]
        public async Task<ActionResult> AddScores(int id, [FromBody] List<CreateScoreDto> scoreDtos, [FromQuery] string term)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                await _service.AddScoresAsync(id, scoreDtos, term, userId);

                var response = new
                {
                    Message = "Scores added successfully."
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

        [HttpPut("scores/{id}")]
        public async Task<ActionResult> UpdateScores(int id, [FromBody] List<CreateScoreDto> scoreDtos, [FromQuery] string term)
        {
            try
            {
                var userId = int.Parse(User.FindFirst("CatechistId")?.Value!);
                await _service.UpdateScoresAsync(id, scoreDtos, term, userId);

                var response = new
                {
                    Message = "Scores updated successfully."
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


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

