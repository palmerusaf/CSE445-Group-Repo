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
            // get cache and set form 
            HttpCookie exchangeRateData=Request.Cookies["exchangeRateData"];
            if (exchangeRateData != null)
            {
                Currency1TextBox.Text = exchangeRateData["currency1"];
                Currency2TextBox.Text = exchangeRateData["currency2"];
            }
        }

        protected async void GetExchangeRateButton_Click(object sender, EventArgs e)
        {
            string currency1 = Currency1TextBox.Text.Trim();
            string currency2 = Currency2TextBox.Text.Trim();

            // remember input by caching into cookies
            HttpCookie exchangeRateData = new HttpCookie("exchangeRateData");
            exchangeRateData["currency1"]=currency1;
            exchangeRateData["currency2"]=currency2;
            Response.Cookies.Add(exchangeRateData);

            // Call the service method and get the exchange rate
            string result = await serviceClient.ExchangeRateAsync(currency1, currency2);

            // Display the result
            ResultLabel.Text = $"<pre>{result}</pre>";  // display formatted output
        }
    }
}