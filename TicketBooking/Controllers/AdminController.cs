using Microsoft.AspNetCore.Mvc;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    public class AdminController : Controller
    {
        private readonly IConcertService _concertService;

        public AdminController(IConcertService concertService)
        {
            _concertService = concertService;
        }

        public ActionResult Index()
        {
            var concert = _concertService.GetConcert();
            return View(concert);
        }

        //public ActionResult AddConcert()
        //{
        //    var conNew = new ConcertViewModel
        //    {
        //         Title="Добавить новый кноцерт",
        //         AddButtonTitle ="Добавить",
        //         RedirectUrl = Url.Action("Index", "Concert")
        //    };
        //    return View(conNew);
        //}
        [HttpGet]
        public ActionResult AddConcert()
        {
            var conNew = new ConcertViewModel
            {
                Title = "Добавить новый кноцерт",
                AddButtonTitle = "Добавить",
                RedirectUrl = Url.Action("Index", "Concert")
            };
            return View(conNew);
        }
        [HttpPost]
        public ActionResult AddConcert(ConcertViewModel concertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var concert = new Concert()
            {
                ID = concertViewModel.Id,
                ExectorName = concertViewModel.ExectorName,
                CountOfTicket = concertViewModel.CountOfTicket,
                DateOfConcert = concertViewModel.DateOfConcert,
                Price = concertViewModel.Price,
                Img = concertViewModel.Img,
                LocationOfConcert = concertViewModel.LocationOfConcert,
                TypeOfConcertID = concertViewModel.TypeOfConcertID
            };

            _concertService.AddConcert(concert);
            return RedirectToAction("Index");
        }
        public ActionResult DetailsOfConcert(int id)
        {
            var concert = _concertService.GetSelectedConcert(id);
            return View(new ConcertViewModel
            {
                Id = concert.ID,
                ExectorName = concert.ExectorName,
                CountOfTicket = concert.CountOfTicket,
                DateOfConcert = concert.DateOfConcert,
                Price = concert.Price,
                Img = concert.Img,
                LocationOfConcert = concert.LocationOfConcert
            });
        }


        [HttpGet]
        public ActionResult SaveConcert(int id/*, string redirectUrl*/)
        {
            var concert = _concertService.GetSelectedConcert(id);
            return View(concert);
        }

        [HttpPost]
        public ActionResult SaveConcert(ConcertViewModel concertViewModel/*, string redirectUrl*/)
        {
            if (!ModelState.IsValid)
            {
                return View(concertViewModel);
            }
            var concert = _concertService.GetSelectedConcert(concertViewModel.Id);
            if (concert != null)
            {
                concert.ID = concertViewModel.Id;
                concert.LocationOfConcert = concertViewModel.LocationOfConcert;
                concert.ExectorName = concertViewModel.ExectorName;
                concert.CountOfTicket = concertViewModel.CountOfTicket;
                concert.DateOfConcert = concertViewModel.DateOfConcert;
                concert.Price = concertViewModel.Price;
                concert.Img = concertViewModel.Img;
                _concertService.UpdateConcert(concert);
            }
            return RedirectToAction("Index");
            //return RedirectToLocation(redirectUrl);
        }

        [HttpGet]
        public ActionResult EditConcert(int id)
        {
            var concert = _concertService.GetSelectedConcert(id);
            ConcertViewModel concertViewModel = new ConcertViewModel
            {
                Id = concert.ID,
                ExectorName = concert.ExectorName,
                CountOfTicket = concert.CountOfTicket,
                DateOfConcert = concert.DateOfConcert,
                Price = concert.Price,
                Img = concert.Img,
                LocationOfConcert = concert.LocationOfConcert
            };
            return View(concertViewModel);
        }
        [HttpPost]
        public ActionResult EditConcert(ConcertViewModel concertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(concertViewModel);
            }
            var concert = _concertService.GetSelectedConcert(concertViewModel.Id);
            if (concert != null)
            {
                concert.ID = concertViewModel.Id;
                concert.LocationOfConcert = concertViewModel.LocationOfConcert;
                concert.ExectorName = concertViewModel.ExectorName;
                concert.CountOfTicket = concertViewModel.CountOfTicket;
                concert.DateOfConcert = concertViewModel.DateOfConcert;
                concert.Price = concertViewModel.Price;
                concert.Img = concertViewModel.Img;
                _concertService.UpdateConcert(concert);
            }
            return RedirectToAction("Index");
        }


        public ActionResult DeleteConcert(int id)
        {
            _concertService.DeleteConcert(id);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public ActionResult AddNewConcert(ConcertViewModel concertViewModel, string redirectUrl)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var concert = new Concert()
        //    {
        //        ID = concertViewModel.Id,
        //        ExectorName = concertViewModel.ExectorName,
        //        CountOfTicket = concertViewModel.CountOfTicket,
        //        DateOfConcert = concertViewModel.DateOfConcert,
        //        Price = concertViewModel.Price,
        //        Img = concertViewModel.Img,
        //        LocationOfConcert = concertViewModel.LocationOfConcert
        //    };
        //    return RedirectToLocation(redirectUrl);
        //}

        //private ActionResult RedirectToLocation(string redirectUrl)
        //{
        //    if (Url.IsLocalUrl(redirectUrl))
        //    {
        //        return Redirect(redirectUrl);
        //    }
        //    return RedirectToAction("Index", "Concert");
        //}






        //public async Task<ActionResult> Index()
        //{
        //    var concert = _concertService.GetConcertAsync();
        //    return View(concert);
        //}

        //public ActionResult AddConcert()
        //{
        //    return View();
        //}

        //public ActionResult EditConcert()
        //{
        //    return View();
        //}

        //public ActionResult DeleteConcert()
        //{
        //    return RedirectToAction("Index");
        //}
    }
}
