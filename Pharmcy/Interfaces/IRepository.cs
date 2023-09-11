using Pharmcy.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmcy.Interfaces
{
    public interface IRepository<TModel, TViewModel>
    {
        public Task<int> CreateAsync(TModel obj);

        public Task<int> UpdateAsync(long id, TModel obj);

        public Task<int> DeleteAsync(long id);

        public Task<IList<TViewModel>> GetAllAsync(PaginationParams @params);

        public Task<TViewModel> GetASync(long id);
    }
}
