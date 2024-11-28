using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MockBackendNameSpace;

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
            string validUsername = "TA";
            string validPassword = "Cse445!";

            //check db
            var res = Backend.ValidateLogin(MembersLogin.UserName, MembersLogin.Password);

            // Check if the entered credentials match the hardcoded ones
            if (res.Success)
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
                MembersLogin.FailureText = res.ErrorMsg;
            }
        }


    }
}