using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

namespace TicketBooking.Data.Interfaces
{
    public interface IUserPage
    {
        Task<Account> GetUserAccountAsync(string email);

        Task<Client> GetClientAsync(int id);

        Task<List<Ticket>> GetClientTiketAsync(Account account);

        Task<Account> ChangeAccountData(Account account);

        Task<Client> ChangeClientData(Client client);
    }
}
