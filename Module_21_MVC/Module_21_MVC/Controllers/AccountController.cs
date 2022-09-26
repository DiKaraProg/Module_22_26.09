using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module_21_MVC.Service.Interfaces;
using Module_21_MVC_Domain.ViewModels.Account;
using System.Security.Claims;

namespace Module_21_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register() => View();


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response =await accountService.Register(model);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));
                return RedirectToAction("GetWorkers","Worker");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await accountService.Login(model);
                if (response.StatuseCode == Module_21_MVC_Domain.Unum.StatusCode.OK)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(response.Data));
                    return RedirectToAction("GetWorkers", "Worker");
                }
                ModelState.AddModelError("", response.Description);
              
            }

            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GetWorkers", "Worker");
        }
    }
}
