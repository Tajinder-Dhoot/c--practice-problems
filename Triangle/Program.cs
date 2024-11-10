using System;

namespace Coding.Exercise
{
    public class Triangle
    {
        private int @base;
        private int height;
        
        public Triangle(int @base, int height)
        {
            this.@base = @base;
            this.height = height;
            
        }
        
        public int CalculateArea()
        {
            Console.WriteLine(AsString());
            return ((@base * height) / 2);
            
        }
        
        public string AsString()
        {
            return ("Base is " +@base+ ", height is " +height);
        }

        public static void Main() 
        {
            Triangle triangle1 = new Triangle(5, 10);
            Console.WriteLine("Area of trianle is : " +triangle1.CalculateArea());
        }
    }
}