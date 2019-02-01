using Brad.BrewClub.Services;
using Brad.BrewClub.Services.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Brad.BrewClub.ServicesTests.IntegrationTests.Controllers
{
    public class NewsItemControllerTests : IClassFixture<BrewClubCustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public NewsItemControllerTests(BrewClubCustomWebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task CanGetListOfNewsItems()
        {
            var httpResponse = await client.GetAsync("/api/newsitem");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var newsItems = JsonConvert.DeserializeObject<IEnumerable<NewsItem>>(stringResponse);
            Assert.Contains(newsItems, newsItem => newsItem.Id == 1);
            Assert.Contains(newsItems, newsItem => newsItem.Id == 2);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [Trait("Category", "Integration")]
        public async Task CanGetNewsItemById(int id)
        {
            var httpResponse = await client.GetAsync($"/api/newsitem/{id.ToString()}");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var newsItem = JsonConvert.DeserializeObject<NewsItem>(stringResponse);
            Assert.True(newsItem.Id == id);
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task MissingNewsItemReturnsNotFoundHttpCode()
        {
            var httpResponse = await client.GetAsync($"/api/newsitem/9999");

            var expectedStatusCode = HttpStatusCode.NotFound;
            var actualStatusCode = httpResponse.StatusCode;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
