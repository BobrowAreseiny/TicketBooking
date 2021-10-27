using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Repository
{
    public class TicketRepository : IConcertTicket
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TicketRepository(ApplicationDbContext applicationDbContex)
        {
            _applicationDbContext = applicationDbContex;
        }

        public IEnumerable<Ticket> Tickets { get => _applicationDbContext.Tickets.Include(c => c.Concert); set => throw new NotImplementedException(); }
    }
}
