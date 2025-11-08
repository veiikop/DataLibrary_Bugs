using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateLibrary_Bugs
{
    public static class DateParser
    {
        public static DateTime ParseDate(string date, string format)
        {
            return DateTime.ParseExact(date, format,
                System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
