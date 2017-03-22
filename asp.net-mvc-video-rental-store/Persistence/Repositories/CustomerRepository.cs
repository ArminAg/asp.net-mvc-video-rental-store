using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using System.Collections.Generic;
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
            return _context.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }
    }
}