namespace Library.WebApi.Configuration;

public static class ConfigureExceptionFilter
{
    public static WebApplicationBuilder AddExceptionFilterConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddMvc(options =>
        {
            options.Filters.Add(new ExceptionFilter());
        });

        return builder;
    }
}