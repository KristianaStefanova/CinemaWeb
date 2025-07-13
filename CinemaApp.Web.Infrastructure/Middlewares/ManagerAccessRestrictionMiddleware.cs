using CinemaApp.Services.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.GCommon.ApplicationConstants;


namespace CinemaApp.Web.Infrastructure.Middlewares
{
    public class ManagerAccessRestrictionMiddleware
    {
        private const int HttpForbiddenStatusCode = 403;
        private readonly RequestDelegate next;

        public ManagerAccessRestrictionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context, IManagerService managerService)
        {
            if(!(context.User.Identity?.IsAuthenticated ?? false))
            {
                bool managerCookieExistes = context
                   .Request
                   .Cookies
                   .ContainsKey(ManagerAuthCookie);
                if (managerCookieExistes)
                {
                    context.Response.Cookies.Delete(ManagerAuthCookie);
                }
            }
            
            string requestPath = context.Request.Path.ToString().ToLower();
            if (requestPath.StartsWith("/manager"))
            {
                if (!(context.User.Identity?.IsAuthenticated ?? false))
                {
                    context.Response.StatusCode = HttpForbiddenStatusCode;
                    return;
                }

                bool cookieValueObtained = context
                    .Request
                    .Cookies
                    .TryGetValue(ManagerAuthCookie, out string cookieValue);


                if (!cookieValueObtained)
                {
                    string? userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

                    bool isAuthUserManager = await managerService
                        .ExistsByUserIdAsync(userId);

                    if (!isAuthUserManager)
                    {
                        context.Response.StatusCode = HttpForbiddenStatusCode;
                        return;
                    }
                    await this.AppendManagerAuthCookie(context, userId!);
                }
                else
                {
                    string? userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if(userId == null)
                    {
                        context.Response.StatusCode = HttpForbiddenStatusCode;
                        return;
                    }

                    string hashedUserId = await this.Sha512OverString(userId);

                    if(hashedUserId.ToLower() != cookieValue.ToLower())
                    {
                        context.Response.StatusCode = HttpForbiddenStatusCode;
                        return;
                    }
                }
            }

            await this.next(context);
        }

        private async Task AppendManagerAuthCookie(HttpContext context, string userId)
        {
            CookieBuilder cookieBuilder = new CookieBuilder
            {
                Name = ManagerAuthCookie,
                SameSite = SameSiteMode.Strict,
                HttpOnly = true,
                SecurePolicy = CookieSecurePolicy.SameAsRequest,
                MaxAge = TimeSpan.FromHours(4),
            };

            CookieOptions cookieOptions = cookieBuilder.Build(context);
            string hashedUserId =  await this
                .Sha512OverString(userId);

            context.Response.Cookies.Append(ManagerAuthCookie, hashedUserId, cookieOptions);
        }

        private async Task<string> Sha512OverString(string userId)
        {
            using SHA512 sha512Manager = SHA512.Create();

            byte[] sha512HashBytes = await sha512Manager
                 .ComputeHashAsync(new MemoryStream(Encoding.UTF8.GetBytes(userId)));

            string hashedString = BitConverter
                .ToString(sha512HashBytes)
                .Replace("-", "")
                .Trim()
                .ToLower();

            return hashedString;
        }
    }
}
