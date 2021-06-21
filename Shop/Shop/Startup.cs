using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAllItems,MockItems>();
            services.AddTransient<IItemsCategory, MockCategory>();//объединение интерфейса и класса который он реализует
            services.AddMvcCore(options => options.EnableEndpointRouting = false).AddRazorViewEngine();
            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();    //отображение страницы с ошибками
            app.UseStatusCodePages();   //отображение кода страницы
            app.UseStaticFiles();   //отображение css файлов, картинок и тд
            app.UseMvcWithDefaultRoute();   //вызов контроллера по умолчанию Home
        }
    }
}
