using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace StockQuote
{

    public class StockQuote : IStockQuote
    {
        private const string apiKey = "UUD2YTDKOBE497DF";

        public AnnualStockData AnnualStockReport(string symbol)
        {
            // Uppercase the symbol
            symbol = symbol.ToUpper();

            //test parameters so i don't burn through tokens during dev
            //var apiKey = "demo";
            //symbol = "IBM";

            // sanitize the url
            UriBuilder ub = new UriBuilder($"https://www.alphavantage.co/query?function=TIME_SERIES_MONTHLY&symbol={symbol}&apikey={apiKey}");

            //establish connection
            HttpClient client = new HttpClient();
            var res = client.GetAsync(ub.Uri).Result;

            // alert the api consumer that connection wasn't ok
            if (!res.IsSuccessStatusCode)
            {
                throw new Exception($"Sorry we had trouble connecting to the server.");
            }

            // init our data contract result
            var result = new AnnualStockData()
            {
                monthlyClosings = new List<MonthlyClose>()
            };

            // parse and serialize
            try
            {
                var jsonRaw = res.Content.ReadAsStringAsync().Result;
                var data = JObject.Parse(jsonRaw);
                var monthsRaw = data["Monthly Time Series"];
                //extract data from just the first 12 month objects
                foreach (var month in monthsRaw.Take(12))
                {
                    var monthlyClose = new MonthlyClose
                    {
                        price = month.First["4. close"].ToString(),
                        name = month.Path.Split('.').Last().ToString(),
                    };
                    result.monthlyClosings.Add(monthlyClose);
                }

                //finally calc our apr(annual percentage return)
                var startMonth = float.Parse(result.monthlyClosings.First().price);
                var endMonth = float.Parse(result.monthlyClosings.Last().price);
                result.annualReturn = (((startMonth - endMonth) / endMonth) * 100).ToString("0.00");

                return result;
            }
            //if we didn't find the symbol then our parse will throw a null exception
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Stockquote(string symbol)
        {
            // Uppercase the symbol
            symbol = symbol.ToUpper();
            // sanitize the url
            UriBuilder ub = new UriBuilder($"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={symbol}&apikey={apiKey}");
            //establish connection
            HttpClient client = new HttpClient();
            var res = await client.GetAsync(ub.Uri);
            // alert the api consumer that connection wasn't ok
            if (!res.IsSuccessStatusCode)
            {
                return $"Sorry we had trouble connecting to the server.";
            }

            // parse out the opening price
            var jsonRaw = await res.Content.ReadAsStringAsync();
            Console.WriteLine(jsonRaw.ToString());
            var data = JsonConvert.DeserializeObject<StockData>(jsonRaw).data;
            //if we didn't find the symbol then our parse will return null
            if (data == null)
            {
                return $"Sorry we couldn't find symbol: {symbol}.";
            }
            //return opening price
            return data.price;
        }

        class StockData
        {
            [JsonProperty("Global Quote")]
            public StockPrice data;
        }

        class StockPrice
        {
            [JsonProperty("02. open")]
            public string price;
        }
    }
}
