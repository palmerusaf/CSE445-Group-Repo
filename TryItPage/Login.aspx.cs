using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_client
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie loginCookie = Request.Cookies["login"];
            if (loginCookie != null) { 
                MembersLogin.UserName=loginCookie["Username"];
            }
        }

        protected void Members_Authenticate(object sender, AuthenticateEventArgs e)
        {
            // Temporary hardcoded credentials
            string validUsername = "admin";
            string validPassword = "123";

            // Check if the entered credentials match the hardcoded ones
            if (MembersLogin.UserName == validUsername && MembersLogin.Password == validPassword)
            {
                // Set authentication successful
                e.Authenticated = true;

                // store the user name
                HttpCookie loginCookie = new HttpCookie("login");
                loginCookie["Username"] = MembersLogin.UserName;
                loginCookie.Expires = DateTime.Now.AddMonths(6);
                Response.Cookies.Add(loginCookie);
            }
            else
            {
                // If not, authentication fails
                e.Authenticated = false;
            }
        }


    }
}