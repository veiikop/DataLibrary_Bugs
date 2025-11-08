namespace DateLibrary_Bugs;

public class DateManager
{
    private List<string> dates = new List<string>();

    public void AddDate(string date)
    {
        if (ValidateDate(date))
        {
            dates.Add(date);
        }
        else
        {
            Console.WriteLine($"Некорректная дата: {date}");
        }
    }

    public void ProcessAllDates()
    {
        Console.WriteLine("Обработка всех дат:");
        foreach (var date in dates)
        {
            ProcessSingleDate(date);
        }
    }

    private void ProcessSingleDate(string date)
    {
        if (DateValidator.IsValidDate(date, "dd/MM/yyyy"))
        {
            DateTime dt = DateParser.ParseDate(date, "dd/MM/yyyy");
            Console.WriteLine($"{date} - {DateUtils.GetDayOfWeek(dt)}");
        }
        else
        {
            Console.WriteLine($"{date} - НЕВАЛИДНАЯ ДАТА");
        }
    }

    public bool ValidateDate(string date)
    {
        return DateValidator.IsValidDate(date, "dd/MM/yyyy");
    }
}