using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.Data
{
    public class AddToDb
    {
        public static void PutAndTake(/*IApplicationBuilder app*/ApplicationDbContext context)
        {

            //ApplicationDbContext context;
            //using (var scope = app.ApplicationServices.CreateScope())
            //{
            //    context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //}          
            if (!context.Concerts.Any())
            {
                context.Concerts.AddRange(Concerts.Select(c => c.Value));
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(Users.Select(c => c.Value));
            }
            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(Tickets.Select(c => c.Value));
            }
            if (!context.TypeOfConcerts.Any())
            {
                context.TypeOfConcerts.AddRange(TypeOfConcerts.Select(c => c.Value));
            }
            context.SaveChanges();

        }

        private static Dictionary<int, Concert> concert;
        public static Dictionary<int, Concert> Concerts
        {
            get
            {
                if (Concerts == null)
                {
                    var list = new Concert[]
                    {
                        new Concert{ DateOfConcert=new DateTime(2021,10,01), ExectorName="acs", CountOfTicket=100, LocationOfConcert="Минск", Price =40, Img="/img/serd.png"},
                        new Concert{ DateOfConcert=new DateTime(2020,10,01), ExectorName="ZXC", CountOfTicket=10000, LocationOfConcert="Минск", Price =100, Img="/img/X.png"}
                    };
                    concert = new Dictionary<int, Concert>();
                    foreach (var el in list)
                    {
                        concert.Add(el.ID, el);
                    }
                }
                return concert;
            }
        }
        private static Dictionary<int, User> user;
        public static Dictionary<int, User> Users
        {
            get
            {
                if (Users == null)
                {
                    var list = new User[]
                    {
                        new User{ Name="1", Password="1" },
                        new User{ Name="2", Password="2" }
                    };
                    user = new Dictionary<int, User>();
                    foreach (var el in list)
                    {
                        user.Add(el.ID, el);
                    }
                }
                return user;
            }
        }
        private static Dictionary<int, Ticket> tickets;
        public static Dictionary<int, Ticket> Tickets
        {
            get
            {
                if (Tickets == null)
                {
                    var list = new Ticket[]
                    {
                        new Ticket{ Concert = Concerts[1], User =  Users[1] },
                        new Ticket{ Concert = Concerts[2], User =  Users[2] }
                    };
                    tickets = new Dictionary<int, Ticket>();
                    foreach (var el in list)
                    {
                        tickets.Add(el.ID, el);
                    }
                }
                return tickets;
            }
        }
        private static Dictionary<int, TypeOfConcert> typeOfConcert;
        public static Dictionary<int, TypeOfConcert> TypeOfConcerts
        {
            get
            {
                if (Tickets == null)
                {
                    var list = new TypeOfConcert[]
                    {
                        new TypeOfConcert{ Concert = Concerts[1], TypeOfThisConcert = "Опэнэйр", Healiner="Дурной Вкус" },
                        new TypeOfConcert{ Concert = Concerts[2], TypeOfThisConcert = "Вечеринка", AgeLimit = "18" }
                    };
                    typeOfConcert = new Dictionary<int, TypeOfConcert>();
                    foreach (var el in list)
                    {
                        typeOfConcert.Add(el.ID, el);
                    }
                }
                return typeOfConcert;
            }
        }
    }
}
