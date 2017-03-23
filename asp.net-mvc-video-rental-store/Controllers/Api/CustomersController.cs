using asp.net_mvc_video_rental_store.Core;
using asp.net_mvc_video_rental_store.Core.Dtos;
using asp.net_mvc_video_rental_store.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace asp.net_mvc_video_rental_store.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _unitOfWork.Customers.GetAllCustomers();
            return Mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);

            if (customer == null)
                NotFound();

            return Ok(Mapper.Map<CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<Customer>(customerDto);
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), Mapper.Map<CustomerDto>(customer));
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = _unitOfWork.Customers.GetById(id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customer);

            _unitOfWork.Complete();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _unitOfWork.Customers.GetById(id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.Customers.Remove(customer);
            _unitOfWork.Complete();
        }
    }
}
