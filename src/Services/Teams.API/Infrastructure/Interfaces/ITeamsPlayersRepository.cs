using Teams.API.ApplicationCore.Domain.Entities;

namespace Teams.API.Infrastructure.Interfaces
{
    public interface ITeamsPlayersRepository
    {
        Task<IEnumerable<TeamsPlayers>> GetTeamPlayers();
        Task<TeamsPlayers> GetTeamPlayer(string id); 
        Task SaveTeamPlayer(TeamsPlayers Team);
        Task<bool> UpdateTeamPlayer(TeamInfo Team);
        Task<bool> DeleteTeamPlayer(string id);
    }
}
