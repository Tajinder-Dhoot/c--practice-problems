using CookiesCookbookAppRefactored.DataAccess;
using CookiesCookbookAppRefactored.Recipes.Ingredients;
using CookiesCookbookAppRefactured.Recipes;
using CookiesCookbookAppRefactured.Recipes.Ingredients;

namespace CookiesCookbookAppRefactored.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsTextualRepository;

    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesRepository(IStringsRepository stringsTextualRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringsTextualRepository = stringsTextualRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(",").Select(int.Parse);
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var ingredient = _ingredientsRegister.GetById(textualId);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public List<Recipe> Read(string filePath)
    {
        var recipesFromFiles = _stringsTextualRepository.Read(filePath); // ["1,2,3", "4,5,6", "7,8"]
        var recipes = new List<Recipe>();
        foreach (var recipeFromFile in recipesFromFiles)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    public void Write(string filePath, List<Recipe> recipes)
    {
        List<string> recipesAsStrings = [];
        foreach (var recipe in recipes)
        {
            var ingredientIds = recipe.Ingredients.Select(ingredient => ingredient.Id.ToString());
            recipesAsStrings.Add(string.Join(",", ingredientIds));
        }

        _stringsTextualRepository.Write(filePath, recipesAsStrings);
    }
}
