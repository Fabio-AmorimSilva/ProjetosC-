var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureDbContext(builder);
ConfigureServices(builder);
ConfigureJwt(builder);
ConfigureJsonOptions(builder);
ConfigureOptions(builder);
ConfigureMediaTrAndHandlers(builder);

//External Configs
builder.Services.AuthenticationConfig(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(WebApplicationBuilder builder) 
{
    builder.Services.AddTransient<TokenService>();
    builder.Services.Configure<Settings>(builder.Configuration);
}

void ConfigureJwt(WebApplicationBuilder builder)
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using Bearer scheme.",
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
        });
    });
}

void ConfigureDbContext(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<BaseContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
    });
        
    builder.Services.AddDbContext<LibraryContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        options.UseSqlServer(connectionString);
    });
}

void ConfigureJsonOptions(WebApplicationBuilder builder)
{
    builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy=JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
}

void ConfigureOptions(WebApplicationBuilder builder)
{
    builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
}

void ConfigureMediaTrAndHandlers(WebApplicationBuilder builder)
{
    var assembly = AppDomain.CurrentDomain.Load("Library.Application");
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
}