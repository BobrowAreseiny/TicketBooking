using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketBooking.Data.Interfaces;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    [Authorize(Roles = "Пользователь, Администратор")]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IConcertCatalog _concertRepository;

        public HomeController(IConcertCatalog concertRepository)
        {
            _concertRepository = concertRepository;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var AllConcert = new HomeViewModel
            {
                concerts = _concertRepository.AllConcerts
            };
            return View(AllConcert);
        }
    }
}
