using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    public class ConcertController : Controller
    {
        private readonly IConcertCatalog _concertCatalog;
        private readonly IConcertTicket _concertTicket;

        public ConcertController(IConcertCatalog concertCatalog, IConcertTicket concertTicket)
        {
            _concertCatalog = concertCatalog;
            _concertTicket = concertTicket;
        }    

        public ViewResult List()
        {
            ViewBag.Title = "Страница с концертами";
            ConcertListViewModel concertListViewModel = new ConcertListViewModel
            {
                GetAllConcerts = _concertCatalog.AllConcerts,
                currConcert = "Концерты"
            };
            return View(concertListViewModel);
        }

    }
}
