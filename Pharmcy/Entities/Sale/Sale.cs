using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmcy.Entities.Sales;

public sealed class Sale : Auditable
{
    public long SalesId { get; set; }

    public long PharId { get; set; }

    public long CustId { get; set; }

    public long MedId { get; set; }

    public long PurchaseId { get; set; }

    public int Count { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(50)]
    public string TotalAmount { get; set; } = string.Empty;

}
