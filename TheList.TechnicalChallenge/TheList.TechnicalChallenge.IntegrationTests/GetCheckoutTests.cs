using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TheList.TechnicalChallenge.Core.Models;
using Xunit;

namespace TheList.TechnicalChallenge.IntegrationTests
{
    public class GetCheckoutTests
    {
        protected readonly HttpClient httpClient;

        public GetCheckoutTests()
        {
            var hostBuilder = new HostBuilder()
            .ConfigureWebHost(webHost =>
            {
                webHost.UseTestServer()
                .UseEnvironment("Development")
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                })
                .UseStartup<Startup>();
            });

            var host = hostBuilder.StartAsync().Result;
            httpClient = host.GetTestClient();
        }

        [Fact]
        public async Task Get_Checkout_From_Service_Async()
        {
            var response = await httpClient.GetAsync($"v1/the-list/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            var checkout = JsonConvert.DeserializeObject<Checkout>(content);
            Assert.NotNull(checkout);

        }
    }
}
