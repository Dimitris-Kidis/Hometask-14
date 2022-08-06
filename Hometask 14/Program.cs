using System;
using System.Collections.Generic;



// 1. Method with optional parameters ✅
// 2. Call those methods using named arguments ✅
// 3. Use dynamic variables ✅
// 4. Convert to Autoproperty ✅
// 5. Use expression bodied methods ✅
// 6. Use string interpolation  ✅
// 7. Create exceptions ✅ (hometask #8)
// 8. Create preconditions with nameof() ✅
// 9. Use null conditional operator ✅
// 10. Test C# 7 features: ✅
//     - out ✅
//     - Tuples ✅
//     - Pattern Matching ✅
//     - ref locals ✅
//     - local functions ✅
//     - read about User-defined converions ✅

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Using named arguments
            Console.WriteLine("Standard Hotel Price For 3 Days: {0, 40}", HotelPriceFor(days: 3));
            Console.WriteLine("More Expensive Hotel Price For 5 Days: {0, 34}", HotelPriceFor(days: 5, price: 350));
            Console.WriteLine("Premium Hotel Price For 14 Days: {0, 40}", HotelPriceFor(days: 14, price: 450, stars: 5));

            Console.ForegroundColor = ConsoleColor.White;
            dynamic randomTypeVar = HelperClass.GetRandomType;
            // String interpolation
            Console.WriteLine($"Type: {randomTypeVar.GetType()}, content: {randomTypeVar}");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"Time till New Year: {HelperClass.TimeTillNewYear()}");
            Console.ForegroundColor = ConsoleColor.White;

            // Using of nameof() & Null Conditional Operator
            Console.WriteLine($"nameof(): {nameof(randomTypeVar)}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Random is null: {((randomTypeVar ?? true) != null ? false : true)}");
            Console.ForegroundColor = ConsoleColor.White;

            // Using out
            HelperClass.GetPersonInfo(out string Name, out string Gender, out int Age, out string Profession);
            Console.WriteLine("Person Info:");
            Console.WriteLine($"Name: {Name}, Gender: {Gender}, Age: {Age}, Profession: {Profession}");
            Console.ForegroundColor = ConsoleColor.Yellow;


            int first = 5;
            int second = 7;
            // Tuples & ref
            Console.WriteLine($"Before Swap: {first}, {second}");
            HelperClass.TupleSwap(ref first, ref second);
            Console.WriteLine($"After Swap: {first}, {second}");
            Console.ForegroundColor = ConsoleColor.White;



            var animalsList = new List<Animal>
            {
                new Monkey(),
                new Lion(),
                new Lion(),
                new Hippo(),
                new Monkey(),
                new Hippo(),
                new Hippo(),
                new Monkey()
            };

            var monkeysList = HelperClass.GetMonkeysList(animalsList);
            foreach (var item in monkeysList)
            {
                Console.WriteLine(item.GetType());
            }

            var sequence = new int[] { 3, 5, 7, 4, 8, 3};

            // Local function usage
            bool HasTwoSum(int[] nums, int target)
            {
                var numsDictionary = new Dictionary<int, int>();

                var complement = 0;
                for (var i = 0; i < nums.Length; i++)
                {
                    complement = target - nums[i];
                    var index = 0;
                    if (complement > 0 && numsDictionary.TryGetValue(complement, out index))
                    {
                        return true;
                    }

                    if (numsDictionary.ContainsKey(nums[i]) == false)
                    {
                        numsDictionary.Add(nums[i], i);
                    }
                }

                return false;
            };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Check if an array has a sum of two: {HasTwoSum(sequence, 10)}");

            // User-defined Conversion
            // Implicit: from int to MagicNumber
            MagicNumber magicNumber = new MagicNumber() { Number = 3, IsMagic = true };
            int aNumber = (int)magicNumber;

            // Explicit: from MagicNumber to int
            int bNumber = 3;
            MagicNumber magicNumberB = bNumber;
        }

        // Method with optional parameters
        static int HotelPriceFor(int days, int price = 250, int stars = 1)
        {
            return days * price * stars;
        }
    }


    static class HelperClass
    {
        // Using dynamic variables & autoproperty
        public static dynamic GetRandomType
        {
            get
            {
                var toss = new Random().Next(3);
                if (toss == 0)
                {
                    return DateTime.Now;
                }
                else if (toss == 1)
                {
                    return new Random().Next(100);
                }
                else
                {
                    return "Ciao, World!";
                }
            }
        }

        // Expression-bodied method
        public static string TimeTillNewYear() => DateTime.Now.Year % 4 == 0 ?
                                                $"Days: {366 - DateTime.Now.DayOfYear}, Hours: {24 - DateTime.Now.Hour},  Minutes: {60 - DateTime.Now.Minute}" :
                                                $"Days: {365 - DateTime.Now.DayOfYear}, Hours: {24 - DateTime.Now.Hour},  Minutes: {60 - DateTime.Now.Minute}";
        static public void GetPersonInfo(out string Name, out string Gender, out int Age, out string Profession)
        {
            Name = "Simone Jackson";
            Gender = "Female";
            Age = 32;
            Profession = "IT";
        }

        static public void TupleSwap<T>(ref T item1, ref T item2)
        {
            (item1, item2) = (item2, item1);
        }

        static public List<Monkey> GetMonkeysList(List<Animal> animals)
        {
            var monkeys = new List<Monkey>();
            foreach (var item in animals)
            {
                // Pattern Matching
                if (item is Monkey animal) monkeys.Add(animal);
            }
            return monkeys;
        }
    }


    public class MagicNumber
    {
        public int Number { get; set; }
        public bool IsMagic { get; set; }

        static public implicit operator MagicNumber(int value)
        {
            return new MagicNumber() { Number = value, IsMagic = false };
        }

        static public explicit operator int(MagicNumber magicNumber)
        {
            return magicNumber.Number;
        }
    }
    

    class Animal
    {

    }
    class Monkey : Animal
    {

    }

    class Lion : Animal
    {

    }

    class Hippo : Animal
    {

    }

    
}