using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace asp.net_mvc_video_rental_store.Persistence.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }
    }
}