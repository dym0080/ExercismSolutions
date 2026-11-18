static class LogLine
{
    public static string Message(string logLine)
    {
        var samples = logLine.Split(':');
        return samples[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        var samples = logLine.Split(':');
        return samples[0].Trim().Trim('[',']').ToLower();
    }

    public static string Reformat(string logLine)
    {
        var samples = logLine.Split(':');
        var level = samples[0].Trim().Trim('[', ']').ToLower();
        var message = samples[1].Trim();

        return $"{message} ({level})";
    }
}
