using System;

namespace DiceRoll.UserInterface
{
    public class ConsoleInterface
    {
        public static int ReadUserInput(string message)
        {
            int result;
            do
            {
                Console.WriteLine(message);
            } while (!(int.TryParse(Console.ReadLine(), out result)));
            return result;
        }
    }
}