using System;



// 1. Method with optional parameters ✅
// 2. Call those methods using named arguments ✅
// 3. Use dynamic variables ✅
// 4. Convert to Autoproperty ✅
// 5. Use expression bodied methods ✅
// 6. Use string interpolation  ✅
// 7. Create exceptions ✅
// 8. Create preconditions with nameof() ✅
// 9. Use null conditional operator ✅
// 10. Test C# 7 features: ✅
//     - out
//     - Tuples
//     - Pattern Matching
//     - ref locals and ref returns
//     - local functions
//     - converions

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Standard Hotel Price For 3 Days: {0, 40}", HotelPriceFor(days: 3));
            Console.WriteLine("More Expensive Hotel Price For 5 Days: {0, 34}", HotelPriceFor(days: 5, price: 350));
            Console.WriteLine("Premium Hotel Price For 14 Days: {0, 40}", HotelPriceFor(days: 14, price: 450, stars: 5));


            dynamic randomTypeVar = HelperClass.GetRandomType;
            Console.WriteLine($"Type: {randomTypeVar.GetType()}, content: {randomTypeVar}");

            Console.WriteLine($"Time till New Year: {HelperClass.TimeTillNewYear()}");

            Console.WriteLine($"nameof(): {nameof(randomTypeVar)}");

            Console.WriteLine($"Random is null: {((randomTypeVar ?? true) != null ? false : true)}");
        }


        static int HotelPriceFor(int days, int price = 250, int stars = 1)
        {
            return days * price * stars;
        }
    }


    static class HelperClass
    {
        public static dynamic GetRandomType 
        { 
            get
            {
                var toss = new Random().Next(3);
                if ( toss == 0)
                {
                    return DateTime.Now;
                } else if ( toss == 1)
                {
                    return new Random().Next(100);
                } else
                {
                    return "Ciao, World!";
                }
            }
        }

        public static string TimeTillNewYear() => DateTime.Now.Year % 4 == 0 ?
                                                $"Days: {366 - DateTime.Now.DayOfYear}, Hours: {24 - DateTime.Now.Hour},  Minutes: {60 - DateTime.Now.Minute}" :
                                                $"Days: {365 - DateTime.Now.DayOfYear}, Hours: {24 - DateTime.Now.Hour},  Minutes: {60 - DateTime.Now.Minute}";
    }

    
}