using System.Collections.Generic;
using System.Threading.Tasks;
using AB.TwitterAPI.Interfaces;
using AB.TwitterAPI.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using AB.TwitterAPI.Utils;

namespace AB.TwitterAPI.Services
{
    public class TwitterService : ITwitterService
    {        
        private IHttpRequestService _httpRequestService;
        private IConfiguration _configuration;
        
        private const string BaseUrl = "https://api.twitter.com/";
        private KeyValuePair<string, string> AuthorizationHeader => new KeyValuePair<string, string>("Authorization", $"Bearer {_configuration["Twitter:BearerToken"]}");
        public TwitterService(IHttpRequestService httpRequestService, IConfiguration configuration) 
        {
            _httpRequestService = httpRequestService;
            _configuration = configuration;
        }

        public TwitterService()
        {
        }

        public async Task<SearchResponse> SearchAsync(string accountName, string resultType)
        {
            //https://api.twitter.com/1.1/search/tweets.json?q=from%3A@HuskerFBNation&result_type=recent
            var searchResponse = new SearchResponse();
            if (ValidateSearchParams(accountName, resultType, ref searchResponse)) 
            {
                var authHeader = new Dictionary<string, string>() { {AuthorizationHeader.Key, AuthorizationHeader.Value } };
                var response = await _httpRequestService.GetAsync(new System.Uri(BaseUrl), $"https://api.twitter.com/1.1/search/tweets.json?q=from%3A{accountName}&result_type={resultType}", authHeader);
                
                if (response.IsSuccessStatusCode)
                {
                    ParseSearch(ref searchResponse, await response.Content.ReadAsStringAsync());
                }
                else 
                {
                    searchResponse.Success = false;
                    searchResponse.Message = $"The request was unsuccessful. Status Code: {response.StatusCode}";
                }
            }
            return searchResponse;
        }

        public async Task<OembedResponse> GetOembedAsync(string tweetId, bool omitScript)
        {
            var oembedResponse = new OembedResponse();
            string escapedUri = System.Uri.EscapeUriString($"https://twitter.com/twitter/status/{tweetId}");
            var response = await _httpRequestService.GetAsync(new System.Uri("https://publish.twitter.com/"), $"https://publish.twitter.com/oembed?url={escapedUri}&omit_script={omitScript}", null);

            if (response.IsSuccessStatusCode)
            {
                ParseOembed(ref oembedResponse, await response.Content.ReadAsStringAsync());
            }
            else
            {
                oembedResponse.Success = false;
                oembedResponse.Message = $"The request was unsuccessful. Status Code: {response.StatusCode}";
            }
            return oembedResponse;
        }

        private bool ValidateSearchParams(string accountName, string resultType, ref SearchResponse searchResponse) 
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(accountName)) 
            { 
                searchResponse.Message = $"Parameter: {nameof(accountName)} is required.";
                searchResponse.Success = false;
                isValid = false;
            }
            else if (!ValidationUtil.IsValidLength(1, 15, accountName))
            {
                searchResponse.Message = $"Parameter: {nameof(accountName)} is an invalid character length.";
                searchResponse.Success = false;
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(resultType)) 
            { 
                searchResponse.Message = $"Parameter: {nameof(resultType)} is required.";
                searchResponse.Success = false;
                isValid = false;
            }
            return isValid;
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

        private void ParseOembed(ref OembedResponse oembedResponse, string responseString)
        {
            try
            {
                oembedResponse = JsonConvert.DeserializeObject<OembedResponse>(responseString);
                oembedResponse.Success = true;
            }
            catch (System.Exception)
            {
                oembedResponse.Success = false;
                oembedResponse.Message = "An error occurred parsing the response.";
            }
        }
    }
}