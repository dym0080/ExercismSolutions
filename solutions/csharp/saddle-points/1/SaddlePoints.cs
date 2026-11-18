public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int r = 0; r < rows; r++)
        {
            int rowMax = Enumerable.Range(0, cols).Max(c => matrix[r, c]);

            for (int c = 0; c < cols; c++)
            {
                int value = matrix[r, c];

                int colMin = Enumerable.Range(0, rows).Min(i => matrix[i, c]);

                if (value == rowMax && value == colMin)
                {
                    yield return (r + 1, c + 1);
                }
            }
        }

    }
}
