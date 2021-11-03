﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketBooking.Data.Interfaces;
using TicketBooking.Data.Models;
using TicketBooking.Data.Repository;

namespace TicketBooking
{
    public class IConcertService : Data.Interfaces.IConcertService
    {
        private readonly IAdminRepository _adminRepository;

        public IConcertService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IEnumerable<Concert> GetConcert()
        {
            return _adminRepository.GetConcert();
        }
        public Concert GetSelectedConcert(int id)
        {
            return _adminRepository.GetSelectedConcert(id);
        }
        public Concert AddConcert(Concert concert)
        {
            return _adminRepository.AddConcert(concert);
        }
        public Concert DeleteConcert(int id)
        {
            return _adminRepository.DeleteConcert(id);
        }
        public Concert UpdateConcert(Concert concert)
        {
            return _adminRepository.UpdateConcert(concert);
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