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

        public async Task InvokeAsync(HttpContext context, TimeService timeService)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
        }
    }
}
