public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        return  Enumerable.Range(1, max).Sum() * Enumerable.Range(1, max).Sum();
    }

    public static int CalculateSumOfSquares(int max)
    {
        return Enumerable.Range(1, max).Sum(x => x * x);
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) -CalculateSumOfSquares(max) ;
    }
}