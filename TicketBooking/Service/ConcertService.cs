using System.Collections.Generic;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;

namespace TicketBooking
{
    public class ConcertService : IConcertService
    {
        private readonly IAdminRepository _adminRepository;

        public ConcertService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<IEnumerable<Concert>> GetConcertsAsync()
        {
            return await _adminRepository.GetConcertsAsync();
        }
        public async Task<Concert> GetSelectedConcertAsync(int id)
        {
            return await _adminRepository.GetSelectedConcertAsync(id);
        }
        public async Task<Concert> AddConcertAsync(Concert concert)
        {
            return await _adminRepository.AddConcertAsync(concert);
        }
        public async Task<Concert> DeleteConcertAsync(int id)
        {
            return await _adminRepository.DeleteConcertAsync(id);
        }
        public async Task<Concert> UpdateConcertAsync(Concert concert)
        {
            return await _adminRepository.UpdateConcertAsync(concert);
        }

        //public async Task<Concert> GetOneConcertAsync(int id)
        //{
        //    return _adminRepository.GetOneConcertAsync(id);
        //}
        //public async Task<Concert> AddConcertAsync(Concert concert)
        //{
        //    return _adminRepository.AddConcertAsync(concert);
        //}
        //public async Task<IEnumerable<Concert>> GetConcertAsync()
        //{
        //    return _adminRepository.GetConcertAsync();
        //}
        //public async Task<Concert> DeleteConcertAsync(int id)//??????????
        //{
        //    return _adminRepository.DeleteConcertAsync(id);
        //}
        //public async Task<Concert> UpdateConcertAsync(Concert concert)
        //{
        //    return _adminRepository.UpdateConcertAsync(concert);
        //}
    }
}
