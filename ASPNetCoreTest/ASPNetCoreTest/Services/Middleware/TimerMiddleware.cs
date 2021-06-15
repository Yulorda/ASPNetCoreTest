using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ASPNetCoreTest.Services.Middleware
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate _next;
        TimeService _timeService;

        public TimerMiddleware(RequestDelegate next, TimeService timeService)
        {
            _next = next;
            _timeService = timeService;
        }

        //Singltone
        //public async Task InvokeAsync(HttpContext context)
        //{
        //    if (context.Request.Path.Value.ToLower() == "/time")
        //    {
        //        context.Response.ContentType = "text/html; charset=utf-8";
        //        await context.Response.WriteAsync($"Текущее время: {_timeService?.Time}");
        //    }
        //    else
        //    {
        //        await _next.Invoke(context);
        //    }
        //}

        //Scoped / Transient
        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            if (context.Request.Path.Value.ToLower() == "/time")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.Time}");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}
