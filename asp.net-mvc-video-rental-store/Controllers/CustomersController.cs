using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.Models;
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
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);

            if (customer == null)
                return HttpNotFound();

            return View(Mapper.Map<CustomerViewModel>(customer));
        }

        public ActionResult Create()
        {
            var membershipTypes = _unitOfWork.MembershipTypes.GetAllMembershipTypes();
            
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = Mapper.Map<IEnumerable<MembershipTypeViewModel>>(membershipTypes)
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);

            if (customer == null)
                return HttpNotFound();

            var membershipTypes = _unitOfWork.MembershipTypes.GetAllMembershipTypes();

            var viewModel = Mapper.Map<CustomerFormViewModel>(customer);
            viewModel.MembershipTypes = Mapper.Map<IEnumerable<MembershipTypeViewModel>>(membershipTypes);
            
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = customer;
                viewModel.MembershipTypes = Mapper.Map<IEnumerable<MembershipTypeViewModel>>(_unitOfWork.MembershipTypes.GetAllMembershipTypes());
                
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _unitOfWork.Customers.Add(Mapper.Map<Customer>(customer));
            else
            {
                var dbCustomer = _unitOfWork.Customers.GetById(customer.Id);
                Mapper.Map(customer, dbCustomer);
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Customers");
        }
    }
}