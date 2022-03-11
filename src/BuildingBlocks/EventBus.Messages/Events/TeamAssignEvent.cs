using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class TeamAssignEvent : IntegrationBaseEvent
    {
        public string PlayerName { get; set; }
        public string TeamName { get; set; }
    }
}
