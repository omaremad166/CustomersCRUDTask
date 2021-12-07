using CustomersCRUDTask.Core;
using CustomersCRUDTask.Core.Repositories;
using CustomersCRUDTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomersCRUDTask.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomersController()
        {
            this.unitOfWork = new UnitOfWork(new AppDbContext());
        }
        public IActionResult Index()
        {
            List<Customer> customers = unitOfWork.Customers.GetAllCustomersWithAddresses();

            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Addresses = Address.AdressesHandler(Request.Form["Addresses"], customer.CustomerId);
                unitOfWork.Customers.Add(customer);
                unitOfWork.Finish();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }        

        public IActionResult Edit(int id)
        {
            Customer customer = unitOfWork.Customers.GetCustomerWithAddresses(id);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.Addresses = Address.AdressesHandler(Request.Form["Addresses"], customer.CustomerId);
                unitOfWork.Customers.UpdateCustomerWithAddresses(customer);
                unitOfWork.Finish();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            unitOfWork.Customers.Remove(unitOfWork.Customers.Get(id));
            unitOfWork.Finish();
            return RedirectToAction(nameof(Index));
        }
    }
}
