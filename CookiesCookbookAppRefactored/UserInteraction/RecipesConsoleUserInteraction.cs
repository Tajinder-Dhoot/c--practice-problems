using CookiesCookbookAppRefactured.Recipes;
using CookiesCookbookAppRefactured.Recipes.Ingredients;
using CookiesCookbookAppRefactored.Recipes.Ingredients;

namespace CookiesCookbookAppRefactored.UserInteraction;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        if (recipes.Any())
        {
            int counter = 1;
            Console.WriteLine("Existing Recipes are:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"***** {counter} *****");
                Console.WriteLine(recipe.ToString());
                counter++;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! "
            + "Available ingredients are: ");

        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine($"{ingredient}");
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        Console.WriteLine("Enter the ingredient id to add to the recipe. "
            + "Enter 0 to finish adding ingredients.");

        var ingredients = new List<Ingredient>();
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                if (id == 0)
                {
                    break;
                }

                var ingredient = _ingredientsRegister.All.FirstOrDefault(ingredient => ingredient.Id == id);
                if (ingredient != null)
                {
                    ingredients.Add(ingredient);
                }
                else
                {
                    Console.WriteLine("Invalid ingredient id. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }

        return ingredients;
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
