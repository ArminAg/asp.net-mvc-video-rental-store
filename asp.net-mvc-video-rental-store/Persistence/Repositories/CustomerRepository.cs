using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace asp.net_mvc_video_rental_store.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);
        }
    }
}