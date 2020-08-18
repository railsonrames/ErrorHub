using ErrorHub.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ErrosHub.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(x =>
            {
                x.AddPolicy("EnableCORS", y => { y.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
            });

            services.AddDbContext<ErrorHubContext>();

            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Central de Erros = new Squad(\"#7\", \"Railson Rames\", \"Raphael Fontoura\");",
                    Version = "v1",
                    Description = "Hub de registros de errors"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("EnableCORS");

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Central de Erros");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
