using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MuhendisSozluk
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add("baslik", new Route("{title}", new PageRouteHandler("~/default.aspx")));
            RouteTable.Routes.Add("yazar", new Route("yazar/{name}", new PageRouteHandler("~/user/yazar.aspx")));
            RouteTable.Routes.Add("entry", new Route("entry/{number}", new PageRouteHandler("~/entry/entry.aspx")));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }
        public static void RegisterRoute(System.Web.Routing.RouteCollection routes)
        {
            //routes.MapPageRoute("ForTitle", "~/{Name}", "~/default.aspx");
            //routes.MapPageRoute("ForTitle", "~/{Name}", "~/");

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}