using Pharmcy.Constans;
using System;
namespace Pharmcy.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var dtTime = DateTime.UtcNow;

        //dtTime.AddHours(TimeConstants.UTC);
        dtTime.AddHours(TimeConstants.UTC);


        return dtTime;
    }
}
