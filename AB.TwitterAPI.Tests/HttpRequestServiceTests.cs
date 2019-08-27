using System;
using System.Net.Http;
using AB.TwitterAPI.Interfaces;
using AB.TwitterAPI.Services;
using NUnit.Framework;

namespace AB.TwitterAPI.Tests
{
    [TestFixture]
    public class HttpRequestServiceTests
    {
        [Test]
        public void GetAsync_WithNullBaseAddress_ThrowsArgNullExc()
        {
            IHttpRequestService httpReqSvc = new HttpRequestService(new HttpClient());
            Assert.ThrowsAsync(typeof(ArgumentNullException), async () => await httpReqSvc.GetAsync(null, string.Empty, null));
        }

        [Test]
        public void GetAsync_WithNullUrl_ThrowsArgNullExc()
        {
            IHttpRequestService httpReqSvc = new HttpRequestService(new HttpClient());
            Assert.ThrowsAsync(typeof(ArgumentNullException), async () => await httpReqSvc.GetAsync(new Uri("http://google.com"), null, null));
        }
    }
}