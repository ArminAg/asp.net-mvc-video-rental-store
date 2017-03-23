using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IEnumerable<Movie> GetAllMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);
        }

        public ICollection<Movie> GetMoviesByIds(List<int> movieIds)
        {
            return _context.Movies
                .Where(m => movieIds.Contains(m.Id))
                .ToList();
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
        }

        public void Remove(Movie movie)
        {
            _context.Movies.Remove(movie);
        }
    }
}