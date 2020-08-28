using System;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ParentContactWeb.models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace ParentContactWeb
{
    public class Startup
    { 
        private readonly IWebHostEnvironment _env;
        private string dbconn;
        private string sSecrets;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            dbconn = Environment.GetEnvironmentVariable("ConnectionStrings__ParentContactDB");
            sSecrets = Environment.GetEnvironmentVariable("Authentication_Google_ClientId");

            if (env.IsProduction()){

               

            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
                    .AddCookie()
                    .AddGoogle(options =>
                    {
                        IConfigurationSection googleAuthNSection =
                            Configuration.GetSection("Authentication:Google");

                        options.ClientId = googleAuthNSection["ClientId"];
                        options.ClientSecret = googleAuthNSection["ClientSecret"];
                    });


            services.AddControllersWithViews();

             services.AddDbContextPool<parentcontactdbContext>
                (options => options
               
                    .UseMySql(dbconn, mySqlOptions => mySqlOptions
                    .ServerVersion(new Version(5, 7, 12), ServerType.MySql)
                ));

            





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                dbconn = Environment.GetEnvironmentVariable("ConnectionStrings__ParentContactDB");
                
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
