using WebApp.Models;

namespace WebApp.Services.Interfaces
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
    }
}