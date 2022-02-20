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
        private readonly ApplicationDbContext _applicationDbContext;

        public AdminRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Concert>> GetConcertsAsync()
        {
            List<Concert> results = null;

            results = await _applicationDbContext.Concerts.ToListAsync();
         
            return results;
        }

        public async Task<Concert> GetSelectedConcertAsync(int id)
        {
            Concert concert = null;

            concert = await _applicationDbContext.Concerts.FirstOrDefaultAsync(f => f.ID == id);

            return concert;
        }

        public async Task<Concert> AddConcertAsync(Concert concert)
        {
            _applicationDbContext.Concerts.Add(concert);

            await _applicationDbContext.SaveChangesAsync();

            return concert;
        }

        public async Task<Concert> DeleteConcertAsync(int id)
        {
            var concert = await _applicationDbContext.Concerts.FirstOrDefaultAsync(f => f.ID == id);

            _applicationDbContext.Entry(concert).State = EntityState.Deleted;

            await _applicationDbContext.SaveChangesAsync();

            return null;
        }

        public async Task<Concert> UpdateConcertAsync(Concert concert)
        {
            _applicationDbContext.Entry(concert).State = EntityState.Modified;

            await _applicationDbContext.SaveChangesAsync();

            return concert;
        }

        public async Task<TypeOfConcert> AddDescriptionConcertAsync(TypeOfConcert typeOfConcert)
        {
            _applicationDbContext.TypeOfConcerts.Add(typeOfConcert);

            await _applicationDbContext.SaveChangesAsync();

            return typeOfConcert;
        }

        //private readonly ApplicationDbContext _applicationDbContext;

        //public AdminRepository(ApplicationDbContext applicationDbContext)
        //{
        //    _applicationDbContext = applicationDbContext;
        //}

        //public IEnumerable<Concert> GetConcert()
        //{
        //    IEnumerable<Concert> concert = _applicationDbContext.Concerts;
        //    return concert;
        //}

        //public Concert GetSelectedConcert(int id)
        //{
        //    Concert concert = _applicationDbContext.Concerts.FirstOrDefault(f => f.ID == id);
        //    return concert;
        //}

        //public Concert AddConcert(Concert concert)
        //{
        //    _applicationDbContext.Concerts.Add(concert);
        //    _applicationDbContext.SaveChanges();
        //    return concert;
        //}

        //public Concert DeleteConcert(int id)
        //{
        //    var concert = _applicationDbContext.Concerts.FirstOrDefault(f => f.ID == id);
        //    _applicationDbContext.Entry(concert).State = EntityState.Deleted;
        //    _applicationDbContext.SaveChanges();
        //    return concert;
        //}

        //public Concert UpdateConcert(Concert concert)
        //{
        //    _applicationDbContext.Entry(concert).State = EntityState.Modified;
        //    _applicationDbContext.SaveChanges();
        //    return concert;
        //}
    }
}
