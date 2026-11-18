using System;
using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        int width = 60;
    
        string text = $"{studentA} ♡ {studentB}";
    
        int totalPadding = width - text.Length;
    
        int leftPadding = totalPadding / 2;
        int rightPadding = totalPadding - leftPadding +1;
    
        return new string(' ', leftPadding) + text + new string(' ', rightPadding);
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        string initials1 = GetInitials(studentA);
        string initials2 = GetInitials(studentB);

        string message = $"{initials1}  +  {initials2}";

        string[] heart =
        {
            "     ******       ******",
            "   **      **   **      **",
            " **         ** **         **",
            "**            *            **",
            "**                         **",
            $"**     {message.PadRight(15)}     **",
            " **                       **",
            "   **                   **",
            "     **               **",
            "       **           **",
            "         **       **",
            "           **   **",
            "             ***",
            "              *"
        };

        return string.Join(Environment.NewLine, heart);
    }

    public static string DisplayGermanExchangeStudents(
        string studentA,
        string studentB,
        DateTime start,
        float hours)
    {
        var culture = new CultureInfo("de-DE");

        string date = start.ToString("dd.MM.yyyy", culture);
        string duration = hours.ToString("N2", culture);

        return $"{studentA} and {studentB} have been dating since {date} - that's {duration} hours";
    }


    private static string GetInitials(string name)
    {
        var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0) return "";

        if (parts.Length == 1)
            return parts[0][0] + ".";

        return $"{parts[0][0]}. {parts[1][0]}.";
    }
}