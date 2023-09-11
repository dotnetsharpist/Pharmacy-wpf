using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Pharmcy.Entities.Purchasing;

public class Purchasing : Auditable
{
    

    public long PurchaseId { get; set; }

    public long CustId { get; set; }

    public long MedId { get; set; }

    public int Amount { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(50)]
    public string PurName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string image_path { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Description { get; set; } = string.Empty;
}



