using Pharmcy.Entities.Medicines;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmcy.Interfaces.Medicines;

public interface IMedicineRepository : IRepository<Medicine, Medicine>
{

    public Task<int> CountAsync();
    Task<int> CreateAsync(Medicine obj);
}
