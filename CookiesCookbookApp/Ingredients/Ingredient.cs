namespace Ingredients;

public class Ingredient
{
    public Ingredient()
    {

    }

    public virtual int Id { get; }

    public virtual string Name { get; } = "An Ingredient";

    public virtual string PreparationInstructions { get; } = " ...";
}
