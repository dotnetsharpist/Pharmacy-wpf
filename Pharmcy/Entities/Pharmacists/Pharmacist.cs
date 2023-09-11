
using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmcy.Entities.Pharmacists;

public sealed class Pharmacist : Auditable
{
    public long PharId { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    public int Age { get; set; }

    [MaxLength(50)]
    public string ContactAdd { get; set; } = string.Empty;

    [MaxLength(50)]
    public string PharEmail { get; set; } = string.Empty;

    [MaxLength(50)]
    public string PharPass { get; set; } = string.Empty;

    
    public string salt { get; set; } = string.Empty;

    [MaxLength(20)]
    public string gender { get; set; } = string.Empty;

    public DateTime birth_date { get; set; }

    public string image_path { get; set; } = string.Empty;

}
