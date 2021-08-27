using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Cebulit.API.Core.Extensions
{
    public static class HttpContextExtensions
    {
        public static int? GetUserId(this HttpContext context)
        {
            var value = context.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return value != null ? int.Parse(value) : null;
        }

        public static string GetUserLogin(this HttpContext context)
        {
            return context.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
        }
    }
}