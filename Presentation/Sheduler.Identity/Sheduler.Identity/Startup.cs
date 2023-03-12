using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Sheduler.Identity.Data;
using Sheduler.Identity.Models;

namespace Sheduler.Identity;

public class StartUp
{
    public IConfiguration AppConfiguration { get; }

    public StartUp(IConfiguration configuration)
    {
        AppConfiguration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = AppConfiguration.GetConnectionString("IdentityDbConnection");
        services.AddDbContext<AuthDbContext>(options => options.UseSqlite(connectionString));
        
        var identity = services.AddIdentity<AppUser, IdentityRole>(config =>
        {
            config.Password.RequiredLength = 2;
            config.Password.RequireDigit = true;
            config.Password.RequireNonAlphanumeric = false;
            config.Password.RequireUppercase = false;
        });
        identity
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();
        
        
        services
            .AddIdentityServer()
            .AddAspNetIdentity<AppUser>()
            .AddInMemoryApiResources(Configuration.ApiResources)
            .AddInMemoryIdentityResources(Configuration.IdentityResources)
            .AddInMemoryApiScopes(Configuration.ApiScopes)
            .AddInMemoryClients(Configuration.Clients)
            .AddDeveloperSigningCredential();

        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = "Sheduler.Identity.Cookie";
            config.LoginPath = "/Auth/Login";
            config.LogoutPath = "/Auth/Logout";
        });

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Styles")),
            RequestPath = "/styles"
        });
        app.UseRouting();
        app.UseIdentityServer();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}