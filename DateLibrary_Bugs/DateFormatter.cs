using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateLibrary_Bugs
{
    public static class DateFormatter
    {
        public static string ConvertFormat(string date, string fromFormat, string toFormat)
        {
            if (DateValidator.IsValidDate(date, fromFormat))
            {
                DateTime dt = DateParser.ParseDate(date, fromFormat);
                return dt.ToString(toFormat);
            }
            return date;
        }

        public static string ConvertToUSFormat(string date)
        {
            return ConvertFormat(date, "dd/MM/yyyy", "MM/dd/yyyy");
        }

        public static string ConvertToEUFormat(string date)
        {
            return ConvertFormat(date, "MM/dd/yyyy", "dd/MM/yyyy");
        }
    }
}
