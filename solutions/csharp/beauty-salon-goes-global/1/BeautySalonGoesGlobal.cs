
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
         var localTime = DateTime.Parse(appointmentDateDescription);

        var timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));

        return TimeZoneInfo.ConvertTimeToUtc(localTime, timeZone);;
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),

            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),

            AlertLevel.Late => appointment.AddMinutes(-30),

            _ => appointment
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
         var timeZone = TimeZoneInfo.FindSystemTimeZoneById(GetTimeZoneId(location));

        var now = timeZone.IsDaylightSavingTime(dt);
        var weekAgo = timeZone.IsDaylightSavingTime(dt.AddDays(-7));

        return now != weekAgo;
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        CultureInfo culture = location switch
        {
            Location.NewYork => new CultureInfo("en-US"),
            Location.London => new CultureInfo("en-GB"),
            Location.Paris => new CultureInfo("fr-FR"),
            _ => CultureInfo.InvariantCulture
        };

        if (DateTime.TryParse(dtStr, culture,
            DateTimeStyles.None, out DateTime result))
        {
            return result;
        }

        return new DateTime(1, 1, 1);
    }

    private static string GetTimeZoneId(Location location)
    {
        bool isWindows = RuntimeInformation
            .IsOSPlatform(OSPlatform.Windows);

        if (isWindows)
        {
            return location switch
            {
                Location.NewYork => "Eastern Standard Time",
                Location.London => "GMT Standard Time",
                Location.Paris => "W. Europe Standard Time",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        return location switch
        {
            Location.NewYork => "America/New_York",
            Location.London => "Europe/London",
            Location.Paris => "Europe/Paris",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
