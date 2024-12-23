using CookiesCookbookAppRefactured.Recipes.Ingredients;

namespace CookiesCookbookAppRefactored.Recipes.Ingredients
{
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
}