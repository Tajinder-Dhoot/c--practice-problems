using CookiesCookbookAppRefactured.Recipes;
using CookiesCookbookAppRefactured.Recipes.Ingredients;

namespace CookiesCookbookAppRefactored.UserInteraction;

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    IEnumerable<Ingredient> ReadIngredientsFromUser();
    void PromptToCreateRecipe();
    void Exit();
}