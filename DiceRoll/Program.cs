using System;
using DiceRoll.Game;

class MainClass
{
    public static void Main()
    {
        Dice dice = new Dice(6);
        var guessingGame = new GuessingGame(dice, 2);
        GameResult gameResult= guessingGame.PlayGame();
        guessingGame.PrintResult(gameResult);
        Console.ReadKey();
    }
}    
