using System;

namespace Coding.Exercise
{

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(Exercise.Transform(4));
            Console.WriteLine(Exercise.Transform(100));
            Console.WriteLine(Exercise.Transform(0));
            Console.WriteLine(Exercise.Transform(-1));
        }        
    }
    public static class Exercise
    {
        public static int Transform(int number)
        {
            var transformations = new List<INumericTransformation>
            {
                new By1Incrementer(),
                new By2Multiplier(),
                new ToPowerOf2Raiser()
            };
            
            var result = number;
            foreach(var transformation in transformations)
            {
                result = transformation.Transform(result);
            }
            return result;
        }
    }

    public interface INumericTransformation
    {
        int Transform(int input);
    }

    public class By1Incrementer : INumericTransformation
    {
        public int Transform(int input) => input +1;
    }

    public class By2Multiplier : INumericTransformation
    {
        public int Transform(int input) => input * 2;
    }

    public class ToPowerOf2Raiser : INumericTransformation
    {
        public int Transform(int input) => input * input;
    }
}
