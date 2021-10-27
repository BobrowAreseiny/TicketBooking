using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Mocks
{
    public class MockCatalogConcert : IConcertCatalog
    {
        public IEnumerable<Concert> AllConcerts { 
            get 
            {
                return new List<Concert>
                {
                   new Concert{ DateOfConcert=new DateTime(2021,10,01), ExectorName="acs", CountOfTicket=100, LocationOfConcert="Минск", Price =40, Img="/img/serd.png"},
                   new Concert{ DateOfConcert=new DateTime(2020,10,01), ExectorName="ZXC", CountOfTicket=10000, LocationOfConcert="Минск", Price =100, Img="/img/X.png"}
                };
            }
        }

        public Concert GetSelected(int concertID)
        {
            throw new NotImplementedException();
        }
    }
}
