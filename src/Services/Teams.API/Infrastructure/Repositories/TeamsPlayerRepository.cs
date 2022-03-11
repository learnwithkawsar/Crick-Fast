using MongoDB.Driver;
using Teams.API.ApplicationCore.Domain.Entities;
using Teams.API.Infrastructure.Interfaces;

namespace Teams.API.Infrastructure.Repositories
{
    public class TeamsPlayerRepository : ITeamsPlayersRepository
    {
        private readonly ITeamContext _context;

        public TeamsPlayerRepository(ITeamContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<bool> DeleteTeamPlayer(string id)
        {
            throw new NotImplementedException();
        }

        public Task<TeamsPlayers> GetTeamPlayer(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeamsPlayers>> GetTeamPlayers()
        {
            throw new NotImplementedException();
        }

        public async Task SaveTeamPlayer(TeamsPlayers Team)
        {
            try
            {
               await _context.TeamsPlayers.InsertOneAsync(Team);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> UpdateTeamPlayer(TeamInfo Team)
        {
            throw new NotImplementedException();
        }
    }
}
