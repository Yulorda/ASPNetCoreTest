using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ASPNetCoreTest
{
    public partial class Startup
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //IWebHostEnvironment можно добавить к методу конфиг еще один параметр
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(); // обрабатывает все запросы к root папке (может быть переназначена в программ)
            app.UseStaticFiles(new StaticFileOptions() // обрабатывает запросы к каталогу wwwroot/html
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\html")),
                //к файлам в папке wwwroot\html можно обратиться по директории /pages/filename.html
                RequestPath = new PathString("/pages")
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
            });
        }
    }
}