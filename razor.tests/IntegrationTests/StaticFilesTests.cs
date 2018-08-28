using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace razor.tests.IntegrationTests
{
    public class StaticFilesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public StaticFilesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetBasicJs()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions());

            var testJs = await client.GetAsync("/Test/js/test.js");

            Assert.Equal(HttpStatusCode.OK, testJs.StatusCode);
        }

        [Fact]
        public async Task GetLocalizedJs()
        {
            var client = _factory.CreateClient(new WebApplicationFactoryClientOptions());

            var messagesEnJs = await client.GetAsync("/Test/js/messages.en.js");

            Assert.Equal(HttpStatusCode.OK, messagesEnJs.StatusCode);
        }
    }
}
