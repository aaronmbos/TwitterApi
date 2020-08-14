using System;
using System.Net.Http;
using AB.TwitterAPI.Interfaces;
using AB.TwitterAPI.Services;
using Newtonsoft.Json;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xunit;

namespace AB.TwitterAPI.Tests
{
    public class TwitterServiceTests
    {
        [InlineData(null, null, false)]
        [InlineData("", "", false)]
        [InlineData("Jack", "", false)]
        [InlineData("", "recent", false)]
        [Theory]
        public async Task SearchAsync_WithInvalidParams_ReturnsFalse(string accountName, string resultType, bool expectedResult)
        {
            var configStub = new Mock<IConfiguration>();
            var httpServiceStub = new Mock<IHttpRequestService>();
            ITwitterService tweetService = new TwitterService(httpServiceStub.Object, configStub.Object);

            var response = await tweetService.SearchAsync(accountName, resultType);
            
            Assert.Equal(expectedResult, response.Success);
        }

        [InlineData("Jack", "recent")]
        [InlineData("AaronMBos", "recent")]
        [Theory]
        public async Task SearchAsync_WithValidParams_ReturnsTrue(string accountName, string resultType) 
        {
            var configStub = new Mock<IConfiguration>();
            var httpServiceStub = new Mock<IHttpRequestService>();
            ITwitterService tweetService = new TwitterService(httpServiceStub.Object, configStub.Object);

            configStub.Setup(x => x[It.IsAny<string>()]).Returns("someStringFromConfig");
            httpServiceStub.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                           .ReturnsAsync(new HttpResponseMessage(System.Net.HttpStatusCode.OK) {Content = new StringContent(JsonConvert.SerializeObject(new Models.SearchResponse())) });

            var response = await tweetService.SearchAsync(accountName, resultType);
            Assert.True(response.Success);
        }
    }
}