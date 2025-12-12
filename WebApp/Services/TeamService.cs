using System.Net.Http.Json;
using WebApp.Models;
using WebApp.Services.Interfaces;

namespace WebApp.Services
{
    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;

        public TeamService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Team>>("api/teams/all");
            return response ?? Array.Empty<Team>();
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {
            var response = await _httpClient.PostAsJsonAsync("api/teams/create", team);
            response.EnsureSuccessStatusCode();
            var createdTeam = await response.Content.ReadFromJsonAsync<Team>();
            return createdTeam!;
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/teams/update/{team.Id}", team);
            response.EnsureSuccessStatusCode();
            var updatedTeam = await response.Content.ReadFromJsonAsync<Team>();
            return updatedTeam!;
        }
    }
}