using Pharmcy.Entities.Reports;
using Pharmcy.Interfaces.Reports;
using Pharmcy.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pharmcy.Repostories.Reports;

public class ReportRepository : BaseRepository, IReportRepository
{
    public Task<int> CountAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<int> CreateAsync(Report obj)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<IList<Report>> GetAllAsync(PaginationParams @params)
    {
        throw new System.NotImplementedException();
    }

    public Task<Report> GetASync(long id)
    {
        throw new System.NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Report obj)
    {
        throw new System.NotImplementedException();
    }
}
