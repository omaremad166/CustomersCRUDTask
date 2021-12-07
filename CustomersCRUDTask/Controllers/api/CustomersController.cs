using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomersCRUDTask.Models;
using CustomersCRUDTask.Core;

namespace CustomersCRUDTask.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomersController()
        {
            this.unitOfWork = new UnitOfWork(new AppDbContext());
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<List<Customer>> GetCustomers()
        {
            return  unitOfWork.Customers.GetAllCustomersWithAddresses();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer =  unitOfWork.Customers.GetCustomerWithAddresses(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            unitOfWork.Customers.Update(customer);
            unitOfWork.Finish();
            
            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            unitOfWork.Customers.Add(customer);
            unitOfWork.Finish();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer =  unitOfWork.Customers.GetCustomerWithAddresses(id);
            if (customer == null)
            {
                return NotFound();
            }

            unitOfWork.Customers.Remove(customer);
            unitOfWork.Finish();

            return NoContent();
        }
    }
}
