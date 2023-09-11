using Pharmcy.Entities.Customers;
using System.Threading.Tasks;

namespace Pharmcy.Interfaces.Customers
{
    public interface ICustomerRepository : IRepository<Customer, Customer>
    {
        public Task<int> CountAsync();
    }
}
