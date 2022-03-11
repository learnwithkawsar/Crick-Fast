using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Teams.API.ApplicationCore.Domain.Entities;
using Teams.API.ApplicationCore.Models;
using Teams.API.Infrastructure.Interfaces;
using Teams.API.Infrastructure.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly ITeamsPlayersRepository _teamsPlayerRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public TeamsController(ITeamsRepository teamsRepository, IPublishEndpoint publishEndpoint, ITeamsPlayersRepository teamsPlayerRepository)
        {
            _teamsRepository = teamsRepository ?? throw new ArgumentNullException(nameof(teamsRepository));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _teamsPlayerRepository = teamsPlayerRepository ?? throw new ArgumentNullException(nameof(teamsPlayerRepository));
        }

        // GET: api/<TeamsController>
        [HttpGet]
        public Task<IEnumerable<TeamInfo>> Get()
        {
            return _teamsRepository.GetTeams();
        }

        // GET api/<TeamsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeamsController>
        [HttpPost]
        public async void Post([FromBody] string value)
        {
            TeamInfo teamInfo = new TeamInfo(); 
            teamInfo.TeamName = value;
            teamInfo.ShortCode = value.Substring(0,2).ToLower();
           await _teamsRepository.CreateTeam(teamInfo);

            TeamAssignEvent teamAssignEvent = new TeamAssignEvent();
            teamAssignEvent.TeamName = "BD";

            await _publishEndpoint.Publish<TeamAssignEvent>(teamAssignEvent);
        }

        [HttpPost]
        [Route("PlayerAssign")]
        public async void PlayerAssign(PlayerAssign playerAssign)
        {
            TeamsPlayers teamsPlayers = new TeamsPlayers();
            teamsPlayers.PlayerName = playerAssign.PlayerName;
            teamsPlayers.TeamName = playerAssign.TeamName;
            teamsPlayers.TeamCode = playerAssign.TeamCode;  

           await _teamsPlayerRepository.SaveTeamPlayer(teamsPlayers);

             TeamAssignEvent teamAssignEvent = new TeamAssignEvent();
            teamAssignEvent.TeamName = "BD";
            teamAssignEvent.PlayerName = playerAssign.PlayerName;


            await _publishEndpoint.Publish<TeamAssignEvent>(teamsPlayers);
        }

        // PUT api/<TeamsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeamsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
