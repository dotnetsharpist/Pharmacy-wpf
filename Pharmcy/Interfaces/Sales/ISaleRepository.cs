using Pharmcy.Entities.Sales;
using System.Threading.Tasks;

namespace Pharmcy.Interfaces.Sales
{
    public interface ISaleRepository : IRepository<Sale, Sale>
    {
        public Task<int> CountAsync();
    }
}
