using System;
using System.Reflection.Metadata.Ecma335;

namespace Coding.Exercise
{
    public class MainClass
    {
        public static void Main()
        {
            List<double> shapesAreas = ExerciseShapes.GetShapesAreas([new Square(3), new Rectangle(2, 5), new Circle(5)]);
            foreach(var area in shapesAreas)
            {
                Console.WriteLine(area);
            }
        }
    }
    public static class ExerciseShapes
    {
        public static List<double> GetShapesAreas(List<Shape> shapes)
        {
            var result = new List<double>();
            
            foreach(var shape in shapes)
            {
                result.Add(shape.CalculateArea());
            }
            
            return result;
        }
    }
    
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }    

    public class Square : Shape
    {
        public double Side { get; }
    
        public Square(double side)
        {
            Side = side;
        }
        
        public override double CalculateArea() => Side * Side; 
    }
    
    
    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }
    
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        
        public override double CalculateArea() => Width * Height;
    }
    
    public class Circle(double radius) : Shape
    {
        public double Radius { get; } = radius;

        public override double CalculateArea() => Radius * Radius * Math.PI;
    }
}
