using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Mocks
{
    public class MockTickets : IConcertTicket
    {
        private readonly IConcertCatalog _concertCatalog;
        public IEnumerable<Ticket> Tickets
        {
            get
            {
                return new List<Ticket>
                {
                    new Ticket { Concert = _concertCatalog.AllConcerts.First() },
                    new Ticket { Concert = _concertCatalog.AllConcerts.Last() }
                };
            } set => throw new NotImplementedException(); }
        }
    }
