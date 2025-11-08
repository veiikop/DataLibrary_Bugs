namespace DateLibrary_Bugs;

public class DateManager
{
    private List<string> dates = new List<string>();

    public void AddDate(string date)
    {
        if (ValidateDate(date))
        {
            dates.Add(date);
            Console.WriteLine($"Дата добавлена: {date}");
        }
        else
        {
            Console.WriteLine($"Ошибка: Некорректная дата - {date}");
        }
    }

    public void ProcessAllDates()
    {
        foreach (var date in dates)
        {
            var parts = date.Split('/');
            if (parts.Length == 3)
            {
                int y = int.Parse(parts[2]), m = int.Parse(parts[1]), d = int.Parse(parts[0]);
                if (DateUtils.CheckDate(y, m, d))
                {
                    DateTime dt = new DateTime(y, m, d);
                    Console.WriteLine($"{date} - {DateUtils.GetDayOfWeek(dt)}");
                }
                else
                {
                    Console.WriteLine($"{date} - НЕВАЛИДНАЯ ДАТА");
                }
            }
        }
    }

    public bool ValidateDate(string date)
    {
        try
        {
            var parts = date.Split('/');
            if (parts.Length != 3) return false;

            int year = int.Parse(parts[2]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[0]);

            return DateUtils.CheckDate(year, month, day);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка формата: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка валидации: {ex.Message}");
            return false;
        }
    }
}