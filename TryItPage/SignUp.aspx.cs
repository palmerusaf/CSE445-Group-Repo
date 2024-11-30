using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BackendNameSpace;

namespace web_client
{
    public partial class SignUp : System.Web.UI.Page
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
            string userName = MembersLogin.UserName.Trim();
            string password = MembersLogin.Password.Trim();
            if (userName == string.Empty || password == string.Empty) { 
                MembersLogin.FailureText = "Fields can't be Empty!";
                return;
            }
            MembersLogin.FailureText = "";

            //check db
            var res =  Backend.CreateUser(MembersLogin.UserName, MembersLogin.Password);

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
