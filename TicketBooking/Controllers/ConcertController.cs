using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
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

        [Route("Concert/List")]
        [Route("Concert/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Concert> concerts = null;
            string concertCategory = "";
            ConcertListViewModel ConcertObject = null;
            if (string.IsNullOrEmpty(category))
            {
                concerts = _concertCatalog.AllConcerts.OrderBy(i => i.ID);
            }
            else
            {
                if (string.Equals("Openair", category, StringComparison.OrdinalIgnoreCase))
                {
                    concerts = _concertCatalog.AllConcerts.Where(p => p.TypeOfConcert.TypeOfThisConcert.Equals("Опэнэйр")).OrderBy(i => i.ID);
                }
                else if (string.Equals("Party", category, StringComparison.OrdinalIgnoreCase))
                {
                    concerts = _concertCatalog.AllConcerts.Where(p => p.TypeOfConcert.TypeOfThisConcert.Equals("Вечеринка")).OrderBy(i => i.ID);
                }
                concertCategory = _category;


                //ViewBag.Title = "Страница с концертами";
                //ConcertListViewModel concertListViewModel = new ConcertListViewModel
                //{
                //    GetAllConcerts = _concertCatalog.AllConcerts,
                //    currConcert = "Концерты"
                //};

            }
            ConcertObject = new ConcertListViewModel
            {
                currConcert = concertCategory,
                GetAllConcerts = concerts
            };
            ViewBag.Title = "Страница с концертами";
            return View(/*concertListViewModel*/ConcertObject);
        }
    }
}
