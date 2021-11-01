using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Controllers
{
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

    }
}
