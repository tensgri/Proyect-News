using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using newAdmin.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace newAdmin.Controllers
{
    public class AccountController : Controller
    {
        private string userName="admin";

        private string password = "123";

        public object CookieAuthencationDefaults { get; private set; }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(loginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (loginViewModel.userName==userName && loginViewModel.password== password) {

                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, userName));
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));

                    var identty = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                     new ClaimsPrincipal(identty),
                    new AuthenticationProperties());

                    if (Request.Query.Keys.Contains("urlRedirect")) {

                        var urlRedirect = Request.Query["urlRedirect"].ToString();
                        return Redirect(urlRedirect);

                    }

      

                    return RedirectToAction("Index", "Home");
                }
                
            }
                

            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");


        }


    }
}
