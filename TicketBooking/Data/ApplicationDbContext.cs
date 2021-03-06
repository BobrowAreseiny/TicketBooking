using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext() : base("DefaultConnection")
        //{

        //}       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TypeOfConcert> TypeOfConcerts { get; set; }
        public DbSet<Client> Users { get; set; }        
        public DbSet<Role> Roles { get; set; }        
    }
}
