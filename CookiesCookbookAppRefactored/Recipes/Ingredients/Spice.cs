namespace CookiesCookbookAppRefactured.Recipes.Ingredients
{
    public abstract class Spice : Ingredient
    {
        public override string PreparationSteps =>
            $"Take half a teaspoon. Add to other ingredients.";
    }
}
