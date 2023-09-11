using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmcy.Entities.Customers;

public sealed class Customer : Auditable
{
    public long CustID { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }

    [MaxLength(50)]
    public string ContactAdd { get; set; } = string.Empty;

    [MaxLength(50)]
    public string CustEmail { get; set; } = string.Empty;

    [MaxLength(50)]
    public string CustPass { get; set; } = string.Empty;

    [MaxLength(100)]
    public string image_path { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }



};
