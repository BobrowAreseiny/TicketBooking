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
        public static void PutAndTake(ApplicationDbContext context)
        {
            if (!context.TypeOfConcerts.Any())
            {
                context.TypeOfConcerts.AddRange(TypeOfConcerts.Select(c => c.Value));
            }
            if (!context.Concerts.Any())
            {
                context.Concerts.AddRange(Concerts.Select(c => c.Value));
            } 
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(Roles.Select(c => c.Value));
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
                        new Concert{ DateOfConcert=new DateTime(2021,10,01), ExectorName="Metalica", CountOfTicket=100, LocationOfConcert="Минск", Price = 40, Img="/img/Metallica.png", TypeOfConcert = TypeOfConcerts["Опэнэйр"]},
                        new Concert{ DateOfConcert=new DateTime(2020,10,01), ExectorName="Fluer", CountOfTicket=10000, LocationOfConcert="Минск", Price = 100, Img="/img/Fleur.png", TypeOfConcert = TypeOfConcerts["Вечеринка"]}
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

        private static Dictionary<string, Role> role;
        public static Dictionary<string, Role> Roles
        {
            get
            {
                if (role == null)
                {
                    var list = new Role[]
                    {
                        new Role{ Name = "Пользователь" },
                        new Role{ Name = "Администратор" }
                    };
                    role = new Dictionary<string, Role>();
                    foreach (var el in list)
                    {
                        role.Add(el.Name, el);
                    }
                }
                return role;
            }
        }

        private static Dictionary<string, Client> user;
        public static Dictionary<string, Client> Users
        {
            get
            {
                if (user == null)
                {
                    var list = new Client[]
                    {
                        new Client{ Name = "Арсений", Surname = "Бобров", DateOfBirth = new DateTime(2000,10,10) },
                        new Client{ Name="Пастэрнак", Surname = "Владислав" , DateOfBirth = new DateTime(2002,10,10)}
                    };
                    user = new Dictionary<string, Client>();
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
                        new Account{ Login="Frukt9809@gmail.com", Password="a225119283A", User = Users["Арсений"], Role = Roles["Администратор"] },
                        new Account{ Login="Amogus@gmail.com", Password="1111", User = Users["Пастэрнак"] , Role= Roles["Пользователь"] }
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
                        new Ticket{Account =  Accounts["Frukt9809@gmail.com"], ByTime = DateTime.Now, Concert = Concerts["Metalica"], Price=100},
                        new Ticket{Account =  Accounts["Amogus@gmail.com"], ByTime = DateTime.Now, Concert = Concerts["Fluer"], Price=200}
                    };
                    tickets = new Dictionary<string, Ticket>();
                    foreach (var el in list)
                    {
                        tickets.Add(el.Account.Login, el);
                    }
                }
                return tickets;
            }
        }
    } 
}
