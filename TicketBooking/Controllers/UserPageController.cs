using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    [Authorize]
    public class UserPageController : Controller
    {
        private readonly IUserPage _userPage;

        public UserPageController(IUserPage userPage)
        {
            _userPage = userPage;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Account account = await _userPage.GetUserAccountAsync(User.Identity.Name);

            Client client = await _userPage.GetClientAsync(account.UserID);

            UserPageViewModel userPageViewModel = new UserPageViewModel
            {
                Account = account,
                Client = client,
                GetAllTicket = await _userPage.GetClientTiketAsync(account)
            };

            return View(userPageViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeInfo()
        {
            Account account = await _userPage.GetUserAccountAsync(User.Identity.Name);

            Client client = await _userPage.GetClientAsync(account.UserID);

            UserPageViewModel userPageViewModel = new UserPageViewModel
            {
                Account = account,
                Client = client,
            };

            userPageViewModel.Account.Password = Crypto.Hash(userPageViewModel.Account.Password);

            return View(userPageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeInfo(UserPageViewModel userPageViewModel)
        {
            await _userPage.ChangeClientData(userPageViewModel.Client);

            await _userPage.ChangeAccountData(userPageViewModel.Account);

            return RedirectToAction("Index");
        }
    }
}
