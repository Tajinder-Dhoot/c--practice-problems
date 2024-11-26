using System;
using System.Security.Cryptography;

namespace Coding.Exercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int> {1, 2, 3, 10, 5, 78, 3};
            List<int> result = list.TakeEverySecond();
            foreach (var item in result)
            {
                Console.Write(item + ", ");
            }
        }
    }

    public static class ListExtension
    {
        public static List<int> TakeEverySecond(this List<int> list)
        {
            List<int> result = [];
            
            for (var i = 0; i < list.Count; i+=2)
            {
                result.Add(list[i]);
            }
            return result;
        }
    }
}
