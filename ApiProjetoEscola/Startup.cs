using ApiProjetoEscola.Model.Context;
using ApiProjetoEscola.Repository;
using ApiProjetoEscola.Repository.IRepository;
using ApiProjetoEscola.Services;
using ApiProjetoEscola.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProjetoEscola
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("EscolaDb");

            services.AddDbContext<ProjetoDbContext>(options => options.UseSqlServer(connection));
            services.AddControllers();

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            })
                .AddXmlSerializerFormatters();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiProjetoEscola", Version = "v1" });
            });

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEscolaService, EscolaService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<IAlunoService, AlunoService>();

            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiProjetoEscola v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolveCon = new SqlConnection(connection);

                var evolve = new EvolveDb.Evolve(evolveCon, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "Data/Migrations", "Data/Dataset" }
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Database migration failed", ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
