using System;
using System.IO;

namespace web_client
{
    public class Global : System.Web.HttpApplication
    {
        private static Int32 visitorCount;
        protected void Application_Start(object sender, EventArgs e)
        {
            visitorCount = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            visitorCount++;
            Application["VisitorCount"] = visitorCount;
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