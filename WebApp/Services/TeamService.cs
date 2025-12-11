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
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Team>>("api/Main/teams");
            return response ?? Array.Empty<Team>();
        }
    }
}