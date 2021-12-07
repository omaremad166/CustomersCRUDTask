using CustomersCRUDTask.Core.Repositories;

namespace CustomersCRUDTask.Core
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        int Finish();
    }
}
