﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_client.CurrenyExchangeRate;
using MockBackendNameSpace;
using web_client.StockQuoteService;
using System.Xml.Linq;
using System.Net.Http;

namespace web_client
{
    public partial class Members : System.Web.UI.Page
    {
        private string username;
        // use mock data to save on api calls during testing
        private readonly bool MOCK_DATA = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            // get cookies for username
            HttpCookie loginCookie = Request.Cookies["login"];
            username = loginCookie["Username"];
            // get the watch list and bind it to the ui
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
            if (MOCK_DATA)
            {
                List<string> dataList = new List<string> { "google.com", "facebook.com" };
                NewsLinks.DataSource = dataList;
                NewsLinks.DataBind();
                    return;
            }

            // prep our request
            UriBuilder ub = new UriBuilder($"http://webstrar26.fulton.asu.edu/page2/NewsFocus.svc/NewsFocusService?topics={symbol}");

            //establish connection
            HttpClient client = new HttpClient();
            var res = client.GetAsync(ub.Uri).Result;

            // parse xml into a list of url strings
            var xmlRaw = res.Content.ReadAsStringAsync().Result;
            XDocument doc = XDocument.Parse(xmlRaw);
            var urlsStrings = doc.Descendants().Select(x => x.Value).ToList();

            // i can't figure out how to just target the string elements and descendants("string") isn't working
            // so this hack removes the line where all elements are on the same line
            urlsStrings.RemoveAt(0);

            //update our output box
            NewsLinks.DataSource = urlsStrings;
            NewsLinks.DataBind();
        }
        private bool UpdateCurrentPrice(string symbol)
        {
            string price = "1337";
            if (MOCK_DATA)
            {
                CurrentPrice.Text = "$" + price.ToString();
                return true;
            }
            // establish service connection
            StockQuoteService.StockQuoteClient service = new StockQuoteClient();
            // consume the service
            price = service.Stockquote(symbol);
            // if symbol doesn't exit return false for failed
            if (price==null)
            {
                return false;
            }
            //update our output box
            CurrentPrice.Text = "$"+price;
            //close the connection
            service.Close();
            return true;
        }
        private void UpdateChart(string symbol)
        {
            if (MOCK_DATA)
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
                return;
            }

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