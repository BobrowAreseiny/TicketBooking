using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TicketBooking.Data;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;
using System.Security.Policy;
using Microsoft.AspNetCore.Http;

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
        public IActionResult Register(/*[Bind(include: "IsUserValid,ActivateCode")]*/ AccountViewModel accountViewModel)
        {
            bool status = false;
            string message = "";

            //Validation
            if (!ModelState.IsValid)
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
                //return View(accountViewModel);
            }
            else
            {
                ModelState.AddModelError("", "Пользователь уже существует.");
            }
            return View(accountViewModel);
        }

        [NonAction]
        public bool IsLoginExist(string email)
        {
            var data = _applicationDbContext.Accounts.FirstOrDefault(f => f.Login == email);
            return data != null;
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

        [NonAction]
        public void SendVerificationLinkEmail(string email, string activationCode)
        {
            var verifyUrl = "SelectedUser/VerifyAccount/" + activationCode;
            var link = Request;
            //string url = scheme + "://" + host +
        }
    }
}
