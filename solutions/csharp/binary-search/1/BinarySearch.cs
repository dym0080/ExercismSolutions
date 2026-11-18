public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int left = 0;
        int right = input.Length - 1;
        while (left <= right)
        {
            int middle = (left + right) / 2;
            if (input[middle] == value)
            {
                return middle;
            }

            if (input[middle] > value)
            {
                // value is on the left
                right = middle - 1;
            }
            else
            {
                // value is on the right
                left = middle + 1;
            }
        }
        return -1;
    }
}