using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using TicketBooking.Data;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;
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
        public IActionResult Register(/*[Bind (Exclude =  "IsUserValid,ActivateCode")]*/ AccountViewModel accountViewModel)
        {
            bool status = false;
            string message = "";

            //Validation
            if (ModelState.IsValid)
            {
                var loginIsExist = IsLoginExist(accountViewModel.Login);
                if (loginIsExist)
                {
                    ModelState.AddModelError("LoginExist", "Логин занят");
                }
                //Activate Code
                accountViewModel.ActivateCode = Guid.NewGuid();
                //Hash
                accountViewModel.Password = Crypto.Hash(accountViewModel.Password);
                //accountViewModel.ConfirmPassword = Crypto.Hash(accountViewModel.ConfirmPassword);

                accountViewModel.IsUserConfirm = false;

                //Save in database
                var user = new User()
                {
                    Name = accountViewModel.Name,
                    Surname = accountViewModel.Surname
                };

                _applicationDbContext.Users.Add(user);
                _applicationDbContext.SaveChanges();
                var account = new Account()
                {
                    Login = accountViewModel.Login,
                    Password = accountViewModel.Password,
                    ActivateCode = accountViewModel.ActivateCode,
                    IsUserValid = accountViewModel.IsUserConfirm,
                    UserID = user.ID
                };
                _applicationDbContext.Accounts.Add(account);
                _applicationDbContext.SaveChanges();

                //SendVerificationLinkEmail(accountViewModel.Login, accountViewModel.ActivateCode.ToString());
                message = "Аккаунт создан. Необходимо зайти на почту" + accountViewModel.Login;
                status = true;
                //return View(accountViewModel);
            }
            else
            {
                ModelState.AddModelError("", "Пользователь уже существует.");
            }
            ViewBag.Message = message;
            ViewBag.Status = status;
            return View(accountViewModel);
        }

        [NonAction]
        public bool IsLoginExist(string email)
        {
            var data = _applicationDbContext.Accounts.FirstOrDefault(f => f.Login == email);
            return data != null;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string email, string activationCode)
        {
            //Request.Uri ???
            Uri url = null;
            var verifyUrl = "/SelectedUser/VerifyAccount/" + activationCode;
            var link = url.AbsoluteUri.Replace(url.PathAndQuery, verifyUrl);
            var fromEmail = new MailAddress("Frukt9809@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(email);
            var fromEmailPassword = "a225119283A";
            string subject = "Your account is successfully created!";

            string body = "<br/><br/>Не забыть вставить текст.<br/> <a href='" + link + "'>" + link + "</a>";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            smtp.Send(message);
        }
       
        [HttpGet]
        public IActionResult VerifyAccount(string id)
        {
            bool status = false;
            var v = _applicationDbContext.Accounts.Where(a => a.ActivateCode == new Guid(id)).FirstOrDefault();
            if (v != null)
            {
                v.IsUserValid = true;
                _applicationDbContext.SaveChanges();
                status = true;
            }
            else
            {
                ViewBag.Message = "Ошибка запроса";
            }
            ViewBag.Status = status;
            return View();
        }
    }
}
