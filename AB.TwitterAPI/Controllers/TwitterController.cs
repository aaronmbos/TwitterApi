using AB.TwitterAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AB.TwitterAPI.Models;

namespace AB.TwitterAPI.Controllers
{
    [Route("api/twitter")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly ITwitterService _twitterService;
        public TwitterController(ITwitterService twitterService) 
        {
            _twitterService = twitterService;
        }
        
        [HttpGet("Search/{accountName}/{resultType}")]
        public async Task<SearchResponse> Search(string accountName, string resultType) 
        {
            return  await _twitterService.SearchAsync(accountName, resultType);
        }

        [HttpGet("Oembed/{tweetId}")]
        public async Task<OembedResponse> Oembed(string tweetId, bool omitScript)
        {
            return await _twitterService.GetOembedAsync(tweetId, omitScript);
        }
    }
}
