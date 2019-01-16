using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB.TwitterAPI.Helpers 
{
    public class HttpClientHelper : AB.TwitterAPI.Models.IHttpClient
    {
        private readonly HttpClient _client;
        public HttpClientHelper(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> Get(System.Uri baseAddress, string url, Dictionary<string, string> headers)
        {
            _client.BaseAddress = baseAddress;

            foreach (var header in headers)
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }

            return await _client.GetAsync(url);
        }
    }
}