using System;

namespace Pharmcy.Entities.Reports;

public class Report : Auditable
{
    public long ReportId { get; set; }

    public long PurchaseId { get; set; }

    public long SalesId { get; set; }

    public long CustId { get; set; }

    public DateTime Date { get; set; }


}
