using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Concert> concerts { get; set; }
    }
}
