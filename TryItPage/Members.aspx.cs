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
            HttpCookie loginCookie = Request.Cookies["login"];
            username = loginCookie["Username"];
            UpdateWatchList();
        }

        private void UpdateWatchList()
        {
            var watchListData = Backend.GetWatchList(username);
            WatchList.DataSource = watchListData.Content;
            WatchList.DataBind();
        }

        private void UpdateNewsLinks(string symbol)
        {
            // TODO: plug in news api
            List<string> dataList = new List<string> { "google.com", "facebook.com" };
            NewsLinks.DataSource = dataList;
            NewsLinks.DataBind();
        }
        private bool UpdateCurrentPrice(string symbol)
        {
            bool res = true;
            string price = "1337";
            if (res)
            {
                CurrentPrice.Text = "$" + price.ToString();
            }
            return res;
        }
        private void UpdateChart(string symbol)
        {

            // establish service connection
            ChartService.ChartsClient service = new ChartService.ChartsClient();
            //parse out input
            // TODO: call api to get real data
            var dataLabels = new string[] { "Label1", "Label2" };
            var dataValues = new string[] { "10", "15" };
            var label = "Annual Price Chart for " + symbol;
            //call service and embed html string
            Chart.Text = service.Chart(label, dataLabels, dataValues);
            service.Close();
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
            UpdateWatchList();
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
            UpdateWatchList();
        }

        protected void ReportClick(object sender, EventArgs e)
        {
            var symbol = InputBox.Text;
            if (symbol == string.Empty)
            {
                InputBox.Text = "Field Empty";
                return;
            }
            var success = UpdateCurrentPrice(symbol);
            if (!success)
            {
                InputBox.Text = "Invalid symbol.";
                return;
            }
            UpdateChart(symbol);
            UpdateNewsLinks(symbol);
        }

        protected void WatchListItemClick(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            InputBox.Text = clickedButton.Text;
        }
    }
}