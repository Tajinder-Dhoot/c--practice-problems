using Recipes;
using Ingredients;

namespace CookiesCookbookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Create a new cookie recipe! Available ingredients are:");

            // print all ingredients
            IEnumerable<Ingredient> availableIngredients = [
                new WheatFlour(),
                new CoconutFlour(),
                new Butter(),
                new Chocolate()
            ];

            foreach (Ingredient ingredient in availableIngredients) {
                Console.WriteLine(ingredient.Id + ". " + ingredient.Name);
            }

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
                new Recipe(ingredientsSelected).StepsToString();
            }

            //press any key to exit
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
