using System;
using Login.Areas.Identity.Data;
using Login.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Login.Areas.Identity.IdentityHostingStartup))]
namespace Login.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<LoginContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("LoginContextConnection")));

                services.AddDefaultIdentity<LoginUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<LoginContext>();
            });
        }
    }
}