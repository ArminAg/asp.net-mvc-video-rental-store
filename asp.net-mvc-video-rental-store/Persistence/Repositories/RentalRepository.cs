using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using System;
using System.Collections.Generic;

namespace asp.net_mvc_video_rental_store.Persistence.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private ApplicationDbContext _context;

        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddNewRentals(int customerId, ICollection<Movie> movies)
        {
            foreach (var movie in movies)
            {
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    DateRented = DateTime.Now,
                    CustomerId = customerId,
                    Movie = movie
                };

                _context.Rentals.Add(rental);
            }
        }
    }
}