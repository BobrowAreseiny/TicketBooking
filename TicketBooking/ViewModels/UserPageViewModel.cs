using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class UserPageViewModel
    {
        public Client Client { get; set; }
        public Account Account { get; set; }
        public List<Ticket> GetAllTicket { get; set; }
    }
}
