using Microsoft.AspNetCore.Builder;
using TheList.TechnicalChallenge.Middlewares;

namespace TheList.TechnicalChallenge.Controllers
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder ConfigureGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
