using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace asp.net_mvc_video_rental_store.Persistence.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.SingleOrDefault(m => m.Id == id);
        }
    }
}