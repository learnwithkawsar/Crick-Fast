using Teams.API.ApplicationCore.Domain.Entities;

namespace Teams.API.Infrastructure.Interfaces
{
    public interface ITeamsRepository
    {
        Task<IEnumerable<TeamInfo>> GetTeams();
        Task<TeamInfo> GetTeam(string id);
        Task<IEnumerable<TeamInfo>> GetTeamByName(string name);
       // Task<IEnumerable<TeamInfo>> GetTeamByCategory(string categoryName);

        Task CreateTeam(TeamInfo Team);
        Task<bool> UpdateTeam(TeamInfo Team);
        Task<bool> DeleteTeam(string id);
    }
}
