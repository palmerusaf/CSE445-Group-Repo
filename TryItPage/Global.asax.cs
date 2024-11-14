using System;
using System.IO;

namespace web_client
{
    public class Global : System.Web.HttpApplication
    {
        private static Int32 visitorCount;
        private static const var filePath = Server.MapPath("./VisitorCount.txt")
        protected void Application_Start(object sender, EventArgs e)
        {

            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                try
                {
                    var contents = sr.ReadToEnd();
                    visitorCount = int.Parse(contents);
                    Application["VisitorCount"] = visitorCount;
                }
                finally
                {
                    sr.Close();
                }
            }
            else
            {
                    visitorCount = 0;
                    Application["VisitorCount"] = visitorCount;
            }
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
            StreamWriter sw = new StreamWriter("./VisitorCount", false);
            try
            {
                sw.Write(visitorCount);
            }
            finally
            {
                sw.Close();
            }

        }
    }
}