using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CarServiceAPI;

public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, configBuilder) =>
        {
            // Adjust the configuration for testing
            var projectDir = Directory.GetCurrentDirectory();
            configBuilder.AddJsonFile(Path.Combine(projectDir, "appsettings.json"), optional: false);
            configBuilder.AddJsonFile("data.json", optional: false, reloadOnChange: false);
        });

        builder.UseStartup<TestStartup>(); // Use TestStartup instead of the default Startup class

        builder.ConfigureServices(services =>
        {
            // Optionally replace services with mocks or other test-specific implementations
        });
    }
}
