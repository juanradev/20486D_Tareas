using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EntityFrameworkExample.Data; // añadimos estos 3 using 
using Microsoft.EntityFrameworkCore;
using EntityFrameworkExample.Repositories;

namespace EntityFrameworkExample
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PersonContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))); // aqui le decimos la base de datos del Personcontext

            services.AddScoped<IRepository, MyRepository>(); // La injeccion de depencia utilizada 
        }

        public void Configure(IApplicationBuilder app, PersonContext personContext) // le pasmos el  PersonContext
        {
            app.UseStaticFiles();

            personContext.Database.EnsureDeleted();  // eliminamos y creamos la base de datos
            personContext.Database.EnsureCreated();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Person}/{action=Index}/{id?}");
            });
        }
    }
}
