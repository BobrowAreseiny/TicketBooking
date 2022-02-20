using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Interfaces
{
    public interface IConcertService
    {
        //IEnumerable<Concert> GetConcertAsync();
        //Concert GetSelectedConcertAsync(int id);
        //Concert AddConcertAsync(Concert concert);
        //Concert DeleteConcertAsync(int id);
        //Concert UpdateConcertAsync(Concert concert);

        Task<IEnumerable<Concert>> GetConcertsAsync();
        Task<Concert> GetSelectedConcertAsync(int id);
        Task<Concert> AddConcertAsync(Concert concert);
        Task<Concert> DeleteConcertAsync(int id);
        Task<Concert> UpdateConcertAsync(Concert concert);
    }
}
