using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        public string CashBoxID { get; set; }

        public int ConcertID { get; set; }
        public int UserID { get; set; }

        public Concert Concert { get; set; }
        public User User { get; set; }

    }
}
