using Pharmcy.Entities.Purchasing;
using System.Threading.Tasks;

namespace Pharmcy.Interfaces.Purchasings
{
    public interface IPurchasingRepository : IRepository<Purchasing, Purchasing>
    {
        public Task<int> CountAsync();
    }
}
