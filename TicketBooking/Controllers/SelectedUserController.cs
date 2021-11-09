using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

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
        public IActionResult Register(/*Bind[Exclude = ""]*/ AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                return View(accountViewModel);
            }
            var a = _applicationDbContext.Users.FirstOrDefault(f => f.ID == accountViewModel.Id);
            var b = _applicationDbContext.Accounts.FirstOrDefault(f => f.ID == accountViewModel.Id);
            User newUser = null;
            if (a == null && b == null)
            {
                newUser = new User()
                {
                    Name = accountViewModel.Name,
                    Surname = accountViewModel.Surname,
                    ID = accountViewModel.Id
                };
                var account = new Account()
                {
                    Login = accountViewModel.Login,
                    Password = accountViewModel.Password,
                    UserID = newUser.ID
                };
                NewUser(newUser);
                _applicationDbContext.Accounts.Add(account);
                _applicationDbContext.SaveChanges();
                a = _applicationDbContext.Users.FirstOrDefault(f => f.ID == accountViewModel.Id);
                b = _applicationDbContext.Accounts.FirstOrDefault(f => f.ID == accountViewModel.Id);

                if (a != null && b != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь уже существует.");
            }
            return View(accountViewModel);
        }

        public User NewUser(User user)
        {
            _applicationDbContext.Users.Add(user);
            return user;
        }
    }
}
