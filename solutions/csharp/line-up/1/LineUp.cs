public static class LineUp
{
    public static string Format(string name, int number)
    {
       var str ="";
       var num = number % 100;
       if(num>10 && num < 14)
        {
            str = "th";
        }
        else
        {
            switch (number %10)
            {
                case 1:
                    str = "st";
                    break;
                case 2:
                    str = "nd";
                    break;
                case 3:
                    str = "rd";
                    break;
                default:
                    str = "th";
                    break;
            }
        }
        
       return $"{name}, you are the {number}{str} customer we serve today. Thank you!";
    }
}
