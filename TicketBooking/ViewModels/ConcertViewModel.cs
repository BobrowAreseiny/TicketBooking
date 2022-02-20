using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class ConcertViewModel
    {
        public string Title { get; set; }

        public string AddButtonTitle { get; set; }

        public string RedirectUrl { get; set; }


        public int Id { get; set; }

        public string ExectorName { get; set; }

        public DateTime DateOfConcert { get; set; }

        public int CountOfTicket { get; set; }

        public string LocationOfConcert { get; set; }

        public ushort Price { get; set; }

        public string Img { get; set; }

        public int TypeOfConcertID { get; set; }

        public IEnumerable<TypeOfConcert> GetAllDescriptions { get; set; }

    }
}
