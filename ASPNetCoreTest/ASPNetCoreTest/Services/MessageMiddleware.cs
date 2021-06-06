using ASPNetCoreTest.Services;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ASPNetCoreTest
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate next;

        public MessageMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, MessageFormatterServices messageSender)
        {
            context.Response.ContentType = "text/html;charset=utf-8";
            messageSender.AddMessage("daff");
            messageSender.AddMessage("sms34");
            await next.Invoke(context);
        }
    }
}