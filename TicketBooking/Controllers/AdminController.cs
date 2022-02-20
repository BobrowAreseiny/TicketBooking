using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _concertService;

        public AdminController(IAdminRepository concertService)
        {
            _concertService = concertService;
        }

        public async Task<ActionResult> Index()
        {
            var concert = await _concertService.GetConcertsAsync();

            return View(concert);
        }

        [HttpGet]
        public ActionResult AddDescription()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddDescription(ConcertDescriptionViewModel description)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var typeOfConcert = new TypeOfConcert()
            {
                ID = description.ID,
                Composer = description.Composer,
                AgeLimit = description.AgeLimit,
                Healiner = description.Healiner,
                NameOfConcert = description.NameOfConcert,
                TypeOfThisConcert = description.TypeOfThisConcert,
                TypeOfVoice = description.TypeOfVoice,
                Way = description.Way
            };
            await _concertService.AddDescriptionConcertAsync(typeOfConcert);
            return RedirectToAction("AddDescription");
        }


        [HttpGet]
        public ActionResult AddConcert()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddConcert(ConcertViewModel concertViewModel)
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
            await _concertService.AddConcertAsync(concert);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> EditConcert(int id)
        {
            var concert = await _concertService.GetSelectedConcertAsync(id);
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
        public async Task<ActionResult> EditConcert(ConcertViewModel concertViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(concertViewModel);
            }
            var concert = await _concertService.GetSelectedConcertAsync(concertViewModel.Id);
            if (concert != null)
            {
                concert.ID = concertViewModel.Id;
                concert.LocationOfConcert = concertViewModel.LocationOfConcert;
                concert.ExectorName = concertViewModel.ExectorName;
                concert.CountOfTicket = concertViewModel.CountOfTicket;
                concert.DateOfConcert = concertViewModel.DateOfConcert;
                concert.Price = concertViewModel.Price;
                concert.Img = concertViewModel.Img;
                await _concertService.UpdateConcertAsync(concert);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DetailsOfConcert(int id)
        {
            var concert = await _concertService.GetSelectedConcertAsync(id);
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

        public async Task<ActionResult> DeleteConcert(int id)
        {
            await _concertService.DeleteConcertAsync(id);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task<ActionResult> SaveConcert(int id)
        //{
        //    var concert = await _concertService.GetSelectedConcertAsync(id);
        //    return View(concert);
        //}
        //[HttpPost]
        //public async Task<ActionResult> SaveConcert(ConcertViewModel concertViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(concertViewModel);
        //    }
        //    var concert = await _concertService.GetSelectedConcertAsync(concertViewModel.Id);
        //    if (concert != null)
        //    {
        //        concert.ID = concertViewModel.Id;
        //        concert.LocationOfConcert = concertViewModel.LocationOfConcert;
        //        concert.ExectorName = concertViewModel.ExectorName;
        //        concert.CountOfTicket = concertViewModel.CountOfTicket;
        //        concert.DateOfConcert = concertViewModel.DateOfConcert;
        //        concert.Price = concertViewModel.Price;
        //        concert.Img = concertViewModel.Img;
        //        await _concertService.UpdateConcertAsync(concert);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}
