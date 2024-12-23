namespace _6Tuples.WithoutTuples;

public class ReturnMultipleTypes
{
    public static TwoInts GetMinAndMax(IEnumerable<int> numbers)
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

        return new TwoInts(min, max);
    }

    public static TwoIntsOneFloat GetMinMaxAndAverage(IEnumerable<int> numbers)
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

        return new TwoIntsOneFloat(min, max, average);
    }

    public static TwoStrings GetFirstAndLastName(string fullname)
    {
        string firstName = fullname.Split(' ')[0];
        string lastName = fullname.Split(' ')[1];

        return new TwoStrings(firstName, lastName);

    }

    public static ThreeStrings GetFirstMiddleAndLastName(string fullname)
    {
        string firstName = fullname.Split(' ')[0];
        string middleName = fullname.Split(' ')[1];
        string lastName = fullname.Split(' ')[2];

        return new ThreeStrings(firstName, middleName, lastName);
    }
}