namespace CookiesCookbookAppRefactured.Recipes.Ingredients
{
    public class Sugar : Ingredient
    {
        public override int Id => 5;
        public override string Name => "Sugar";

        public override string PreparationSteps =>
            $"{base.PreparationSteps}";
    }
}
