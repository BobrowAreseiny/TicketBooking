using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
using TicketBooking.ViewModels;

namespace TicketBooking.Data.Repository
{
    public class AutorisationRepository : IAutorisation
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AutorisationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Role> LoginAsync(UserLoginViewModel Userlogin)
        {
            Account account = await _applicationDbContext.Accounts
                .Where(p => p.Login == Userlogin.Login && p.Password == Crypto.Hash(Userlogin.Password))
                .FirstOrDefaultAsync();

            account.Role = await _applicationDbContext.Roles.Where(p => p.Id == account.RoleID).FirstOrDefaultAsync();

            await _applicationDbContext.SaveChangesAsync();

            return account.Role;
        }

        public async Task<Role> RegistrateAccountAsync(AccountViewModel UserInfo)
        {            
            Client client = new Client
            {
                Name = UserInfo.Name,
                Surname = UserInfo.Surname,
                DateOfBirth = UserInfo.DateOfBirth,
            };

            _applicationDbContext.Users.Add(client);

            await _applicationDbContext.SaveChangesAsync();

            UserInfo.Password = Crypto.Hash(UserInfo.Password);

            UserInfo.Role = await _applicationDbContext.Roles.FirstOrDefaultAsync();

            Account account = new Account()
            {
                Login = UserInfo.Login,
                Password = UserInfo.Password,
                UserID = client.ID,
                Role = UserInfo.Role
            };

            _applicationDbContext.Accounts.Add(account);

            await _applicationDbContext.SaveChangesAsync();

            account.Role = await _applicationDbContext.Roles.Where(p => p.Id == account.RoleID).FirstOrDefaultAsync();

            return account.Role;
        }

        public async Task<Role> UserRole(Account User)
        {                      
            return await _applicationDbContext.Roles.Where(p => p.Id == User.RoleID).FirstOrDefaultAsync();
        } 
        
        public async Task<bool> IsLoginExist(string email)
        {
            Account account = await _applicationDbContext.Accounts.Where(p => p.Login == email).FirstOrDefaultAsync();

            return account != null;
        }
    }
}
