var builder = WebApplication.CreateBuilder(args);

builder
    .AddJwtConfiguration()
    .AddJsonConfiguration()
    .AddDbContextConfiguration()
    .AddMediatR()
    .AddExceptionFilterConfiguration()
    .AddCorsConfiguration()
    .AddSerilogCustomConfiguration();

builder.Services
    .AddJwtConfig(builder.Configuration)
    .AddVersioning()
    .AddCustomHealthCheck(builder)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
    app.UseCors("Development");
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

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

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();