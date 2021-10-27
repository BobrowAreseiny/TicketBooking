using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public List<Ticket> Ticket { get; set; }
    }
}
