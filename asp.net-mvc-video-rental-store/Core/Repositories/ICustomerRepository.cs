using asp.net_mvc_video_rental_store.Core.Models;
using System.Collections.Generic;

namespace asp.net_mvc_video_rental_store.Core.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers(string query = null);
        Customer GetById(int id);
        void Add(Customer customer);
        void Remove(Customer customer);
    }
}