using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.Dtos;
using System.Linq;
using System.Web.Http;

namespace asp.net_mvc_video_rental_store.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public RentalsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _unitOfWork.Customers.GetById(newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid.");

            var movies = _unitOfWork.Movies.GetMoviesByIds(newRental.MovieIds);

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");

            if (movies.Any(m => m.NumberAvailable == 0))
                return BadRequest("Movie is not available.");

            _unitOfWork.Rentals.AddNewRentals(newRental.CustomerId, movies);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
