using ElShop.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using Shop.Data.Models;
using Shop.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class Startup
    {

        private readonly IConfigurationRoot _confString;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllItems,ItemRepository>();
            services.AddTransient<IItemsCategory, CategoryRepository>();//объединение интерфейса и класса который он реализует
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//работа с сессиями
            services.AddScoped(sp => ShopCart.GetCart(sp));//разные корзины для разных пользователей
            //services.AddMvcCore(options => options.EnableEndpointRouting = false).AddRazorViewEngine();//
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();    //отображение страницы с ошибками
            app.UseStatusCodePages();   //отображение кода страницы
            app.UseStaticFiles();   //отображение css файлов, картинок и тд
            app.UseSession();
            //app.UseMvcWithDefaultRoute();   //вызов контроллера по умолчанию Home
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "desault", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Item/{action}/{category?}", defaults: new { Controller = "Item", action = "List" });
            });

            using var scope = app.ApplicationServices.CreateScope();
            AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
            DBObjects.Initial(content);
        }
    }
}
