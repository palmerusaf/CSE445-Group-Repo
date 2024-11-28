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
        private readonly CurrencyExchangeClient serviceClient = new CurrencyExchangeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            // get the watch list and bind it to the ui
            // TODO: add real username
            var watchListData=Backend.GetWatchList("foo");
            WatchList.DataSource = watchListData.Content;
            WatchList.DataBind();
        }

        protected void RemoveClick(object sender, EventArgs e)
        {
            Response.Write("remove");
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Response.Write("add");
        }

        protected void ReportClick(object sender, EventArgs e)
        {
            Response.Write("report");
        }

        protected void WatchListItemClick(object sender, EventArgs e)
        {

        }
    }
}