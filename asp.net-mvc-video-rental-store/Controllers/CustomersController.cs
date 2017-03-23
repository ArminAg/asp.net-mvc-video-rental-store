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

        public ActionResult Create()
        {
            var membershipTypes = _unitOfWork.MembershipTypes.GetAllMembershipTypes();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new CustomerViewModel(),
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
            var viewModel = new CustomerFormViewModel
            {
                Customer = Mapper.Map<CustomerViewModel>(customer),
                MembershipTypes = Mapper.Map<IEnumerable<MembershipTypeViewModel>>(membershipTypes)
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var vm = new CustomerFormViewModel
                {
                    Customer = viewModel.Customer,
                    MembershipTypes = Mapper.Map<IEnumerable<MembershipTypeViewModel>>(_unitOfWork.MembershipTypes.GetAllMembershipTypes())
                };
                return View("CustomerForm", vm);
            }

            if (viewModel.Customer.Id == 0)
                _unitOfWork.Customers.Add(Mapper.Map<Customer>(viewModel.Customer));
            else
            {
                var customer = _unitOfWork.Customers.GetById(viewModel.Customer.Id);
                customer.Name = viewModel.Customer.Name;
                customer.BirthDate = viewModel.Customer.BirthDate;
                customer.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                customer.MembershipTypeId = viewModel.Customer.MembershipTypeId;
            }

            _unitOfWork.Complete();

            return RedirectToAction("Index", "Customers");
        }
    }
}