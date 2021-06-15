using ASPNetCoreTest.Services;
using ASPNetCoreTest.Services.Middleware;
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
            //Transient create new after request
            //ѕерегрузки дл€ инжекта фабрики или типа реализации
            // Singleton
            // Scoped inject одинаковых типов во все параметры методов
            services.AddTransient<IMessageFormatter, EmailMessanger>();
            services.AddTransient<MessageFormatterServices>();
            services.AddTransient<TimeService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MessageFormatterServices messageSender, MessageFormatterServices messageSender2)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Inject with Use

            app.UseMiddleware<TimerMiddleware>();

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

            app.Use(async (context, next) =>
            {
                //Inject applicationServices
                ///MessageFormatterServices messageSender = app.ApplicationServices.GetService<MessageFormatterServices>();

                //Inject RequestServices 
                //если MessageFormatterServices обь€влен как Scoped, он сюда не прокинетс€!!! получим новыэ экземпл€р
                MessageFormatterServices messageSender = context.RequestServices.GetService<MessageFormatterServices>();
                //context.Response.ContentType = "text/html;charset=utf-8";
                messageSender.AddMessage("daff");
                messageSender.AddMessage("sms");
                await next.Invoke();
            });

            //app.UseMiddleware<MessageMiddleware>();
            //app.UseMiddleware<MessageMiddleware>();
            //app.UseMiddleware<MessageMiddleware>();
            //app.UseMiddleware<MessageMiddleware>();

            app.Run(async (context) =>
            {
                //≈сли будет объ€влен как Transient вернет пустую строку, в этот экземпл€р мы ничего не писали
                await context.Response.WriteAsync(messageSender2.GetResult());
            });
        }
    }
}