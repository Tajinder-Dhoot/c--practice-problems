using System;
using Programs;

namespace Programs
{
    public class Dog
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class Cat
    {
        // Name field is a required field, cannot be skipped in object initialization
        public required string Name { get; set; }
        public int Age { get; set; }
    }

    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; init; }

        public Person()
        {
        }

        public Person(string name)
        {
            this.Name = name;
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            // can pass all props in object initializer
            Dog dog1 = new Dog
            {
                Name = "Bruno",
                Age = 5
            };

            // can skip few props in object initializer
            Dog dog2 = new Dog
            {
                Name = "Jackson"
            };

            // can pass all props in object initializer
            Dog dog3 = new Dog
            {
            };

            // Name is required field for Cat object initialization
            Cat cat1 = new Cat
            {
                Name = "Tom"
            };

            Person person1 = new Person
            {
                Name = "Tajinder Singh",
                Age = 29
            };

            Person person2 = new Person("Harman Singh") { Age = 30 };

            Person person3 = new Person("Miller Hawkins")
            {
                Name = "David Goggins", // this overwrites parameter in constructor call as it is executed after
                Age = 35
            };

            // person1.Age = 30; // this will give error as Age cannot be set after initialization
            person2.Name = "";

            Console.WriteLine(dog1.Name + " is a dog of age " +dog1.Age);
            Console.WriteLine(dog2.Name + " is a dog of age " +dog2.Age);
            Console.WriteLine(dog3.Name + " is a dog of age " +dog3.Age);
            Console.WriteLine(cat1.Name + " is a cat of age " +cat1.Age);
            Console.WriteLine(person1.Name + " is of age " +person1.Age);
            Console.WriteLine(person2.Name + " is of age " +person2.Age);
            Console.WriteLine(person3.Name + " is of age " +person3.Age);
        }
    }
}
