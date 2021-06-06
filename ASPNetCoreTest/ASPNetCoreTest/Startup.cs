using ASPNetCoreTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text;

namespace ASPNetCoreTest
{
    public partial class Startup
    {
        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageFormatter, EmailMessanger>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMessageFormatter messageSender)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.Run(async (context) =>
            {
                messageSender.Add("daff");
                messageSender.Add("sms");
                await context.Response.WriteAsync(messageSender.GetResult());
            });
        }
    }
}