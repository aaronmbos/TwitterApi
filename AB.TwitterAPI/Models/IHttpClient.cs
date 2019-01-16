using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AB.TwitterAPI.Models
{
    public interface IHttpClient
    {
         Task<HttpResponseMessage> Get(System.Uri baseAddress, string url, Dictionary<string, string> headers);
    }
}