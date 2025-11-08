namespace DateLibrary_Bugs;

class Program
{
    static void Main(string[] args)
    {
        // Тестирование DateManager
        DateManager manager = new DateManager();

        manager.AddDate("25/12/2023");
        manager.AddDate("01/01/2024");
        manager.AddDate("29/02/2020"); // Високосный год
        manager.AddDate("29/02/2023"); // Невалидная
        manager.AddDate("31/04/2023"); // Невалидная
        manager.AddDate("15/13/2023"); // Невалидная

        manager.ProcessAllDates();

        Console.WriteLine("\nОперации с датами:");
        DateUtils.ProcessAllDateOperations("25/12/2023", "01/01/2024", 7);

        // Тестирование отдельных функций
        Console.WriteLine("\nТестирование функций:");

        string converted = DateFormatter.ConvertToUSFormat("25/12/2023");
        Console.WriteLine($"Конвертированная дата: {converted}");

        // Тестирование високосных годов
        TestLeapYears();

        // Тестирование валидации дат
        TestDateValidation();
    }

    static void TestLeapYears()
    {
        Console.WriteLine("\nТестирование високосных годов:");
        Console.WriteLine($"2020 високосный: {DateValidator.IsLeapYear(2020)}"); // true
        Console.WriteLine($"2024 високосный: {DateValidator.IsLeapYear(2024)}"); // true
        Console.WriteLine($"1900 високосный: {DateValidator.IsLeapYear(1900)}"); // false
        Console.WriteLine($"2000 високосный: {DateValidator.IsLeapYear(2000)}"); // true
    }

    static void TestDateValidation()
    {
        Console.WriteLine("\nТестирование валидации дат:");
        Console.WriteLine($"29/02/2020 валидна: {DateValidator.IsValidDate("29/02/2020", "dd/MM/yyyy")}"); // true
        Console.WriteLine($"29/02/2023 валидна: {DateValidator.IsValidDate("29/02/2023", "dd/MM/yyyy")}"); // false
        Console.WriteLine($"31/04/2023 валидна: {DateValidator.IsValidDate("31/04/2023", "dd/MM/yyyy")}"); // false
        Console.WriteLine($"15/13/2023 валидна: {DateValidator.IsValidDate("15/13/2023", "dd/MM/yyyy")}"); // false
    }
}
