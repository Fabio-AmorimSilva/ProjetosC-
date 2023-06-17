using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Library.WebApi.Configuration;

public static class ConfigureAuthentication
{
    public static IServiceCollection AuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetValue<string>("JwtKey");
        var key = Encoding.ASCII.GetBytes(settings);

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
                ValidateAudience = true
            };
        });

        return services;
    }
}
