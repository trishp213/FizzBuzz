using System;
using Domain;

namespace CMFB
{
    class Program
    {
        static void Main(string[] args)
        {
            var fizzBuzzService = new FizzBuzzService()
            {
                MinNumber = GetNumericInputFromUser("Enter the min number to start from", 1),
                MaxNumber = GetNumericInputFromUser("Enter the max number to go to", 100)
            };

            fizzBuzzService.AddMap(
                GetNumericInputFromUser("Enter number to replace, or hit enter to use the default", 3),
                GetStringInputFromUser("Enter fizz word, or hit enter to just use the default", "Fizz")
                );

            fizzBuzzService.AddMap(
               GetNumericInputFromUser("Enter number to replace, or hit enter to use the default", 5),
               GetStringInputFromUser("Enter buzz word, or hit enter to just use the default", "Buzz")
               );

            var results = fizzBuzzService.GetAllValues();
            
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }


            Console.ReadKey();
        }

        private static string GetStringInputFromUser(string messageText, string defaultWord)
        {
            Console.WriteLine(messageText);

            var input = Console.ReadLine();
            return string.IsNullOrEmpty(input) ? defaultWord : input;
        }

        private static int GetNumericInputFromUser(string messageText, int defaultNumber)
        {
            Console.WriteLine(messageText);
            var input = Console.ReadLine();
            int fizzNumber;
            int.TryParse(input, out fizzNumber);
            return fizzNumber > 0 ? fizzNumber : defaultNumber;
        }
    }
}
