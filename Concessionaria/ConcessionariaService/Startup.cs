using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ConcessionariaContextLib;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ConcessionariaService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            string dataBasePath = Path.Combine("..", "Concessionaria.db");

            services.AddDbContext<Concessionaria>(
                options => options.UseSqlite($"Data Source={dataBasePath}"));

            services.AddScoped<Carros.ICarros, Carros.Carros>();

            services.AddCors();

            services.AddControllers(options =>
            {
                Console.WriteLine("Formatadores Padrões de saída.");
                foreach(IOutputFormatter formatter in options.OutputFormatters){
                    var mediaFormatter = formatter as OutputFormatter;
                    if(mediaFormatter == null){
                        Console.WriteLine($"{formatter.GetType().Name}");
                        
                    }else{ //Outputformatter class tem SupportedMediaTypes
                        Console.WriteLine("{0}, Media Types: {1}",
                        arg0: mediaFormatter.GetType().Name,
                        arg1: string.Join(", ", mediaFormatter.SupportedMediaTypes));

                    }

                }
            })
            .AddXmlDataContractSerializerFormatters()
            .AddXmlSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ConcessionariaService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConcessionariaService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(configurePolicy: options =>{
                options.WithMethods("GET", "POST", "PUT", "DELETE");
                options.WithOrigins(
                    "http://localhost:5002" //Para o cliente MVC
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
