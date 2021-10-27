using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Interfaces
{
    public interface IConcertTicket
    {
        IEnumerable<Ticket> Tickets { get; set; }
    }
}
