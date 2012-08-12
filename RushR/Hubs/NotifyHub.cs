using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SignalR;
using SignalR.Hubs;

namespace RushR.Hubs
{
    [HubName("notifyHub")]
    public class NotifyHub : Hub
    {
        public void Broadcast(string message)
        {
            GetClients().broadcast(message);
        }

        public void TrackMe(string location)
        {
            var found = Tracking.OnlineUsers.Where(u => u.SignalrId == Context.ConnectionId).ToList();

            if (found.Any())
            {
                found.ForEach(f => f.Location = location);
            }
            else
            {
                Tracking.OnlineUsers.Add(new User
                    {
                        SignalrId = Context.ConnectionId,
                        Location = location
                    });
            }
        }

        private dynamic GetClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<NotifyHub>().Clients;
        }
    }
}