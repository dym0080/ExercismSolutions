using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {

        if (identifier == "") return "";

        StringBuilder result = new StringBuilder();
        bool upperNext = false;

        foreach (char c in identifier)
        {
            if (c == ' ')
            {
                result.Append('_');
                continue;
            }

            if (char.IsControl(c))
            {
                result.Append("CTRL");
                continue;
            }

            if (c == '-')
            {
                upperNext = true;
                continue;
            }

            char current = c;

            if (upperNext)
            {
                current = char.ToUpper(current);
                upperNext = false;
            }

            if (current >= 'α' && current <= 'ω')
            {
                continue;
            }

            if (char.IsLetter(current) || current == '_')
            {
                result.Append(current);
            }
        }

        return result.ToString();
    }
}
