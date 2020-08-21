using ErrorHub.Data.Context;
using ErrorHub.Data.Repositories;
using ErrorHub.Domain.Models;
using ErrorHub.Domain.Repositories.Interfaces;
using ErrorHub.Domain.Services;
using ErrorHub.Domain.Services.Interfaces;
using ErrosHub.WebApi.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

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

            var token = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(Configuration.GetSection(typeof(TokenConfiguration).Name)).Configure(token);
            services.AddSingleton(token);

            var signingConfiguration = new SigningConfiguration(token);
            services.AddSingleton(signingConfiguration);

            services.AddDbContext<ErrorHubContext>();

            services.AddHttpContextAccessor();

            services.AddSingleton<IAuthenticationService, JwtAuthenticationService>();
            services.AddSingleton<ILoggedUserService, LoggedUserService>();

            services.AddScoped<IErrorOccurrenceRepository, ErrorOccurrenceRepository>();
            services.AddScoped<IErrorOccurrenceService, ErrorOccurrenceService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(y =>
            {
                y.TokenValidationParameters.IssuerSigningKey = signingConfiguration.Key;
                y.TokenValidationParameters.ValidAudience = token.ValidAudience;
                y.TokenValidationParameters.ValidIssuer = token.ValidIssuer;
                y.TokenValidationParameters.ValidateIssuerSigningKey = token.ValidadeIssuerSigningKey;
                y.TokenValidationParameters.ValidateLifetime = token.ValidateLifetime;
                y.TokenValidationParameters.ValidateIssuer = true;
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy(TokenConfiguration.Policy, new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Central de Erros = new Squad(\"#7\", \"Railson Rames\", \"Raphael Fontoura\");",
                    Version = "v1",
                    Description = "Hub de registros de errors"
                });
                x.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });

                x.OperationFilter<AuthenticationRequirementsOperationFilter>();

            });

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.IgnoreNullValues = true;
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCors("EnableCORS");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Central de Erros");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
