namespace Library.WebApi.Configuration;

public static class ConfigureAuthentication
{
    public static IServiceCollection AddJwtConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSection("JwtConfigurationSettings");
        services.Configure<JwtConfigurationSettings>(settings);

        var appsSettings = settings.Get<JwtConfigurationSettings>();
        var key = Encoding.ASCII.GetBytes(appsSettings?.JwtKey);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appsSettings.ValidOn,
                ValidIssuer = appsSettings.Emissary
            };
        });

        return services;
    }
}
