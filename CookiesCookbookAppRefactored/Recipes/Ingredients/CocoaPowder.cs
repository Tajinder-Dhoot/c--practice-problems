namespace CookiesCookbookAppRefactured.Recipes.Ingredients
{
    public class CocoaPowder : Ingredient
    {
        public override int Id => 8;
        public override string Name => "Cocoa powder";

        public override string PreparationSteps =>
            $"{base.PreparationSteps}";
    }
}
