using System;
using System.Net.Http;
using AB.TwitterAPI.Interfaces;
using AB.TwitterAPI.Services;
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace AB.TwitterAPI.Tests
{
    [TestFixture]
    public class TwitterServiceTests
    {
        [Test]
        [TestCase(null, null, ExpectedResult = false)]
        [TestCase("", "", ExpectedResult = false)]
        public async Task<bool> SearchAsync_WithInvalidParams_ReturnsFalse(string accountName, string resultType)
        {
            var configMock = new Mock<IConfiguration>();
            var httpMock = new Mock<IHttpRequestService>();
            ITwitterService tweetService = new TwitterService(httpMock.Object, configMock.Object);

            var response = await tweetService.SearchAsync(accountName, resultType);
            return response.Success;
        }
    }
}