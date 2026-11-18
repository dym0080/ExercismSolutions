public static class Darts
{
    public static int Score(double x, double y)
    {
        var z = Math.Sqrt(x * x + y * y);
        if (z <= 1)
        {
            return 10;
        }
        else if (z <= 5)
        {
            return 5;
        }
        else if (z <= 10)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
