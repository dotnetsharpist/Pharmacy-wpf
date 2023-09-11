
using Pharmcy.Helpers;
using System;

namespace Pharmcy.Entities;

public abstract class Auditable
{
    public DateTime CreatedAT { get; set; }
    public DateTime UpdatedAT { get; set; }

    public Auditable()
    {
        CreatedAT = TimeHelper.GetDateTime();
        UpdatedAT = TimeHelper.GetDateTime();
    }
}
