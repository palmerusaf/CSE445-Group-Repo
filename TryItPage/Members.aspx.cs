using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_client.CurrenyExchangeRate;

namespace web_client
{
    public partial class Members : System.Web.UI.Page
    {
        private readonly CurrencyExchangeClient serviceClient = new CurrencyExchangeClient();
        protected void Page_Load(object sender, EventArgs e)
        {
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
    }
}