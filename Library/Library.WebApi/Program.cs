var builder = WebApplication.CreateBuilder(args);

builder
    .AddJwtConfiguration()
    .AddJsonConfiguration()
    .AddDbContextConfiguration()
    .AddMediatR()
    .AddExceptionFilterConfiguration()
    .AddCorsConfiguration();

builder.Services
    .AddJwtConfig(builder.Configuration)
    .AddVersioning();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

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

app.MapControllers();

app.Run();