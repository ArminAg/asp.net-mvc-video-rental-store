using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace asp.net_mvc_video_rental_store.Controllers
{
    public class MoviesController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var movies = _unitOfWork.Movies.GetAllMovies();
            return View(Mapper.Map<IEnumerable<MovieViewModel>>(movies));
        }
    }
}