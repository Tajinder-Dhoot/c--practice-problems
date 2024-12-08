using Ingredients;

namespace Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }
    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public void StepsToString()
    {
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Name}.{ingredient.PreparationInstructions}");
        }
    }
}
