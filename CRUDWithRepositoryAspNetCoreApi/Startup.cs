//using Castle.Core.Configuration;
using CRUDWithRepositoryAspNetCoreApi.Models;
using CRUDWithRepositoryAspNetCoreApi.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace CRUDWithRepositoryAspNetCoreApi
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup( IConfiguration _configuration)
        {
            configuration = _configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(
               options => options.UseLazyLoadingProxies()
                                 .UseSqlServer(configuration.GetConnectionString("myDb1")));                   
                   
                 
            services.AddControllers();
            services.AddScoped<IitemRepository, ItemRepository>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
             endpoints.MapControllers();
            });
        }
    }
}
