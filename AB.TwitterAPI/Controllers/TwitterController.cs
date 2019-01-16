using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AB.TwitterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly TwitterAPI.Managers.TwitterManager _twitterManager;
        public TwitterController(Managers.TwitterManager twitterManager) 
        {
            _twitterManager = twitterManager;
        }
        
        [HttpGet]
        [Route("search")]
        public Task<IActionResult> Search() 
        {
            throw new Exception();
        }
    }
}
