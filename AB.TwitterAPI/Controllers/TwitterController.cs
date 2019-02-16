using AB.TwitterAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AB.TwitterAPI.Managers;
using AB.TwitterAPI.Models;

namespace AB.TwitterAPI.Controllers
{
    [Route("api/twitter")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly TwitterManager _twitterManager;
        public TwitterController(IManager twitterManager) 
        {
            _twitterManager = (TwitterManager)twitterManager;
        }
        
        [HttpGet("Search/{accountName}/{resultType}")]
        public Task<SearchResponse> Search(string accountName, string resultType) 
        {
            var guid = Guid.NewGuid();
            Console.WriteLine(guid.ToString());
            return  _twitterManager.SearchAsync(accountName, resultType);
        }

        [HttpGet("Oembed/{tweetId}")]
        public OembedResponse Oembed(string tweetId, bool omitScript)
        {
            return new OembedResponse();
        }
    }
}
