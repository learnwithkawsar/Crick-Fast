using MongoDB.Driver;
using Teams.API.ApplicationCore.Constants;
using Teams.API.ApplicationCore.Domain.Entities;
using Teams.API.Infrastructure.Interfaces;

namespace Teams.API.Infrastructure.DBContext
{
    public class TeamContext : ITeamContext
    {
        public TeamContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Teams = database.GetCollection<TeamInfo>(Constant.TEAMS_COLLECTION);
            TeamsPlayers = database.GetCollection<TeamsPlayers>(Constant.TEAMS_PLAYERS_COLLECTION);
        }
        public IMongoCollection<TeamInfo> Teams { get; }

        public IMongoCollection<TeamsPlayers> TeamsPlayers { get; }
    }
}
