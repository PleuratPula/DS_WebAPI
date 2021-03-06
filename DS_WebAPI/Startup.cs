﻿using System;
using System.Text;
using AutoMapper;
using DS_WebAPI.Data;
using DS_WebAPI.Interfaces;
using DS_WebAPI.Services;
using DS_WebAPI.SharedResources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SistemeTeShperndara.Models;

namespace DS_WebAPI
{
    public class Startup
    {
        public IWebHostEnvironment hostEnvironment;

        public Startup(IWebHostEnvironment env)
        {
            var build = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false)
                .AddEnvironmentVariables()
                .Build();

            Configuration = build;
            hostEnvironment = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddXmlDataContractSerializerFormatters()
                .AddXmlSerializerFormatters();

            services.AddMvc(options =>
            options.RespectBrowserAcceptHeader = true
            );

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("WWW-Authenticate")
                    .Build());
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            // Database Setup
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(hostEnvironment.IsDevelopment() ?
                    appSettings.ConnectionStrings_Local :
                    appSettings.ConnectionStrings_Public));



            // Authentication Setup
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            TokenProvider.Secret = appSettings.Secret;
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            services.AddAuthorization();
            services.AddAuthentication(IISServerDefaults.AuthenticationScheme);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUsersRepository<User>, UsersService>();
            services.AddScoped<IStudentsRepository<Student>, StudentsService>();
            services.AddScoped<IExamsRepository<Exam>, ExamsService>();
            services.AddScoped<IProfessorsRepository<Professor>, ProfessorsService>();
            services.AddScoped<ISubjectsRepository<Subject>, SubjectsService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
