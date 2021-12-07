using CustomersCRUDTask.Models;

namespace CustomersCRUDTask.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        List<Customer> GetAllCustomersWithAddresses();
        Customer GetCustomerWithAddresses(int id);
        void UpdateCustomerWithAddresses(Customer customer);
    }
}
