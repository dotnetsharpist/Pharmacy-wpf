using System;
using System.ComponentModel.DataAnnotations;

namespace Pharmcy.Entities.Medicines;

public sealed class Medicine : Auditable
{
    public long MedId { get; set; }


    [MaxLength(50)]
    public string MedCategory { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Price { get; set; } = string.Empty;

    public DateTime CreatTime { get; set; }

    public DateTime EndTime { get; set; }

    public string image_path { get; set; } = string.Empty;

}
