using Ambev.DeveloperEvaluation.ORM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Store.SharedDatabaseSetup;

namespace Store.FunctionalTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(static services =>
            {

                // Add DefaultContext using an in-memory database for testing.
                services.AddDbContext<DefaultContext>(static options =>
                {
                    options.UseInMemoryDatabase("Ambev.DeveloperEvaluation.ORM.DefaultContext");
                });

                // Get service provider.
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    var storeDbContext = scopedServices.GetRequiredService<DefaultContext>();

                    storeDbContext.Database.EnsureCreated();

                    try
                    {
                        DatabaseSetup.SeedData(storeDbContext);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the Store database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }

        public void CustomConfigureServices(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Get service provider.
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    var storeDbContext = scopedServices.GetRequiredService<DefaultContext>();

                   try
                   {
                     DatabaseSetup.SeedData(storeDbContext);
                   }
                   catch (Exception ex)
                   {
                     logger.LogError(ex, $"An error occurred seeding the Store database with test messages. Error: {ex.Message}");
                   }
                }
            });
        }
    }
}