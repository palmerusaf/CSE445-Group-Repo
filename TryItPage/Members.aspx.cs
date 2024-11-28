using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_client.CurrenyExchangeRate;
using MockBackendNameSpace;

namespace web_client
{
    public partial class Members : System.Web.UI.Page
    {
        private string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            // get the watch list and bind it to the ui
            // TODO: add real username
            username = "foo";
            UpdateList();
        }

        private void UpdateList()
        {
            var watchListData = Backend.GetWatchList(username);
            WatchList.DataSource = watchListData.Content;
            WatchList.DataBind();
        }

        protected void RemoveClick(object sender, EventArgs e)
        {
            var symbol = InputBox.Text;
            var res=Backend.RemoveSymbol(username, symbol);
            if (!res.Success)
            {
                InputBox.Text = res.ErrorMsg;
                return;
            }
            UpdateList();
        }

        protected void AddClick(object sender, EventArgs e)
        {
            var symbol = InputBox.Text;
            var res=Backend.AddSymbol(username, symbol);
            if (!res.Success)
            {
                InputBox.Text = res.ErrorMsg;
                return;
            }
            UpdateList();
        }

        protected void ReportClick(object sender, EventArgs e)
        {
            Response.Write("report");
        }

        protected void WatchListItemClick(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            InputBox.Text = clickedButton.Text;
        }
    }
}