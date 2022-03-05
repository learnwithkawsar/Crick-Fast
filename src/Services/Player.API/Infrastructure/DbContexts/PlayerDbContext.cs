
using Microsoft.EntityFrameworkCore;
using Player.API.Domain.Entities;

namespace Player.API.Infrastructure
{
    public class PlayerDbContext: DbContext
    {
        public PlayerDbContext(DbContextOptions<PlayerDbContext> options) : base(options)
        {

        }

        public DbSet<PlayerInfo> PlayerInfos { get; set; }
    }
}
