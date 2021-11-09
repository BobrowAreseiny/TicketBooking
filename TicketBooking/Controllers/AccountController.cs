﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TicketBooking.Data;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public AccountController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                var a = _applicationDbContext.Users.FirstOrDefault(f => f.ID == accountViewModel.Id);
                var b = _applicationDbContext.Accounts.FirstOrDefault(f => f.ID == accountViewModel.Id);
                User newUser = null;
                if (a == null && b == null)
                {
                    _applicationDbContext.Users.Add(new User()
                    {
                        Name = accountViewModel.Name,
                        Surname = accountViewModel.Surname,
                        ID = accountViewModel.Id
                    });
                    _applicationDbContext.Accounts.Add(new Account()
                    {
                        Login = accountViewModel.Login,
                        Password = accountViewModel.Password,
                        UserID = newUser.ID
                    });
                    _applicationDbContext.SaveChanges();
                    a = _applicationDbContext.Users.FirstOrDefault(f => f.ID == accountViewModel.Id);
                    b = _applicationDbContext.Accounts.FirstOrDefault(f => f.ID == accountViewModel.Id);

                    if (a != null && b != null)
                    {
                        //Session["userId"] = 
                        //FormsAuthentication.SetAuthCockie(accountViewModel.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь уже существует.");
                }
            }
            return View(accountViewModel);
        }      
    }
}
