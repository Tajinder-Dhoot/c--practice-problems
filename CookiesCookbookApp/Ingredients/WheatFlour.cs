namespace Ingredients;

public class WheatFlour : Ingredient
{
    public WheatFlour()
    {
        
    }

    public override int Id { get; } = 1;

    public override string Name { get; } = "Wheat Flour";

    public override string PreparationInstructions { get; } = "Sieve, Add to other ingredients";
}
