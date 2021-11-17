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
//using System.Web.Mvc;

namespace TicketBooking.Controllers
{
    public class SelectedUserController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SelectedUserController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
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
            //Validation
            if (ModelState.IsValid)
            {
                var loginIsExist = IsLoginExist(accountViewModel.Login);
                if (loginIsExist)
                {
                    ModelState.AddModelError("LoginExist", "Логин занят");
                }
                //Activate Code
                //accountViewModel.ActivateCode = Guid.NewGuid();
                //Hash
                accountViewModel.Password = Crypto.Hash(accountViewModel.Password);
                accountViewModel.ConfirmPassword = Crypto.Hash(accountViewModel.ConfirmPassword);
                List<Role> role = _applicationDbContext.Roles.ToList();
                accountViewModel.Role = role.Last();
                var user = new Client()
                {
                    Name = accountViewModel.Name,
                    Surname = accountViewModel.Surname,
                    DateOfBirth = accountViewModel.DateOfBirth,                    
                };
                _applicationDbContext.Users.Add(user);
                await _applicationDbContext.SaveChangesAsync();


                var account = new Account()
                {
                    Login = accountViewModel.Login,
                    Password = accountViewModel.Password,                    
                    UserID = user.ID,
                    RoleId = 2,
                    Role = accountViewModel.Role

                    /*accountViewModel.Role.Id*/,                    
                };
                _applicationDbContext.Accounts.Add(account);
                await _applicationDbContext.SaveChangesAsync();

                //SendVerificationLinkEmail(accountViewModel.Login, accountViewModel.ActivateCode.ToString());
                
                await Authenticate(accountViewModel.Login, accountViewModel.Role); // аутентификация
                await _applicationDbContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Пользователь уже существует.");
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
        public async Task<IActionResult> Login(AccountViewModel Userlogin)
        {
            //if (ModelState.IsValid)
            //{
            //string message = "";
            var user = _applicationDbContext.Accounts.Where(p => p.Login == Userlogin.Login && p.Password == Crypto.Hash(Userlogin.Password)).FirstOrDefault();
            user.Role = _applicationDbContext.Roles.Where(p => p.Id == user.RoleId).FirstOrDefault();// ???????
            if (user != null)
            {
                //if (string.Compare(Crypto.Hash(Userlogin.Password), user.Password) == 0)
                //{
                //int timeout = Userlogin.RememberMe ? 525600 : 20; // 525600 min = 1  year
                //var ticket = new FormsAuthenticationTicket(Userlogin.Login, Userlogin.RememberMe, timeout);
                //string encrypted = FormsAuthentication.Encrypt(ticket);
                //var cookie = new HttpCookie(FormsAuthentication.FormsCookingName, encrypted);
                //cookie.Expires = DateTime.Now.AddMinutes(timeout);
                //cookie.HttpOnly = true;
                //Response.Cookies.Add(cookie);
                //}
                //else
                //{
                //    message = "Ошибка входа";
                //}
                
                await Authenticate(user.Login, user.Role); // аутентификация
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            //}
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task Authenticate(string Login, Role Role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Role?.Name)
                //new Claim(ClaimTypes.Locality, client.Name),
                //new Claim("company", client.Surname)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [NonAction]
        public bool IsLoginExist(string email)
        {
            var data = _applicationDbContext.Accounts.FirstOrDefault(f => f.Login == email);
            return data != null;
        }

        //[NonAction]
        //public void SendVerificationLinkEmail(string email, string activationCode)
        //{
        //    //Request.Uri ???
        //    //var f = new Uri(Request.Url, Request.ApplicationPath);
        //    //var a= HttpContext.Current.Request.Url.AbsoluteUri;
          
        //    Uri url = new Uri("https://localhost:44309/SelectedUser/Register");
        //    //var verifyUrl = "/SelectedUser/VerifyAccount/" + activationCode;
        //    var verifyUrl = "/SelectedUser/Register/" + activationCode;
        //    var link = url.AbsoluteUri.Replace(url.PathAndQuery, verifyUrl);
        //    var fromEmail = new MailAddress("Frukt9809@gmail.com", "Dotnet Awesome");
        //    var toEmail = new MailAddress(email);
        //    var fromEmailPassword = "a225119283A";
        //    string subject = "Your account is successfully created!";

        //    string body = "<br/><br/>Не забыть вставить текст.<br/> <a href='" + link + "'>" + link + "</a>";
        //    //var smtp = new SmtpClient
        //    //{
        //    //    Host = "smtp.gmail.com",
        //    //    Port = 587,
        //    //    EnableSsl = true,
        //    //    DeliveryMethod = SmtpDeliveryMethod.Network,
        //    //    UseDefaultCredentials = false,
        //    //    Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
        //    //};

        //    //using var message = new MailMessage(fromEmail, toEmail)
        //    //{
        //    //    Subject = subject,
        //    //    Body = body,
        //    //    IsBodyHtml = true
        //    //};
        //    //smtp.Send(message);
            

        //    using MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress(fromEmail.Address);
        //    mail.To.Add(toEmail);
        //    mail.Subject = subject;
        //    mail.Body = body;
        //    mail.IsBodyHtml = true;
        //    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

        //    using SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
        //    smtp.Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword);
        //    smtp.EnableSsl = true;
        //    smtp.Send(mail);
        //}
       
        //[HttpGet]
        //public IActionResult VerifyAccount(string id)
        //{
        //    bool status = false;
        //    var v = _applicationDbContext.Accounts.Where(a => a.ActivateCode == new Guid(id)).FirstOrDefault();
        //    if (v != null)
        //    {
        //        v.IsUserValid = true;
        //        _applicationDbContext.SaveChanges();
        //        status = true;
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Ошибка запроса";
        //    }
        //    ViewBag.Status = status;
        //    return View();
        //}
    }
}
