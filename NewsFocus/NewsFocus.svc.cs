using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;

namespace NewsFocus
{
    public class NewsFocus : INewsFocus
    {
        // Find news about topics and return news urls
        public string[] NewsFocusService(string topics)
        {
            //replace sperator to search of topic1 or topicN
            var parsedTopics = topics.Replace(',', '|');

            //prep uri
            string apiKey = "1SrDdiHMYnU0kMnDc4ZoufDtKTUMPrFfx6xKXgCv";
            UriBuilder ub = new UriBuilder($"https://api.thenewsapi.com/v1/news/all?api_token={apiKey}&search={parsedTopics}&language=en");

            //establish connection
            HttpClient client = new HttpClient();
            var res = client.GetAsync(ub.Uri).Result;

            // alert the api consumer that connection wasn't ok
            if (!res.IsSuccessStatusCode)
            {
                return new string[] { $"Sorry we had trouble connecting to the server." };
            }

            // parse out the urls
            var jsonRaw = res.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<NewsData>(jsonRaw).data;
            //if we didn't get a response let user know
            if (data == null)
            {
                return new string[] { $"Sorry news urls about: {topics}." };
            }
            //return urls
            return data.Select(el => el.url).ToArray();
        }
    }
    class NewsData
    {
        public NewsFields[] data;
    }
    class NewsFields
    {
        public string url;
    }
}
