using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<Concert> GetConcert();
        Concert GetSelectedConcert(int id);
        Concert AddConcert(Concert concert);
        Concert DeleteConcert(int id);
        Concert UpdateConcert(Concert concert);



        //Task<IEnumerable<Concert>> GetConcertAsync();
        //Task<Concert> GetOneConcertAsync(int id);
        //Task<Concert> AddConcertAsync(Concert concert);
        //Task<Concert> DeleteConcertAsync(int id);
        //Task<Concert> UpdateConcertAsync(Concert concert);

    }
}
