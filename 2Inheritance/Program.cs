using System;
using System.Reflection.Metadata.Ecma335;

namespace Coding.Exercise
{
    public class MainClass
    {
        public static void  Main(string[] args)
        {
            // var cheese = new Cheese();
            var ingredient = new Ingredient();
            var cheese = new Cheese();
            var veggie = new Veggie();
            var cheddar = new Cheddar();
            var mozerrela = new Mozerrela();

            ingredient.GenerateRandomIngredient();
            cheese.GenerateRandomIngredient();
            mozerrela.GenerateRandomIngredient();
            cheese.CheeseMethod();
            mozerrela.CheeseMethod();
            mozerrela.MozerellaMethod();

            Console.WriteLine(ingredient.IngredientProperty);
            Console.WriteLine(cheese.IngredientProperty);
            Console.WriteLine(cheddar.IngredientProperty);
            Console.WriteLine(cheddar.CheeseProperty);
            Console.WriteLine(cheddar.CheddarProperty);

            /* 
                Implicit Conversion 
                done by itself in upcasting
                Every derived class object is also an object of base class
            */
            Ingredient ingredient1 = new Cheese();

            /* 
                Implicit Conversion 
                done by itself in upcasting
                Every derived class object is also an object of base class
            */
            // Cheese cheese1 = new Ingredient(); //gives error

            /*
            object of derived class can access properties and functions of base class
            but object of derived class cannot implicitly convert type of base class 
            */
            // Cheddar cheddar1= cheddar.GenerateRandomIngredient(); // this returns compile error
            Cheddar cheddar1= (Cheddar) cheddar.GenerateRandomIngredient();  // no compile error but can be runtime error

        }
    }

    public class Pizza
    {

    }
    
    public class Ingredient
    {
        public Ingredient()
        {
            Console.WriteLine("class ingredient");
        }

        public string IngredientProperty { get; set; } = "Ingredient Property";

        public Ingredient GenerateRandomIngredient()
        {
            int randomNum = new Random().Next(0, 3);
            Console.WriteLine("random number: " + randomNum);
            if (randomNum == 0) { return new Cheddar(); }
            if (randomNum == 1) { return new Mozerrela(); }
            else { return new Veggie(); }
        }
    }

    public class Cheese : Ingredient
    {
        public Cheese()
        {
            Console.WriteLine("class cheese");
        }

        public string CheeseProperty { get; set; } = "Cheese Property";

        public void CheeseMethod()
        {
            Console.WriteLine("This method does something to cheese");
        }
    }

    public class Veggie : Ingredient
    {
        public Veggie()
        {
            Console.WriteLine("class veggie");
        }

        public void VeggieMethod()
        {
            Console.WriteLine("This method does something to veggie");
        }
    }

    public class Cheddar : Cheese
    {
        public Cheddar()
        {
            Console.WriteLine("class Cheddar");
        }

        public string CheddarProperty { get; set; } = "Cheddar Property";


        public void CheddarMethod()
        {
            Console.WriteLine("This method does something to cheddar");
        }
    }

    public class Mozerrela : Cheese
    {
        public Mozerrela()
        {
            Console.WriteLine("class Mozerrela");
        }

        public string MozerrelaProperty { get; set; } = "Mozerrela Property";

        public void MozerellaMethod()
        {
            Console.WriteLine("This method does something to Mozerrela");
        }
    }
}
