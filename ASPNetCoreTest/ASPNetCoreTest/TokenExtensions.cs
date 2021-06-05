using Microsoft.AspNetCore.Builder;
using System.Reflection.Metadata.Ecma335;

namespace ASPNetCoreTest
{
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenMiddleware>();
        }

        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddlewareWithPattern>(pattern);
        }
    }
}