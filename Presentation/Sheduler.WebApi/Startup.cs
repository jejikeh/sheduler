using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Sheduler.Application;
using Sheduler.Application.Common.Mappings;
using Sheduler.Application.Interfaces;
using Sheduler.Persistence;
using Sheduler.WebApi.Middleware;

namespace Sheduler.WebApi
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
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ITeachersDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(ILessonsDbContext).Assembly));
            });

            services
                .AddApplication()
                .AddPersistence(Configuration)
                .AddControllers();

            services.AddCors(options =>
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                }));

            var authentication = services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
            });
            authentication.AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://localhost:56163";
                options.Audience = "ShedulerWebApi";
                options.RequireHttpsMetadata = false;
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}