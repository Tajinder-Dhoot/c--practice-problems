namespace CookiesCookbookAppRefactured.Recipes.Ingredients
{
    public abstract class Flour : Ingredient
    {
        public override string PreparationSteps =>
            $"Sieve. ${base.PreparationSteps}";
    }
}
