using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REALtor1._2.Data;
using REALtor1._2.Data.Interfaces;
using REALtor1._2.Data.Repository;
using REALtor1._2.Service;

namespace REALtor1._2
{
    public class Startup
    {
        private IConfigurationRoot _confString;
        public Startup(IHostingEnvironment host)
        {
            _confString = new ConfigurationBuilder().SetBasePath(host.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllHouses, HouseRepository>();
            services.AddTransient<IAllPerson, PersonRepository>();
            services.AddTransient<DataManager>();
            services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<DbContent>().AddDefaultTokenProviders();
            //настраиваем autentification cookie
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "myAutentification";
                opt.Cookie.HttpOnly = true;
                opt.LoginPath = "/Account/Login";
                opt.AccessDeniedPath = "/Account/Accessdenied";
                opt.SlidingExpiration = true;
            });
            //настраиваем политику авторизации для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //добавляем сервисы для контроллеров и представлений (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //подключаем систему маршрутизации
            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=House}/{action=MainView}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Houses}/{action=MainView}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                DbContent content = scope.ServiceProvider.GetRequiredService<DbContent>();
                DbObjects.Initial(content);
            }


        }
    }
}
