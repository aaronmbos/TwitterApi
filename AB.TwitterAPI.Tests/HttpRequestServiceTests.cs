using System;
using System.Net.Http;
using System.Threading.Tasks;
using AB.TwitterAPI.Interfaces;
using AB.TwitterAPI.Services;
using Xunit;

namespace AB.TwitterAPI.Tests
{
    public class HttpRequestServiceTests
    {
        [Fact]
        public void GetAsync_WithNullBaseAddress_ThrowsArgNullExc()
        {
            IHttpRequestService httpReqSvc = new HttpRequestService(new HttpClient());
            Assert.ThrowsAsync(typeof(ArgumentNullException), async () => await httpReqSvc.GetAsync(null, string.Empty, null));
        }

        [Fact]
        public async Task GetAsync_WithBaseAddress_ReturnsResponse()
        {
            IHttpRequestService httpReqSvc = new HttpRequestService(new HttpClient());
            object resp = await httpReqSvc.GetAsync(new Uri("https://google.com"), string.Empty, null);
            Assert.NotNull(resp);
        }

        [Fact]
        public void GetAsync_WithNullUrl_ThrowsArgNullExc()
        {
            IHttpRequestService httpReqSvc = new HttpRequestService(new HttpClient());
            Assert.ThrowsAsync(typeof(ArgumentNullException), async () => await httpReqSvc.GetAsync(new Uri("http://google.com"), null, null));
        }
    }
}