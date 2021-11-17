using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    [Authorize]
    public class UserPageController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserPageController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index(UserPageViewModel userPageViewModel)
        {
            var account = _applicationDbContext.Accounts.Where(p => p.Login == User.Identity.Name).FirstOrDefault();
            
            var user = _applicationDbContext.Users.Where(p => p.ID == account.UserID).FirstOrDefault();

            var ticket = _applicationDbContext.Tickets.Where(p => p.AccountID == account.ID).ToList();

            userPageViewModel.Client = user;
            userPageViewModel.Account = account;
            userPageViewModel.GetAllTicket = ticket;
            return View(userPageViewModel);
        }
    }
}
