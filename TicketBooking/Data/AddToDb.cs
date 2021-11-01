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
            
            if (!context.TypeOfConcerts.Any())
            {
                context.TypeOfConcerts.AddRange(TypeOfConcerts.Select(c => c.Value));
            }
            if (!context.Concerts.Any())
            {
                context.Concerts.AddRange(Concerts.Select(c => c.Value));
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(Users.Select(c => c.Value));
            }
            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(Accounts.Select(c => c.Value));
            }
            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(Tickets.Select(c => c.Value));
            }                   
            context.SaveChanges();
        }


        private static Dictionary<string, TypeOfConcert> typeOfConcert;
        public static Dictionary<string, TypeOfConcert> TypeOfConcerts
        {
            get
            {
                if (typeOfConcert == null)
                {
                    var list = new TypeOfConcert[]
                    {
                        new TypeOfConcert{ TypeOfThisConcert = "Опэнэйр", Healiner="Дурной Вкус" },
                        new TypeOfConcert{ TypeOfThisConcert = "Вечеринка", AgeLimit = "18" }
                    };
                    typeOfConcert = new Dictionary<string, TypeOfConcert>();
                    foreach (var el in list)
                    {
                        typeOfConcert.Add(el.TypeOfThisConcert, el);
                    }
                }
                return typeOfConcert;
            }
        }

        private static Dictionary<string, Concert> concert;
        public static Dictionary<string, Concert> Concerts
        {
            get
            {
                if (concert == null)
                {
                    var list = new Concert[]
                    {
                        new Concert{ DateOfConcert=new DateTime(2021,10,01), ExectorName="Metalica", CountOfTicket=100, LocationOfConcert="Минск", Price =40, Img="/img/serd.png", TypeOfConcert = TypeOfConcerts["Опэнэйр"]},
                        new Concert{ DateOfConcert=new DateTime(2020,10,01), ExectorName="Fluer", CountOfTicket=10000, LocationOfConcert="Минск", Price =100, Img="/img/X.png", TypeOfConcert = TypeOfConcerts["Вечеринка"]}
                    };
                    concert = new Dictionary<string, Concert>();
                    foreach (var el in list)
                    {
                        concert.Add(el.ExectorName, el);
                    }
                }
                return concert;
            }
        }

        private static Dictionary<string, User> user;
        public static Dictionary<string, User> Users
        {
            get
            {
                if (user == null)
                {
                    var list = new User[]
                    {
                        new User{ Name = "Арсений", Surname = "Бобров" },
                        new User{ Name="2", Surname = "2" }
                    };
                    user = new Dictionary<string, User>();
                    foreach (var el in list)
                    {
                        user.Add(el.Name, el);
                    }
                }
                return user;
            }
        }

        private static Dictionary<string, Account> account;
        public static Dictionary<string, Account> Accounts
        {
            get
            {
                if (account == null)
                {
                    var list = new Account[]
                    {
                        new Account{ Login="1", Password="1", User = Users["Арсений"] },
                        new Account{ Login="2", Password="2", User = Users["2"] }
                    };
                    account = new Dictionary<string, Account>();
                    foreach (var el in list)
                    {
                        account.Add(el.Login, el);
                    }
                }
                return account;
            }
        }
        private static Dictionary<string, Ticket> tickets;
        public static Dictionary<string, Ticket> Tickets
        {
            get
            {
                if (tickets == null)
                {
                    var list = new Ticket[]
                    {
                        new Ticket{ Concert = Concerts["Metalica"], Account =  Accounts["1"]},
                        new Ticket{ Concert = Concerts["Fluer"], Account =  Accounts["2"]}
                    };
                    tickets = new Dictionary<string, Ticket>();
                    foreach (var el in list)
                    {
                        tickets.Add(el.Account.Password,el);
                    }
                }
                return tickets;
            }
        }
    }
}
