using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Data;
using System.Globalization;
using Projekt_2.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace Projekt_2
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
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddAuthentication("CookieAuthentication")
             .AddCookie("CookieAuthentication", config =>
             {
                 config.Cookie.HttpOnly = true;
                 config.Cookie.SecurePolicy = CookieSecurePolicy.None;
                 config.Cookie.Name = "UserLoginCookie";
                 config.LoginPath = "/Login/UserLogin";
                 config.Cookie.SameSite = SameSiteMode.Strict;
             });
            services.AddRazorPages(options => {
                options.Conventions.AuthorizeFolder("/Users");
                options.Conventions.AuthorizeFolder("/ProductCategories");
                options.Conventions.AuthorizeFolder("/ProductTypes");

                options.Conventions.AuthorizePage("/Categories/Create");
                options.Conventions.AuthorizePage("/Categories/Delete");
                options.Conventions.AuthorizePage("/Categories/Edit");
                options.Conventions.AuthorizePage("/Categories/Detail");
                options.Conventions.AuthorizePage("/Categories/Index");

                options.Conventions.AuthorizePage("/Products/Create");
                options.Conventions.AuthorizePage("/Products/Delete");
                options.Conventions.AuthorizePage("/Products/Edit");
                options.Conventions.AuthorizePage("/Products/Cart");
                options.Conventions.AuthorizePage("/Products/Index");

                options.Conventions.AuthorizePage("/Login/LogOut");

            });
            services.AddRazorPages();

            services.AddDbContext<ProjectContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProjectContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseErrorMiddleware(); //to

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
    public static class MyAppData
    {
        public static IConfiguration Configuration;
    }
}
