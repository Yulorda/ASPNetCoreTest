using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreTest
{
    //Почему не используется интерфейс
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        //Ctor RequestDelegate next
        public TokenMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        //Invoke/ InvoketAsync возвращать Task принимать HttpContext
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token.Contains("1234"))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}