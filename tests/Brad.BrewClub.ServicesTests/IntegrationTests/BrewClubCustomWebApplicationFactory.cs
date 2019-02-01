using Brad.BrewClub.Data;
using Brad.BrewClub.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Brad.BrewClub.ServicesTests.IntegrationTests
{
    public class BrewClubCustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var dbContextServiceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                // Add a database context (BrewClubDbContext) using an in-memory database for testing.
                services.AddDbContext<BrewClubDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestBrewClubDb");
                    options.UseInternalServiceProvider(dbContextServiceProvider);
                });

                // Build the service provider.
                var serviceProvider = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database contexts
                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var testBrewClubDbContext = scopedServices.GetRequiredService<BrewClubDbContext>();

                    var logger = scopedServices.GetRequiredService<ILogger<BrewClubCustomWebApplicationFactory<TStartup>>>();
                    // Ensure the database is created.
                    testBrewClubDbContext.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with some specific test data.
                        NewsItemTestDataSeeder.SetTestData(testBrewClubDbContext);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " + "database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
