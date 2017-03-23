using asp.net_mvc_video_rental_store.Core.Models;
using System.Collections.Generic;

namespace asp.net_mvc_video_rental_store.Core.Repositories
{
    public interface IRentalRepository
    {
        void AddNewRentals(int customerId, ICollection<Movie> movies);
    }
}