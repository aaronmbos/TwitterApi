using AB.TwitterAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AB.TwitterAPI.Managers;

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
        
        [HttpGet("search")]
        public Task<object> Search() 
        {
            return  _twitterManager.Search();
        }
    }
}
