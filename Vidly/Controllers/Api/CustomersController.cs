using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            return Mapper.Map<Customer, CustomerDto>(customer) ?? throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }

        [HttpPut]
        public void EditCustomer(int id,CustomerDto  customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
