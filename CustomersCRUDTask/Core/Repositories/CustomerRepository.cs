using CustomersCRUDTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersCRUDTask.Core.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
            
        }

        public List<Customer> GetAllCustomersWithAddresses()
        {
            return _context.Customers.Include(c => c.Addresses).ToList();
        }

        public Customer GetCustomerWithAddresses(int id)
        {
            return _context.Customers.Include(c => c.Addresses).FirstOrDefault(c => c.CustomerId == id);
        }

        public void UpdateCustomerWithAddresses(Customer customer)
        {
            List<Address> addresses = _context.Addresses.Where(a => a.CustomerId == customer.CustomerId).ToList();
            foreach (Address address in addresses)
            {
                _context.Addresses.Remove(address);
            }
            foreach (Address address in customer.Addresses)
            {
                _context.Addresses.Add(address);
            }
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
