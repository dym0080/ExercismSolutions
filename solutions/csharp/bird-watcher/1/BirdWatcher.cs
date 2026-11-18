class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return [0, 2, 5, 3, 7, 8, 4];
    }

    public int Today()
    {
        return birdsPerDay[^1];
    }

    public void IncrementTodaysCount()
    {
        birdsPerDay[^1] += 1;
    }

    public bool HasDayWithoutBirds()
    {
        return birdsPerDay.Contains(0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        var result = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            result += birdsPerDay[i];
        }
        return result;
    }

    public int BusyDays()
    {
        var result = 0;
        for (int i = 0; i < this.birdsPerDay.Length; i++)
        {
            if (birdsPerDay[i] >= 5)
            {
                result++;
            }
        }
        return result;
    }
}
