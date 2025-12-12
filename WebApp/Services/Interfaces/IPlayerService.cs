using WebApp.Models;

namespace WebApp.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<IEnumerable<Player>> GetAllPlayersByTeam(int teamId);
        Task<Player> CreatePlayerAsync(Player newPlayer);
        Task<Player> UpdatePlayerAsync(Player updatedPlayer);
        Task DeletePlayer(int playerId);
    }
}