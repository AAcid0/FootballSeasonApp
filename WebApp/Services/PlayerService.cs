using System.Net.Http.Json;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly HttpClient _httpClient;

        public PlayerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Player> CreatePlayerAsync(Player newPlayer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/players/create", newPlayer);
            response.EnsureSuccessStatusCode();
            var createdPlayer = await response.Content.ReadFromJsonAsync<Player>();
            return createdPlayer!;
        }

        public async Task<Player> UpdatePlayerAsync(Player updatedPlayer)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/players/update/{updatedPlayer.Id}", updatedPlayer);
            response.EnsureSuccessStatusCode();
            var updatedPlayerResponse = await response.Content.ReadFromJsonAsync<Player>();
            return updatedPlayerResponse!;
        }

        public Task DeletePlayer(int playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Player>> GetAllPlayersByTeam(int teamId)
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Player>>($"api/players/by-team/{teamId}");
            return response ?? Array.Empty<Player>();
        }

        public Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            var response = _httpClient.GetFromJsonAsync<IEnumerable<Player>>("api/players/all");
            return response!;
        }
    }    
}