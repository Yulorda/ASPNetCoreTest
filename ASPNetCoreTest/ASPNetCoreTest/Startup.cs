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
            //Inject
            services.AddTransient<IMessageFormatter, EmailMessanger>();
            services.AddSingleton<MessageFormatterServices>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageFormatterServices messageSender)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Inject with Use


            app.Use(async (context,next) =>
            {
                //Inject applicationServices
                //MessageFormatterServices messageSender = app.ApplicationServices.GetService<MessageFormatterServices>();

                //Inject RequestServices 
                //MessageFormatterServices messageSender = context.RequestServices.GetService<MessageFormatterServices>();
                //context.Response.ContentType = "text/html;charset=utf-8";
                messageSender.AddMessage("daff");
                messageSender.AddMessage("sms");
                await next.Invoke();
            });

            app.UseMiddleware<MessageMiddleware>();
        }
    }
}