using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace asp.net_mvc_video_rental_store.Controllers
{
    public class MoviesController : Controller
    {
        public ActionResult Index()
        {
            var movies = GetMovies();
            return View(Mapper.Map<IEnumerable<MovieViewModel>>(movies));
        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Movie 1" },
                new Movie { Id = 2, Name = "Movie 2"}
            };
        }
    }
}