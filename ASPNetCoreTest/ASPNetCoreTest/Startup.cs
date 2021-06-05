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
        //IWebHostEnvironment ����� �������� � ������ ������ ��� ���� ��������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async (context) =>
            {
                //��������� HTTP ���������, ��� ������������ ����������� ������ �������� �� ��������
                context.Response.Headers["Content-Type"] = "text/html; charset=utf-8";

                // ���������� ���� ��� � launchSettings
                if (env.IsEnvironment("Test")) // ���� ������ � ��������� "Test"
                {
                    await context.Response.WriteAsync("� ��������� ������������");
                }
                else
                {
                    await context.Response.WriteAsync("� �������� ���������� ��� � ����������");
                }
            });
        }
    }
}