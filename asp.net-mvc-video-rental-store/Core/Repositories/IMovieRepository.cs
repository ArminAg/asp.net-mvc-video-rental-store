using asp.net_mvc_video_rental_store.Core.Models;
using System.Collections.Generic;

namespace asp.net_mvc_video_rental_store.Core.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetById(int id);
        ICollection<Movie> GetMoviesByIds(List<int> movieIds);
        void Add(Movie movie);
        void Remove(Movie movie);
    }
}