using AB.TwitterAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AB.TwitterAPI.Services 
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly HttpClient _client;
        public HttpRequestService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpResponseMessage> GetAsync(System.Uri baseAddress, string url, Dictionary<string, string> headers)
        {
            if (baseAddress == null) { throw new ArgumentNullException(nameof(baseAddress)); }
            if (url == null) { throw new ArgumentNullException(nameof(url)); }
            _client.BaseAddress = baseAddress;
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            
            return await _client.GetAsync(url);
        }
    }
}