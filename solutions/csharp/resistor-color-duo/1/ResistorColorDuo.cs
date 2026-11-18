public static class ResistorColorDuo
{
    private static string[] arrColors ={
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white"
    };

    public static int Value(string[] colors)
    {
        if (colors.Length == 1)
        {
            return Array.IndexOf(arrColors, colors[0]);
        }
        return 10 * Array.IndexOf(arrColors, colors[0]) + Array.IndexOf(arrColors, colors[1]);
    }
}
