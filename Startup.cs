using Auth1.Data;
using Auth1.Models;
//using IdentityManagerUI.Models;
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
using System.Security.Claims;
using Microsoft.ML.OnnxRuntime;
//using FileContextCore;

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
                //.AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddRoles<IdentityRole>()
            //    .AddDefaultTokenProviders();


            //services.AddSingleton<InferenceSession>( // REMEMBER TO COMMENT BACK
            //    new InferenceSession("Models/decisiontreemod.onnx")
            //);

            services.AddDbContext<MummyContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("AWSConnection")));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddScoped<IMummyRepository, EFMummyRepository>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });

            services.AddSingleton<InferenceSession>(
                new InferenceSession("wwwroot/decisiontreemodel1.onnx")
            );

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<ApplicationRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 14;
                options.Password.RequiredUniqueChars = 2;
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
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();




            app.Use(async (context, next) => {
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self' 'unsafe-inline' ; script-scr 'self'; style-src 'self' https://cdn.jsdelivr.net; font-src 'self'; img-src 'self'; frame-src 'self'");

                await next();
              });  //CSP Header if we want to use cdn.jsdelivr to speed up the process of bring in the bootstrap this code allows it

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "IdentityManager",
                    areaName: "IdentityManager",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Records" });


                endpoints.MapRazorPages();
            });
        }
    }
}
