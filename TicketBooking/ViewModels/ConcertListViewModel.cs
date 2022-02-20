using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class ConcertListViewModel
    {
        public string currConcert { get; set; }

        public IEnumerable<Concert> GetAllConcerts { get; set; }
    }
}
