using Auth1.Data;
using Auth1.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Auth1
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<MummyContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLConnectionString")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddScoped<IMummyRepository, EFMummyRepository>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            
            app.UseCookiePolicy();

            app.Use(async (context, next) => {
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self' ; script-scr 'self'; style-src 'self' https://cdn.jsdelivr.net; font-src 'self'; img-src 'self'; frame-src 'self'");

                await next();
              });  //CSP Header if we want to use cdn.jsdelivr to speed up the process of bring in the bootstrap this code allows it

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "typePage",
                    pattern: "{fieldType}/Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Records" });

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Records" });

                endpoints.MapControllerRoute(
                    name: "type",
                    pattern: "{fieldType}",
                    defaults: new { Controller = "Home", action = "Records", pageNum = 1 });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();

                //Old stuff
                //endpoints.MapControllerRoute(
                //    name: "typePage",
                //    pattern: "{fieldType}/Page{pageNum}",
                //    defaults: new { Controller = "Home", action = "Records" });

                //endpoints.MapControllerRoute(
                //    name: "type",
                //    pattern: "{fieldType}",
                //    defaults: new { Controller = "Home", action = "Records", pageNum = 1 });

                //endpoints.MapControllerRoute(
                //   name: "Paging",
                //   pattern: "Page{pageNum}",
                //   defaults: new { Controller = "Home", action = "Records" });

                //endpoints.MapDefaultControllerRoute();

                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
