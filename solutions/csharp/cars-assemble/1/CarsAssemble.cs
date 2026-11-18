static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        if(speed == 0) return 0.0;
        if(speed >= 1 && speed <= 4) return 1.0;
        if(speed >= 5 && speed <= 8) return 0.9;
        if(speed == 9) return 0.8;
        if(speed == 10) return 0.77;
        
        throw new ArgumentException("Speed must be between 0 and 10.");
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        var rate = SuccessRate(speed);
        return SuccessRate(speed) * speed * 221;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int) ProductionRatePerHour(speed) / 60;
    }
}
