using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

namespace TicketBooking.Data.Interfaces
{
    public interface IAutorisation
    {
       Task<Role> RegistrateAccountAsync(AccountViewModel accountViewModel);

       Task<Role> LoginAsync(UserLoginViewModel Userlogin);

       Task<Role> UserRole(Account Account);

       Task<bool> IsLoginExist(string email);
    }
}
