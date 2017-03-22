using asp.net_mvc_video_rental_store.Core.Models;
using asp.net_mvc_video_rental_store.Core.Repositories;
using asp.net_mvc_video_rental_store.Core.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace asp.net_mvc_video_rental_store.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var customers = _repository.GetAllCustomers();
            return View(Mapper.Map<IEnumerable<CustomerViewModel>>(customers));
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(Mapper.Map<CustomerViewModel>(customer));
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id=1, Name = "Customer 1" },
                new Customer { Id=2, Name = "Customer 2" }
            };
        }
    }
}