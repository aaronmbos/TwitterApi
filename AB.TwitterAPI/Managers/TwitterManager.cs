using System.Collections.Generic;
using System.Threading.Tasks;
using AB.TwitterAPI.Helpers;
using AB.TwitterAPI.Interfaces;
using AB.TwitterAPI.Models;
using Newtonsoft.Json;

namespace AB.TwitterAPI.Managers
{
    public class TwitterManager : IManager
    {        
        private HttpClientHelper _httpHelper;
        // In prod this value would come from POST request to Twitter (Twitter recommends caching it) or stored in db
        private const string BearerToken = "AAAAAAAAAAAAAAAAAAAAAIYc9QAAAAAABAU37w2rU38%2BQ%2FxpHAC06edYIl0%3Djjuv0lYn4SdZ0gIWbXso3GUJVXv14ZdtxK6jfLfjPo5vLzwsWf";
        private const string BaseUrl = "https://api.twitter.com/";
        public TwitterManager(IHttpClient httpHelper) 
        {
            _httpHelper = (HttpClientHelper)httpHelper;
        }

        public TwitterManager()
        {
        }

        public async Task<SearchResponse> Search()
        {
            //https://api.twitter.com/1.1/search/tweets.json?q=from%3A@HuskerFBNation&result_type=recent
            var searchResponse = new SearchResponse();
            var test = await _httpHelper.Get(new System.Uri(BaseUrl), "https://api.twitter.com/1.1/search/tweets.json?q=from%3A@HuskerFBNation&result_type=recent", new System.Collections.Generic.Dictionary<string, string>() 
            {
                {"Authorization", $"Bearer {BearerToken}"}
            });
            
            if (test.IsSuccessStatusCode)
            {
                ParseSearch(ref searchResponse, await test.Content.ReadAsStringAsync());
            }
            else 
            {
                searchResponse.Success = false;
                searchResponse.Message = $"The request was unsuccessful. Status Code: {test.StatusCode}";
            }
            return searchResponse;
        }

        private void ParseSearch(ref SearchResponse searchResponse, string responseString) 
        {
            try
            {
                searchResponse = JsonConvert.DeserializeObject<SearchResponse>(responseString);
                searchResponse.Success = true;
            }
            catch (System.Exception)
            {
                searchResponse.Success = false;
                searchResponse.Message = "An error occurred parsing the statuses.";
            }
        }
    }
}