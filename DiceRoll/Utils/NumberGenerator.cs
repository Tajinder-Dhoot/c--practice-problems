namespace DiceRoll.Utils;

public class NumberGenerator
{
    public static int randomNumber(int start, int end)
    {
        return new Random().Next(start, end);
    }
}