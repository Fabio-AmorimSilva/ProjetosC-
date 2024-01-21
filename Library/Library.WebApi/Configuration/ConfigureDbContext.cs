namespace Library.WebApi.Configuration;

public static class ConfigureDbContext
{
    public static WebApplicationBuilder AddDbContextConfiguration(this WebApplicationBuilder builder)
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
        
        return builder;
    }
}