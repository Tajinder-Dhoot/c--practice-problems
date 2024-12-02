using System;

namespace CookiesCookbookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<int> userInput = [1, 3, 4];
            var ingredients = new List<Ingredient>();

            ingredients.Add(new WheatFlour());

            var recipe1 = new Recipe([new WheatFlour(), new CoconutFlour()]);
        }
    }

    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }
        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }
    }

    public class Ingredient
    {
        public Ingredient()
        {

        }

        public virtual int Id { get; }

        public virtual string Name { get; } = "An Ingredient";

        public virtual string PreparationInstructions { get; } = " ..."
    }

    public class WheatFlour : Ingredient
    {
        public WheatFlour()
        {
            
        }

        public override int Id { get; } = 1;

        public override string Name { get; } = "Wheat Flour";

        public override string PreparationInstructions { get; } = "Sieve, Add to other ingredients";
    }

    public class CoconutFlour : Ingredient
    {
        public CoconutFlour()
        {
            
        }
        public override int Id { get; } = 2;

        public override string? Name { get; } = "Coconut Flour";

        public override string PreparationInstructions { get; } = "Sieve, Add to other ingredients";
    }

    public class Butter : Ingredient
    {
        public override int Id { get; } = 3;

        public override string? Name { get; } = "Butter";

        public override string PreparationInstructions { get; } = "Melt on low heat. Add to other ingredients";
    }

    public class Chocolate : Ingredient
    {
        public override int Id { get; } = 4;

        public override string Name { get; } = "Chocolate";

        public override string PreparationInstructions { get; } = "Melt in a watter bath. Add to other ingredients";
    }
}