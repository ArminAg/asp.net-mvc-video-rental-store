using asp.net_mvc_video_rental_store.Core.Repositories;

namespace asp.net_mvc_video_rental_store.Core
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IMovieRepository Movies { get; }
        IMembershipTypeRepository MembershipTypes { get; }
        IGenreRepository Genres { get; }

        void Complete();
    }
}