using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{

    public class Role
    {
        public int Id { get; set; }


        public string Name { get; set; }
       
        public List<Account> Account { get; set; }
    }
}
