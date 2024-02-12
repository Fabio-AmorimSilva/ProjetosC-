using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;

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
    .AddVersioning();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddHealthChecks()
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