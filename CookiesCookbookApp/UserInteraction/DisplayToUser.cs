using DataAccess;
using Recipes;
using Ingredients;

namespace UserInteraction;


public class DisplayToUser
{
    public static void PrintToConsole(List<string> listOfStrings)
    {
        foreach (var item in listOfStrings) {
            Console.WriteLine(item);
        }
    }

    public static void PrintToConsole(List<string> listOfStrings, string message)
    {
        var listItemsCounter = 1;
        Console.WriteLine($"*****{listItemsCounter}*****");

        foreach (var item in listOfStrings) {
            Console.WriteLine(item);
        }
    }

    public static void PrintRecipeToConsole(IEnumerable<Ingredient> ingredients)
    {
        var recipe = new Recipe(ingredients);
        var recipeSteps = recipe.StepsToString();
        foreach (var step in recipeSteps)
        {
            Console.WriteLine(step);
        }
    }

    public static void PrintSavedRecipesToConsole(IEnumerable<Ingredient> availableIngredients)
    {
        Console.WriteLine("Exisiting recipes are:");
        string savedRecipesFilepath = "./DataRepository/recipes.txt";
        List<string>? savedRecipes = ReadFile.Read(savedRecipesFilepath);
        if(savedRecipes != null)
        {
            var recipesCounter = 1;
            foreach (var savedRecipe in savedRecipes)
            {
                List<string> recipeIngredientIds = [.. savedRecipe.Split(',')];
                IEnumerable<Ingredient> recipeIngredients = availableIngredients.Where(ingredient => recipeIngredientIds.Contains(ingredient.Id.ToString()));
                Console.WriteLine($"*****{recipesCounter}*****");
                var recipe = new Recipe(recipeIngredients);
                var recipeSteps = recipe.StepsToString();
                PrintToConsole(recipeSteps);
                recipesCounter +=1;
            }
        }
    }

    public static void PrintIngredientsToConsole(IEnumerable<Ingredient> ingredients)
    {
        foreach (Ingredient ingredient in ingredients) {
            Console.WriteLine(ingredient.Id + ". " + ingredient.Name);
        }
    }
}
