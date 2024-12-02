using System;

namespace Linq
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pets = new List<Pet>()
            {
                new(1, "Bruce", PetType.Cat, 5f),
                new(2, "Bruno", PetType.Dog, 25f),
                new(3, "Anabelle", PetType.Fish, 0.55f),
                new(4, "Tom", PetType.Dog, 40f),
                new(5, "Nyan", PetType.Fish, 0.7f),
                new(6, "Jackson", PetType.Dog, 50),
                new(7, "Tyson", PetType.Dog, 20f),
                new(8, "Jim", PetType.Cat, 4f),
                new(9, "Nimo", PetType.Cat, 5f)
            };

            // Any
            var isAnyPetNamedBruce = pets.Any(pet => pet.Name == "Bruce");
            Console.WriteLine(isAnyPetNamedBruce);

            //All
            var areAllEmptyNames = pets.All(pet => string.IsNullOrEmpty(pet.Name));
            Console.WriteLine(areAllEmptyNames);

            var ints = new[]{1, 4, 6, 34, 7, 78};
            var areAllGreaterThanZero = ints.All(p => p > 0);
            Console.WriteLine(areAllGreaterThanZero);

            //Contains
            var has7InInts = ints.Contains(7);
            Console.WriteLine("has7InInts: " + has7InInts);

            // order by
            IEnumerable<string?> sortedByName = pets.OrderBy(pet => pet.Name).Select(pet => pet.Name);
            Console.WriteLine("sorted by pet name");
            foreach (var name in sortedByName)
            {
                Console.Write(name + ", ");
            }
            Console.WriteLine();

            IEnumerable<string?> sortedByTypeAndName = pets.OrderBy(pet => pet.PetType).ThenBy(pet => pet.Name).Select(pet => pet.Name);
            Console.WriteLine("sorted by pet type and name");
            foreach (var name in sortedByTypeAndName)
            {
                Console.Write(name+ ", ");
            }
            Console.WriteLine();
            
            var sortedNums = ints.Order();
            Console.WriteLine("sorted nums in ascending order");
            foreach (var num in sortedNums)
            {
                Console.Write(num+ ", ");
            }
            Console.WriteLine("");

            sortedNums = ints.OrderBy(num => num);
            Console.WriteLine("sorted nums in ascending order");
            foreach (var num in sortedNums)
            {
                Console.Write(num+ ", ");
            }
            Console.WriteLine();

            sortedNums = ints.OrderByDescending(num => num);
            Console.WriteLine("sorted nums in decending order");
            foreach (var num in sortedNums)
            {
                Console.Write(num+ ", ");
            }
            Console.WriteLine();

            // firts and last
            var heaviestPet = pets.OrderBy(pet => pet.Weight).Last();
            Console.WriteLine("Heaviest Pet: " +heaviestPet.Name);

            var lightestDog = pets.Where(pet => pet.PetType == PetType.Dog).OrderBy(pet => pet.Weight).First();
            Console.WriteLine("Lightest Dog: " +lightestDog.Name);

            var catsHeavierThan = pets.Where(pet => pet.PetType == PetType.Cat && pet.Weight > 4).OrderByDescending(pet => pet.Name);
            Console.WriteLine("cats Heavier Than 4 ordered by descending order of names");
            foreach (var cat in catsHeavierThan)
            {
                Console.WriteLine(cat.Name);
            }

            // distiinct by
            var distinctPetTypes = pets.DistinctBy(pet => pet.PetType);
            Console.WriteLine("distinct pet types");
            foreach (var pet in distinctPetTypes)
            {
                Console.WriteLine(pet.PetType);
            }

            // distiinct
            string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog", "over", "and", "over"];
            Console.WriteLine("distinct words");
            foreach (var word in words.Distinct())
            {
                Console.WriteLine(word);
            }

            // select -- can create new data, or extract data
            var dogsData = pets.Where(pet => pet.PetType == PetType.Dog)
                            .Select(pet => $"{pet.Name} is a {pet.PetType} having weight {pet.Weight} kgs.");
            foreach (var data in dogsData) 
            {
                Console.WriteLine(data);
            }

            var distinctPetTypes1 = pets.Select(pet => pet.PetType).Distinct();
            Console.WriteLine("disinct pet types");
            foreach (var type in distinctPetTypes1) 
            {
                Console.WriteLine(type);
            }

            var distinctPetTypes2 = pets.DistinctBy(pet => pet.PetType);
            Console.WriteLine("can also be achieved by 'DistinctBy' clause");
            foreach (var pet in distinctPetTypes2) 
            {
                Console.WriteLine(pet.PetType);
            }

            var wordsToUpperCase = words.Select(word => word.ToUpper()).ToArray();
            foreach (var word in wordsToUpperCase) 
            {
                Console.Write(word + ", ");
            }
        }
    }

    public enum PetType
    {
        Dog,
        Cat,
        Fish
    }

    public class Pet(int id, string? name, PetType petType, float weight)
    {
        public int Id { get; init; } = id;

        public string? Name { get; init; } = name;

        public PetType PetType { get; init; } = petType;

        public float Weight { get; init;} = weight;
    }
}