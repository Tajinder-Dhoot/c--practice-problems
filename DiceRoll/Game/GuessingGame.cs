using DiceRoll.UserInterface;

namespace DiceRoll.Game;

public class GuessingGame
{
    public Dice Dice { get; private set; }
    public int GuessesAllowed { get; private set; }

    public GuessingGame(Dice dice, int guessesAllowed)
    {
        this.Dice = dice;
        this.GuessesAllowed = guessesAllowed;
    }

    public GameResult PlayGame()
    {
        var diceRollResult = Dice.RollDice();
        Console.WriteLine(diceRollResult);
        Console.WriteLine("Dice Rolled. Guess what number it shows in " + GuessesAllowed + " tries.");

        while (GuessesAllowed > 0)
        {
            int userInput = ConsoleInterface.ReadUserInput("Enter a number: ");
            if(userInput == diceRollResult)
            {
                return GameResult.Victory;
            }
            Console.WriteLine("Wrong number");
            GuessesAllowed--;
        }
        return GameResult.Loss;
    }

    public void PrintResult(GameResult result)
    {
        string message = result == GameResult.Loss ? "You Lost :(" : "You Won :)";
        Console.WriteLine(message);
    }
}