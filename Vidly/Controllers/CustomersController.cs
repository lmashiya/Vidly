using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        /// <inheritdoc cref="Dispose"/>
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var newCustomerViewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",newCustomerViewModel);
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int? id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int? id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null) return HttpNotFound();

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}