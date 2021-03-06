using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Models;

namespace TicketBooking.Data.Interfaces
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Concert>> GetConcertsAsync();
        Task<Concert> GetSelectedConcertAsync(int id);
        Task<Concert> AddConcertAsync(Concert concert);
        Task<TypeOfConcert> AddDescriptionConcertAsync(TypeOfConcert typeOfConcert);
        Task<Concert> DeleteConcertAsync(int id);
        Task<Concert> UpdateConcertAsync(Concert concert);
    }
}
