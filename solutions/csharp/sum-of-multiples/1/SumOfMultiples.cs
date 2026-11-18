public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        var items = new HashSet<int>();
        foreach (int multiple in multiples)
        {
            if (multiple == 0)
            {
                continue;
            }
            int i = 1;
            while (multiple * i < max)
            {
                items.Add(multiple * i);
                i++;
            }
        }
        return items.Sum();
    }
}