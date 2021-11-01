using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly CashBox cashBox;

        public OrderRepository(ApplicationDbContext applicationDbContext, CashBox cashBox)
        {
            this.applicationDbContext = applicationDbContext;
            this.cashBox = cashBox;
        }

        public void CreateOrder(Ticket ticket)
        {
            ticket.ByTime = DateTime.Now;
            applicationDbContext.Tickets.Add(ticket);

            var items = cashBox.tickets;

            foreach(var a in items)
            {
                var orderDetail = new Ticket()
                {
                    ConcertID = a.Concert.ID,
                    Price = a.Concert.Price,

                };
                applicationDbContext.Tickets.Add(orderDetail);
            }
            applicationDbContext.SaveChanges();
        }
    }
}
