using CookiesCookbookAppRefactured.Recipes;
using CookiesCookbookAppRefactored.Recipes;
using CookiesCookbookAppRefactored.UserInteraction;

namespace CookiesCookbookAppRefactored.App;

public class CookiesRecipeApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipeApp(
        IRecipesRepository recipesRepository,
        IRecipesUserInteraction receipesUserInteraction
        )
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = receipesUserInteraction;
    }

    public void Run(string filepath)
    {
        var allRecipes = _recipesRepository.Read(filepath);
        
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Any())
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filepath, allRecipes);
            _recipesUserInteraction.ShowMessage("Recipe Saved");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No ingredienst have been added." +
                "Recipe would not be saved.");
        }

        _recipesUserInteraction.Exit();
    }
}