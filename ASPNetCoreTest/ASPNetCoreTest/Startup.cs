using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
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
            //services.AddRazorPages();
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 44344;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //IWebHostEnvironment ����� �������� � ������ ������ ��� ���� ��������
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //����� ��������, ��� ����� UseHsts ����������, ���� ������ ���������� ��� ���������� ��� ������������ �������������,
                //������ ��� � �������� ���������� ������������� ������� ������ ����� ��������� ����������, ��� ��� ��������� ����������.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.Run(async (context) =>  
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}