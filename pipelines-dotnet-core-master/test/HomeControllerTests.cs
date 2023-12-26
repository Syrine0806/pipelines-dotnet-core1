using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace namespace pipelines_dotnet_core.Tests
{
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<pipelines_dotnet_core.Startup>>
    {
        private readonly WebApplicationFactory<pipelines_dotnet_core.Startup> _factory;

        public HomeControllerTests(WebApplicationFactory<pipelines_dotnet_core.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task IndexPageShouldContainWelcomeMessage()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Contains("Welcome to my SYRINE application", content);
        }
    }
}

