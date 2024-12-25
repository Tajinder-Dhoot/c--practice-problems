namespace GenericClassesMethods;

public class Program
{
    public static void Main()
    {
        // using generic type (class type)
        var pairOfInts = new Pair<int>(1, 2);
        var pairOfStrings = new Pair<string>("one", "two");
        var pairOfDateTime = new Pair<DateTime>(DateTime.Now, DateTime.Now.AddDays(1));

        Console.WriteLine($"Pair of ints: {pairOfInts.First}, {pairOfInts.Second}");
        Console.WriteLine($"Pair of strings: {pairOfStrings.First}, {pairOfStrings.Second}");
        Console.WriteLine($"Pair of date time: {pairOfDateTime.First}, {pairOfDateTime.Second}");

        // using generic method
        var pairOfNums = new List<int> { 1, 2 };
        var pairOfStrings1 = new List<string> { "one", "two" };

        // using generic type
        Tuple<int, int> swappedNums = Swap(pairOfNums[0], pairOfNums[1]);
        Tuple<string, string> swappedStrings = Swap(pairOfStrings1[0], pairOfStrings1[1]);

        Console.WriteLine($"Swapped pair of nums: {swappedNums.Item1}, {swappedNums.Item2}");
        Console.WriteLine($"Swapped pair of strings: {swappedStrings.Item1}, {swappedStrings.Item2}");

        var numbers = new List<int> { 2, 4, 6, 8, 9 };
        var decimals = new List<decimal> { 2.3m, 4.1m, 6.5m, 8.1m, 9m };
        var listOfInts = ListExtensions.ConvertTo<decimal, int>(decimals);
        var listOfStrings = ListExtensions.ConvertTo<decimal, string>(decimals);

        foreach (var item in listOfInts)
        {
            Console.Write($"{item}, ");
        }

        foreach (var item in listOfStrings)
        {
            Console.Write($"{item}, ");
        }
    }

    // generic method
    public static Tuple<T, T> Swap<T>(T item1, T item2)
    {
        T temp = item1;
        item1 = item2;
        item2 = temp;

        return new Tuple<T, T>(item1, item2);
    }
    
}

// generic type (class) 
public class Pair<T>
{
    public T First { get; private set; }
    public T Second { get; private set; }

    public Pair(T item1, T item2)
    {
        First = item1;
        Second = item2;
    }

    public void ResetFirst()
    {
        First = default;
    }

    public void ResetSecond()
    {
        Second = default;
    }
}

public static class ListExtensions
{
    public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> decimals)
    {
        var listOfInts = new List<TTarget>();
        foreach (var item in decimals)
        {
            listOfInts.Add((TTarget)Convert.ChangeType(item, typeof(TTarget))!);
        }

        return listOfInts;
    }
}
