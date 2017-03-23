using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.ViewModels;
using AutoMapper;
using System;
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

        public ActionResult Details(int id)
        {
            var movie = _unitOfWork.Movies.GetById(id);

            if (movie == null)
                return HttpNotFound();

            return View(Mapper.Map<MovieViewModel>(movie));
        }

        public ActionResult Create()
        {
            var genres = _unitOfWork.Genres.GetAllGenres();

            var viewModel = new MovieFormViewModel
            {
                Genres = Mapper.Map<IEnumerable<GenreViewModel>>(genres)
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _unitOfWork.Movies.GetById(id);

            if (movie == null)
                return HttpNotFound();

            var genres = _unitOfWork.Genres.GetAllGenres();
            var viewModel = new MovieFormViewModel
            {
                Movie = Mapper.Map<MovieViewModel>(movie),
                Genres = Mapper.Map<IEnumerable<GenreViewModel>>(genres)
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (viewModel.Movie.Id == 0)
            {
                viewModel.Movie.DateAdded = DateTime.Now;
                _unitOfWork.Movies.Add(Mapper.Map<Movie>(viewModel.Movie));
            }
            else
            {
                var movie = _unitOfWork.Movies.GetById(viewModel.Movie.Id);
                Mapper.Map(viewModel.Movie, movie);
            }
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Movies");
        }
    }
}