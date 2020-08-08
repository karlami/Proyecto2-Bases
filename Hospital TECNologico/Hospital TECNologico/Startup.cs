using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospital_TECNologico.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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

            //Llama a la funcion para habilitar CORS
            EnableCORS(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");

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
            //MongoClient mongoDBClient = new MongoClient("localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");


            //SQLServer

        }

        //Metodo para habilitar CORS
        private void EnableCORS(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
        }
    }
}
