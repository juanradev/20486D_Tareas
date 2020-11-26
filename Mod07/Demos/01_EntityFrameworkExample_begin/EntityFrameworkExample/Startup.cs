using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; // Añadimos estos dos using 
using EntityFrameworkExample.Data;


namespace EntityFrameworkExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<PersonContext>(options =>
                     options.UseSqlite("Data Source=person.db"));  //Aqui es donde le vamos a decir que el PersonContext está asociado a SqlLite (person.db)
        }

        public void Configure(IApplicationBuilder app,   PersonContext personContext)  // le pasamos el PersonContext
        {
            personContext.Database.EnsureDeleted(); // Cada vez que ejecutemos borramos la base 
            personContext.Database.EnsureCreated(); // y la creamos segun el contexto

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Person}/{action=Index}/{id?}");
            });
        }
    }
}
