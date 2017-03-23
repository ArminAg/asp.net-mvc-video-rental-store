using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.Repositories;
using asp.net_mvc_video_rental_store.Persistence.Repositories;

namespace asp.net_mvc_video_rental_store.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICustomerRepository Customers { get; private set; }
        public IMovieRepository Movies { get; private set; }
        public IMembershipTypeRepository MembershipTypes { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IRentalRepository Rentals { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
            Movies = new MovieRepository(_context);
            MembershipTypes = new MembershipTypeRepository(_context);
            Genres = new GenreRepository(_context);
            Rentals = new RentalRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}