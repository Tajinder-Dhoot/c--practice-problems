using DataAccess;
using Enums;
using Ingredients;
using UserInteraction;

namespace CookiesCookbookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileType = FileExtensions.JSON;
            Console.WriteLine(fileType);

            IEnumerable<Ingredient> availableIngredients = [
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate()
            ];

            // print existing recipes
            string savedRecipesFilepath = $"./DataRepository/recipes.{fileType.ToString().ToLower()}";
            List<string>? savedRecipes = ReadFile.AllLines(savedRecipesFilepath);
            DisplayToUser.PrintSavedRecipesToConsole(availableIngredients, fileType);

            // print all ingredients
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
            DisplayToUser.PrintIngredientsToConsole(availableIngredients);

            // select ingredients for a new recipe
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
            string? input = Console.ReadLine();

            var idsSelectedByUser = new List<int>();
            while (int.TryParse(input, out int inputId))
            {
                if(inputId > 0 && inputId <= 4)
                {
                    Console.WriteLine("valid input");
                    idsSelectedByUser.Add(inputId);
                }
                input = Console.ReadLine();
            }

            IEnumerable<Ingredient> ingredientsSelected = availableIngredients.Where(ingredient =>  idsSelectedByUser.Contains(ingredient.Id));
            savedRecipesFilepath = $"./DataRepository/recipes.{fileType.ToString().ToLower()}";

            // print new recipe
            if(ingredientsSelected.Any())
            {
                Console.WriteLine("recipe added:");
                DisplayToUser.PrintRecipeToConsole(ingredientsSelected);

                // store recipe to file
                string recipeIds = String.Join(',', idsSelectedByUser);
                if(fileType.Equals(FileExtensions.TXT))
                {
                    WriteFile.AppendTotextFile(savedRecipesFilepath, recipeIds);
                }
                else if(fileType.Equals(FileExtensions.JSON))
                {
                    WriteFile.AppendToJsonFile(savedRecipesFilepath, recipeIds);
                }
            }
            else
            {
                Console.WriteLine("No ingredients have been selected. Recipe will not be saved.");
            }

            //press any key to exit
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
