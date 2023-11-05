using CriminalsCloudApp.Interfaces;
using CriminalsCloudApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

public class Startup
{
    public readonly IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(Configuration)
            .CreateLogger();
    }

    public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        // ...
        services.AddScoped<ICriminalInterface, criminalDao>();
        services.AddControllersWithViews();

        // Add Serilog services
        loggerFactory.AddSerilog();





    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // Add production-specific error handling here
            // Example: app.UseExceptionHandler("/Home/Error");
            // app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Configure middleware and routing here
        // Example: app.UseAuthentication();
        // app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
