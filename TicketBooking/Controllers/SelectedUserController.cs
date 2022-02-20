using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using TicketBooking.Data;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using TicketBooking.Data.Interfaces;
using Microsoft.AspNetCore.Http;
//using System.Web.Mvc;

namespace TicketBooking.Controllers
{
    public class SelectedUserController : Controller
    {
        private readonly IAutorisation _autorisation;

        public SelectedUserController(IAutorisation autorisation)
        {
            _autorisation = autorisation;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await IsLoginExist(accountViewModel.Login))
                {
                    ModelState.AddModelError("Login", "Почта занята");
                }
                else
                {
                    accountViewModel.Role = await _autorisation.RegistrateAccountAsync(accountViewModel); 
                    
                    await Authenticate(accountViewModel.Login, accountViewModel.Role);
                    string a = Request.Headers["Referer"].ToString();

                    return Redirect(Request.Headers["Referer"].ToString());
                }
            }                
            return View(accountViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (user != null)
                {
                    user.Role = await _autorisation.LoginAsync(user);

                    await Authenticate(user.Login, user.Role);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        [NonAction]
        private async Task Authenticate(string Login, Role Role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [NonAction]
        public async Task<bool> IsLoginExist(string email)
        {
            return await _autorisation.IsLoginExist(email); 
        }

        [NonAction]
        public async Task<Role> UserRole(Account account)
        {
            return await _autorisation.UserRole(account);
        }
    }
}
