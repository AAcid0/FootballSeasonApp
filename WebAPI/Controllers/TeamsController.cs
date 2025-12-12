using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly IRepository<Team> _teamRepository;

        public TeamsController(IRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            var createdTeam = await _teamRepository.AddAsync(team);
            return CreatedAtAction(nameof(CreateTeam), new { id = createdTeam.Id }, createdTeam);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateTeam(int id, [FromBody] Team team)
        {
            var existingTeam = await _teamRepository.GetByIdAsync(id);
            if (existingTeam == null)
            {
                return NotFound();
            }

            existingTeam.TeamCode = team.TeamCode;
            existingTeam.Name = team.Name;
            existingTeam.Country = team.Country;
            existingTeam.Category = team.Category;
            existingTeam.FoundationDate = team.FoundationDate;
            existingTeam.Budget = team.Budget;

            await _teamRepository.UpdateAsync(existingTeam);
            return CreatedAtAction(nameof(UpdateTeam), new { id = existingTeam.Id }, existingTeam);
        }
    }
}