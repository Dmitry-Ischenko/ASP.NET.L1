using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webstore.DAL.Context;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Services;
using WebStore.Service;
using WebStore.Infrastructure.Services.InSql;
using WebStore.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace WebStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration Configuration) => _Configuration = Configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(_Configuration.GetConnectionString("Default")));
            services.AddTransient<WebStoreDbInitializer>();

            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<WebStoreDB>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 3;
#endif
                opt.User.RequireUniqueEmail = false;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "WebStore.GB";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);

                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Account/AccessDenied";

                opt.SlidingExpiration = true;
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            //services.AddTransient<IProductData, InMemoryProductsData>();
            services.AddTransient<IProductData, InSqIProductData>();
            //InMemoryBlogsData: IBlogsData
            services.AddSingleton<IBlogsData, InMemoryBlogsData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDbInitializer db)
        {
            db.Initialize();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // http://localhost:5000 -> controller == "Home" action == "Index"
                // http://localhost:5000/Products -> controller == "Products" action == "Index"
                // http://localhost:5000/Products/Page -> controller == "Products" action == "Page"
                // http://localhost:5000/Products/Page/5 -> controller == "Products" action == "Page" id = "5"
            });
        }
    }
}
