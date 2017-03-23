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
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _unitOfWork.Movies.GetById(id);

            if (movie == null)
                return HttpNotFound();

            return View(Mapper.Map<MovieViewModel>(movie));
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var genres = _unitOfWork.Genres.GetAllGenres();

            var viewModel = new MovieFormViewModel
            {
                Genres = Mapper.Map<IEnumerable<GenreViewModel>>(genres)
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _unitOfWork.Movies.GetById(id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = Mapper.Map<MovieFormViewModel>(movie);
            viewModel.Genres = Mapper.Map<IEnumerable<GenreViewModel>>(_unitOfWork.Genres.GetAllGenres());

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(MovieFormViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = movie;
                viewModel.Genres = Mapper.Map<IEnumerable<GenreViewModel>>(_unitOfWork.Genres.GetAllGenres());

                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                var newMovie = Mapper.Map<Movie>(movie);
                newMovie.DateAdded = DateTime.Now;
                _unitOfWork.Movies.Add(newMovie);
            }
            else
            {
                var dbMovie = _unitOfWork.Movies.GetById(movie.Id.Value);
                Mapper.Map(movie, dbMovie);
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Movies");
        }
    }
}