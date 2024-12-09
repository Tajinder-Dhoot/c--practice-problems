using Ingredients;

namespace Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }
    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public List<string> StepsToString()
    {
        return Ingredients.Select(ingredient => $"{ingredient.Name}.{ingredient.PreparationInstructions}").ToList();
    }
}
