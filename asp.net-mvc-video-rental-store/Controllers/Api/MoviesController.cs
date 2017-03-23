using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.Dtos;
using asp.net_mvc_video_rental_store.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace asp.net_mvc_video_rental_store.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = _unitOfWork.Movies.GetAllMovies();
            return Mapper.Map<IEnumerable<MovieDto>>(movies);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _unitOfWork.Movies.GetById(id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<MovieDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<Movie>(movieDto);
            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), Mapper.Map<MovieDto>(movie));
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = _unitOfWork.Movies.GetById(id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movie);

            _unitOfWork.Complete();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = _unitOfWork.Movies.GetById(id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.Movies.Remove(movie);
            _unitOfWork.Complete();
        }
    }
}
