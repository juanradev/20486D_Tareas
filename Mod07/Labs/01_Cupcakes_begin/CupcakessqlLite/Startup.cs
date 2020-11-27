using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Configuration;  // añadimos estos using 
using Cupcakes.Data;
using Microsoft.EntityFrameworkCore;

using Cupcakes.Repositories;   // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< injeccion de depencia de los Repositorios

namespace Cupcakes
{
    public class Startup
    {

        private IConfiguration _configuration;                   //injection de dependencia de IConfiguration

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<CupcakeContext>(options =>
                          options.UseSqlite("Data Source=cupcake.db"));  // le indicamos que el contexto va a usar Sqlite 
            services.AddTransient<ICupcakeRepository, CupcakeRepository>();   // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< injeccion de depencia de los Repositorios
        }

        public void Configure(IApplicationBuilder app, CupcakeContext cupcakeContext)  // Le añadimos el contexto al Configure
        {
            app.UseStaticFiles();

            cupcakeContext.Database.EnsureDeleted();                  // y ya sabemos que con esto en cada ejecución tenemos una base de datos original!
            cupcakeContext.Database.EnsureCreated();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "CupcakeRoute",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Cupcake", action = "Index" },
                    constraints: new { id = "[0-9]+" });
            });
        }
    }
}
