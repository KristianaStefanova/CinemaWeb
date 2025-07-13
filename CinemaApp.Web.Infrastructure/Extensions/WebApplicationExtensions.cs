using CinemaApp.Web.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder UseManagerAccessRestriction(this IApplicationBuilder app)
        {
            app.UseMiddleware<ManagerAccessRestrictionMiddleware>();

            return app;
        }
    }
}
