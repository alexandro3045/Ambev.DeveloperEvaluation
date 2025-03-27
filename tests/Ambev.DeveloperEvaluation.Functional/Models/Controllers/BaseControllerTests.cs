using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi;
using Store.FunctionalTests;
using Store.SharedDatabaseSetup;
using System.Net.Http.Headers;
using Xunit;

namespace Ambev.DeveloperEvaluation.Functional.Controllers
{
    public class BaseControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {

        public Branch Branch { get; set; }
        public User User { get; set; }

        private readonly CustomWebApplicationFactory<Program> _factory;

        public BaseControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;

        }

        public HttpClient GetNewClient()
        {
            var newClient = _factory.WithWebHostBuilder(builder =>
            {
                _factory.CustomConfigureServices(builder);
            }).CreateClient();

            //newClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

            newClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Branch = DatabaseSetup.BranchsFaker.FirstOrDefault();
            User = DatabaseSetup.UsersFaker.FirstOrDefault();

            return newClient;
        }
    }
}