using System.Text;

namespace LeetCodePractice.Easy;

public class RomanDateTime
{
    private string IntToRoman(int num)
    {
        // Define the values and corresponding symbols
        var romanNumerals = new List<(int value, string symbol)>
        {
            (1000, "M"), (900, "CM"), (500, "D"), (400, "CD"),
            (100, "C"), (90, "XC"), (50, "L"), (40, "XL"),
            (10, "X"), (9, "IX"), (5, "V"), (4, "IV"), (1, "I")
        };

        var result = new StringBuilder();

        foreach (var (value, symbol) in romanNumerals)
        {
            while (num >= value)
            {
                result.Append(symbol);
                num -= value;
            }
        }

        return result.ToString();
    }

    public void DisplayRomanDateTime()
    {
        DateTime previousTime = DateTime.MinValue;

        ////while (true)
        ////{
        ////    // Get the current date and time
        ////    DateTime now = DateTime.Now;

        ////    if (now.Second != previousTime.Second)
        ////    {
        ////        string secondRoman = IntToRoman(now.Second);
        ////        Console.SetCursorPosition(0, 1);
        ////        Console.WriteLine($"Second: {secondRoman}".PadRight(Console.WindowWidth));
        ////    }

        ////    if (now.Minute != previousTime.Minute)
        ////    {
        ////        string minuteRoman = IntToRoman(now.Minute);
        ////        Console.SetCursorPosition(0, 1);
        ////        Console.WriteLine($"Minute: {minuteRoman}".PadRight(Console.WindowWidth));
        ////    }

        ////    if (now.Hour != previousTime.Hour)
        ////    {
        ////        string hourRoman = IntToRoman(now.Hour);
        ////        Console.SetCursorPosition(0, 1);
        ////        Console.WriteLine($"Hour: {hourRoman}".PadRight(Console.WindowWidth));
        ////    }

        ////    if (now.Day != previousTime.Day)
        ////    {
        ////        string dayRoman = IntToRoman(now.Day);
        ////        Console.SetCursorPosition(0, 0);
        ////        Console.WriteLine($"Day: {dayRoman}".PadRight(Console.WindowWidth));
        ////    }

        ////    if (now.Month != previousTime.Month)
        ////    {
        ////        string monthRoman = IntToRoman(now.Month);
        ////        Console.SetCursorPosition(0, 0);
        ////        Console.WriteLine($"Month: {monthRoman}".PadRight(Console.WindowWidth));
        ////    }

        ////    if (now.Year != previousTime.Year)
        ////    {
        ////        string yearRoman = IntToRoman(now.Year);
        ////        Console.SetCursorPosition(0, 0);
        ////        Console.WriteLine($"Year: {yearRoman}".PadRight(Console.WindowWidth));
        ////    }

        ////    // Update previousTime
        ////    previousTime = now;

        ////    // Wait for one second before updating
        ////    Thread.Sleep(1000);
        ////}

        while (true)
        {
            // Get the current date and time
            DateTime now = DateTime.Now;

            // Update only if the component has changed
            if (now.Day != previousTime.Day || now.Month != previousTime.Month || now.Year != previousTime.Year)
            {
                string dayRoman = IntToRoman(now.Day);
                string monthRoman = IntToRoman(now.Month);
                string yearRoman = IntToRoman(now.Year);
                string dateRoman = $"Date: {dayRoman}/{monthRoman}/{yearRoman}";

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(dateRoman.PadRight(Console.WindowWidth));
            }

            if (now.Hour != previousTime.Hour || now.Minute != previousTime.Minute || now.Second != previousTime.Second)
            {
                string hourRoman = IntToRoman(now.Hour);
                string minuteRoman = IntToRoman(now.Minute);
                string secondRoman = IntToRoman(now.Second);
                string timeRoman = $"Time: {hourRoman}:{minuteRoman}:{secondRoman}";

                Console.SetCursorPosition(0, 1);
                Console.WriteLine(timeRoman.PadRight(Console.WindowWidth));
            }

            // Update previousTime
            previousTime = now;

            // Wait for one second before updating
            Thread.Sleep(1000);
        }

    }
}
