using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateLibrary_Bugs
{
    public static class DateValidator
    {
        public static bool IsValidDate(string date, string format)
        {
            if (string.IsNullOrEmpty(date)) return false;

            try
            {
                DateTime dt = DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }
    }
}
