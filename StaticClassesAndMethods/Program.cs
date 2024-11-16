using System;

namespace PracticeProblems
{
    static class NumberToDayOfWeekTranslator
    {
        public static string Translate(int num)
        {
            switch (num)
            {  
                case 1: return "Monday";
                case 2: return "Tuesday";
                case 3: return "Wednesday";
                case 4: return "Thursday";
                case 5: return "Friday";
                case 6: return "Saturday";
                case 7: return "Sunday";
                default: return "Invalid day of week";
            };
        }
    }

    class MainClass
    {
        public static void Main()
        {
            Console.WriteLine(NumberToDayOfWeekTranslator.Translate(0));
            Console.WriteLine(NumberToDayOfWeekTranslator.Translate(1));
            Console.WriteLine(NumberToDayOfWeekTranslator.Translate(5));
        }
    }
}