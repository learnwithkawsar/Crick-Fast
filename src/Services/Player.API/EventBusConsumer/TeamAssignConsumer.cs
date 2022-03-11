using EventBus.Messages.Events;
using MassTransit;

namespace Player.API.EventBusConsumer
{
    public class TeamAssignConsumer : IConsumer<TeamAssignEvent>
    {
        private readonly ILogger<TeamAssignConsumer> _logger;

        public TeamAssignConsumer(ILogger<TeamAssignConsumer> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public  Task Consume(ConsumeContext<TeamAssignEvent> context)
        {
             _logger.LogInformation($"Message : {context.Message.TeamName}");
           return Task.CompletedTask;
        }
    }
}
