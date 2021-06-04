using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ASPNetCoreTest
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
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            int x = 5;
            int y = 8;
            int z = 0;

            //Use , await next.Invoke() вызывает следующие действие в цепочке
            app.Use(async (context, next) =>
            {
                z = x * y;
                await next.Invoke();
            });

            app.Use(async (context, next) =>
            {
                z = z / y;
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"x * y = {z}");
            });

            //Скомпилирует но не будет вызова, Run конец
            //app.Use(async (context, next) =>
            //{
            //    z = z / y;
            //    await next.Invoke();
            //});
        }
    }
}