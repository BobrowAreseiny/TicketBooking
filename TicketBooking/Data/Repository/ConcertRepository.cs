using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Repository
{
    public class ConcertRepository : IConcertCatalog
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ConcertRepository(ApplicationDbContext applicationDbContex)
        {
            _applicationDbContext = applicationDbContex;
        }

        public IEnumerable<Concert> AllConcerts { get => _applicationDbContext.Concerts; }

        public Concert GetSelected(int concertID) => _applicationDbContext.Concerts.FirstOrDefault(p => p.ID == concertID);
    }
}
