using System.Security.Claims;

namespace PresentationLayer.WebApplication.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal claims) => claims.FindFirstValue("name");
    }
}