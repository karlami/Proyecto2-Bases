using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_TECNologico.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hospital_TECNologico
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
            services.AddControllers();

            //Llama a la función de inicializado
            InitializeStorage(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //Metodo para iniciar la conección a las bases de datos
        private void InitializeStorage(IServiceCollection services)
        {
            //PostgreSQL
            string postgreSQLConnectionString = Configuration.GetConnectionString("PostgreSQLConnection");
            services.AddDbContext<HospitalTECNologicoContext>(options => options.UseNpgsql(postgreSQLConnectionString));

            //MongoDB

            //SQLServer

        }
    }
}
