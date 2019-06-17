using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return new ChallengeResult(ChallengeScheme.OpenIdConnect, new AuthenticationProperties
            {
                RedirectUri = "Advert/Index"
            });
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            //SignOut(new AuthenticationProperties
            //{
            //    RedirectUri = string.Empty
            //}, "oidc", "Cookies");


            await HttpContext.SignOutAsync(ChallengeScheme.OpenIdConnect);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Advert");
        }
    }
}