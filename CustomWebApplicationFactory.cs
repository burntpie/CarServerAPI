namespace CarServiceAPI;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration((context, configBuilder) =>
        {
            // Adjust the path as necessary to point to your project's root directory
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

            configBuilder.AddJsonFile(configPath);
        });

        builder.ConfigureServices(services =>
        {
            // Here you can remove or replace services for testing purposes
            // For example, to use an in-memory database instead of the real one
        });

        builder.ConfigureAppConfiguration((_, config) =>
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            config.AddJsonFile(Path.Combine(path, "data.json"), optional: false, reloadOnChange: false);
        });
    }
}

