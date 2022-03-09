namespace Teams.API.ApplicationCore.Domain.Entities
{
    public class TeamsPlayers : BaseEntity
    {
     
        public string PlayerName { get; set; }
        public string  Format { get; set; }
        public int Age { get; set; }
    }
}
