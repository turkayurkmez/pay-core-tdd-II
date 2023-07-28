using System.Net;

namespace Catalog.API.Tests
{
    public class APIIntegration : IClassFixture<InMemoryApplicationFactory<Program>>
    {
        private readonly InMemoryApplicationFactory<Program> applicationFactory;
        private IEnumerable<object> httpStatusCode;

        public APIIntegration(InMemoryApplicationFactory<Program> applicationFactory)
        {
            this.applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task Search_Products()
        {
            var client = applicationFactory.CreateClient();
            var response = await client.GetAsync("api/products/laptop");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
