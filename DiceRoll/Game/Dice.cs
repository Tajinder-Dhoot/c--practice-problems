using DiceRoll.Utils;

namespace DiceRoll.Game;

public class Dice
{
    public int SidesOfDice { get; private set; }

    public Dice(int sidesOfDice)
    {
        this.SidesOfDice = sidesOfDice;
    }

    public int RollDice()   
    {
        return NumberGenerator.randomNumber(1, SidesOfDice + 1);
    }
}