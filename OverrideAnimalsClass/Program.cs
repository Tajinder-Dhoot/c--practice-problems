using System;

namespace Coding.Exercise
{

    public class MainClass
    {
        public static void  Main(string[] args)
        {
            Exercise ex = new Exercise();
            List<int> legsCount = ex.GetCountsOfAnimalsLegs();
            foreach(var count in legsCount)
            {   
                Console.WriteLine(count);
            }
        }
    }

    public class Exercise
    {
        public List<int> GetCountsOfAnimalsLegs()
        {
            var animals = new List<Animal>
            {
                new Lion(),
                new Tiger(),
                new Duck(),
                new Spider()
            };
            
            var result = new List<int>();
            foreach(var animal in animals)
            {
                result.Add(animal.NumberOfLegs);
            }
            return result;
        }
    }

    public class Animal
    {
        public virtual int NumberOfLegs { get; } = 4;
    }

    public class Lion : Animal
    {
    }

    public class Tiger : Animal
    {
    }

    public class Duck : Animal
    {
        public override int NumberOfLegs { get; } = 2;
        
    }

    public class Spider : Animal
    {
        public override int NumberOfLegs { get; } = 8;
    }
}
