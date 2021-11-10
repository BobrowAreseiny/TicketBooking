using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsUserConfirm { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Guid ActivateCode { get; set; }
    }
}
