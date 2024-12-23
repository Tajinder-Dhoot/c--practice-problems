namespace _6Tuples.WithTuples;

public class ReturnMultipleTypesWithTuples
{
    public static SimpleTuple<int, int> GetMinAndMax(IEnumerable<int> numbers)
    {
        int min = numbers.First();
        int max = numbers.First();

        foreach (var number in numbers)
        {
            if (number < min)
            {
                min = number;
            }

            if (number > max)
            {
                max = number;
            }
        }

        return new SimpleTuple<int, int>(min, max);
    }

    public static TupleOfThree<int, int, float> GetMinMaxAndAverage(IEnumerable<int> numbers)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        float average = 0;

        foreach (var number in numbers)
        {
            if (number < min)
            {
                min = number;
            }

            if (number > max)
            {
                max = number;
            }

            average += number;
        }

        average /= numbers.Count();

        return new TupleOfThree<int, int, float>(min, max, average);
    }

    public static SimpleTuple<string, string> GetFirstAndLastName(string fullname)
    {
        string firstName = fullname.Split(' ')[0];
        string lastName = fullname.Split(' ')[1];

        return new SimpleTuple<string, string>(firstName, lastName);

    }

    public static TupleOfThree<string, string, string> GetFirstMiddleAndLastName(string fullname)
    {
        string firstName = fullname.Split(' ')[0];
        string middleName = fullname.Split(' ')[1];
        string lastName = fullname.Split(' ')[2];

        return new TupleOfThree<string, string, string>(firstName, middleName, lastName);
    }
}