namespace Library.WebApi.Configuration;

public static class ConfigureHealthChecks
{
    public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddHealthChecks()
            .AddSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty,
                name: "Library"
            );

        builder.Services.AddHealthChecksUI(options =>
            {
                options.AddHealthCheckEndpoint("Healthcheck API", "/api/healthcheck");
                options.SetEvaluationTimeInSeconds(5);
                options.SetMinimumSecondsBetweenFailureNotifications(5);
            })
            .AddInMemoryStorage();

        return services;
    }

    public static void AddCustomHealthCheckUrl(this WebApplication app)
    {
        app.MapHealthChecks("/api/healthcheck", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(options =>
        {
            options.UIPath = "/api/healthcheck-dashboard";

            options.UseRelativeApiPath = false;
            options.UseRelativeResourcesPath = false;
            options.UseRelativeWebhookPath = false;
        });
    }
}