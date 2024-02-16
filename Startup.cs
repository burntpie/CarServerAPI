public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    // Dependency Injection
    services.AddSingleton<IItemService, ItemService>();
    // ... other services
}
