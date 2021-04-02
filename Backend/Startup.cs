using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// internal imports
using Backend.Areas.Identity.Data;
using Backend.Data;
using Backend.Models;
using Backend.Context;
// dotnet imports
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Backend
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
            services.AddRazorPages();
            services.AddControllersWithViews();

            // env variables for DB Context
            // use default of service name specified in docker-compose.yaml if you want it to automatically work
            // these defaults are erroneous to ensure that the app doesn't work without docker
            // we are passing these env variables in through the docker-compose environment section
            var server = Configuration["DBServer"] ?? "localhost"; 
            var port = Configuration["DBPort"] ?? "6969"; // huehue
            var database = Configuration["Database"] ?? "DEEZ"; // huehue
            var user = Configuration["DBUser"] ?? "DONTUSESAACCOUNT"; // huehue
            var password = Configuration["DBPassword"] ?? "CHANGEME!!!"; // huehue

            services.AddDbContext<DowlingContext>(options =>
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database}; User ID={user}; Password={password}"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
