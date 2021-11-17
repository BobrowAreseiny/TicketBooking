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
            //if (User.Identity.IsAuthenticated)
            //{
                var AllConcert = new HomeViewModel
                {
                    concerts = _concertRepository.AllConcerts
                };
                //var a = System.Security.Claims.ClaimsIdentity.DefaultNameClaimType.;
                //Microsoft.AspNetCore.Http.HttpContext.User.Identity.Name;
                //var a = HttpContext.User.Identity.Name;
                return View(/*User.Identity.Name*/AllConcert);
            //}
            
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
