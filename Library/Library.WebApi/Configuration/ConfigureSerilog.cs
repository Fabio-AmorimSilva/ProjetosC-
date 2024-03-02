namespace Library.WebApi.Configuration;

public static class ConfigureSerilog
{
    public static void AddSerilogCustomConfiguration(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));
    }
}