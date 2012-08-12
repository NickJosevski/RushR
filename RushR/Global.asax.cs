using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using RushR.Hubs;

namespace RushR
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var server = new Task(ServerRoutingEventsToWebServer.Start);
            server.Start();
        }
    }

    public static class ServerRoutingEventsToWebServer
    {
        public static void Start()
        {
            return;
            while(true)
            {
                var h = new NotifyHub();
                h.Broadcast("hello");
                Thread.Sleep(2000);
            }
        }
    }

    public static class Tracking
    {
        public static List<User> OnlineUsers = new List<User>();
    }

    public class User
    {
        public string Location { get; set; }

        public string SignalrId { get; set; }
    }
}