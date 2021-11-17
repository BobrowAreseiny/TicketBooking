using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
using TicketBooking.Data.Repository;
using TicketBooking.ViewModels;

namespace TicketBooking.Controllers
{
    [Authorize]
    public class CashBoxController : Controller
    {
        private readonly IConcertCatalog _concertRepository;
        private readonly CashBox _cashBox;

        public CashBoxController(IConcertCatalog concertRepository, CashBox cashBox)
        {
            _concertRepository = concertRepository;
            _cashBox = cashBox;
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            var items = _cashBox.GetTickets();
            _cashBox.tickets = items;

            var obj = new CashBoxViewModel
            {
                cashBox = _cashBox
            };
            return View(obj);
        }



        //[AllowAnonymous]
        public RedirectToActionResult addToCashBox(int ID)
        {
            var item = _concertRepository.AllConcerts.FirstOrDefault(c => c.ID == ID);
            if(item != null)
            {
                _cashBox.AddToCashBox(item, User.Identity.Name);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public RedirectToActionResult DelFromCashBox(int ID)
        {
            var items = _cashBox.GetTickets().Where(p => p.ID == ID);
            if (items != null)
            {
                _cashBox.DelFromCashBox(items);
            }
            return RedirectToAction("Index");
        }
    }
}
