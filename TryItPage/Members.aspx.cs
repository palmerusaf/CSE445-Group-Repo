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

        protected async void GetExchangeRateButton_Click(object sender, EventArgs e)
        {
            string currency1 = Currency1TextBox.Text.Trim();
            string currency2 = Currency2TextBox.Text.Trim();

            

            // Call the service method and get the exchange rate
            string result = await serviceClient.ExchangeRateAsync(currency1, currency2);

            // Display the result
            ResultLabel.Text = $"<pre>{result}</pre>";  // display formatted output
        }
    }
}