using Pharmcy.Entities.Sales;
using Pharmcy.Interfaces.Sales;
using Pharmcy.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmcy.Repostories.Sales
{
    public class SaleRepository :BaseRepository, ISaleRepository
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Sale obj)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Sale>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetASync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, Sale obj)
        {
            throw new NotImplementedException();
        }
    }
}
