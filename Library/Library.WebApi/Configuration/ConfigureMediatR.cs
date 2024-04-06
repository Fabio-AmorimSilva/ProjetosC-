namespace Library.WebApi.Configuration;

public static class ConfigureMediatR
{
    public static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        var assembly = AppDomain.CurrentDomain.Load("Library.Application");
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        builder.Services.AddValidatorsFromAssembly(assembly);
        builder.Services.TryAddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.TryAddScoped(typeof(IPipelineBehavior<,>), typeof(RetryPolicyBehavior<,>));

        return builder;
    }
}