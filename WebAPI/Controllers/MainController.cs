using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        private readonly IRepository<Team> _teamRepository;
        private readonly IRepository<Player> _playerRepository;

        public MainController(IRepository<Team> teamRepository, IRepository<Player> playerRepository)
        {
            _teamRepository = teamRepository;
            _playerRepository = playerRepository;
        }

        [HttpGet("teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        [HttpPost("teams")]
        public async Task<IActionResult> CreateTeam([FromBody] Team team)
        {
            var createdTeam = await _teamRepository.AddAsync(team);
            return CreatedAtAction(nameof(GetAllTeams), new { id = createdTeam.Id }, createdTeam);
        }
    }
}