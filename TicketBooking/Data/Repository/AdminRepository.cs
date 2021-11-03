using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Repository
{
    public class AdminRepository : IAdminRepository
    {

        //public AdminRepository() { }

        //public async Task<Concert> GetOneConcertAsync(int id)
        //{
        //    Concert concert = null;
        //    using (var DbContext = new ApplicationDbContext())
        //    {
        //        concert = await DbContext.Concerts.FirstOrDefaultAsync(f => f.ID == id);
        //    }
        //    return concert;
        //}

        //public async Task<Concert> AddConcertAsync(Concert concert)
        //{
        //    Concert result = null;
        //    using (var DbContext = new ApplicationDbContext())
        //    {
        //       result = DbContext.Concerts.Add(concert);
        //       await DbContext.SaveChangesAsync();
        //    }
        //    return result;
        //}

        //public async Task<IEnumerable<Concert>> GetConcertAsync()
        //{
        //    List<Concert> results = new List<Concert>();
        //    using (var DbContext = new ApplicationDbContext())
        //    {
        //        results = await DbContext.Concerts.ToListAsync();
        //    }          
        //    return results;
        //}

        //public async Task<Concert> DeleteConcertAsync(int id)//??????????
        //{

        //    using (var DbContext = new ApplicationDbContext())
        //    {
        //        var concert = await DbContext.Concerts.FirstOrDefaultAsync(f => f.ID == id);
        //        DbContext.Entry(concert).State = EntityState.Deleted;
        //        await DbContext.SaveChangesAsync();
        //    }
        //    return null;
        //}

        //public async Task<Concert> UpdateConcertAsync(Concert concert)
        //{
        //    using (var DbContext = new ApplicationDbContext())
        //    {
        //        DbContext.Entry(concert).State = EntityState.Modified;
        //        await DbContext.SaveChangesAsync();
        //    }

        //    return concert;
        //}



        private readonly ApplicationDbContext _applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Concert> GetConcert()
        {
            IEnumerable<Concert> concert = _applicationDbContext.Concerts;
            return concert;
        }

        public Concert GetSelectedConcert(int id)
        {
            Concert concert = _applicationDbContext.Concerts.FirstOrDefault(f => f.ID == id);
            return concert;
        }

        public Concert AddConcert(Concert concert)
        {
            _applicationDbContext.Concerts.Add(concert);
            _applicationDbContext.SaveChanges();
            return concert;
        }

        public Concert DeleteConcert(int id)
        {
            var concert = _applicationDbContext.Concerts.FirstOrDefault(f => f.ID == id);
            _applicationDbContext.Entry(concert).State = EntityState.Deleted;
            _applicationDbContext.SaveChanges();
            return concert;
        }

        public Concert UpdateConcert(Concert concert)
        {
            _applicationDbContext.Entry(concert).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return concert;
        }

    }
}
