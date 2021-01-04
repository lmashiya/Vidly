using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCustomers();

            var viewModel = new RandomMovieViewModel(){ Customers = customers};

            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            var customers = GetCustomers();
            if (!customers.Any())
            {
                return HttpNotFound();
            }
            var customer = customers.SingleOrDefault(x => x.Id == id);

            return View(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer(){Name = "Mary smith",Id = 1},
                new Customer(){Name = "John Wick",Id = 2},
                new Customer(){Name = "Nicholas Cage",Id = 3},
                new Customer(){Name = "Nasty C",Id = 4}
            };
        }

    }
}