using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketBooking.Data.Models
{
    public class CashBox
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CashBox(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        
        public string cashBoxID { get; set; }
       
        public List<Ticket> tickets { get; set; }
    
        public static CashBox GetTickets(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string cashBoxID = session.GetString("ID") ?? Guid.NewGuid().ToString();
            session.SetString("ID", cashBoxID);

            return new CashBox(context) { cashBoxID = cashBoxID };
        }

        //public void AddToCashBox(Concert concert, String Emali)
        //{
        //    //if (User.Identity.IsAuthenticated)
        //    //{
        //    var selectedTickets = new Ticket()
        //    {
        //        CashBoxID = cashBoxID,
        //        Concert = concert,
        //        Account = applicationDbContext.Accounts.FirstOrDefault(f => f.Login == Emali),
        //        ByTime = DateTime.Now,
        //        Price = concert.Price,
        //    };
        //    applicationDbContext.Tickets.Add(selectedTickets);
        //    applicationDbContext.SaveChanges();
        //    //}
        //}
        public void AddToCashBox(Concert concert, String Emali)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            var selectedTickets = new Ticket()
            {
                CashBoxID = cashBoxID,
                Concert = concert,
                Account = applicationDbContext.Accounts.FirstOrDefault(f => f.Login == Emali),
                ByTime = DateTime.Now,
                Price = concert.Price,
            };
            applicationDbContext.Tickets.Add(selectedTickets);
            applicationDbContext.SaveChanges();
            //}
        }

        public void DelFromCashBox(IEnumerable<Ticket> tickets)
        {   
            applicationDbContext.Tickets.RemoveRange(tickets);
            applicationDbContext.SaveChanges();
        }

        public List<Ticket> GetTickets()
        {
            return applicationDbContext.Tickets.Where(p => p.CashBoxID == cashBoxID).Include(c => c.Concert).ToList();
        }
    }
}
