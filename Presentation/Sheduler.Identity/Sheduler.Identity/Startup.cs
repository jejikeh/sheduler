using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;

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
        var connectionServer = AppConfiguration.GetConnectionString("IdentityDbConnection");
        services
            .AddIdentityServer()
            .AddInMemoryApiResources(Configuration.ApiResources)
            .AddInMemoryIdentityResources(Configuration.IdentityResources)
            .AddInMemoryApiScopes(Configuration.ApiScopes)
            .AddInMemoryClients(Configuration.Clients)
            .AddDeveloperSigningCredential();
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