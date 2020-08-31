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
        public IActionResult Info()
        {
            var claimsInfo = User.Claims.Select(x => new
            {
                Key = x.Type,
                Value = x.Value
            });

            return Ok(claimsInfo);
        }
    }
}