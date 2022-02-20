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

        public DateTime ByTime { get; set; }

        public int Price { get; set; }


        public int AccountID { get; set; }

        public virtual Account Account { get; set; }

        public int ConcertID { get; set; }

        public virtual Concert Concert { get; set; }           
    }
}
