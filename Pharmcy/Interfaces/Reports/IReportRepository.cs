using Pharmcy.Entities.Reports;
using System.Threading.Tasks;

namespace Pharmcy.Interfaces.Reports
{
    public interface IReportRepository : IRepository<Report, Report>
    {

        public Task<int> CountAsync();
    }
}
