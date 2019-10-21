using System;
using System.Net.Http;
using AB.TwitterAPI.Interfaces;
using AB.TwitterAPI.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AB.TwitterAPI.Tests
{
    [TestFixture]
    public class TwitterServiceTests
    {
        [TestCase(null, null, ExpectedResult = false)]
        [TestCase("", "", ExpectedResult = false)]
        [TestCase("Jack", "", ExpectedResult = false)]
        [TestCase("", "recent", ExpectedResult = false)]
        public async Task<bool> SearchAsync_WithInvalidParams_ReturnsFalse(string accountName, string resultType)
        {
            var configStub = new Mock<IConfiguration>();
            var httpServiceStub = new Mock<IHttpRequestService>();
            ITwitterService tweetService = new TwitterService(httpServiceStub.Object, configStub.Object);

            var response = await tweetService.SearchAsync(accountName, resultType);
            
            return response.Success;
        }

        [TestCase("Jack", "recent")]
        [TestCase("AaronMBos", "recent")]
        public async Task SearchAsync_WithValidParams_ReturnsTrue(string accountName, string resultType) 
        {
            var configStub = new Mock<IConfiguration>();
            var httpServiceStub = new Mock<IHttpRequestService>();
            ITwitterService tweetService = new TwitterService(httpServiceStub.Object, configStub.Object);

            configStub.Setup(x => x[It.IsAny<string>()]).Returns("someStringFromConfig");
            httpServiceStub.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                           .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK) {Content = new StringContent(JsonConvert.SerializeObject(new Models.SearchResponse())) });

            var response = await tweetService.SearchAsync(accountName, resultType);
            Assert.That(response.Success == true);
        }
    }
}