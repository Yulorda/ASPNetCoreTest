using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async (context) =>
            {
                //Изменение HTTP заголовка, для последующего корректного вывода символов на страницу
                context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";

                // Добавилили этот тэг в launchSettings
                if (env.IsEnvironment("Test")) // Если проект в состоянии "Test"
                {
                    await context.Response.WriteAsync("В состоянии тестирования");
                }
                else
                {
                    await context.Response.WriteAsync("В процессе разработки или в продакшене");
                }
            });
        }
    }
}