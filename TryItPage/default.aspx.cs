using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using web_client.PasswordHasher;
using web_client.StockQuoteService;

namespace web_client
{
    public partial class _default : Page
    {

        protected void StockQuoteSubmit(object sender, EventArgs e)
        {
            //do some client error handling for input
            if (StockQuoteInput.Text == "")
            {
                StockQuoteOutput.Text = "Error: Input is empty.";
                return;
            }
            // let client know something is happening
            StockQuoteOutput.Text = "Loading...";
            // establish service connection
            StockQuoteService.StockQuoteClient service = new StockQuoteClient();
            // consume the service
            var price = service.Stockquote(StockQuoteInput.Text);
            //update our output box
            StockQuoteOutput.Text = price;
            //close the connection
            service.Close();
        }
        protected void AnnualStockSubmit(object sender, EventArgs e)
        {
            //do some client error handling for input
            if (AnnualStockInput.Text == "")
            {
                AnnualStockListOutput.DataSource = new List<string> { "Error: Input is empty." };
                AnnualStockListOutput.DataBind();
                return;
            }

            // let client know something is happening
            AnnualStockListOutput.DataSource = new List<string> { "Loading..." };
            AnnualStockListOutput.DataBind();

            // establish service connection
            StockQuoteService.StockQuoteClient service = new StockQuoteClient();
            try
            {

                // consume the service
                var report = service.AnnualStockReport(AnnualStockInput.Text);

                //convert to list to bind to frontend
                var outputList = new List<string>();
                outputList.Add($"Annual Percent Return: {report.annualReturn}%");
                foreach (var month in report.monthlyClosings)
                {
                    outputList.Add($"Month: {month.name} Closing Price: {month.price}");
                }

                AnnualStockListOutput.DataSource = outputList;
                AnnualStockListOutput.DataBind();
            }
            catch (Exception ex)
            {
                AnnualStockListOutput.DataSource = new List<string> { ex.Message };
                AnnualStockListOutput.DataBind();
            }
            finally
            {
                //close the connection
                service.Close();
            }
        }
        protected void NewsFocusSubmit(object sender, EventArgs e)
        {
            //do some client error handling for input
            if (NewsFocusInput.Text == "")
            {
                NewsFocusOutput.DataSource = new List<string> { "Error: Input is empty." };
                NewsFocusOutput.DataBind();
                return;
            }

            // let client know something is happening
            NewsFocusOutput.DataSource = new List<string> { "Loading..." };
            NewsFocusOutput.DataBind();

            // prep our request
            UriBuilder ub = new UriBuilder($"http://localhost:50159/NewsFocus.svc/NewsFocus?topics={NewsFocusInput.Text}");

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
            NewsFocusOutput.DataSource = urlsStrings;
            NewsFocusOutput.DataBind();
        }
        protected void ChartSubmit(object sender, EventArgs e)
        {
            // establish service connection
            ChartService.ChartsClient service = new ChartService.ChartsClient();
            //parse out input
            var dataLabels = ChartDataLabelsInput.Text.Split(',');
            var dataValues = ChartDataValuesInput.Text.Split(',');
            //call service and embed html string
            ChartOutput.Text = service.Chart(ChartLabelInput.Text, dataLabels, dataValues);
            service.Close();
        }


        //Hashing Logic-----------------
        private IPasswordHasher client;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize the WCF client
            if (client == null)
            {
                var factory = new ChannelFactory<IPasswordHasher>("BasicHttpBinding_IPasswordHasher");
                client = factory.CreateChannel();
            }

            Int32 visitorCount = (int)Application["VisitorCount"];
            VisitorCountOutput.Text = visitorCount.ToString();
        }

        protected void btnGenerateSalt_Click(object sender, EventArgs e)
        {
            txtSalt.Text = client.GenerateSalt();
        }

        protected void btnHashPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtSalt.Text))
            {
                txtHashedPassword.Text = client.HashPassword(txtPassword.Text, txtSalt.Text);
            }
            else
            {
                lblVerificationResult.Text = "Please enter a password and generate a salt.";
            }
        }

        protected void btnVerifyPassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtVerifyPassword.Text) && !string.IsNullOrEmpty(txtHashedPassword.Text) && !string.IsNullOrEmpty(txtSalt.Text))
            {
                bool isValid = client.VerifyPassword(txtVerifyPassword.Text, txtHashedPassword.Text, txtSalt.Text);
                lblVerificationResult.Text = isValid ? "Password verified successfully!" : "Verification failed.";
            }
            else
            {
                lblVerificationResult.Text = "Please fill in all fields for verification.";
            }
        }
        protected void CookiesStoreButtonClick(object sender, EventArgs e) {
            if (CookiesUserNameInput.Text == "" || CookiesPasswordInput.Text == "")
            {
                CookiesOutput.Text = "Fields can't be empty.";
                CookiesOutput.Style.Add(HtmlTextWriterStyle.Color, "red");
                return;
            }
            CookiesOutput.Style.Add(HtmlTextWriterStyle.Color, "black");
            HttpCookie cook = new HttpCookie("login");
            cook["Username"]=CookiesUserNameInput.Text;
            cook["Password"]=CookiesPasswordInput.Text;
            cook.Expires = DateTime.Now.AddMonths(6);
            Response.Cookies.Add(cook);
            CookiesOutput.Text = "Cookies stored.";
            CookiesUserNameInput.Text = "";
            CookiesPasswordInput.Text = "";
        }
        protected void CookiesGetButtonClick(object sender, EventArgs e) {
            HttpCookie cook = Request.Cookies["login"];
            CookiesUserNameInput.Text=cook["Username"];
            CookiesPasswordInput.Text=cook["Password"];
            CookiesOutput.Text = "Cookies retrieved.";
        }
    }
}