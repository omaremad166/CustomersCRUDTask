using CustomersCRUDTask.Core.Repositories;
using CustomersCRUDTask.Models;

namespace CustomersCRUDTask.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
        }
        public ICustomerRepository Customers { get; set;}

        public int Finish()
        {
            return _context.SaveChanges();
        }
    }
}
