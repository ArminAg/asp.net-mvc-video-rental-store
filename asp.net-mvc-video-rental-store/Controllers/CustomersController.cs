using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace asp.net_mvc_video_rental_store.Controllers
{
    public class CustomersController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var customers = _unitOfWork.Customers.GetAllCustomers();
            return View(Mapper.Map<IEnumerable<CustomerViewModel>>(customers));
        }

        public ActionResult Details(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);

            if (customer == null)
                return HttpNotFound();

            return View(Mapper.Map<CustomerViewModel>(customer));
        }
    }
}