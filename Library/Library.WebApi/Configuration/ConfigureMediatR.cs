namespace Library.WebApi.Configuration;

public static class ConfigureMediatR
{
    public static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        var assembly = AppDomain.CurrentDomain.Load("Library.Application");
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
        builder.Services.AddValidatorsFromAssemblyContaining<CreateAuthorCommandValidator>();
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RetryPolicyBehavior<,>));

        return builder;
    }
}