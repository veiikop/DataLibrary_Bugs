namespace DateLibrary_Bugs;

public static class DateUtils
{
    private static readonly Dictionary<DayOfWeek, string> RussianDaysOfWeek = new Dictionary<DayOfWeek, string>
    {
        { DayOfWeek.Monday, "Понедельник" },
        { DayOfWeek.Tuesday, "Вторник" },
        { DayOfWeek.Wednesday, "Среда" },
        { DayOfWeek.Thursday, "Четверг" },
        { DayOfWeek.Friday, "Пятница" },
        { DayOfWeek.Saturday, "Суббота" },
        { DayOfWeek.Sunday, "Воскресенье" }
    };

    public static string GetDayOfWeek(DateTime dt)
    {
        return RussianDaysOfWeek[dt.DayOfWeek];
    }

    public static int GetDateDifference(DateTime date1, DateTime date2)
    {
        TimeSpan diff = date1 - date2;
        return Math.Abs(diff.Days);
    }

    public static DateTime AddDays(DateTime date, int days)
    {
        return date.AddDays(days);
    }

    public static DateTime SubtractDays(DateTime date, int days)
    {
        return date.AddDays(-days);
    }

    public static void ProcessAllDateOperations(string dateStr1, string dateStr2, int daysToAdd)
    {
        if (!DateValidator.IsValidDate(dateStr1, "dd/MM/yyyy") ||
            !DateValidator.IsValidDate(dateStr2, "dd/MM/yyyy"))
        {
            Console.WriteLine("Одна или обе даты невалидны");
            return;
        }

        DateTime dt1 = DateParser.ParseDate(dateStr1, "dd/MM/yyyy");
        DateTime dt2 = DateParser.ParseDate(dateStr2, "dd/MM/yyyy");

        string converted = DateFormatter.ConvertToUSFormat(dateStr1);
        string dayOfWeek = GetDayOfWeek(dt1);
        int diff = GetDateDifference(dt1, dt2);
        DateTime newDate = AddDays(dt1, daysToAdd);
        bool isLeap = DateValidator.IsLeapYear(dt1.Year);

        Console.WriteLine($"Первая дата: {converted}");
        Console.WriteLine($"День недели: {dayOfWeek}");
        Console.WriteLine($"Разница: {diff} дней");
        Console.WriteLine($"Дата после добавления {daysToAdd} дней: {newDate:dd/MM/yyyy}");
        Console.WriteLine($"Високосный год: {isLeap}");
    }
}