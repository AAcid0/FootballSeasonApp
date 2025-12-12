using Microsoft.AspNetCore.Mvc;
using WebAPI.Domain.Interfaces;
using WebAPI.Domain.Entities;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly IRepository<Player> _playerRepository;

        public PlayersController(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePlayer([FromBody] Player player)
        {
            player.Team = null!;
            var createdPlayer = await _playerRepository.AddAsync(player);
            return CreatedAtAction(nameof(CreatePlayer), new { id = createdPlayer.Id }, createdPlayer);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, [FromBody] Player player)
        {
            var existingPlayer = await _playerRepository.GetByIdAsync(id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            existingPlayer.DocumentNumber = player.DocumentNumber;
            existingPlayer.Name = player.Name;
            existingPlayer.TeamId = player.TeamId;
            existingPlayer.Age = player.Age;
            existingPlayer.GoalsScored = player.GoalsScored;
            existingPlayer.Nationality = player.Nationality;
            existingPlayer.Position = player.Position;
            existingPlayer.IsInjured = player.IsInjured;

            await _playerRepository.UpdateAsync(existingPlayer);
            return CreatedAtAction(nameof(UpdatePlayer), new { id = existingPlayer.Id }, existingPlayer);
        }

        [HttpGet("by-team/{teamId}")]
        public async Task<IActionResult> GetPlayersByTeam(int teamId)
        {
            var players = await _playerRepository.FindAsync(p => p.TeamId == teamId);
            return Ok(players);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _playerRepository.GetAllAsync();
            return Ok(players);
        }
    }    
}