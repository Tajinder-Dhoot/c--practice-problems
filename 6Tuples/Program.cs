using _6Tuples.WithoutTuples;
using _6Tuples.WithTuples;

namespace _6Tuples;

public class Program
{
    public static void Main()
    {
        RunWithoutTuples();
        RunWithCustomizedTuples();
    }

    public static void RunWithoutTuples()
    {
        Console.WriteLine($"***** Without Tuples *****");
        IEnumerable<int> integers = [7, 9, 2, 3, 3, 4, 5];
        TwoInts minAndMax = ReturnMultipleTypes.GetMinAndMax(integers);
        TwoIntsOneFloat minmaxAndAverage = ReturnMultipleTypes.GetMinMaxAndAverage(integers);

        TwoStrings firstAndLastNames = ReturnMultipleTypes.GetFirstAndLastName("Tajinder Singh");
        ThreeStrings firstMiddleAndLastNames = ReturnMultipleTypes.GetFirstMiddleAndLastName("Tajinder Singh Dhoot");

        Console.WriteLine($"Min: {minAndMax.Num1}, Max: {minAndMax.Num2}");
        Console.WriteLine($"Min: {minmaxAndAverage.Num1}, Max: {minmaxAndAverage.Num2}, Average: {minmaxAndAverage.Num3}");
        Console.WriteLine($"first name: {firstAndLastNames.String1}, last name: {firstAndLastNames.String2}");
        Console.WriteLine($"Min: {firstMiddleAndLastNames.String1}, middle name:: {firstMiddleAndLastNames.String2}, last name:: {firstMiddleAndLastNames.String3}");
    }

    public static void RunWithCustomizedTuples()
    {
        Console.WriteLine($"***** With Tuples *****");
        IEnumerable<int> integers = [7, 9, 2, 3, 3, 4, 5];
        SimpleTuple<int, int> minAndMax = ReturnMultipleTypesWithTuples.GetMinAndMax(integers);
        TupleOfThree<int, int, float> minmaxAndAverage = ReturnMultipleTypesWithTuples.GetMinMaxAndAverage(integers);

        SimpleTuple<string, string> firstAndLastNames = ReturnMultipleTypesWithTuples.GetFirstAndLastName("Tajinder Singh");
        TupleOfThree<string, string, string> firstMiddleAndLastNames = ReturnMultipleTypesWithTuples.GetFirstMiddleAndLastName("Tajinder Singh Dhoot");

        Console.WriteLine($"Min: {minAndMax.Item1}, Max: {minAndMax.Item2}");
        Console.WriteLine($"Min: {minmaxAndAverage.Item1}, Max: {minmaxAndAverage.Item2}, Average: {minmaxAndAverage.Item3}");
        Console.WriteLine($"first name: {firstAndLastNames.Item1}, last name: {firstAndLastNames.Item2}");
        Console.WriteLine($"Min: {firstMiddleAndLastNames.Item1}, middle name:: {firstMiddleAndLastNames.Item2}, last name:: {firstMiddleAndLastNames.Item3}");
    }
}
