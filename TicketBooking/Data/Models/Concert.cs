using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class Concert
    {
        [Key]
        public int ID { get; set; }


        public string ExectorName { get; set; }

        public DateTime DateOfConcert { get; set; }

        public int CountOfTicket { get; set; }

        public string LocationOfConcert { get; set; }

        public ushort Price { get; set; }

        public string Img { get; set; }


        public int TypeOfConcertID { get; set; }

        public virtual TypeOfConcert TypeOfConcert { get; set; }

        public List<Ticket> Ticket { get; set; }

       
    }
}
