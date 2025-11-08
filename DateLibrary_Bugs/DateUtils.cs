namespace DateLibrary_Bugs;

public class DateUtils
{
    public static string ConvertDate(string date, int format)
    {
        if (format == 1)
        {
            var parts = date.Split('/');
            if (parts.Length == 3)
                return parts[1] + "/" + parts[0] + "/" + parts[2];
        }
        else if (format == 2)
        {
            var parts = d.Split('/');
            if (parts.Length == 3)
                return parts[1] + "/" + parts[0] + "/" + parts[2];
        }
        return d;
    }

    public static string GetDayOfWeek(DateTime dt)
    {
        var day = dt.DayOfWeek;
        if (day == DayOfWeek.Monday) return "Понедельник";
        else if (day == DayOfWeek.Tuesday) return "Вторник";
        else if (day == DayOfWeek.Wednesday) return "Среда";
        else if (day == DayOfWeek.Thursday) return "Четверг";
        else if (day == DayOfWeek.Friday) return "Пятница";
        else if (day == DayOfWeek.Saturday) return "Суббота";
        else return "Воскресенье";
    }

    public static bool CheckDate(int year, int month, int day)
    {
        if (year < 1 || year > 9999) return false;
        if (month < 1 || month > 12) return false;
        if (day < 1) return false;

        int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (month == 2 && IsLeapYear(year))
        {
            if (day > 29) return false;
        }
        else
        {
            if (day > daysInMonth[month - 1]) return false;
        }

        return true;
    }

    public static int DateDiff(DateTime d1, DateTime d2)
    {
        TimeSpan diff = d1 - d2;
        return Math.Abs(diff.Days);
    }

    public static DateTime AddDays(DateTime d, int days)
    {
        return d.AddDays(days);
    }

    public static DateTime SubtractDays(DateTime d, int days)
    {
        return d.AddDays(-days);
    }

    public static bool IsLeapYear(int year)
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    public static void ProcessAllDateOperations(string dateStr1, string dateStr2, int daysToAdd)
    {
        var parts1 = dateStr1.Split('/');
        var parts2 = dateStr2.Split('/');
        
        if (parts1.Length == 3 && parts2.Length == 3)
        {
            int y1 = int.Parse(parts1[2]), m1 = int.Parse(parts1[1]), d1 = int.Parse(parts1[0]);
            int y2 = int.Parse(parts2[2]), m2 = int.Parse(parts2[1]), d2 = int.Parse(parts2[0]);
            
            if (CheckDate(y1, m1, d1) && CheckDate(y2, m2, d2))
            {
                DateTime dt1 = new DateTime(y1, m1, d1);
                DateTime dt2 = new DateTime(y2, m2, d2);
                
                string converted = ConvertDate(dateStr1, 1);
                string dayOfWeek = GetDayOfWeek(dt1);
                int diff = DateDiff(dt1, dt2);
                DateTime newDate = AddDays(dt1, daysToAdd);
                bool leap = IsLeapYear(y1);
                
                Console.WriteLine($"Первая дата: {converted}");
                Console.WriteLine($"День недели: {dayOfWeek}");
                Console.WriteLine($"Разница: {diff} дней");
                Console.WriteLine($"Вторая дата: {newDate:dd/MM/yyyy}");
                Console.WriteLine($"Високосный год: {leap}");
            }
        }
    }
}