namespace Library.WebApi.Configuration;

public static class ConfigureHangFire
{
    public static IServiceCollection AddCustomHangFire(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSerilogLogProvider()
            .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

        services.AddHangfireServer();

        services.AddMvc();
        
        return services;
    }
}