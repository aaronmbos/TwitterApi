using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AB.TwitterAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB.TwitterAPI.Interfaces
{
    public interface ITwitterService
    {
        Task<SearchResponse> SearchAsync(string accountName, string resultType);
        Task<OembedResponse> GetOembedAsync(string tweetId, bool omitScript);
    }
}