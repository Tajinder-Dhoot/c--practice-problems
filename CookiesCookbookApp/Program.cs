using DataAccess;
using Ingredients;
using UserInteraction;

namespace CookiesCookbookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            IEnumerable<Ingredient> availableIngredients = [
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate()
            ];

            // print existing recipes
            DisplayToUser.PrintSavedRecipesToConsole(availableIngredients);

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
            
            // print new recipe
            if(ingredientsSelected.Any())
            {
                Console.WriteLine("recipe added:");
                DisplayToUser.PrintRecipeToConsole(ingredientsSelected);

                // store recipe to file
                string recipeIds = String.Join(',', idsSelectedByUser);
                string savedRecipesFilepath = "./DataRepository/recipes.txt";
                WriteFile.Write(savedRecipesFilepath, recipeIds);
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
