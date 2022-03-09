using MongoDB.Driver;
using Teams.API.ApplicationCore.Domain.Entities;
using Teams.API.Infrastructure.Interfaces;

namespace Teams.API.Infrastructure.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly ITeamContext _context;

        public TeamsRepository(ITeamContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateTeam(TeamInfo Team)
        {
            try
            {
              await  _context.Teams.InsertOneAsync(Team);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteTeam(string id)
        {
            try
            {
                FilterDefinition<TeamInfo> filter = Builders<TeamInfo>.Filter.Eq(p => p.Id, id);

                DeleteResult deleteResult = await _context
                                                    .Teams
                                                    .DeleteOneAsync(filter);

                return deleteResult.IsAcknowledged
                    && deleteResult.DeletedCount > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TeamInfo> GetTeam(string id)
        {
            try
            {
                return await _context.Teams.Find(e => e.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TeamInfo>> GetTeamByName(string name)
        {
            try
            {
                return await _context.Teams.Find(e => e.TeamName.Contains(name)).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<TeamInfo>> GetTeams()
        {
            try
            {
                return await _context
                                .Teams
                                .Find(p => true)
                                .ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateTeam(TeamInfo Team)
        {
            var updateResult = await _context
                                         .Teams
                                         .ReplaceOneAsync(filter: g => g.Id == Team.Id, replacement: Team);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
