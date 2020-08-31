using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ShareCookie.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> Login()
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, "chen2584"));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, "Chen"));
            identity.AddClaim(new Claim(ClaimTypes.Surname, "Semapat"));

            identity.AddClaim(new Claim(ClaimTypes.Role, "Administrator"));

            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddMinutes(30)
            };
            await HttpContext.SignInAsync("Identity.Application", principal, properties);

            return Ok();
        }

        public IActionResult Info()
        {
            var claimsInfo = User.Claims.Select(x => new
            {
                Key = x.Type,
                Value = x.Value
            });

            return Ok(claimsInfo);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}