using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.ViewModels
{
    public class SelectedUserViewModel
    {
        public Account account { get; set; }
        public User user { get; set; }
        public Guid ActivateCode { get; set; }
    }
}
