using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Interfaces
{
    public interface IConcertCatalog
    {
        IEnumerable<Concert> AllConcerts { get; }

        Concert GetSelected(int concertID);
    }
}
