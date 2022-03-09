using MongoDB.Driver;
using Teams.API.ApplicationCore.Domain.Entities;

namespace Teams.API.Infrastructure.Interfaces
{
    public interface ITeamContext
    {
        IMongoCollection<TeamInfo> Teams { get; }
        IMongoCollection<TeamsPlayers> TeamsPlayers { get; }

    }
}
