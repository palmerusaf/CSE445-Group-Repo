using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace CurrencyExchangeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class CurrencyExchange : ICurrencyExchange
    {
        private const string apiKey = "DZ3IP6ZU09HV8ZRU";
        private static readonly HttpClient client = new HttpClient();
        public async Task<string> ExchangeRate(string cur1, string cur2) 
        {
            cur1 = cur1.ToUpper();
            cur2 = cur2.ToUpper();

            string URL = $"https://www.alphavantage.co/query?function=CURRENCY_EXCHANGE_RATE&from_currency={cur1}&to_currency={cur2}&apikey={apiKey}"; //URL for API call to get exchange rate
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseBody);

                var exchangeResponse = JsonSerializer.Deserialize<CurrencyExchangeResponse>(responseBody);
                if (exchangeResponse?.ExchangeRateDetails != null)
                {
                    var details = exchangeResponse.ExchangeRateDetails;
                    return $"From: {details.FromCurrencyCode} ({details.FromCurrencyName})\n" +
                           $"To: {details.ToCurrencyCode} ({details.ToCurrencyName})\n" +
                           $"Exchange Rate: {details.ExchangeRate}\n" +
                           $"Last Refreshed: {details.LastRefreshed}\n" +
                           $"Time Zone: {details.TimeZone}\n" +
                           $"Bid Price: {details.BidPrice}\n" +
                           $"Ask Price: {details.AskPrice}";
                }
            }
            catch (HttpRequestException e)
            {
                return $"Request error: {e.Message}";
            }
            catch (JsonException jsonEx)
            {
                return $"JSON Exception: {jsonEx.Message}";
            }
            catch (Exception ex)
            {
                return $"Unexpected error: {ex.Message}. Inner exception: {ex.InnerException?.Message}";
            }

            return "Invaild Request.";
        }

        public class CurrencyExchangeResponse
        {
            [JsonPropertyName("Realtime Currency Exchange Rate")]
            public ExchangeRateDetails ExchangeRateDetails { get; set; }
        }

        public class ExchangeRateDetails
        {
            [JsonPropertyName("1. From_Currency Code")]
            public string FromCurrencyCode { get; set; }

            [JsonPropertyName("2. From_Currency Name")]
            public string FromCurrencyName { get; set; }

            [JsonPropertyName("3. To_Currency Code")]
            public string ToCurrencyCode { get; set; }

            [JsonPropertyName("4. To_Currency Name")]
            public string ToCurrencyName { get; set; }

            [JsonPropertyName("5. Exchange Rate")]
            public string ExchangeRate { get; set; }

            [JsonPropertyName("6. Last Refreshed")]
            public string LastRefreshed { get; set; }

            [JsonPropertyName("7. Time Zone")]
            public string TimeZone { get; set; }

            [JsonPropertyName("8. Bid Price")]
            public string BidPrice { get; set; }

            [JsonPropertyName("9. Ask Price")]
            public string AskPrice { get; set; }
        }
    }
}
