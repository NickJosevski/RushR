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

        private dynamic GetClients()
        {
            return GlobalHost.ConnectionManager.GetHubContext<NotifyHub>().Clients;
        }
    }
}