using Pharmcy.Entities.Pharmacists;
using System.Threading.Tasks;

namespace Pharmcy.Interfaces.Pharmacists
{
    public interface IPharmacistRepository : IRepository<Pharmacist, Pharmacist>
    {
        public Task<int> CountAsync();
    }
}
