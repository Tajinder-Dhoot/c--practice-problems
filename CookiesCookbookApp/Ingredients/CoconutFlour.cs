namespace Ingredients;
public class CoconutFlour : Ingredient
{
    public CoconutFlour()
    {
        
    }
    public override int Id { get; } = 2;

    public override string Name { get; } = "Coconut Flour";

    public override string PreparationInstructions { get; } = "Sieve, Add to other ingredients";
}
