using Microsoft.AspNet.SignalR;

namespace Localwire.Graphinder.WebVisualizer.Hubs
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("SimulatedAnnealingHub")]
    public class SimulatedAnnealingHub : Hub
    {
        public Task JoinFeed(string algorithmId)
        {
            return Groups.Add(Context.ConnectionId, algorithmId);
        }
    }
}