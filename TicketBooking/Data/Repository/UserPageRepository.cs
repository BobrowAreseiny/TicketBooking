using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Repository
{
    public class UserPageRepository : IUserPage
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserPageRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Account> ChangeAccountData(Account account)
        {
            Account changeAccount = await _applicationDbContext.Accounts.Where(p => p.ID == account.ID).FirstOrDefaultAsync();
            account.UserID = changeAccount.UserID;
            account.RoleID = changeAccount.RoleID;
            account.Ticket = changeAccount.Ticket;
            account.User = changeAccount.User;
            account.Role = changeAccount.Role;

            _applicationDbContext.Entry(account).State = EntityState.Modified;

            await _applicationDbContext.SaveChangesAsync();

            return account;
        }

        public async Task<Client> ChangeClientData(Client client)
        {
            _applicationDbContext.Entry(client).State = EntityState.Modified;

            await _applicationDbContext.SaveChangesAsync();

            return client;
        }

        public async Task<Client> GetClientAsync(int ID)
        {
            return await _applicationDbContext.Users.Where(p => p.ID == ID).FirstOrDefaultAsync();
        }

        public async Task<List<Ticket>> GetClientTiketAsync(Account account)
        {
            return await _applicationDbContext.Tickets.Where(p => p.AccountID == account.ID).ToListAsync();
        }

        public async Task<Account> GetUserAccountAsync(string Email)
        {
            return await _applicationDbContext.Accounts.Where(p => p.Login == Email).FirstOrDefaultAsync();
        }
    }
}
