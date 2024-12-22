using System.Runtime.CompilerServices;
using System.Collections;
using CookiesCookbookAppRefactured.Recipes;
using CookiesCookbookAppRefactured.Recipes.Ingredients;
using System.Threading.Tasks.Dataflow;

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipeApp(
    new RecipesRepository(new StringsTextualRepository(), ingredientsRegister),
    new RecipesConsoleUserInteraction(ingredientsRegister)
);
cookiesRecipesApp.Run();

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

    public void Run(string filepath = "recipes.txt")
    {
        var allRecipes = _recipesRepository.Read(filepath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        
        _recipesUserInteraction.PromptToCreateRecipe();

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if(ingredients.Any())
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

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> recipes);
}

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsTextualRepository _stringsTextualRepository;

    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesRepository(IStringsTextualRepository stringsTextualRepository, IIngredientsRegister ingredientsRegister)
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
        foreach(var recipe in recipes)
        {
            var ingredientIds = recipe.Ingredients.Select(ingredient => ingredient.Id.ToString());
            recipesAsStrings.Add(string.Join(",", ingredientIds));
        }
        
        _stringsTextualRepository.Write(filePath, recipesAsStrings);
    }
}

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}

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

    public void Exit()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> recipes)
    {
        if(recipes.Any())
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
}

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }
    Ingredient GetById(int id);
}

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } =
    [
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    ];

    public Ingredient GetById(int id)
    {
        return All.FirstOrDefault(ingredient => ingredient.Id == id)!;
    }
}

public interface IStringsTextualRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}

public class StringsTextualRepository : IStringsTextualRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        if(File.Exists(filePath)) {
            var fileContents = File.ReadAllText(filePath);
            return [.. fileContents.Split(Separator)];
        }
        return [];
    }

    public void Write(string filepath, List<string> strings)
    {
        File.WriteAllText(filepath, string.Join(Separator, strings));
    }
}
