using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public int UseraId { get; set; }

        public virtual List<Ticket> Ticket { get; set; }
        public virtual User User { get; set; }

    }
}
