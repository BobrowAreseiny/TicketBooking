using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly IAllOrders AllOrders;
        private readonly CashBox cashBox;

        public TicketController(IAllOrders AllOrders, CashBox cashBox)
        {
            this.AllOrders = AllOrders;
            this.cashBox = cashBox;
        }

        public IActionResult Checkout()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Checkout(Ticket ticket)
        {
            cashBox.tickets = cashBox.GetTickets();
            if(cashBox.tickets.Count == 0)
            {
                ModelState.AddModelError("","Добавте товары!");
            }
            if (ModelState.IsValid)
            {
                AllOrders.CreateOrder(ticket);
                return RedirectToAction("Complete");
            }
            return View();
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
